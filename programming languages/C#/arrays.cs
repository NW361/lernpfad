namespace arrays.cs
{
    // ============================================================
    //  04 – ARRAYS IN C#
    //  Lernprogramm für die Ausbildung Fachinformatiker AE
    // ============================================================
    
    using System;
    using System.Linq; // für LINQ-Erweiterungen
    
    class Arrays
    {
        static void Main()
        {
            Console.WriteLine("=== ARRAYS IN C# ===\n");
    
            // ----------------------------------------------------------
            // WAS IST EIN ARRAY?
            // ----------------------------------------------------------
            // Ein Array ist eine geordnete Sammlung von Elementen
            // des GLEICHEN Datentyps mit FESTER Größe.
            // Alle Elemente liegen hintereinander im Speicher.
            // Zugriff über Index (0-basiert in C# / den meisten Sprachen).
    
            // ----------------------------------------------------------
            // 1. DEKLARATION UND INITIALISIERUNG
            // ----------------------------------------------------------
    
            // a) Deklarieren + Größe festlegen (Standardwerte: 0, false, null)
            int[] noten = new int[5];       // 5 Elemente, alle = 0
            noten[0] = 2;
            noten[1] = 3;
            noten[2] = 1;
            noten[3] = 4;
            noten[4] = 2;
    
            // b) Array-Initialisierer (Größe wird automatisch ermittelt)
            string[] staedte = { "Berlin", "Hamburg", "München", "Köln" };
    
            // c) Explizit mit new und Initialisierer
            double[] preise = new double[] { 9.99, 14.50, 3.99, 24.00 };
    
            // d) var
            var farben = new string[] { "Rot", "Grün", "Blau" };
    
            Console.WriteLine("--- Initialisierung ---");
            Console.WriteLine($"noten[0] = {noten[0]}");
            Console.WriteLine($"staedte Länge: {staedte.Length}");
            Console.WriteLine($"preise[2] = {preise[2]}");
    
            // ----------------------------------------------------------
            // 2. ZUGRIFF UND ITERATION
            // ----------------------------------------------------------
            Console.WriteLine("\n--- Zugriff per Index ---");
            Console.WriteLine($"Erste Stadt:  {staedte[0]}");
            Console.WriteLine($"Letzte Stadt: {staedte[staedte.Length - 1]}");  // klassisch
            Console.WriteLine($"Letzte Stadt: {staedte[^1]}");                  // C# 8+ Index-from-end
    
            Console.WriteLine("\n--- foreach ---");
            foreach (string stadt in staedte)
                Console.Write($"{stadt}  ");
            Console.WriteLine();
    
            Console.WriteLine("\n--- for mit Index ---");
            for (int i = 0; i < noten.Length; i++)
                Console.Write($"noten[{i}]={noten[i]}  ");
            Console.WriteLine();
    
            // ----------------------------------------------------------
            // 3. WICHTIGE ARRAY-EIGENSCHAFTEN UND -METHODEN
            // ----------------------------------------------------------
            Console.WriteLine("\n--- Array-Methoden ---");
    
            // Länge
            Console.WriteLine($"Länge: {noten.Length}");
    
            // Sortieren (in-place, verändert das Original!)
            int[] kopieFuerSort = (int[])noten.Clone();
            Array.Sort(kopieFuerSort);
            Console.Write("Sortiert:    ");
            foreach (int n in kopieFuerSort) Console.Write($"{n} ");
            Console.WriteLine();
    
            // Umkehren
            Array.Reverse(kopieFuerSort);
            Console.Write("Umgekehrt:   ");
            foreach (int n in kopieFuerSort) Console.Write($"{n} ");
            Console.WriteLine();
    
            // Suchen (Array muss sortiert sein für BinarySearch!)
            int[] sortiert = { 1, 2, 2, 3, 4 };
            int index = Array.BinarySearch(sortiert, 3);
            Console.WriteLine($"BinarySearch(3): Index = {index}");
    
            // Füllen
            int[] nullen = new int[5];
            Array.Fill(nullen, 7);
            Console.Write("Fill(7):     ");
            foreach (int n in nullen) Console.Write($"{n} ");
            Console.WriteLine();
    
            // Kopieren
            int[] quelle      = { 10, 20, 30, 40, 50 };
            int[] ziel        = new int[5];
            Array.Copy(quelle, ziel, quelle.Length);
            Console.Write("Kopie:       ");
            foreach (int n in ziel) Console.Write($"{n} ");
            Console.WriteLine();
    
            // Clone (oberflächliche Kopie)
            int[] klon = (int[])quelle.Clone();
            klon[0] = 999;
            Console.WriteLine($"Original[0]={quelle[0]}  Klon[0]={klon[0]}  (unabhängig)");
    
            // ----------------------------------------------------------
            // 4. LINQ-ERWEITERUNGEN (sehr nützlich in der Praxis)
            // ----------------------------------------------------------
            Console.WriteLine("\n--- LINQ auf Arrays ---");
            int[]  zahlen = { 5, 3, 8, 1, 9, 2, 7 };
    
            Console.WriteLine($"Min:     {zahlen.Min()}");
            Console.WriteLine($"Max:     {zahlen.Max()}");
            Console.WriteLine($"Summe:   {zahlen.Sum()}");
            Console.WriteLine($"Durchschnitt: {zahlen.Average():F2}");
    
            int[] groessAls5 = zahlen.Where(z => z > 5).ToArray();
            Console.Write("Größer 5: ");
            foreach (int z in groessAls5) Console.Write($"{z} ");
            Console.WriteLine();
    
            bool allePositiv = zahlen.All(z => z > 0);
            bool einsEnthalten = zahlen.Any(z => z == 1);
            Console.WriteLine($"Alle positiv: {allePositiv}");
            Console.WriteLine($"Enthält 1:    {einsEnthalten}");
    
            // ----------------------------------------------------------
            // 5. MEHRDIMENSIONALE ARRAYS
            // ----------------------------------------------------------
            Console.WriteLine("\n--- 2D-Array (Tabelle) ---");
    
            // a) Rechteckiges Array (rectangular)
            int[,] matrix = new int[3, 3];
            for (int r = 0; r < 3; r++)
                for (int s = 0; s < 3; s++)
                    matrix[r, s] = r * 3 + s + 1;
    
            for (int r = 0; r < matrix.GetLength(0); r++)
            {
                for (int s = 0; s < matrix.GetLength(1); s++)
                    Console.Write($"{matrix[r, s],4}");
                Console.WriteLine();
            }
    
            // b) Jagged Array (Array von Arrays – unterschiedliche Längen möglich)
            Console.WriteLine("\n--- Jagged Array ---");
            int[][] dreieck = new int[4][];
            for (int r = 0; r < dreieck.Length; r++)
            {
                dreieck[r] = new int[r + 1];
                for (int s = 0; s <= r; s++)
                    dreieck[r][s] = s + 1;
            }
            foreach (int[] zeile in dreieck)
            {
                foreach (int val in zeile) Console.Write($"{val} ");
                Console.WriteLine();
            }
    
            // ----------------------------------------------------------
            // 6. RANGE-SYNTAX (C# 8+)
            // ----------------------------------------------------------
            Console.WriteLine("\n--- Range & Index (C# 8+) ---");
            int[] arr = { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9 };
    
            int[] teil1 = arr[2..5];        // Index 2,3,4 (Ende exklusiv)
            int[] teil2 = arr[^3..];        // letzte 3 Elemente
            int[] teil3 = arr[..4];         // erste 4
    
            Console.Write("arr[2..5]: "); foreach (int v in teil1) Console.Write($"{v} "); Console.WriteLine();
            Console.Write("arr[^3..]: "); foreach (int v in teil2) Console.Write($"{v} "); Console.WriteLine();
            Console.Write("arr[..4]:  "); foreach (int v in teil3) Console.Write($"{v} "); Console.WriteLine();
    
            // ----------------------------------------------------------
            // 7. ARRAYS VS. LIST<T>
            // ----------------------------------------------------------
            Console.WriteLine("\n--- Array vs. List<T> ---");
            // Array:   Feste Größe, etwas schneller, direkte MSIL-Unterstützung
            // List<T>: Dynamische Größe, flexibler, intern ebenfalls Array-basiert
            //
            // Faustregel:
            // - Größe bekannt & unveränderlich → Array
            // - Größe variiert → List<T>
    
            // ----------------------------------------------------------
            // 8. HÄUFIGE FEHLER
            // ----------------------------------------------------------
            Console.WriteLine("\n--- Häufige Fehler ---");
    
            // a) IndexOutOfRangeException
            try
            {
                int[] klein = { 1, 2, 3 };
                Console.WriteLine(klein[5]); // Index 5 existiert nicht!
            }
            catch (IndexOutOfRangeException)
            {
                Console.WriteLine("IndexOutOfRangeException abgefangen! (Index 5 bei Länge 3)");
            }
    
            // b) Array ist Referenztyp → Zuweisung kopiert NICHT!
            int[] original = { 1, 2, 3 };
            int[] aliasRef = original;   // beide zeigen auf dasselbe Objekt!
            aliasRef[0] = 999;
            Console.WriteLine($"original[0] = {original[0]}  (geändert durch aliasRef!)");
    
            // Richtig: Clone() oder Array.Copy() verwenden
            int[] echteKopie = (int[])original.Clone();
            echteKopie[0] = 0;
            Console.WriteLine($"original[0] = {original[0]}  (echteKopie unabhängig)");
    
            Console.WriteLine("\n=== ENDE: Arrays ===");
        }
    } 
}