using System;
namespace ConAppAss23
{
    class Program
    {
      
        delegate void SpinDelegate(ref int energyLevel, ref int winningProbability);

        static void Main()
        {
            do
            {


                Console.Write("Enter Your Name: ");
                string playerName = Console.ReadLine();

                int energyLevel = 1;
                int winningProbability = 100;
                int noOfSpins = 5;

              
                SpinDelegate[] spins =
                {
                    (ref int e, ref int w) => { e += 1; w += 10; },
                    (ref int e, ref int w) => { e += 2; w += 20; },
                    (ref int e, ref int w) => { e -= 3; w -= 30; },
                    (ref int e, ref int w) => { e += 4; w += 40; },
                    (ref int e, ref int w) => { e += 5; w += 50; },
                    (ref int e, ref int w) => { e -= 1; w -= 60; },
                    (ref int e, ref int w) => { e += 1; w += 70; },
                    (ref int e, ref int w) => { e -= 2; w -= 20; },
                    (ref int e, ref int w) => { e -= 3; w -= 30; },
                    (ref int e, ref int w) => { e += 10; w += 100; }
                };

                Console.WriteLine($"Hello {playerName}!");
                Console.Write("Enter Your Lucky Number from 1 to 10: ");
                int luckyNumber = int.Parse(Console.ReadLine());

            
                for (int i = 0; i < noOfSpins; i++)
                {
                    Console.WriteLine($"Spin {i + 1}:");
                    spins[luckyNumber - 1](ref energyLevel, ref winningProbability);
                    Console.WriteLine($"Energy Level: {energyLevel}, Winning Probability: {winningProbability}");

                    if (energyLevel >= 4 && winningProbability > 60)
                    {
                        Console.WriteLine("Winner!");
                        break;
                    }
                    else if (energyLevel >= 1 && winningProbability > 50)
                    {
                        Console.WriteLine("Runner Up!");
                        break;
                    }
                    else
                    {
                        Console.WriteLine("Loser!");
                    }
                }
                Console.WriteLine("Press enter or 'Q' to quit.");
            } while (Console.ReadKey().Key != ConsoleKey.Q);


            Console.ReadKey();
        }
    }
}