using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace balkezesek
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] sorok = File.ReadAllLines("balkezesek.csv", Encoding.UTF8);
            List<Adat> adatok = new List<Adat>();
            foreach (string sor in sorok.Skip(1))
            {
                adatok.Add(new Adat(sor));
            }

            int adatokszama = adatok.Count();
            Console.WriteLine($"3.feladat: hány adatsor van a forrásállományban? => {adatokszama} db adat van");



            /* 4 írd ki annak a nevét és magasságát centiben, aki utoljára 99 októberben lépett pályára */
            Console.WriteLine("4.Feladat:");
            for (int i = 0; i < adatokszama; i++)
            {
                if (adatok[i].utolsoDatum.Year == 1999 && adatok[i].utolsoDatum.Month == 10)
                {
                    double magassagCMben = adatok[i].magassagInchben * 2.54;
                    Console.WriteLine($"\t{adatok[i].Nev}, {magassagCMben} cm");
                }
            }

            /* 5 kérj be egy évszámot, hanem nagyobb mint 90 vagy nagyobb mint 99 akkor dobj ki errort */
            Console.WriteLine("Adj meg egy évszámot!");
            string valasz = Console.ReadLine();
            int megadottEv = int.Parse(valasz);

            while (!(1990 <= megadottEv && megadottEv <= 1999))
            {
                Console.WriteLine($"Hibás adat, kérlek 1990 és 1999 közötti számot adj meg!: {megadottEv}");
                 valasz = Console.ReadLine();
                 megadottEv = int.Parse(valasz);
            }

            /* 6 */
            double osszSuly = 0;
            int emberszama = 0;
            for (int i = 0; i < adatokszama; i++)
            {
                if (adatok[i].elsoDatum.Year == megadottEv)
                {
                    osszSuly += adatok[i].sulyFontban;
                    emberszama++;
                }
            }
            double osszSulyAtlag = osszSuly / emberszama;

            Console.WriteLine($"6.Feladat: {osszSulyAtlag:N2} font;");


            Console.ReadLine();
        }

        class Adat
        {
            public string Nev { get; set; }
            public DateTime elsoDatum { get; set; }
            public DateTime utolsoDatum { get; set; }
            public double sulyFontban { get; set; }
            public double magassagInchben { get; set; }

            public Adat(string sor)
            {
                string[] s = sor.Split(';');
                Nev = s[0];
                elsoDatum = DateTime.Parse(s[1]);
                utolsoDatum = DateTime.Parse(s[2]);
                sulyFontban = double.Parse(s[3]);
                magassagInchben = double.Parse(s[4]);
            }
        }
    }
}
