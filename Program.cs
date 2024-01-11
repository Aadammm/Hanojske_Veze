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
            Stack<int> veza1 = new Stack<int>();
            Stack<int> veza2 = new Stack<int>();
            Stack<int> veza3 = new Stack<int>();
            var veze = new List<Stack<int>>() { veza1, veza2, veza3 };
            for (int i = 5; i >= 1; i--)
            {
                veza1.Push(i);
            }
            int zVeze;
            int naVezu;
            int kotuc;
            do
            {
                Console.Clear();
                Console.WriteLine(Vypis(veze));
                Console.WriteLine("Přesunout kotouč z věže: ");
                //z ktorej veze vezme kotuc
                while (!int.TryParse(Console.ReadLine(), out zVeze) || zVeze < 1 || zVeze > 3)
                    Console.WriteLine("Zadej znovu:");

                Console.WriteLine("Přesunout kotouč na věž: ");
                //na ktoru vezu polozi kotuc
                while (!int.TryParse(Console.ReadLine(), out naVezu) || naVezu < 1 || naVezu > 3)
                    Console.WriteLine("Zadej znovu:");
                //vezme kotuc z veze
                if (veze[zVeze - 1].Count > 0)
                {
                    kotuc = veze[zVeze - 1].Peek();
                    //ak je v zasobniku kotuc mensi tak ho tam neprida
                    try
                    {
                        if (veze[naVezu - 1].Peek() > kotuc)
                        {
                            veze[zVeze - 1].Pop();
                            veze[naVezu - 1].Push(kotuc);
                        }
                    }
                    catch (Exception)
                    {
                        veze[zVeze - 1].Pop();
                        veze[naVezu - 1].Push(kotuc);
                    }
                }
               
            }
            while (!Koniec(veza2));
            Console.WriteLine(Vypis(veze));
            Console.WriteLine("Vyhrál jsi!");
            Console.Read();


        }
        static bool Koniec(Stack<int> DruhaVeza)
        {
            int pocetKotucov = 1;
            foreach (int i in DruhaVeza)
            {
                if (i == pocetKotucov)
                    pocetKotucov++;
            }

            if (pocetKotucov == 6)
                return true;
            return false;
        }
        static string Vypis(List<Stack<int>> list)
        {
            string[] kotuce = { "", "█", "██", "███", "████", "█████" };
            int[][] kopia = new int[list.Count][];
            for (int i = 0; i < kopia.Length; i++)
            {
                kopia[i] = new int[list[i].Count];
                int zaciatok = 0;
                int koniec = list[i].Count;
                foreach (int item in list[i])
                {
                    if (zaciatok < koniec)
                    {
                        kopia[i][zaciatok] = item;
                        zaciatok++;
                    }
                }
            }
            //vypis textu
            string text = "1".PadRight(10) + "2".PadRight(10) + "3\n";
            for (int j = 0; j <5; j++)
            {
                if (j < kopia[0].Length&& kopia[0].Length!=0)
                    text += kotuce[kopia[0][j]].PadLeft(5) + kotuce[kopia[0][j]].PadRight(5);
                else
                text+="".PadLeft(10);    
                if (j < kopia[1].Length && kopia[1].Length != 0 )
                    text += kotuce[kopia[1][j]].PadLeft(5) + kotuce[kopia[1][j]].PadRight(5);
                else
                    text += "".PadLeft(10);
                if (j < kopia[2].Length && kopia[2].Length != 0 )
                    text += kotuce[kopia[2][j]].PadLeft(5) + kotuce[kopia[2][j]].PadRight(5);
                else
                    text += "".PadLeft(10);

                text += "\n";
            }

            //toto funguje     text += kotuce[kopia[0][j]].PadLeft(5)+ kotuce[kopia[0][j]].PadRight(5);
            return text;
        }
    }
}
