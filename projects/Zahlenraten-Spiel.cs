using System;

namespace ZahlenRaten
{
    class Program
    {
        static void Main(string[] args)
        {
            // Begrüßung und kurze Erklärung für den Spieler
            Console.WriteLine("=== Zahlen Raten ===");
            Console.WriteLine("Ich denke mir eine Zahl zwischen 1 und 100. Kannst du sie erraten?\n");

            // Zufallszahl generieren — Next(1, 101) weil die obere Grenze exklusiv ist
            Random rng = new Random();
            int geheimeZahl = rng.Next(1, 101);

            // Spielvariablen: Zähler für Versuche, Maximum und ob gewonnen wurde
            int versuche = 0;
            int maxVersuche = 7;
            bool gewonnen = false;

            // Hauptschleife — läuft solange der Spieler noch Versuche hat
            while (versuche < maxVersuche)
            {
                // Verbleibende Versuche anzeigen
                int uebrig = maxVersuche - versuche;
                Console.Write($"Dein Tipp ({uebrig} Versuch{(uebrig == 1 ? "" : "e")} übrig): ");

                string eingabe = Console.ReadLine();

                // Eingabe prüfen — TryParse gibt false zurück wenn kein gültiger int eingegeben wurde
                if (!int.TryParse(eingabe, out int tipp))
                {
                    Console.WriteLine("Bitte gib eine gültige Zahl ein!\n");
                    continue; // Versuch nicht zählen, nochmal fragen
                }

                // Prüfen ob die Zahl im erlaubten Bereich liegt
                if (tipp < 1 || tipp > 100)
                {
                    Console.WriteLine("Die Zahl muss zwischen 1 und 100 liegen.\n");
                    continue;
                }

                // Erst hier zählen — nur bei gültiger Eingabe
                versuche++;

                // Treffer prüfen
                if (tipp == geheimeZahl)
                {
                    gewonnen = true;
                    break; // Schleife sofort verlassen
                }
                else if (tipp < geheimeZahl)
                {
                    // Feedback je nach Abstand zur gesuchten Zahl (kalt / warm / heiß)
                    if (geheimeZahl - tipp > 25)
                        Console.WriteLine("Zu niedrig — und zwar deutlich!\n");
                    else if (geheimeZahl - tipp > 10)
                        Console.WriteLine("Zu niedrig!\n");
                    else
                        Console.WriteLine("Zu niedrig, aber schon warm!\n");
                }
                else
                {
                    if (tipp - geheimeZahl > 25)
                        Console.WriteLine("Zu hoch — und zwar deutlich!\n");
                    else if (tipp - geheimeZahl > 10)
                        Console.WriteLine("Zu hoch!\n");
                    else
                        Console.WriteLine("Zu hoch, aber schon warm!\n");
                }
            }

            // Ergebnis ausgeben — gewonnen oder verloren
            if (gewonnen)
            {
                Console.WriteLine($"Richtig! Du hast die {geheimeZahl} in {versuche} Versuch{(versuche == 1 ? "" : "en")} erraten!");

                // Bewertung je nach Anzahl der benötigten Versuche
                if (versuche <= 3)
                    Console.WriteLine("Wahnsinn, das war schnell!");
                else if (versuche <= 5)
                    Console.WriteLine("Gut gemacht!");
                else
                    Console.WriteLine("Hat etwas gedauert, aber du hast es geschafft.");
            }
            else
            {
                // Versuche aufgebraucht — Auflösung
                Console.WriteLine($"Leider keine Versuche mehr übrig. Die Zahl war {geheimeZahl}.");
                Console.WriteLine("Vielleicht nächstes Mal!");
            }

            // Spieler fragen ob er nochmal spielen will
            Console.WriteLine("\nNochmal spielen? (j/n)");
            string antwort = Console.ReadLine();

            if (antwort?.ToLower() == "j")
            {
                Console.WriteLine();
                Main(args); // einfach nochmal starten
            }
            else
            {
                Console.WriteLine("Tschüss!");
            }
        }
    }
}
