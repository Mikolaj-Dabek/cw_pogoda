using System;
using System.Collections.Generic;
using System.IO;

namespace cw6___pogoda
{
    class Program
    {
        static String[][] readFile()
        {
            List<String[]> list = new List<String[]>();
            using (StreamReader reader = new StreamReader("pogoda.txt"))
            {
                while (!reader.EndOfStream)
                {
                    String line = reader.ReadLine();
                    String[] values = line.Split(';');
                    list.Add(values);
                }
            }
            return list.ToArray();
        }
        static void Main(string[] args)
        {
            string[][] dane = readFile();
            int[] wartosci = new int[dane.Length];
            double zbiornik = 25000;
            double pelny_zbironik = 25000;
            double dolano = 0;
            int day = 1;



            //Console.WriteLine(dane);

            for (int i = 0; i < dane.Length; i++)
            {

                String[] pogoda = dane[i];
                Double temp = Double.Parse(pogoda[0]);
                Double rain = Double.Parse(pogoda[1]);
                //Console.WriteLine(temp + " " + rain);
                double ubytek_parowanie = (0.0003 * Math.Pow(temp, 1.5));

                if (rain > 0)
                {
                    zbiornik = zbiornik + (700 * rain);
                    if (zbiornik > 25000)
                    {
                        zbiornik = 25000;
                    }

                }

                if (rain == 0)
                {
                    zbiornik = zbiornik - ubytek_parowanie;
                    if (zbiornik < 0)
                    {
                        Console.WriteLine("Dnia" + " " + day + " " + "Dolano wodę");
                        dolano = pelny_zbironik - zbiornik;
                        Console.WriteLine("Dolano" + " " + dolano);
                        zbiornik = 25000;

                        break;
                    }
                }
                if (temp > 15 && rain < 0.61)
                {

                    zbiornik = zbiornik - 12000;
                    if (zbiornik < 12000)
                    {
                        Console.WriteLine("Dnia" + " " + day + " " + "Dolano wodę");
                        dolano = pelny_zbironik - zbiornik;
                        Console.WriteLine("Dolano" + " " + dolano);
                        zbiornik = 25000;

                        break;
                    }
                }
                if (temp > 30 && rain < 0.61)
                {
                    zbiornik = zbiornik - 24000;
                    if (zbiornik < 24000)
                    {
                        Console.WriteLine("Dnia" + " " + day + " " + "Dolano wodę");
                        dolano = pelny_zbironik - zbiornik;
                        Console.WriteLine("Dolano" + " " + dolano);
                        zbiornik = 25000;

                        break;
                    }
                }
                // Console.WriteLine("W zbironiku" + " " + zbiornik);
                day++;
                //Console.WriteLine("Dzień" + " " + day);




            }
        }
    }
}
