using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Globalization;
using Newtonsoft.Json;
using System.IO;

namespace Task4
{
    interface IPerson
    {
        void Print();
    }

    class Kundendaten : IPerson
    {
        public string KName;
        public string KAdresse;
        public int Kundennummer;

        public Kundendaten(string kunde, string kundenadresse, int nummer)
        {
            if (string.IsNullOrWhiteSpace(kunde))
                throw new ArgumentException("Kein Name", nameof(kunde));
            if (string.IsNullOrWhiteSpace(kundenadresse))
                throw new ArgumentException("Kein Name", nameof(kundenadresse));
            if (nummer < 0)
                throw new ArgumentException("Keine gueltige Kundennummer", nameof(nummer));

            KName = kunde;
            KAdresse = kundenadresse;
            neueNummer(nummer);
        }

        public string GetKName => KName;
        public string GetKAdresse => KAdresse;
        public int GetKundennummer => Kundennummer;

        public void neueNummer(int nummer)
        {
            if (nummer < 0)
                throw new ArgumentException("Negative Nummer", nameof(nummer));
            Kundennummer = nummer;
        }

        public void Print()
        {
            Console.WriteLine($"\nKundendaten: {GetKName} \nAdresse: {GetKAdresse} \nKundennummer: {GetKundennummer}");
        }
    }

    class Mitarbeiter : IPerson
    {
       
        public string MName;
        public string MAdresse;
        public string Taetigkeit;
        public int Dienstnummer;

        public Mitarbeiter(string arbeiter, string madresse, string anstellung, int id)
        {
            if (string.IsNullOrWhiteSpace(arbeiter))
                throw new ArgumentException("Kein Name", nameof(arbeiter));
            if (string.IsNullOrWhiteSpace(madresse))
                throw new ArgumentException("Keine Adresse", nameof(madresse));
            if (string.IsNullOrWhiteSpace(anstellung))
                throw new ArgumentException("Keine gueltige Anstellung", nameof(anstellung));
            if (id < 0)
                throw new ArgumentException("Keine gueltige Bedienstetennummer", nameof(id));

            MName = arbeiter;
            MAdresse = madresse;
            Taetigkeit = anstellung;
            Dienstnummer = id;
        }
        public string GetMName => MName;
        public string GetMAdresse => MAdresse;
        public string GetTaetigkeit => Taetigkeit;
        public int GetDienstnummer => Dienstnummer;

        public void Print()
        {
            Console.WriteLine($"\nMitarbeiter: {GetMName} \nAdresse: {GetMAdresse} \nTaetigkeit: {GetTaetigkeit} \nDienstnumer: {GetDienstnummer}");
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                Kundendaten ersterk = new Kundendaten("Max Mustermann", "Musterweg 15", 1);
                ersterk.Print();
                ersterk.neueNummer(2);
                ersterk.Print();
                Kundendaten zweiterk = new Kundendaten("Ludwig Leiner", "Kikagasse 68", 2);
                Mitarbeiter ersterm = new Mitarbeiter("Karl Klumpat", "Forstgasse 27", "Elektriker", 1);
                Mitarbeiter zweiterm = new Mitarbeiter("Toni Toner", "Druckstrasse 87", "Assistent", 2);

                IPerson[] PersonArray = { ersterk,zweiterk, ersterm, zweiterm, new Kundendaten("Ilse Ilsensberger", "Ilsenweg 30", 3), new Mitarbeiter("Koalrina Karlson", "Karlsonweg 12", "EDV-Technikerin", 3) };

                foreach (IPerson Person in PersonArray)
                {
                    Person.Print();
                }

                var jsonsettings = new JsonSerializerSettings() { Formatting = Formatting.Indented, TypeNameHandling = TypeNameHandling.Auto };
                var json = JsonConvert.SerializeObject(PersonArray, jsonsettings);
                Console.WriteLine(json);

                File.WriteAllText(@"Person.json", json);
                string content = File.ReadAllText(@"Person.json");

                var itemsfromjson = JsonConvert.DeserializeObject<IPerson[]>(content, jsonsettings);
                foreach (var Actuator in itemsfromjson)
                {
                    Actuator.Print();
                }
            }
            catch (Exception error)
            {
                Console.WriteLine($"Error ({error.Message})");
            }
        }
    }
}