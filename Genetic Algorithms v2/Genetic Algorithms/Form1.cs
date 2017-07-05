using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Genetic_Algorithms
{
    public partial class Form1 : Form
    {
        private double crossoverRate, mutationRate;
        private bool elitism = false;
        private int populationSize, iterations, elitismCount;

        List<List<Binary>> populationHistory;

        List<Binary> currentPopulation;

        List<Binary> newPopulation;

        Random r;

        public Form1()
        {
            populationHistory = new List<List<Binary>>();
            currentPopulation = new List<Binary>();
            newPopulation = new List<Binary>();
            r = new Random();
            elitismCount = 0;
            InitializePopulation();

            InitializeComponent();

          
        }

        private void StartGeneticAlgorithm()
        {
            // In this assignment you must build a genetic algorithm and apply it to a simple problem. The simple problem is the
            // maximization of the function
            // 𝑓(𝑥) = −x 2 + 7x


            //beginning
            //minimal binary string is: 00000 
            //maximal binary string is: 11111
            

            //evaluation
            //selection
            for (int i = 0; i < iterations; i++)
            {
                populationHistory.Add(new List<Binary>());
                newPopulation = populationHistory.Last();
                currentPopulation = populationHistory[populationHistory.Count - 2];
                

                //ELITISM
                if (elitism)
                {
                    elitismCount = 1;
                    Elitism(elitismCount);
                }
                
                //adding 2 because adding 2 children at once
                //starting from 0 if no elitism starting from # if elitism is true
                for (int j = elitismCount; j < currentPopulation.Count; j += 2)
                {
                    double crossoverDecider = r.NextDouble();
                    //Tuple<Binary, Binary> parents = SelectParentsTournament();
                    Tuple<Binary, Binary> parents = RankSelection();
                    if (crossoverDecider <= crossoverRate)
                    {
                        Tuple<Binary, Binary> children = Crossover(parents);
                        newPopulation.Add(children.Item1);
                        newPopulation.Add(children.Item2);
                    }
                    else
                    {
                        newPopulation.Add(parents.Item1);
                        newPopulation.Add(parents.Item2);
                    }
                }
                //make sure u have the populationSize with uneven numbers and elitism off and vica versa
                newPopulation = newPopulation.GetRange(0, populationSize);

                //mutation
                Mutate(new Binary(), mutationRate);

                SetNewPopulationFitness();
                //evolved population

            }
            PrintOutput();

            Console.Read();
        }
        void InitializePopulation()
        {
            for (int i = 0; i < 25; i++)
            {
                Binary individual = new Binary();

                for (int j = 0; j < individual.BitArray.Length; j++)
                {
                    if (r.Next(0, 2) == 1)
                    {
                        individual.BitArray[j] = true;
                    }
                }
                individual.Fitness = ComputeFitness(individual);
                currentPopulation.Add(individual);
            }
            populationHistory.Add(currentPopulation);
        }

        double ComputeFitness(Binary bin)
        {
            double fitness = -Math.Pow(bin.CalculateBinaryCode(), 2) + 7 * bin.CalculateBinaryCode();

            return fitness;
        }

        void Elitism(int elitismCount)
        {
            List<Binary> elite = currentPopulation.OrderByDescending(x => x.Fitness).Take(elitismCount).ToList();

            foreach (var eliteIndividual in elite)
            {
                newPopulation.Add(eliteIndividual);
            }
        }

        Tuple<Binary, Binary> RankSelection()
        {
            Binary mother = new Binary();
            Binary father = new Binary();
            //order fitness
            var sortedPopulation = currentPopulation.OrderBy(x => x.Fitness).ToList();

            int sum = 0;
            for (int i = 1; i <= currentPopulation.Count; i++)
            {
                sum += i;
            }


            //MOTHER
            double motherRand = r.Next(1, sum + 1);
            double motherChance = motherRand/sum;
            double motherSum = 0;

            for (int i = 1; i <= sortedPopulation.Count; i++)
            {
                motherSum += ((double)i /(double)sortedPopulation.Count);

                if (motherChance < motherSum)
                {
                    mother = sortedPopulation[i-1];
                    break;
                }
            }

            //FATHER
            double fatherRand = r.Next(1, sum + 1);
            double fatherChance = fatherRand / sum;
            double fatherSum = 0;

            for (int i = 1; i <= sortedPopulation.Count; i++)
            {
                fatherSum += (i / sortedPopulation.Count);

                if (fatherChance < fatherSum)
                {
                    father = sortedPopulation[i - 1];
                    break;
                }
            }

            return new Tuple<Binary, Binary>(mother, father);
        }

        Tuple<Binary, Binary> SelectParentsTournament()
        {
            List<Binary> tournamentPlayers = new List<Binary>();

            //get first (Mother)
            for (int i = 0; i < 5; i++)
            {
                int randomIndexMother = r.Next(0, currentPopulation.Count);
                tournamentPlayers.Add(currentPopulation[randomIndexMother]);
            }
            double fittestNumberMother = tournamentPlayers.Max(individual => individual.Fitness);
            Binary mother = tournamentPlayers.Where(individual => individual.Fitness == fittestNumberMother).FirstOrDefault();
            tournamentPlayers.Clear();


            //get second (Father)
            for (int i = 0; i < 5; i++)
            {
                int randomIndexFather = r.Next(0, currentPopulation.Count);
                tournamentPlayers.Add(currentPopulation[randomIndexFather]);
            }
            double fittestNumberFather = tournamentPlayers.Max(individual => individual.Fitness);
            Binary father = tournamentPlayers.Where(individual => individual.Fitness == fittestNumberFather).FirstOrDefault();
            tournamentPlayers.Clear();

            return new Tuple<Binary, Binary>(mother, father);
        }

        Tuple<Binary, Binary> Crossover(Tuple<Binary, Binary> masterRace)
        {
            Binary newMother = new Binary();
            Binary newFather = new Binary();

            int crossoverPoint = r.Next(1, newMother.BitArray.Length);


                for (int i = 0; i < newMother.BitArray.Length; i++)
                {
                    if (i < newMother.BitArray.Length - crossoverPoint)
                    {
                        newFather.BitArray[i] = masterRace.Item1.BitArray[i];
                        newMother.BitArray[i] = masterRace.Item2.BitArray[i];
                    }
                    else
                    {
                        newMother.BitArray[i] = masterRace.Item1.BitArray[i];
                        newFather.BitArray[i] = masterRace.Item2.BitArray[i];
                    }
                }
            

            newMother.Fitness = ComputeFitness(newMother);
            newFather.Fitness = ComputeFitness(newFather);

            return new Tuple<Binary, Binary>(newMother, newFather);
        }

        void Mutate(Binary individual, double mutationRate)
        {

            for (int i = 0; i < newPopulation.Count; i++)
            {
                double mutateDecider = r.NextDouble();
                if (mutateDecider <= mutationRate)
                {
                    int randomBit = r.Next(0, individual.BitArray.Length);
                    bool mutateBit = newPopulation[i].BitArray[randomBit];

                    if (mutateBit)
                    {
                        newPopulation[i].BitArray[randomBit] = false;
                    }
                    else
                    {
                        newPopulation[i].BitArray[randomBit] = true;
                    }
                }
            }
        }

        void SetNewPopulationFitness()
        {
            for (int i = 0; i < newPopulation.Count; i++)
            {
                newPopulation[i].Fitness = ComputeFitness(newPopulation[i]);
            }
        }

        void PrintOutput()
        {
            double countFitness = 0;

            for (int i = 0; i < newPopulation.Count; i++)
            {
                countFitness += newPopulation[i].Fitness;
            }

            Console.WriteLine("population average fitness: " + countFitness / populationHistory.Last().Count);
            Binary fittest = currentPopulation.OrderByDescending(x => x.Fitness).Take(1).First();
            Console.WriteLine("Fittest of last population: " + fittest.Fitness);
            Console.WriteLine("Fittest number:" + fittest.CalculateBinaryCode());

            lbl_AverageFittness.Text = "Average Fittness: " + countFitness / populationHistory.Last().Count;
            lbl_BestFittness.Text = "Best Fittness: " + fittest.Fitness;
            lbl_BestIndividual.Text = "Best individual: " + fittest.ToString();
        }

        private void btn_Start_Click(object sender, EventArgs e)
        {
            if (ValidateInput())
            {
                StartGeneticAlgorithm();
            }
        }
        private bool ValidateInput()
        {
            lbl_Error.Text = "Error: ";

            if (!Double.TryParse(txt_CrossoverRate.Text, out crossoverRate) )
            {
                lbl_Error.Text += "Crossover, ";
                return false;
            }
            if (!Double.TryParse(txt_MutationRate.Text, out mutationRate))
            {
                lbl_Error.Text += "Mutation, ";
                return false;
            }
            if (!Int32.TryParse(txt_Iterations.Text, out iterations))
            {
                lbl_Error.Text += "Iterations, ";
                return false;
            }
            if (!Int32.TryParse(txt_PopulationSize.Text, out populationSize))
            {
                lbl_Error.Text += "Population Size";
                return false;
            }
            if (chbx_Elitism.Checked)
            {
                elitism = true;
            }

            lbl_Error.Text = "";
            return true;
        }
    }
}
