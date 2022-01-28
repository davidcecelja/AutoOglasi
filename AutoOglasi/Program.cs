using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoOglasi
{

    public enum Proizvodjac { Audi, Mazda, Škoda, Yugo, BMW, Fiat};

    public enum DodatnaOprema { Klima, ABS, Koža, Radio, Šiber, Pojasevi, AutomatskiMjenjac};

    public struct AutoOglas
    {
        // polja (fields)
        public string Tip;
        public int GodinaProizvodnje;
        public double Cijena;
        public bool PrviVlasnik;
        public Proizvodjac Marka;
        public DodatnaOprema[] Oprema;        
    }

    class Program
    {
        // lista oglasa 
        private static List<AutoOglas> oglasnik = new List<AutoOglas>();

        static void Main(string[] args)
        {
            // 1 autooglas
            AutoOglas o1 = new AutoOglas();
            o1.Tip = "A4";
            o1.Marka = Proizvodjac.Audi;
            o1.GodinaProizvodnje = 2015;
            o1.PrviVlasnik = true;
            o1.Cijena = 120000;
            DodatnaOprema[] oprema = new DodatnaOprema[] {
                DodatnaOprema.ABS,
                DodatnaOprema.Koža,
                DodatnaOprema.Radio};
            o1.Oprema = oprema;

            // dodajemo oglas u kolekciju oglasa
            oglasnik.Add(o1);

            // drugi oglas
            AutoOglas o2 = new AutoOglas()
            {
                Tip = "3",
                Marka = Proizvodjac.BMW,
                GodinaProizvodnje = 2019,
                PrviVlasnik = false,
                Cijena = 234000,
                Oprema = new DodatnaOprema[] { DodatnaOprema.Šiber,
                    DodatnaOprema.Pojasevi, DodatnaOprema.Klima,
                    DodatnaOprema.AutomatskiMjenjac}
            };

            oglasnik.Add(o2);

            // treci oglas
            oglasnik.Add(new AutoOglas {
                Tip = "45",
                Marka = Proizvodjac.Yugo,
                GodinaProizvodnje = 1982,
                PrviVlasnik = false,
                Cijena = 200
            });

            // ispis autooglasa na konzolu
            Console.WriteLine("{0,-10}{1,-10}{2,-6}{3,-6}{4,8} {5,-25}",
                "MARKA", "TIP", "GOD.", "PRVL.", "CIJENA", "OPERMA");
            Console.WriteLine("===============================================================");
            foreach (AutoOglas ao in oglasnik)
                IspisOglasa(ao);
            // ispis ostalih podataka
            Console.WriteLine("Ukupna cijena svih vozila iznosi: {0:f2}",
                VratiUkupnuCijenu());

            Console.WriteLine("Najstarije vozilo je: {0}/{1}",
                VratiNajstarijeVozilo().Marka,
                VratiNajstarijeVozilo().Tip);

            Console.WriteLine("Prosječna starost svih vozila iznosi: {0:f2}",
                VratiProsjecnuStarstVozila());
        }

        // metoda koja vraca najstarije vozilo
        private static AutoOglas VratiNajstarijeVozilo()
        {
            // prvo pretpostavim da je najstarije vozilo prvi oglas
            AutoOglas najstarijeVozilo = oglasnik.Last();
            // provjerim da li je to istina
            foreach (AutoOglas ao in oglasnik)
            {
                if (najstarijeVozilo.GodinaProizvodnje >
                    ao.GodinaProizvodnje)
                    najstarijeVozilo = ao;
            }
            return najstarijeVozilo;            
        }

        // metoda koja daje ukupnu cijenu svih oglasa
        private static double VratiUkupnuCijenu()
        {
            double ukupnaCijena = 0;
            foreach (AutoOglas ao in oglasnik)
                ukupnaCijena += ao.Cijena;
            return ukupnaCijena;
        }

        // metoda koja daje prosjecnu starost vozila
        private static double VratiProsjecnuStarstVozila()
        {
            double starost = 0;
            double ukupnaStarost = 0;
            //int koliko = 0;
            foreach (AutoOglas ao in oglasnik)
            {
                starost = DateTime.Now.Year - ao.GodinaProizvodnje;
                ukupnaStarost += starost;
                //koliko++;
            }
            return ukupnaStarost/oglasnik.Count;
        }

        // metoda za ispis vozila na konzolu
        private static void IspisOglasa(AutoOglas os)
        {
            //dodatna oprema u string
            string opisDodatneOpreme = "";
            if (os.Oprema != null)
            {
                foreach (DodatnaOprema _do in os.Oprema)
                    opisDodatneOpreme += _do.ToString() + ", ";
            }

            // opis prvog vlasnika

            //string opisPrviVlasnik = "";
            //if (os.PrviVlasnik)
            //    opisPrviVlasnik = "DA";
            //else
            //    opisPrviVlasnik = "NE";

            string opisPrviVlasnik = os.PrviVlasnik ? "DA" : "NE";

            Console.WriteLine("{0,-10}{1,-10}{2,-6}{3,-6}{4,8} {5,-25}",
                os.Marka, os.Tip, os.GodinaProizvodnje,
                opisPrviVlasnik, os.Cijena, opisDodatneOpreme
                );
        }
    }
}
