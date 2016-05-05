using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Prog2_Beadando
{
    class Feldolgoz
    {

        string filename; //a file neve amit szeretnénk, hogy a program feldolgozzon
        List<string> txtSorai; //a beolvasott txt sorait tárolja el
        List<Alkatresz> alkatreszek; //a fileban megadott alkatrészeket fogja eltárolni
        string optimalizacioKikotes; //Aszerinti ki kötés, hogy mi alapján keressen a Backtrack alkatrészeket
        Alkatresz alkatreszKikotes; //ez lesz az az alkatrész amire a kikötés szól
        List<Auto> autok;
        List<Auto> osszesAuto;

        public List<Auto> OsszesAuto
        {
            get { return osszesAuto; }
            set { osszesAuto = value; }
        }

        public List<Auto> Autok
        {
            get { return autok; }
            set { autok = value; }
        }

        public Alkatresz AlkatreszKikotes
        {
            get { return alkatreszKikotes; }
            set { alkatreszKikotes = value; }
        }
        //List<Alkatresz> autova; //ezekből az alkatrészekből fog összeállni egy auto
        Auto auto;

        public Auto Auto
        {
            get { return auto; }
            set { auto = value; }
        }


        public Feldolgoz(string filename)
        {
            this.auto = new Auto();
            this.filename = filename;
            this.txtSorai = new List<string>();
            this.alkatreszek = new List<Alkatresz>(); 
        }

        /// <summary>
        /// Beolvassa az adott file adatait, és eltárolja egy listában
        /// </summary>
        public void Beolvas()
        {
            StreamReader sr = new StreamReader(filename, Encoding.Default);
            string line;
            while (!sr.EndOfStream)
            {
                line = sr.ReadLine();
                txtSorai.Add(line);
            }
            sr.Close();
        }

        /// <summary>
        /// A feldogoz osztály metódusainak a tesztelése céljából lett létrehozva ez a metódus
        /// </summary>
        public void Teszt()
        {
            //Console.WriteLine("Beolvasott sorok:");
            //foreach (string item in txtSorai)
            //{
            //    Console.WriteLine(item);
            //}

            //Console.WriteLine("\nLista tartalma");
            //foreach (IAlkatresz item in alkatreszek)
            //{
            //    Console.WriteLine("típus: {0}, név: {1}, súly: {2}, ár: {3}", item.Tipus, item.Nev, item.Suly, item.Ar);
            //}

            //Console.WriteLine("\nvalamelyik elem kompatibilis elemei");
            //foreach (Alkatresz item in alkatreszek[0].KompatibilisElektronika)
            //{
            //    Console.WriteLine("elektronika: " + item);
            //}
            //foreach (Alkatresz item in alkatreszek[0].KompatibilisFekrendszer)
            //{
            //    Console.WriteLine("fék: " + item);
            //}
            //foreach (Alkatresz item in alkatreszek[0].KompatibilisLegszuro)
            //{
            //    Console.WriteLine("légszűrő: " + item);
            //}
            //foreach (Alkatresz item in alkatreszek[0].KompatibilisValto)
            //{
            //    Console.WriteLine("váltó: " + item);
            //}

            //Console.WriteLine("\nKikötés");
            //Console.WriteLine(alkatreszKikotes.Nev);

            //Console.WriteLine("\nAuto motorja: " + auto.Motor.Nev);

            //Console.WriteLine("\nÖsszes kompatibilis elem listája");
            //foreach (Alkatresz item in alkatreszek[0].OsszesKompatibilisAlkatresz)
            //{
            //    Console.WriteLine("neve: " + item.Nev + "típusa: " + item.Tipus);
            //}

            //Console.WriteLine("\n létrehozott autok:");
            //foreach (var item in autok)
            //{
            //    Console.WriteLine("auto motorja: " + item.Motor.Nev);
            //    Console.WriteLine("auto féke: " + item.Fekrendszer.Nev);
            //    Console.WriteLine("auto váltója: " + item.Valto.Nev);
            //    Console.WriteLine("auto légszűrője: " + item.Legszuro.Nev);
            //    Console.WriteLine("auto elektronikája: " + item.Elektronika.Nev);
            //}

            Console.WriteLine("\nLétrehozott Autok súlya és ára");
            int i = 1;
            foreach (var item in autok)
            {
                Console.WriteLine(i + ". auto súlya: " + item.AutoSulya());
                Console.WriteLine(i + ". auto ára: " + item.AutoAra());
                i++;
            }

        }

        /// <summary>
        /// A fileból kiolvassa, hogy milyen alkatrészeket kell létrehozni. A létrehozott alkatrészeket eltárolja egy listában.
        /// </summary>
        public void Letrehoz()
        {
            for (int i = 0; i < txtSorai.Count; i++)
            {
                if (txtSorai[i].StartsWith("Alkatrész"))
                {
                    string tipus = txtSorai[i].Split(':')[1];
                    //txtSorai: ha az i-edik sor az Alkatrész, akkor az i+1ben van a név, az i+2ben a suly és az i+3ban pedig az ár

                    switch (tipus)
                    {
                        case "Elektronika":
                            alkatreszek.Add(new Elektronika(txtSorai[(i + 1)].Split(':')[1], int.Parse(txtSorai[(i+2)].Split(':')[1]), int.Parse(txtSorai[(i+3)].Split(':')[1])));
                            break;
                        case "Fekrendszer":
                            alkatreszek.Add(new Fekrendszer(txtSorai[(i + 1)].Split(':')[1], int.Parse(txtSorai[(i + 2)].Split(':')[1]), int.Parse(txtSorai[(i + 3)].Split(':')[1])));
                            break;
                        case "Legszuro":
                            alkatreszek.Add(new Legszuro(txtSorai[(i + 1)].Split(':')[1], int.Parse(txtSorai[(i + 2)].Split(':')[1]), int.Parse(txtSorai[(i + 3)].Split(':')[1])));
                            break;
                        case "Valto":
                            alkatreszek.Add(new Valto(txtSorai[(i + 1)].Split(':')[1], int.Parse(txtSorai[(i + 2)].Split(':')[1]), int.Parse(txtSorai[(i + 3)].Split(':')[1])));
                            break;
                        case "BenzinMotor":
                            alkatreszek.Add(new BenzinMotor(txtSorai[(i + 1)].Split(':')[1], int.Parse(txtSorai[(i + 2)].Split(':')[1]), int.Parse(txtSorai[(i + 3)].Split(':')[1])));
                            break;
                        default:
                            throw new Exception();
                    }
                }
            }
        }

        /// <summary>
        /// Ez a metódus "húzza be a gárf életi", vagyis beállítja, hogy mi mivel kompatibilis
        /// </summary>
        public void GrafotLetrehoz()
        {
            for (int i = 0; i < txtSorai.Count; i++)
            {
                //ha az txtsorai i-edik elem Alkatrész szóval kezdődik, akkor a txtSorai i + 4.sorban vannaka  vele kompatibilis alkatrészek
                if (txtSorai[i].StartsWith("Alkatrész"))
                {
                    string[] kompatibilisek = txtSorai[(i + 4)].Split(':')[1].Split(',');
                    if (alkatreszek.Contains(MelyikElem(txtSorai[(i+1)].Split(':')[1])))
                    {
                        for (int j = 0; j < kompatibilisek.Length; j++)
                        {
                            MelyikElem(txtSorai[(i + 1)].Split(':')[1]).KompatibilisHozzaAd(MelyikElem(kompatibilisek[j]));
                        }
                    }
                }
            }
        }

        /// <summary>
        /// Az alkatrészek listából vissza ad egy alkatrészt, amit név alapján keres ki
        /// </summary>
        Alkatresz MelyikElem(string nev)
        {
            foreach (Alkatresz item in alkatreszek)
            {
                if (item.Nev == nev)
                {
                    return item;
                }
            }
            throw new NemTalalNevetException(nev);
        }

        /// <summary>
        /// Megkeresi az optimalizáció kikötést.
        /// Megkeresi azt az elemet amire a kikötés szól, és aminek mindenképpen benne kell lennie az autoban
        /// </summary>
        public void Kikotes()
        {
            string nevKikotes = "";
            foreach (string item in txtSorai)
            {
                if (item.StartsWith("név kikötés"))
                {
                    nevKikotes = item.Split(':')[1];
                }
            }
            alkatreszKikotes = MelyikElem(nevKikotes);
            alkatreszKikotes.Beepit(auto);

            foreach (string item in txtSorai)
            {
                if (item.StartsWith("szempont"))
                {
                    optimalizacioKikotes = item.Split(':')[1];
                }
            }
        }

        public void Backtrack(Alkatresz alkatresz, Auto auto, Alkatresz alkatreszKikotes)
        {
            if (auto.Elektronika != null && auto.Fekrendszer != null && auto.Legszuro != null && auto.Motor != null && auto.Valto != null)
            {
                Console.WriteLine("Kész az auto");
            }
            else
            {
                int i;
                switch (alkatresz.Tipus)
                {
                    case Tipus.motor:
                        if (alkatreszKikotes.Tipus != Tipus.valto)
                        {
                            i = 0;
                            while (alkatreszKikotes.KompatibilisValto != null && i < alkatreszKikotes.KompatibilisValto.Count && auto.Valto == null)
                            {
                                try
                                {
                                    alkatreszKikotes.KompatibilisValto[i].Beepit(auto);
                                }
                                catch (BeepitException)
                                {
                                  i++;
                                }
                            }
                            if (alkatreszKikotes.KompatibilisValto != null && i > alkatreszKikotes.KompatibilisValto.Count)
                            {
                                throw new NemTalaltAlkatresztException(alkatresz);
                            }
                            else if (alkatreszKikotes.KompatibilisValto == null)
                            {
                                throw new NemTalaltAlkatresztException(alkatresz);
                            }
                            else if (auto.Valto == null)
                            {
                                throw new NemTalaltAlkatresztException(alkatresz);
                            }
                        }
                        if (auto.Valto != null)
                        {
                            Backtrack(auto.Valto, auto, alkatreszKikotes);   
                        }
                        break;
                    case Tipus.legszuro:
                        if (alkatreszKikotes.Tipus != Tipus.fekrendszer)
                        {
                            i = 0;
                            while (alkatreszKikotes.KompatibilisFekrendszer != null && i < alkatreszKikotes.KompatibilisFekrendszer.Count && auto.Fekrendszer == null)
                            {
                                try
                                {
                                    alkatreszKikotes.KompatibilisFekrendszer[i].Beepit(auto);
                                }
                                catch (BeepitException)
                                {
                                    i++;
                                }
                            }
                            if (alkatreszKikotes.KompatibilisFekrendszer != null && i > alkatreszKikotes.KompatibilisFekrendszer.Count)
                            {
                                throw new NemTalaltAlkatresztException(alkatresz);
                            }
                            else if (alkatreszKikotes.KompatibilisFekrendszer == null)
                            {
                                throw new NemTalaltAlkatresztException(alkatresz);
                            }
                            else if (auto.Fekrendszer == null)
                            {
                                throw new NemTalaltAlkatresztException(alkatresz);
                            }
                        }
                        if(auto.Fekrendszer != null)
                        {
                            Backtrack(auto.Fekrendszer, auto, alkatreszKikotes);
                        }
                        break;
                    case Tipus.fekrendszer:
                        if (alkatreszKikotes.Tipus != Tipus.elektronika)
                        {
                            i = 0;
                            while (alkatreszKikotes.KompatibilisElektronika != null && i < alkatreszKikotes.KompatibilisElektronika.Count && auto.Elektronika == null)
                            {
                                try
                                {
                                    alkatreszKikotes.KompatibilisElektronika[i].Beepit(auto);
                                }
                                catch (BeepitException)
                                {
                                    i++;
                                }
                            }
                            if (alkatreszKikotes.KompatibilisElektronika != null && i > alkatreszKikotes.KompatibilisElektronika.Count)
                            {
                                throw new NemTalaltAlkatresztException(alkatresz);
                            }
                            else if (alkatreszKikotes.KompatibilisElektronika == null)
                            {
                                throw new NemTalaltAlkatresztException(alkatresz);
                            }
                            else if (auto.Elektronika == null)
                            {
                                throw new NemTalaltAlkatresztException(alkatresz);
                            }
                        }
                        if (auto.Elektronika != null)
                        {
                            Backtrack(auto.Elektronika, auto, alkatreszKikotes);
                        }
                        break;
                    case Tipus.elektronika:
                        if (alkatreszKikotes.Tipus != Tipus.motor)
                        {
                            i = 0;
                            while (alkatreszKikotes.KompatibilisMotorok != null && i < alkatreszKikotes.KompatibilisMotorok.Count && auto.Motor == null)
                            {
                                try
                                {
                                    alkatreszKikotes.KompatibilisMotorok[i].Beepit(auto);
                                }
                                catch (BeepitException)
                                {
                                    i++;
                                }
                            }
                            if (alkatreszKikotes.KompatibilisMotorok != null && i > alkatreszKikotes.KompatibilisMotorok.Count)
                            {
                                throw new NemTalaltAlkatresztException(alkatresz);
                            }
                            else if (alkatreszKikotes.KompatibilisMotorok == null)
                            {
                                throw new NemTalaltAlkatresztException(alkatresz);
                            }
                            else if (auto.Motor == null)
                            {
                                throw new NemTalaltAlkatresztException(alkatresz);
                            }
                        }
                        if (auto.Motor != null)
                        {
                            Backtrack(auto.Motor, auto, alkatreszKikotes);
                        }
                        break;
                    case Tipus.valto:
                        if (alkatreszKikotes.Tipus != Tipus.legszuro)
                        {
                            i = 0;
                            while (alkatreszKikotes.KompatibilisLegszuro != null && i < alkatreszKikotes.KompatibilisLegszuro.Count && auto.Legszuro == null)
                            {
                                try
                                {
                                    alkatreszKikotes.KompatibilisLegszuro[i].Beepit(auto);
                                }
                                catch (BeepitException)
                                {
                                    i++;
                                }
                            }
                            if (alkatreszKikotes.KompatibilisLegszuro != null && i > alkatreszKikotes.KompatibilisLegszuro.Count)
                            {
                                throw new NemTalaltAlkatresztException(alkatresz);
                            }
                            else if (alkatreszKikotes.KompatibilisLegszuro == null)
                            {
                                throw new NemTalaltAlkatresztException(alkatresz);
                            }
                            else if (auto.Legszuro == null)
                            {
                                throw new NemTalaltAlkatresztException(alkatresz);
                            }
                        }
                        if(auto.Legszuro != null)
                        {
                            Backtrack(auto.Legszuro, auto, alkatreszKikotes);
                        }
                        break;
                }
            }
        }

        public void AutokatLetrehoz()
        {
            for (int i = 0; i < alkatreszek.Count; i++)
            {
                if (osszesAuto == null)
                {
                    osszesAuto = new List<Auto>();
                }

                osszesAuto.Add(new Auto());
                alkatreszek[i].Beepit(osszesAuto[(osszesAuto.Count - 1)]);
                try
                {
                    Backtrack(alkatreszek[i], osszesAuto[(osszesAuto.Count - 1)], alkatreszek[i]);
                }
                catch (NemTalaltAlkatresztException)
                {
                    osszesAuto.Remove(osszesAuto[(osszesAuto.Count - 1)]);
                }
            }

            foreach (var item in osszesAuto)
            {
                if (autok == null)
                {
                    autok = new List<Auto>();
                    autok.Add(item);
                }
                else if (!VanEMarIlyenAuto(autok, item))
                {
                    autok.Add(item);
                }
            }
        }

        bool VanEMarIlyenAuto(List<Auto> autok, Auto auto)
        {
            foreach (Auto item in autok)
            {
                if (item.Equals(auto))
                {
                    return true;
                }
            }
            return false;
        }

        public Auto LegkonyebbAuto(List<Auto> autok)
        {
            int index = 0;
            int min = int.MaxValue;
            for (int i = 0; i < autok.Count; i++)
            {
                if (min > autok[i].AutoSulya())
                {
                    min = autok[i].AutoSulya();
                    index = i;
                }
            }
            return autok[index];
        }

        public Auto LegOlcsobbAuto(List<Auto> autok)
        {
            int index = 0;
            int min = int.MaxValue;
            for (int i = 0; i < autok.Count; i++)
            {
                if (min > autok[i].AutoAra())
                {
                    min = autok[i].AutoAra();
                    index = i;
                }
            }

            return autok[index];
        }

        /// <summary>
        /// Kikeresei az adott alkatrész istából a legkönyebb alkatrészt
        /// </summary>
        //Alkatresz Legkonnyebb(List<Alkatresz> alkatreszek)
        //{
        //    int index = 0;
        //    int min = int.MaxValue;
        //    for (int i = 0; i < alkatreszek.Count; i++)
        //    {
        //        if (alkatreszek[i].Suly < min)
        //        {
        //            min = alkatreszek[i].Suly;
        //            index = i;
        //        }
        //    }

        //    return alkatreszek[index]; 
        //}

        /// <summary>
        /// Kikeresi az adott alaktrész listából a legolcsóbb alkatrészt
        /// </summary>
        //Alkatresz Legolcsobb(List<Alkatresz> alkatreszek)
        //{
        //    int index = 0;
        //    int min = int.MaxValue;
        //    for (int i = 0; i < alkatreszek.Count; i++)
        //    {
        //        if (alkatreszek[i].Ar < min)
        //        {
        //            min = alkatreszek[i].Ar;
        //            index = i;
        //        }
        //    }

        //    return alkatreszek[index];
        //}

        /// <summary>
        /// Megnézi, hogy két alkatrész kompatibilis-e egymással
        /// </summary>
        //bool Kompatibilis(Alkatresz alkatreszMi, Alkatresz alkatereszMivel)
        //{
        //    return alkatereszMivel.KompatibilisElektronika.Contains(alkatreszMi) || alkatereszMivel.KompatibilisFekrendszer.Contains(alkatreszMi) || alkatereszMivel.KompatibilisLegszuro.Contains(alkatreszMi) || alkatereszMivel.KompatibilisMotorok.Contains(alkatreszMi) || alkatereszMivel.KompatibilisValto.Contains(alkatreszMi);
        //}
    }
}