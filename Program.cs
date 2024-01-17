using System;
using System.Collections.Generic;
using System.Threading.Tasks;//Ajoutez l'import pour System.Threading.Tasks à votre projet.
using System.Threading;
using System.Diagnostics;

namespace ParallelOpsLab
//Step 1 : Premier usage de Parallel.ForEach
{
    class Program
    {
        static void Main(string[] args)
        {
            

            // Dans la méthode main, créez une liste de nombre à procéder, par exemple, une liste de nombre de 1 à 10.
            var numbers = new List<int>() { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };

            // Utilisez la méthode Parallel.ForEach pour afficher les nombres de la liste de manière concurrentielle.
            Parallel.ForEach(numbers, number => 
            {
                Console.WriteLine(number);
                Thread.Sleep(1000); // Ajoutez un Thread.Sleep(1000) à l'intérieur du ForEach.
            });
            // Step 2 : Adding a Stopwatch to check the time elapsed during operations
            //- Ajoutez un Stopwatch pour analyser le temps nécessaire pour réaliser l'opération, sans programmation parallèle, l'opération durerait minimum 10 secondes (vous pouvez tester d'ailleur avec un simple ForEach sur la liste)
            var timer = new Stopwatch();
            timer.Start();
            Parallel.ForEach(numbers, number => 
            {
                Console.WriteLine(number);
                Thread.Sleep(1000);
            });
            timer.Stop();
            Console.WriteLine("Temps écoulé : " + timer.Elapsed);

            // S### Step 3 : First usage of Parallel.For
            timer.Reset();
            timer.Start();
            Parallel.For(0, numbers.Count, i => 
            {
                Console.WriteLine(numbers[i]);
                Thread.Sleep(1000);
            });
            timer.Stop();
            Console.WriteLine("Temps écoulé : " + timer.Elapsed);

           // ### Step 4 : First usage of Parallel.Invoke

            timer.Reset();
            timer.Start();
            Parallel.Invoke(
                () => {
                    for (int i = 1; i <= 10; i++)
                    {
                        Console.WriteLine(i);
                        Thread.Sleep(1000);
                    }
                },
                () => {
                    for (int i = 10; i <= 20; i++)
                    {
                        Console.WriteLine(i);
                        Thread.Sleep(1500);
                    }
                }
            );
            timer.Stop();
            Console.WriteLine("Temps écoulé : " + timer.Elapsed);

             //### Step 5 : First usage of aggregate with Parallel.Invoke
            int sum = 0;
            Parallel.ForEach(numbers, () => 0, (j, loop, subtotal) =>
            {
                subtotal += j;
                return subtotal;
            },
            (finalResult) => Interlocked.Add(ref sum, finalResult));
            Console.WriteLine("Somme : " + sum);

            // Comparaison avec numbers.Sum();
            timer.Reset();
            timer.Start();
            int directSum = numbers.Sum();
            timer.Stop();
            Console.WriteLine("Somme directe : " + directSum + ", Temps : " + timer.Elapsed);

              // ### Step 6 : Using Action & Parallel.Invoke to read two file calculate the number of words in it
            Action readFile1 = () => {
                var text = File.ReadAllText("file1.txt");
                var wordCount = text.Split(' ').Length;
                Console.WriteLine("Nombre de mots dans le fichier 1 : " + wordCount);
            };

            Action readFile2 = () => {
                var text = File.ReadAllText("file2.txt");
                var wordCount = text.Split(' ').Length;
                Console.WriteLine("Nombre de mots dans le fichier 2 : " + wordCount);
            };

            Parallel.Invoke(readFile1, readFile2);
        }
    }
}

  



