using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Data.SqlTypes;

namespace kraterek
{
    internal class Program
    {
        static void Feladat3(List<Krater> kraterek)
        {
            Console.WriteLine("3. feladat");
            Console.Write("Kérem egy kráter nevét: ");
            string nev = Console.ReadLine();

            Krater keresett = kraterek[0];
            bool volt = false;

            foreach(var i in kraterek)
            {
                if(i.Nev == nev)
                {
                    keresett = i;
                    volt = true;
                }
            }

            if (volt)
            {
                Console.WriteLine($"A(z) {nev} középpontja X={keresett.X} Y={keresett.Y} sugara R={keresett.R}.");
            }
            else
            {
                Console.WriteLine("Nincs ilyen nevű kráter.");
            }
        }
        static double tavolsag(double x1, double x2, double y1, double y2)
        {
            return Math.Sqrt((x2 - x1) * (x2 - x1) + (y2 - y1) * (y2 - y1));
        }
        static void Main(string[] args)
        {
            List<Krater> kraterek = new List<Krater>();

            StreamWriter sw = new StreamWriter("terulet.txt");

            foreach(var i in File.ReadLines("felszin_tvesszo.txt"))
            {
                Krater k = new Krater(i);
                kraterek.Add(k);
            }

            //2. feladat
            Console.WriteLine($"2. feladat\nA kráterek száma: {kraterek.Count}");

            //3. feladat
            Feladat3(kraterek);

            //4. feladat
            Krater legnagyobb = kraterek[0];

            foreach(var  i in kraterek)
            {
                if(i.R > legnagyobb.R)
                {
                    legnagyobb = i;
                }
            }

            Console.WriteLine($"4. feladat\nA legnagyobb kráter neve és sugara: {legnagyobb.Nev} {legnagyobb.R}");

            //6. feladat
            Console.WriteLine("6. feladat");

            Console.Write("Kérem egy kráter nevét: ");
            string nev = Console.ReadLine();

            Krater keresett = new Krater("4,33\t3,22\t2,44\tKráter");

            foreach(var i in kraterek)
            {
                if(i.Nev == nev)
                {
                    keresett = i;
                }
            }
            if(keresett.Nev != "Kráter")
            {
                List<string> nincsKozos = new List<string>();

                foreach (var i in kraterek)
                {
                    if (tavolsag(keresett.X, i.X, keresett.Y, i.Y) > (i.R + keresett.R))
                    {
                        nincsKozos.Add(i.Nev);
                    }
                }

                Console.Write("Nincs közös része: ");
                for (int i = 0; i < nincsKozos.Count; i++)
                {
                    if (i == nincsKozos.Count - 1)
                    {
                        Console.Write($"{nincsKozos[i]}.");
                    }
                    else
                    {
                        Console.Write($"{nincsKozos[i]}, ");
                    }
                }
            }

            //7. feladat
            Console.WriteLine("\n7. feladat");
            for (int i = 0; i < kraterek.Count; i++)
            {
                for(int j = i + 1; j < kraterek.Count; j++)
                {
                    if (kraterek[i].R > kraterek[j].R)
                    {
                        if (tavolsag(kraterek[i].X, kraterek[j].X, kraterek[i].Y, kraterek[j].Y) < (kraterek[i].R - kraterek[j].R))
                        {
                            Console.WriteLine($"A(z) {kraterek[i].Nev} kráter tartalmazza a(z) {kraterek[j].Nev} krátert.");
                        }

                    }
                    else if(kraterek[i].R < kraterek[j].R)
                    {
                        if (tavolsag(kraterek[i].X, kraterek[j].X, kraterek[i].Y, kraterek[j].Y) < (kraterek[j].R - kraterek[i].R))
                        {
                            Console.WriteLine($"A(z) {kraterek[j].Nev} kráter tartalmazza a(z) {kraterek[i].Nev} krátert.");
                        }

                    }
                }
            }

            //8. feladat
            foreach(var i in kraterek)
            {
                sw.WriteLine($"{Math.Round(i.R * i.R * 3.14, 2)}\t{i.Nev}");
            }

            sw.Close();
            Console.ReadKey();
        }
    }
}
