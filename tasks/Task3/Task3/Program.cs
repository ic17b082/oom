using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task3
{
    interface IPerson
    {
        void Print();
    }

    class Kundendaten : IPerson
    {
        public void Print()
        {
            Console.WriteLine($"\nKundendaten: {KName} \nAdresse: {KAdresse} \nKundennummer: {Kundennummer}");
        }
        private string  KName;
        private string  KAdresse;
        private int     Kundennummer;

        public Kundendaten(string kunde,string kundenadresse, int nummer)
        {
            if (kunde == null || kunde.Length < 1)
                throw new Exception("Kein Name");
            if (kundenadresse == null || kundenadresse.Length < 1)
                throw new Exception("Kein Name");
            if (nummer < 0)
                throw new Exception("Keine gueltige Kundennummer");

            KName           =   kunde;
            KAdresse        =   kundenadresse;
            Kundennummer    =   nummer;
        }
        public string GetKName() => KName;
        public string GetKAdresse() => KAdresse;
        public int GetKundennummer() { return Kundennummer; }

        public void SetKundennummer(int neueNummer)
        {
            if (neueNummer < 0)
                throw new Exception("Negative Nummer");
            Kundennummer = neueNummer;
        }   
    }

    class Mitarbeiter : IPerson
    {
        public void Print()
        {
            Console.WriteLine($"\nMitarbeiter: {MName} \nAdresse: {MAdresse} \nTaetigkeit: {Taetigkeit} \nDienstnumer: {Dienstnummer}");
        }
        private string  MName;
        private string  MAdresse;
        private string  Taetigkeit;
        private int     Dienstnummer;

        public Mitarbeiter(string arbeiter,string madresse, string anstellung, int id)
        {
            if (arbeiter == null || arbeiter.Length < 1)
                throw new Exception("Kein Name");
            if (madresse == null || madresse.Length < 1)
                throw new Exception("Keine Adresse");
            if (anstellung == null || anstellung.Length < 1)
                throw new Exception("Keine gueltige Anstellung");
            if (id < 0)
                throw new Exception("Keine gueltige Bedienstetennummer");

            MName           =   arbeiter;
            MAdresse        =   madresse;
            Taetigkeit      =   anstellung;
            Dienstnummer    =   id;
        }
        public string GetMName()        => MName;
        public string GetMAdresse()     => MAdresse;
        public string GetTaetigkeit()   => Taetigkeit;
        public int GetDienstnummer()    { return Dienstnummer; }
    }

    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                Kundendaten ersterk = new Kundendaten("Max Mustermann", "Musterweg 15", 1);
               // Console.WriteLine($"Kunde: {ersterk.GetKName()}\nAdresse: {ersterk.GetKAdresse()}\nKundennummer: {ersterk.GetKundennummer()} ");


                Mitarbeiter ersterm = new Mitarbeiter("Karl Klumpat", "Forstgasse 27", "Elektriker", 1);
               // Console.WriteLine($"\nMitarbeiter: {ersterm.GetMName()}\nAdresse: {ersterm.GetMAdresse()}\nTaetigkeit: {ersterm.GetTaetigkeit()}\nKundennummer: {ersterm.GetDienstnummer()} ");



                IPerson[] PersonArray = {ersterk,ersterm, new Kundendaten("Ilse Ilsensberger", "Ilsenweg 30", 2), new Mitarbeiter("Koalrina Karlson", "Karlsonweg 12", "EDV-Technikerin", 2) };

                foreach (IPerson Person in PersonArray)
                {
                    Person.Print();
                }
            }
            catch (Exception e)
            {
                Console.WriteLine($"Fehler ({e.Message})");
            }          
        }
    }
}