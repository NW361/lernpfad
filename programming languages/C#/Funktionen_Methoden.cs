namespace Funktionen_Methoden.cs
{
        // ============================================================
    //  05 – FUNKTIONEN UND METHODEN IN C#
    //  Lernprogramm für die Ausbildung Fachinformatiker AE
    // ============================================================
    
    using System;
    using System.Collections.Generic;
    
    class Methoden
    {
        // ==========================================================
        // IN C# heißen Funktionen innerhalb einer Klasse "Methoden".
        // Eine Methode:
        //  - hat einen Rückgabetyp (void = kein Rückgabewert)
        //  - hat einen Namen (PascalCase für public, camelCase intern)
        //  - hat eine Parameterliste (kann leer sein)
        //  - hat einen Körper (Codeblock in {})
        // ==========================================================
    
        static void Main()
        {
            Console.WriteLine("=== METHODEN IN C# ===\n");
    
            // ----------------------------------------------------------
            // 1. EINFACHE METHODEN (void = kein Rückgabewert)
            // ----------------------------------------------------------
            BegruesseBenutzer("Anna");
            TrennLinie();
    
            // ----------------------------------------------------------
            // 2. METHODEN MIT RÜCKGABEWERT
            // ----------------------------------------------------------
            int s = Addiere(5, 3);
            Console.WriteLine($"5 + 3 = {s}");
    
            double flaeche = KreisFlaeche(4.0);
            Console.WriteLine($"Kreisfläche r=4: {flaeche:F2}");
    
            // ----------------------------------------------------------
            // 3. MEHRERE PARAMETER / PARAMETER-TYPEN
            // ----------------------------------------------------------
            string satz = BaueSatz("Lernprogramm", "C#", 2025);
            Console.WriteLine(satz);
    
            // ----------------------------------------------------------
            // 4. OPTIONAL / DEFAULT PARAMETER
            // ----------------------------------------------------------
            Begruesse("Max");              // Standardwert "Hallo" wird genutzt
            Begruesse("Max", "Servus");    // eigener Gruß
    
            // ----------------------------------------------------------
            // 5. NAMED ARGUMENTS (beim Aufruf)
            // ----------------------------------------------------------
            Begruesse(gruss: "Moin", name: "Hanna");  // Reihenfolge egal
    
            // ----------------------------------------------------------
            // 6. ÜBERLADUNG (Overloading)
            // ----------------------------------------------------------
            // Gleicher Name, unterschiedliche Parameterlisten
            Console.WriteLine($"\nAddiere(3, 4)     = {Addiere(3, 4)}");
            Console.WriteLine($"Addiere(1.5, 2.5) = {Addiere(1.5, 2.5)}");
            Console.WriteLine($"Addiere(1,2,3)    = {Addiere(1, 2, 3)}");
    
            // ----------------------------------------------------------
            // 7. REF- UND OUT-PARAMETER
            // ----------------------------------------------------------
            // ref: Variable wird per Referenz übergeben (muss initialisiert sein)
            // out: Methode setzt den Wert (muss nicht initialisiert sein)
    
            int wert = 10;
            Verdopple(ref wert);
            Console.WriteLine($"\nNach Verdopple(ref): {wert}");
    
            int min, max;
            MinMax(new int[] { 3, 1, 7, 2, 9 }, out min, out max);
            Console.WriteLine($"Min={min}, Max={max}");
    
            // Inline out-Deklaration (C# 7+)
            if (int.TryParse("123", out int zahl))
                Console.WriteLine($"TryParse: {zahl}");
    
            // ----------------------------------------------------------
            // 8. PARAMS – VARIABLE ANZAHL VON ARGUMENTEN
            // ----------------------------------------------------------
            Console.WriteLine($"\nSumme(1,2,3):     {Summe(1, 2, 3)}");
            Console.WriteLine($"Summe(5,10,15,20):{Summe(5, 10, 15, 20)}");
    
            // ----------------------------------------------------------
            // 9. REKURSION (Methode ruft sich selbst auf)
            // ----------------------------------------------------------
            Console.WriteLine($"\n5! = {Fakultaet(5)}");         // 120
            Console.WriteLine($"Fibonacci(10) = {Fibonacci(10)}"); // 55
    
            // ACHTUNG: Rekursion ohne Abbruchbedingung → StackOverflowException!
    
            // ----------------------------------------------------------
            // 10. LOKALE FUNKTIONEN (C# 7+)
            // ----------------------------------------------------------
            // Methode definiert innerhalb einer anderen Methode
            double Hypotenuse(double a, double b) => Math.Sqrt(a * a + b * b);
    
            Console.WriteLine($"\nHypotenuse(3,4) = {Hypotenuse(3, 4)}");
    
            // ----------------------------------------------------------
            // 11. EXPRESSION-BODIED METHODS (C# 6+)
            // ----------------------------------------------------------
            // Kurze Einzeiler: Methode => Ausdruck;  (kein return nötig)
            Console.WriteLine($"Quadrat(7) = {Quadrat(7)}");
            Console.WriteLine($"Gruss('Lea') = {Gruss("Lea")}");
    
            // ----------------------------------------------------------
            // 12. LAMBDA-AUSDRÜCKE (anonyme Funktionen)
            // ----------------------------------------------------------
            Func<int, int, int> mult = (a, b) => a * b;
            Action<string>      log  = msg   => Console.WriteLine($"[LOG] {msg}");
    
            Console.WriteLine($"\nLambda mult(4,5) = {mult(4, 5)}");
            log("Lambda-Demo");
    
            // ----------------------------------------------------------
            // 13. EXTENSION METHODS (Erweiterungsmethoden)
            // ----------------------------------------------------------
            // Fügen bestehenden Typen neue Methoden hinzu, ohne sie zu ändern.
            // Definiert in statischer Klasse mit 'this' vor erstem Parameter.
            string text = "hallo welt";
            Console.WriteLine($"\nGrossAnfang: {text.GrossAnfangsbuchstabe()}");
            Console.WriteLine($"IstPalindrom('racecar'): {"racecar".IstPalindrom()}");
            Console.WriteLine($"IstPalindrom('hallo'):   {"hallo".IstPalindrom()}");
    
            // ----------------------------------------------------------
            // 14. STATIC VS. INSTANZ-METHODEN
            // ----------------------------------------------------------
            // static: gehört zur Klasse, kein Objekt nötig → Math.Sqrt(x)
            // Instanz: gehört zu einem Objekt  → "text".ToUpper()
    
            Console.WriteLine($"\nMath.Abs(-5) = {Math.Abs(-5)}  (static)");
            Console.WriteLine($"\"hallo\".ToUpper() = {"hallo".ToUpper()}  (Instanz)");
    
            // ----------------------------------------------------------
            // 15. ZUSAMMENFASSUNG: GUTE METHODEN-DESIGN-REGELN
            // ----------------------------------------------------------
            // • Single Responsibility: eine Methode, eine Aufgabe
            // • Sprechende Namen: BerechneRabatt() statt Calc()
            // • Kurz halten: > 30 Zeilen → Refactoring erwägen
            // • Parameter < 5 (sonst Objekt übergeben)
            // • Kein Seiteneffekt, wenn Rückgabewert erwartet wird
    
            Console.WriteLine("\n=== ENDE: Methoden ===");
        }
    
        // ------ Methoden-Definitionen --------------------------------
    
        // 1. void, ein Parameter
        static void BegruesseBenutzer(string name)
        {
            Console.WriteLine($"Hallo, {name}!");
        }
    
        static void TrennLinie() => Console.WriteLine(new string('-', 40));
    
        // 2. Rückgabewert
        static int Addiere(int a, int b) => a + b;
    
        static double KreisFlaeche(double radius) => Math.PI * radius * radius;
    
        // 3. Mehrere Parameter
        static string BaueSatz(string thema, string sprache, int jahr)
        {
            return $"Ich lerne {thema} in {sprache} seit {jahr}.";
        }
    
        // 4. Optional / Default
        static void Begruesse(string name, string gruss = "Hallo")
        {
            Console.WriteLine($"{gruss}, {name}!");
        }
    
        // 6. Überladungen
        static double Addiere(double a, double b)    => a + b;
        static int    Addiere(int a, int b, int c)   => a + b + c;
    
        // 7. ref + out
        static void Verdopple(ref int x) => x *= 2;
    
        static void MinMax(int[] arr, out int min, out int max)
        {
            min = arr[0];
            max = arr[0];
            foreach (int v in arr)
            {
                if (v < min) min = v;
                if (v > max) max = v;
            }
        }
    
        // 8. params
        static int Summe(params int[] werte)
        {
            int s = 0;
            foreach (int v in werte) s += v;
            return s;
        }
    
        // 9. Rekursion
        static long Fakultaet(int n)
        {
            if (n <= 1) return 1;          // Abbruchbedingung!
            return n * Fakultaet(n - 1);
        }
    
        static int Fibonacci(int n)
        {
            if (n <= 1) return n;
            return Fibonacci(n - 1) + Fibonacci(n - 2);
        }
    
        // 11. Expression-bodied
        static int    Quadrat(int n) => n * n;
        static string Gruss(string name) => $"Willkommen, {name}!";
    }
    
    // ------ Extension Methods (eigene statische Hilfsklasse) ------
    
    static class StringExtensions
    {
        // 'this string s' macht es zur Extension Method für string
        public static string GrossAnfangsbuchstabe(this string s)
        {
            if (string.IsNullOrEmpty(s)) return s;
            return char.ToUpper(s[0]) + s[1..];
        }
    
        public static bool IstPalindrom(this string s)
        {
            string r = new string(s.ToCharArray());
            char[] chars = r.ToCharArray();
            Array.Reverse(chars);
            return r == new string(chars);
        }
    }
}