using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

class Kundendaten
{
    private string Name;
    private int Kundennummer;

    public Kundendaten(string kunde, int nummer)
    {
        if (kunde == null || kunde.Length < 1)
            throw new Exception("Kein Name");
        if (nummer < 0)
            throw new Exception("Keine gueltige Kundennummer");
        Name = kunde;
        Kundennummer = nummer;
    }
    public string GetName() => Name;
    public int GetKundennummer() { return Kundennummer; }

    public void SetKundennummer(int neueNummer)
    {
        if (neueNummer < 0)
            throw new Exception("Negative Nummer");
        Kundennummer = neueNummer;
    }
}
namespace Task2
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                Kundendaten eins = new Kundendaten("Mustermann Max", 1);
                Console.WriteLine($"Kunde: {eins.GetKundennummer()} { eins.GetName()} ");
                eins.SetKundennummer(5);
                Console.WriteLine($"Kunde: {eins.GetKundennummer()} { eins.GetName()} ");
            }
            catch (Exception e)
            {
                Console.WriteLine($"Fehler ({e.Message})");
            }
        }
    }
}
