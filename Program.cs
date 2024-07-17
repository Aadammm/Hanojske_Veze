using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace Hanojske_Veze
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Stack<int> tower1 = new Stack<int>();
            Stack<int> tower2 = new Stack<int>();
            Stack<int> tower3 = new Stack<int>();
            var towers = new List<Stack<int>>() { tower1, tower2, tower3 };
            for (int i = 5; i >= 1; i--)
            {
                tower1.Push(i);
            }
            int zVeze;
            int naVezu;
            int kotuc;
            int pocetTahov = 0;
            do
            {
                Console.WriteLine(Display(towers));
                Console.Write("Přesunout kotouč z věže: ");
                //z ktorej veze vezme kotuc
                while (!int.TryParse(Console.ReadLine(), out zVeze) || zVeze < 1 || zVeze > 3)
                    Console.WriteLine("Choose again:");

                Console.Write("Přesunout kotouč na věž: ");
                //na ktoru vezu polozi kotuc
                while (!int.TryParse(Console.ReadLine(), out naVezu) || naVezu < 1 || naVezu > 3)
                    Console.WriteLine("Choose again:");
                //vezme kotuc z veze
                if (towers[zVeze - 1].Count > 0)
                {
                    kotuc = towers[zVeze - 1].Peek();

                    if (towers[naVezu - 1].Count == 0 || towers[naVezu - 1].Peek() > kotuc)
                    {
                        towers[zVeze - 1].Pop();
                        towers[naVezu - 1].Push(kotuc);
                    }

                }
                pocetTahov++;
            }
            while (!End(tower2, tower3));
            Console.WriteLine(Display(towers));
            Console.WriteLine("You won!");
             Console.WriteLine("Numbers of moves {0}",pocetTahov);
            Console.Read();


        }
        static bool End(Stack<int> DruhaVeza, Stack<int> TretiaVeza)
        {
         if(DruhaVeza.Count==5||TretiaVeza.Count==5)
                return true;
            return false;
        }
        static string Display(List<Stack<int>> list)
        {
            Console.Clear();
            string[] kotuce = { "", "█", "██", "███", "████", "█████" };
            int[][] kopia = new int[list.Count][];
            for (int i = 0; i < kopia.Length; i++)
            {
                kopia[i] = new int[list[i].Count];
                int zaciatok = 0;
                foreach (int item in list[i])
                {
                    kopia[i][zaciatok] = item;
                    zaciatok++;
                }
                Array.Reverse(kopia[i]);
            }
            //vypis textu
            List<string> riadky = new List<string>();
            for (int j = 4; j >= 0; j--)
            {
                string riadok = "";
                for (int i = 0; i < kopia.Length; i++)
                {
                    if (j < kopia[i].Length && kopia[i].Length != 0)
                        riadok += kotuce[kopia[i][j]].PadLeft(5) + kotuce[kopia[i][j]].PadRight(5);
                    else
                        riadok += "".PadLeft(10);
                }
                riadky.Add(riadok + "\n");
            }
            string text = "1".PadRight(10) + "2".PadRight(10) + "3\n";
            foreach (string riadkyOpacne in riadky)
            {
                text += riadkyOpacne;
            }
            return text;
        }
    }
}
