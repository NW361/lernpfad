namespace Schleifen.cs
{
    // ============================================================
    //  03 – SCHLEIFEN IN C#
    //  Lernprogramm für die Ausbildung Fachinformatiker AE
    // ============================================================
    
    using System;
    using System.Collections.Generic;
    
    class Schleifen
    {
        static void Main()
        {
            Console.WriteLine("=== SCHLEIFEN IN C# ===\n");
    
            // ----------------------------------------------------------
            // WOZU SCHLEIFEN?
            // ----------------------------------------------------------
            // Schleifen wiederholen einen Codeblock, solange eine
            // Bedingung erfüllt ist (oder für jedes Element einer Sammlung).
            // Ohne Schleifen müsste man Code manuell kopieren → fehleranfällig.
    
            // ----------------------------------------------------------
            // 1. FOR-SCHLEIFE  (wenn Anzahl der Durchläufe bekannt)
            // ----------------------------------------------------------
            // Syntax: for (Initialisierung; Bedingung; Inkrement)
            Console.WriteLine("--- for-Schleife ---");
            for (int i = 0; i < 5; i++)
                {
                    Console.Write($"{i} ");
                }
            Console.WriteLine();
    
            // Rückwärts zählen
            Console.Write("Rückwärts: ");
            for (int i = 5; i > 0; i--)
                {
                    Console.Write($"{i} ");
                }
            Console.WriteLine();
    
            // Schrittweite 2
            Console.Write("Nur gerade: ");
            for (int i = 0; i <= 10; i += 2)
                {
                    Console.Write($"{i} ");
                }
            Console.WriteLine();
    
            // ----------------------------------------------------------
            // 2. WHILE-SCHLEIFE  (Bedingung wird VOR jedem Durchlauf geprüft)
            // ----------------------------------------------------------
            // Ideal wenn die Anzahl der Durchläufe unbekannt ist.
            Console.WriteLine("\n--- while-Schleife ---");
            int zahl = 1;
            while (zahl <= 32)
                {
                    Console.Write($"{zahl} ");
                    zahl *= 2;   // verdoppeln
                }
            Console.WriteLine();
    
            // Typisches Muster: Eingabe solange wiederholen bis gültig
            // (hier simuliert, um kein Console.ReadLine() nötig zu haben)
            string eingabe = "";
            int    versuch = 0;
            string[] simulierteEingaben = { "abc", "x", "42" };
    
            while (eingabe != "42")
                {
                    eingabe = simulierteEingaben[versuch++];
                    Console.WriteLine($"Eingabe: '{eingabe}' – {(eingabe == "42" ? "OK!" : "Nochmal...")}");
                }
    
            // ----------------------------------------------------------
            // 3. DO-WHILE-SCHLEIFE  (Bedingung wird NACH jedem Durchlauf geprüft)
            // ----------------------------------------------------------
            // Der Block wird MINDESTENS EINMAL ausgeführt.
            Console.WriteLine("\n--- do-while-Schleife ---");
            int n = 10;
            do
                {
                    Console.Write($"{n} ");
                    n += 10;
                } while (n <= 50);
            Console.WriteLine();
    
            // Unterschied zu while: wenn Bedingung von Anfang an false →
            // while:    0 Durchläufe
            // do-while: 1 Durchlauf
            int x = 100;
            do
            {
                Console.WriteLine($"do-while läuft trotzdem einmal (x={x}).");
            } while (x < 10);
    
            // ----------------------------------------------------------
            // 4. FOREACH-SCHLEIFE  (über jedes Element einer Sammlung)
            // ----------------------------------------------------------
            Console.WriteLine("\n--- foreach-Schleife ---");
    
            // Array
            string[] wochentage = { "Mo", "Di", "Mi", "Do", "Fr" };
            foreach (string tag in wochentage)
                {
                    Console.Write($"{tag} ");
                }
            Console.WriteLine();
    
            // List<T>
            var zahlen = new List<int> { 3, 7, 2, 9, 4 };
            int summe = 0;
            foreach (int z in zahlen)
                {
                    summe += z;
                }
            Console.WriteLine($"Summe: {summe}");
    
            // foreach mit Index → eleganter mit for oder LINQ
            for (int i = 0; i < wochentage.Length; i++)
                {
                    Console.WriteLine($"  [{i}] = {wochentage[i]}");
                }
    
            // ----------------------------------------------------------
            // 5. BREAK  (Schleife sofort verlassen)
            // ----------------------------------------------------------
            Console.WriteLine("\n--- break ---");
            for (int i = 0; i < 10; i++)
                {
                    if (i == 5) break;
                    Console.Write($"{i} ");
                }
            Console.WriteLine("(nach break)");
    
            // ----------------------------------------------------------
            // 6. CONTINUE  (aktuellen Durchlauf überspringen)
            // ----------------------------------------------------------
            Console.WriteLine("\n--- continue ---");
            for (int i = 0; i < 10; i++)
                {
                    if (i % 2 == 0) continue;  // gerade überspringen
                    Console.Write($"{i} ");
                }
            Console.WriteLine("(nur ungerade)");
    
            // ----------------------------------------------------------
            // 7. VERSCHACHTELTE SCHLEIFEN
            // ----------------------------------------------------------
            Console.WriteLine("\n--- Verschachtelt: Multiplikationstabelle ---");
            for (int zeile = 1; zeile <= 4; zeile++)
                {
                    for (int spalte = 1; spalte <= 4; spalte++)
                    {
                        Console.Write($"{zeile * spalte,4}"); // rechtsbündig, 4 Zeichen
                    }
                    Console.WriteLine();
                }
    
            // break in verschachtelten Schleifen verlässt nur die INNERE Schleife!
            Console.WriteLine("\n--- break verlässt nur innere Schleife ---");
            for (int i = 0; i < 3; i++)
                {
                    for (int j = 0; j < 3; j++)
                    {
                        if (j == 1) break;         // bricht innere ab
                        Console.Write($"({i},{j}) ");
                    }
                }
            Console.WriteLine();
    
            // ----------------------------------------------------------
            // 8. ENDLOSSCHLEIFE  (bewusst einsetzen, mit break beenden)
            // ----------------------------------------------------------
            Console.WriteLine("\n--- Endlosschleife mit break ---");
            int counter = 0;
            while (true)
                {
                    counter++;
                    if (counter >= 5) break;
                }
            Console.WriteLine($"counter nach Endlosschleife: {counter}");
    
            // Variante mit for:
            // for (;;) { ... break; }
    
            // ----------------------------------------------------------
            // 9. HÄUFIGE FEHLER
            // ----------------------------------------------------------
    
            // a) Off-by-one: < vs <=
            Console.WriteLine("\n--- Off-by-one ---");
            Console.Write("< 5:  "); for (int i = 0; i <  5; i++) Console.Write($"{i} "); Console.WriteLine();
            Console.Write("<= 5: "); for (int i = 0; i <= 5; i++) Console.Write($"{i} "); Console.WriteLine();
    
            // b) Schleifenvariable aus Scope heraus
            for (int i = 0; i < 3; i++) { /* i nur hier sichtbar */ }
            // Console.WriteLine(i); // Compilerfehler!
    
            // c) Versehentliche Endlosschleife (Kommentar-Beispiel, nicht ausführen)
            // int k = 0;
            // while (k < 10) { Console.WriteLine(k); }  // k wird nie inkrementiert!
    
            // ----------------------------------------------------------
            // 10. LINQ (kompakte Alternative zu foreach-Schleifen)
            // ----------------------------------------------------------
            // using System.Linq; (hier implizit via global usings)
            Console.WriteLine("\n--- LINQ als Alternative ---");
            var nums = new List<int> { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };
    
            // Alle geraden Zahlen verdoppeln
            foreach (var v in nums)
                {
                    if (v % 2 == 0) Console.Write($"{v * 2} ");
                }
            Console.WriteLine("(foreach-Version)");
    
            // LINQ: dasselbe kompakt
            // var result = nums.Where(v => v % 2 == 0).Select(v => v * 2);
            // → wird in späteren Lerneinheiten vertieft
    
            Console.WriteLine("\n=== ENDE: Schleifen ===");
        }
    }
}