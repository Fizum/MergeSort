using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace MergeSort
{
    class Program
    {
        static void Main(string[] args)
        {
            //creazione lista "disordinata" e "ordinata"
            List<int> unsorted = new List<int>();
            List<int> sorted;

            //assegnazione elementi nella lista
            unsorted.Add(3);
            unsorted.Add(9);
            unsorted.Add(1);
            unsorted.Add(10);
            unsorted.Add(7);
            unsorted.Add(4);
            unsorted.Add(8);
            unsorted.Add(2);
            unsorted.Add(6);
            unsorted.Add(5);

            //stampa lista disordinata
            Console.WriteLine("i numeri sono: ");
            for (int i = 0; i < 10; i++)
            {
                Console.Write(unsorted[i] + " ");
            }
            Console.WriteLine();
            Console.WriteLine();

            sorted = MergeSort(unsorted);

            //stampa della lista riordinata
            Console.WriteLine("lista riordinata: ");
            foreach (int x in sorted)
            {
                Console.Write(x + " ");
            }
            Console.Write("\n");

            Console.ReadLine();
        }


        private static List<int> MergeSort(List<int> unsorted)
        {
            //se il numero di elementi è minore o uguale a 1 ritorna la lista disordinata
            if (unsorted.Count <= 1)
                return unsorted;

            //crea 2 liste che conterranno la lista disordinata ma divisa
            List<int> left = new List<int>();
            List<int> right = new List<int>();

            //divide la lista disordinata in 2 parti
            int middle = unsorted.Count / 2;
            for (int i = 0; i < middle; i++)
            {
                left.Add(unsorted[i]);
            }
            for (int i = middle; i < unsorted.Count; i++)
            {
                right.Add(unsorted[i]);
            }

            left = MergeSort(left);
            right = MergeSort(right);
            return Merge(left, right);
        }

        private static List<int> Merge(List<int> left, List<int> right)
        {
            //crea la lista risultato
            List<int> result = new List<int>();

            //finchè gli elementi della parte di sinistra o di destra saranno maggiori di 0 si ripete il ciclo
            while (left.Count > 0 || right.Count > 0)
            {
                if (left.Count > 0 && right.Count > 0)
                {
                    //compara 2 elementi per vedere il più piccolo tra i 2
                    if (left.First() <= right.First())
                    {
                        //aggiunge l'elemento più piccolo nella lista finale e lo rimuove dalla lista "left"
                        result.Add(left.First());
                        left.Remove(left.First()); 
                    }
                    else
                    {
                        //aggiunge l'elemento più piccolo nella lista finale e lo rimuove dalla lista "right"
                        result.Add(right.First());
                        right.Remove(right.First());
                    }
                }
                else if (left.Count > 0)
                {
                    result.Add(left.First());
                    left.Remove(left.First());
                }
                else if (right.Count > 0)
                {
                    result.Add(right.First());
                    right.Remove(right.First());
                }
            }
            //restituisce la lista terminata
            return result;
        }
            
            

    }
}
