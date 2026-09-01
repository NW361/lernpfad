namespace Bedingungen.cs
{
    // ============================================================
    //  02 – IF / ELSE BEDINGUNGEN IN C#
    //  Lernprogramm für die Ausbildung Fachinformatiker AE
    // ============================================================
 
    using System;
    
    class Bedingungen
    {
        static void Main()
        {
            Console.WriteLine("=== IF / ELSE BEDINGUNGEN IN C# ===\n");
    
            // ----------------------------------------------------------
            // 1. GRUNDPRINZIP
            // ----------------------------------------------------------
            // Eine Bedingung (boolean-Ausdruck) ist entweder true oder false.
            // Danach wird entschieden, welcher Codeblock ausgeführt wird.
    
            int alter = 20;
    
            if (alter >= 18)
            {
                Console.WriteLine("Volljährig.");
            }
    
            // ----------------------------------------------------------
            // 2. IF / ELSE
            // ----------------------------------------------------------
            if (alter >= 18)
            {
                Console.WriteLine("Darf wählen.");
            }
            else
            {
                Console.WriteLine("Darf nicht wählen.");
            }
    
            // ----------------------------------------------------------
            // 3. IF / ELSE IF / ELSE
            // ----------------------------------------------------------
            int punkte = 75;
    
            if (punkte >= 90)
            {
                Console.WriteLine("\nNote: Sehr gut");
            }
            else if (punkte >= 75)
            {
                Console.WriteLine("\nNote: Gut");
            }
            else if (punkte >= 60)
            {
                Console.WriteLine("\nNote: Befriedigend");
            }
            else if (punkte >= 50)
            {
                Console.WriteLine("\nNote: Ausreichend");
            }
            else
            {
                Console.WriteLine("\nNote: Nicht bestanden");
            }
    
            // ----------------------------------------------------------
            // 4. VERGLEICHSOPERATOREN
            // ----------------------------------------------------------
            // ==   gleich
            // !=   ungleich
            // >    größer als
            // <    kleiner als
            // >=   größer oder gleich
            // <=   kleiner oder gleich
    
            int a = 5, b = 10;
            Console.WriteLine($"\n--- Vergleiche ({a} und {b}) ---");
            Console.WriteLine($"a == b : {a == b}");
            Console.WriteLine($"a != b : {a != b}");
            Console.WriteLine($"a >  b : {a > b}");
            Console.WriteLine($"a <  b : {a < b}");
            Console.WriteLine($"a >= b : {a >= b}");
            Console.WriteLine($"a <= b : {a <= b}");
    
            // ----------------------------------------------------------
            // 5. LOGISCHE OPERATOREN
            // ----------------------------------------------------------
            // &&   UND  (beide Bedingungen müssen true sein)
            // ||   ODER (mindestens eine Bedingung muss true sein)
            // !    NICHT (negiert den boolean-Wert)
    
            bool hatFuehrerschein = true;
            bool hatAuto          = false;
    
            Console.WriteLine("\n--- Logische Operatoren ---");
            Console.WriteLine($"Führerschein UND Auto: {hatFuehrerschein && hatAuto}");
            Console.WriteLine($"Führerschein ODER Auto:{hatFuehrerschein || hatAuto}");
            Console.WriteLine($"NICHT Führerschein:    {!hatFuehrerschein}");
    
            // Kurzschlussauswertung (Short-Circuit):
            // Bei &&: wenn links false → rechts wird NICHT ausgewertet
            // Bei ||: wenn links true  → rechts wird NICHT ausgewertet
            string s = null;
            if (s != null && s.Length > 0) // s.Length wird nie aufgerufen wenn s null ist
            {
                Console.WriteLine("String hat Inhalt.");
            }
            else
            {
                Console.WriteLine("String ist null oder leer (sicher geprüft).");
            }
    
            // ----------------------------------------------------------
            // 6. SWITCH – AUSWAHL UNTER VIELEN WERTEN
            // ----------------------------------------------------------
            int tag = 3;
            Console.WriteLine("\n--- switch (klassisch) ---");
    
            switch (tag)
            {
                case 1:
                    Console.WriteLine("Montag");
                    break;
                case 2:
                    Console.WriteLine("Dienstag");
                    break;
                case 3:
                    Console.WriteLine("Mittwoch");
                    break;
                case 4:
                case 5:                        // Fallthrough: 4 UND 5 → gleiche Ausgabe
                    Console.WriteLine("Donnerstag oder Freitag");
                    break;
                default:
                    Console.WriteLine("Wochenende");
                    break;
            }
    
            // ----------------------------------------------------------
            // 7. SWITCH EXPRESSION (C# 8+) – moderner, kompakter
            // ----------------------------------------------------------
            string tagName = tag switch
            {
                1 => "Montag",
                2 => "Dienstag",
                3 => "Mittwoch",
                4 => "Donnerstag",
                5 => "Freitag",
                _ => "Wochenende"   // _ = default
            };
            Console.WriteLine($"\nswitch expression → Tag {tag}: {tagName}");
    
            // ----------------------------------------------------------
            // 8. TERNÄRER OPERATOR  (Bedingung ? wennTrue : wennFalse)
            // ----------------------------------------------------------
            int temperatur = 22;
            string wetter = temperatur >= 20 ? "warm" : "kalt";
            Console.WriteLine($"\nTernär: {temperatur}°C ist {wetter}.");
    
            // Verschachtelter ternärer (lesbar nur bei 2–3 Stufen!)
            string ampel = "Gelb";
            string aktion = ampel == "Grün"  ? "Fahren" :
                            ampel == "Gelb"  ? "Bremsen" :
                                            "Stopp";
            Console.WriteLine($"Ampel {ampel} → {aktion}");
    
            // ----------------------------------------------------------
            // 9. NULL-PRÜFUNGEN (C#-typisch)
            // ----------------------------------------------------------
            string benutzername = null;
    
            // a) klassisch
            if (benutzername == null)
                Console.WriteLine("\nbenutzername ist null (klassisch).");
    
            // b) is null / is not null (empfohlen ab C# 7)
            if (benutzername is null)
                Console.WriteLine("benutzername ist null (is null).");
    
            // c) Null-Coalescing
            string anzeige = benutzername ?? "Gast";
            Console.WriteLine($"Anzeige: {anzeige}");
    
            // d) Null-Conditional-Operator ?.
            int? laenge = benutzername?.Length;  // null statt Exception
            Console.WriteLine($"Länge: {laenge}");
    
            // ----------------------------------------------------------
            // 10. PATTERN MATCHING (C# 7+)
            // ----------------------------------------------------------
            object objekt = 42;
            Console.WriteLine("\n--- Pattern Matching ---");
    
            if (objekt is int zahl)
            {
                Console.WriteLine($"objekt ist int: {zahl}");
            }
    
            // switch mit Patterns (C# 9+)
            object wert = 3.14;
            string beschreibung = wert switch
            {
                int    n when n < 0 => "negative Ganzzahl",
                int    n            => $"positive Ganzzahl: {n}",
                double d            => $"Kommazahl: {d}",
                string str          => $"Text: {str}",
                null                => "null",
                _                   => "unbekannt"
            };
            Console.WriteLine($"Pattern Match: {beschreibung}");
    
            // ----------------------------------------------------------
            // 11. HÄUFIGE FEHLER
            // ----------------------------------------------------------
            // = (Zuweisung) vs == (Vergleich)
            int x = 5;
            // if (x = 5)   // COMPILERFEHLER in C# – in C++ oft stiller Bug!
            if (x == 5)
                Console.WriteLine("\nx ist 5 (korrekter Vergleich mit ==).");
    
            // Ganzzahldivision als Bedingung
            int teiler = 4;
            if (teiler % 2 == 0)
                Console.WriteLine($"{teiler} ist gerade.");
    
            Console.WriteLine("\n=== ENDE: Bedingungen ===");
        }
    }
}