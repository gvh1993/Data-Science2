using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Genetic_algorithm
{
    class Program
    {
        static List<List<Binary>> populationHistory = new List<List<Binary>>();

        static List<Binary> currentPopulation;

        static List<Binary> newPopulation;

        static Random r = new Random();

        static void Main(string[] args)
        {
            // In this assignment you must build a genetic algorithm and apply it to a simple problem. The simple problem is the
            // maximization of the function
            // 𝑓(𝑥) = −x 2 + 7x


            //beginning
            //minimal binary string is: 00000 
            //maximal binary string is: 11111

            //initial population
            InitializePopulation();

            //evaluation
            //selection
            for (int i = 0; i < 20; i++)
            {
                populationHistory.Add(new List<Binary>());
                newPopulation = populationHistory.Last();
                currentPopulation = populationHistory[populationHistory.Count - 2];

                SelectTop();
                for (int j = 1; j < currentPopulation.Count; j += 2)
                {
                    Tuple<Binary, Binary> parents = SelectParentsTournament();

                    Tuple<Binary, Binary> children = Crossover(parents);

                    newPopulation.Add(children.Item1);
                    newPopulation.Add(children.Item2);
                }

                //mutation
                Mutate(new Binary(), 0.05);

                SetNewPopulationFitness();
                //evolved population
                //end or go to selection
                
                Reset();
                
            }
            PrintOutput();

            Console.Read();
        }

        static void InitializePopulation()
        {
            currentPopulation = new List<Binary>();

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

        static double ComputeFitness(Binary bin)
        {
            double fitness = -Math.Pow(bin.CalculateBinaryCode(), 2) + 7*bin.CalculateBinaryCode();

            return fitness;
        }

        static void SelectTop()
        {
            List<Binary> elite = currentPopulation.OrderByDescending(x => x.Fitness).Take(1).ToList();

            foreach (var eliteIndividual in elite)
            {
                newPopulation.Add(eliteIndividual);
            }
        }

        static Tuple<Binary, Binary> SelectParentsTournament()
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

        static Tuple<Binary, Binary> Crossover(Tuple<Binary, Binary> masterRace)
        {
            Binary newMother = new Binary();
            Binary newFather = new Binary();

            int crossoverPoint = r.Next(1, newMother.BitArray.Length);

            for (int i = 0; i < newMother.BitArray.Length; i++)
            {
                if (i < newMother.BitArray.Length-crossoverPoint)
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

        static void Mutate(Binary individual, double mutationRate)
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

        static void SetNewPopulationFitness()
        {
            for (int i = 0; i < newPopulation.Count; i++)
            {
                newPopulation[i].Fitness = ComputeFitness(newPopulation[i]);
            }
        }

        static void PrintOutput()
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
        }

        private static void Reset()
        {

            //currentPopulation.Clear();
            //currentPopulation = new List<Binary>(newPopulation);
            //newPopulation.Clear();
        }
    }
}
