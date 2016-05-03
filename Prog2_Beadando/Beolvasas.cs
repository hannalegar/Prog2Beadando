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
        /*
        string filename;
        List<string> list; //a beolvasott fájl sorait tartalmazza
        List<IAlkatresz> alkatReszek; //a létrehozott alkatrészeket tárolja
        string nevkikotes;
        Tipus tipusKikotes;
        IAlkatresz alkatreszKikotes;
        List<IAlkatresz> autova = new List<IAlkatresz>();
        List<IAlkatresz> F = new List<IAlkatresz>(); //kikötésre vonatkozóan ezekben lesznek az egymással kompatibilis alkatrészek

        public List<IAlkatresz> Autova
        {
            get { return autova; }
        }
        
        string szempont; //milyen szempont szerint legyen a konfiguráció

        public List<IAlkatresz> AlkatReszek
        {
            get { return alkatReszek; }
        }
        public List<string> List
        {
            get { return list; }
        }

        public Feldolgoz(string filename)
        {
            this.filename = filename;
            this.list = new List<string>();
            this.alkatReszek = new List<IAlkatresz>();
            this.Beolvas();
            this.GrafotLetrehoz();
            this.Kikotes();
            this.SzelessegiBejaras();
        }

        /// <summary>
        /// beolvassa a fájl sorait
        /// </summary>
        void Beolvas()
        {
            StreamReader sr = new StreamReader(filename, Encoding.Default);
            string line;
            while (!sr.EndOfStream)
            {
                line = sr.ReadLine();
                list.Add(line);
            }
            sr.Close();
        }

        /// <summary>
        /// A list alapján létrehozza az alkatrészeket, majd beállítja, hogy mi mivel kompatibilis,
        /// a gárf tulajdonképpen az alapján jön létre.
        /// </summary>
        void GrafotLetrehoz()
        {
            for (int i = 0; i < list.Count; i++)
            {
                if (list[i].StartsWith("IAlkatrész"))
                {
                    string[] tipus = list[i].Split(':');
                    //Az IAlkatrész után van, hogy milyen típus lesz, és ez alapján hívja meg a megfelelő osztály konstruktorát.
                    //Ha a dokumentációnak megfelelően lettek felírva az adatok, akor létrhozza a program a kívánt alkatrészt
                    switch (tipus[1])
                    {
                        case "BenzinMotor":
                            alkatReszek.Add(new BenzinMotor(list[i + 1].Split(':')[1], int.Parse(list[i + 2].Split(':')[1]), int.Parse(list[i + 3].Split(':')[1])));
                            break;
                        case "Valto":
                            alkatReszek.Add(new Valto(list[i + 1].Split(':')[1], int.Parse(list[i + 2].Split(':')[1]), int.Parse(list[i + 3].Split(':')[1])));
                            break;
                        case "Elektronika":
                            alkatReszek.Add(new Elektronika(list[i + 1].Split(':')[1], int.Parse(list[i + 2].Split(':')[1]), int.Parse(list[i + 3].Split(':')[1])));
                            break;
                        case "Fekrendszer":
                            alkatReszek.Add(new Fekrendszer(list[i + 1].Split(':')[1], int.Parse(list[i + 2].Split(':')[1]), int.Parse(list[i + 3].Split(':')[1])));
                            break;
                        case "Legszuro":
                            alkatReszek.Add(new Legszuro(list[i + 1].Split(':')[1], int.Parse(list[i + 2].Split(':')[1]), int.Parse(list[i + 3].Split(':')[1])));
                            break;
                        default:
                            //throw exception
                            break;
                    }

                }
            }

            //A már meglévő alkatrészeknek beállítja, hogy mi mivel kompatibilis
            for (int i = 0; i < list.Count; i++)
            {
                if (list[i].StartsWith("IAlkatrész"))
                {
                    string[] kompatibilis = list[i + 4].Split(':')[1].Split(',');//idáig kikeresi az első alkatrészt, és kikeresi azokat a neveket amikker az adott alkatrész kompatiblis
                    foreach (IAlkatresz item in alkatReszek) 
                    {
                        if (list[i + 1].Contains(item.Nev)) //Ez a sor megkeresi a létrehozott alkatrészek között azt az alkatrészt aminek be akarjuk állítani, hogy mikkel kompatiblis
                        {
                            foreach (String kompItem in kompatibilis) //végig szalad azon a tömbön amit a beolvasott listából vágtunk ki, ami neveket tartalmaz
                            {
                                foreach (IAlkatresz alkItem in alkatReszek) 
                                {
                                    if (kompItem.Contains(alkItem.Nev)) //összehasonlítja a nevet az alkatrészek között található nevekkel
                                    {
                                        item.KompatibilisHozzaAd(alkItem); //Ha a két név egyezik, akkor létrehozza köztük a kompatibilitás, azaz a gráf két csúcsa közé húz egy élt
                                    }
                                }
                            }
                        }
                    }

                }
            }
        }

        void Kikotes()
        {
            foreach (String item in list)
            {
                if (item.Contains("név kikötés"))
                {
                    nevkikotes = item.Split(':')[1];
                }
                else if (item.Contains("típus kikötés"))
                {
                    string tipus = item.Split(':')[1];
                    switch (tipus)
                    {
                        case "motor":
                            tipusKikotes = Tipus.motor;
                            break;
                        case "Benzin motor":
                            tipusKikotes = Tipus.motor;
                            break;
                        case "Diesel motor":
                            tipusKikotes = Tipus.motor;
                            break;
                        case "fekrendszer":
                            tipusKikotes = Tipus.fekrendszer;
                            break;
                        case "valto":
                            tipusKikotes = Tipus.valto;
                            break;
                        case "legszuro":
                            tipusKikotes = Tipus.legszuro;
                            break;
                        case "elektronika":
                            tipusKikotes = Tipus.elektronika;
                            break;
                        default:
                            //throw exception
                            break;
                    }
                }
                else if (item.Contains("szempont"))
                {
                    szempont = item.Split(':')[1];
                }
            }
            foreach (IAlkatresz item in alkatReszek)
            {
                if (item.Tipus == tipusKikotes && item.Nev.Contains(nevkikotes))
                {
                    alkatreszKikotes = item;
                }
            }
        }
        
        /*
        void Backtrack(IAlkatresz alkatresz, string szempont)
        {
            IAlkatresz kovetkezoAlkatresz = null;
            if (autova.Count == 0)
            {
                autova.Add(alkatresz);
            }
            if (autova.Count != 5)
            {
                kovetkezoAlkatresz = SzempontszerintKivalaszt(alkatresz.Kompatibilis, szempont);
                autova.Add(kovetkezoAlkatresz);
                Backtrack(kovetkezoAlkatresz, szempont);    
            }
        }
        
        IAlkatresz SzempontszerintKivalaszt(List<IAlkatresz> alkatreszLista, string szempont)
		{
            IAlkatresz ret = 
           
            if (szempont == "ár")
	        {
		        foreach (IAlkatresz item in alkatreszLista)
	            {
		            if (item.Ar < ret.Ar && !(autova.Contains(item)))
	                {
		                ret = item;
	                }
	            }
	        }
            else if(szempont == "súly")
	        {
                foreach (IAlkatresz item in alkatreszLista)
	            {
		            if (item.Suly < ret.Suly && !(autova.Contains(item)))
	                {
		                ret = item;
	                }
	            }
            }
            else if (szempont == "opt")
            {
                foreach (IAlkatresz item in alkatreszLista)
                {
                    if (!autova.Contains(item))
                    {
                        ret = item;
                    }
                }
            }
            return ret;
        }
        
        

        void SzelessegiBejaras()
        {
            Queue<IAlkatresz> S = new Queue<IAlkatresz>();
            S.Enqueue(alkatreszKikotes);
            
            F.Add(alkatreszKikotes);

            while (S.Count > 0)
            {
                IAlkatresz k = S.Dequeue();
                int index = 0;
                while (index < k.Kompatibilis.Count)
                {
                    if (!F.Contains(k.Kompatibilis[index]))
                    {
                        S.Enqueue(k.Kompatibilis[index]);
                        F.Add(k.Kompatibilis[index]);
                    }
                    index++;
                }
            }

            Console.WriteLine("Graf csúcsai");
            foreach (IAlkatresz item in F)
            {
                Console.WriteLine(item.Nev);
            }
        }


        void AutoOsszeallitas()
        {
               
        }
        */

        string filename; //a file neve amit szeretnénk, hogy a program feldolgozzon
        List<string> txtSorai; //a beolvasott txt sorait tárolja el
        List<Alkatresz> alkatreszek; //a fileban megadott alkatrészeket fogja eltárolni
        string optimalizacioKikotes; //Aszerinti ki kötés, hogy mi alapján keressen a Backtrack alkatrészeket
        Alkatresz alkatreszKikotes; //ez lesz az az alkatrész amire a kikötés szól

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
            Console.WriteLine("Beolvasott sorok:");
            foreach (string item in txtSorai)
            {
                Console.WriteLine(item);
            }

            Console.WriteLine("\nLista tartalma");
            foreach (IAlkatresz item in alkatreszek)
            {
                Console.WriteLine("típus: {0}, név: {1}, súly: {2}, ár: {3}", item.Tipus, item.Nev, item.Suly, item.Ar);
            }

            Console.WriteLine("\nvalamelyik elem kompatibilis elemei");
            foreach (Alkatresz item in alkatreszek[0].KompatibilisElektronika)
            {
                Console.WriteLine("elektronika: " + item);
            }
            foreach (Alkatresz item in alkatreszek[0].KompatibilisFekrendszer)
            {
                Console.WriteLine("fék: " + item);
            }
            foreach (Alkatresz item in alkatreszek[0].KompatibilisLegszuro)
            {
                Console.WriteLine("légszűrő: " + item);
            }
            foreach (Alkatresz item in alkatreszek[0].KompatibilisValto)
            {
                Console.WriteLine("váltó: " + item);
            }

            Console.WriteLine("\nKikötés");
            Console.WriteLine(alkatreszKikotes.Nev);

            //alkatreszek[5].Beepit(auto);
            //alkatreszek[1].Beepit(auto);
            //alkatreszek[2].Beepit(auto);
            //alkatreszek[3].Beepit(auto);
            //alkatreszek[4].Beepit(auto);
            //Console.WriteLine("kocsi váltója: " + auto.Valto.Nev);
            //Console.WriteLine("Kocsi féke: " + auto.Fekrendszer.Nev);
            //Console.WriteLine("kocsi légsz: " + auto.Legszuro.Nev);
            //Console.WriteLine("kocsi elektr: " + auto.Elektronika.Nev);

            Console.WriteLine("\nAuto motorja: " + auto.Motor.Nev);

            Console.WriteLine("\nÖsszes kompatibilis elem listája");
            foreach (Alkatresz item in alkatreszek[0].OsszesKompatibilisAlkatresz)
            {
                Console.WriteLine("neve: " + item.Nev + "típusa: " + item.Tipus);
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
            Console.WriteLine("nem talált ilyen névvel alkatreszt: " + nev);
            throw new Exception();
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

        public void Backtrack(Alkatresz alkatresz)
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
                        }
                        if (auto.Valto != null)
                        {
                            Backtrack(auto.Valto);   
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
                        }
                        if(auto.Legszuro != null)
                        {
                            Backtrack(auto.Fekrendszer);
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
                        }
                        if (auto.Elektronika != null)
                        {
                            Backtrack(auto.Elektronika);
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
                        }
                        if (auto.Motor != null)
                        {
                            Backtrack(auto.Motor);
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
                        }
                        if(auto.Legszuro != null)
                        {
                            Backtrack(auto.Legszuro);
                        }
                        break;
                }
            }
            
        }

        /// <summary>
        /// Kikeresei az adott alkatrész istából a legkönyebb alkatrészt
        /// </summary>
        Alkatresz Legkonnyebb(List<Alkatresz> alkatreszek)
        {
            int index = 0;
            int min = int.MaxValue;
            for (int i = 0; i < alkatreszek.Count; i++)
            {
                if (alkatreszek[i].Suly < min)
                {
                    min = alkatreszek[i].Suly;
                    index = i;
                }
            }

            return alkatreszek[index]; 
        }

        /// <summary>
        /// Kikeresi az adott alaktrész listából a legolcsóbb alkatrészt
        /// </summary>
        Alkatresz Legolcsobb(List<Alkatresz> alkatreszek)
        {
            int index = 0;
            int min = int.MaxValue;
            for (int i = 0; i < alkatreszek.Count; i++)
            {
                if (alkatreszek[i].Ar < min)
                {
                    min = alkatreszek[i].Ar;
                    index = i;
                }
            }

            return alkatreszek[index];
        }

        /// <summary>
        /// Megnézi, hogy két alkatrész kompatibilis-e egymással
        /// </summary>
        //bool Kompatibilis(Alkatresz alkatreszMi, Alkatresz alkatereszMivel)
        //{
        //    return alkatereszMivel.KompatibilisElektronika.Contains(alkatreszMi) || alkatereszMivel.KompatibilisFekrendszer.Contains(alkatreszMi) || alkatereszMivel.KompatibilisLegszuro.Contains(alkatreszMi) || alkatereszMivel.KompatibilisMotorok.Contains(alkatreszMi) || alkatereszMivel.KompatibilisValto.Contains(alkatreszMi);
        //}
    }
}