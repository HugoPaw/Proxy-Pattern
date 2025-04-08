using System;

namespace ProxyPattern
{
    // 1. Gemeinsames Interface
    public interface IDrucker
    {
        void Drucken(string text);
    }

    // 2. Der echte Drucker
    public class EchterDrucker : IDrucker
    {
        public void Drucken(string text)
        {
            Console.WriteLine("Drucke: " + text);
        }
    }

    // 3. Der Proxy mit Passwortschutz
    public class DruckerProxy : IDrucker
    {
        private EchterDrucker drucker = new EchterDrucker();
        private string passwort = "geheim";

        public void Drucken(string text)
        {
            Console.Write("Passwort eingeben: ");
            string eingabe = Console.ReadLine();

            if (eingabe == passwort)
            {
                drucker.Drucken(text);
            }
            else
            {
                Console.WriteLine("Falsches Passwort.");
            }
        }
    }

    // 4. Anwendung
    class Program
    {
        static void Main(string[] args)
        {
            IDrucker drucker = new DruckerProxy();

            Console.WriteLine("Dokument wird gesendet...");
            drucker.Drucken("Wichtige Dokumente");

            Console.WriteLine("Programm beendet.");
            Console.ReadLine(); // damit das Fenster offen bleibt
        }
    }
}
