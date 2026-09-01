namespace Variablen.cs
{
    // ============================================================
    //  01 – VARIABLEN IN C#
    //  Lernprogramm für die Ausbildung Fachinformatiker AE
    // ============================================================

    using System;

    class Variablen
    {
        static void Main()
        {
            Console.WriteLine("=== VARIABLEN IN C# ===\n");

            // ----------------------------------------------------------
            // 1. WAS IST EINE VARIABLE?
            // ----------------------------------------------------------
            // Eine Variable ist ein benannter Speicherplatz im Arbeitsspeicher.
            // Sie hat:  - einen Datentyp  (was wird gespeichert?)
            //           - einen Namen     (wie heißt sie?)
            //           - einen Wert      (was steht drin?)

            // ----------------------------------------------------------
            // 2. PRIMITIVE DATENTYPEN (Werttypen)
            // ----------------------------------------------------------
            // Ganzzahlen
            byte   b  = 255;           // 0 … 255            (8 Bit, unsigned)
            short  s  = -32_000;       // ±32 767             (16 Bit)
            int    i  = 2_147_483_647; // ±2,1 Mrd.           (32 Bit) ← häufigster Typ
            long   l  = 9_000_000_000L;// ±9,2 * 10^18        (64 Bit, Suffix L)

            // Kommazahlen (IEEE 754)
            float  f  = 3.14f;         // ~7 Dezimalstellen   (32 Bit, Suffix f)
            double d  = 3.14159265358; // ~15 Dezimalstellen  (64 Bit) ← Standard
            decimal m = 19.99m;        // 28-29 Stellen, exakt(128 Bit, Suffix m) → Geldbeträge

            // Zeichen & Wahrheitswert
            char   c  = 'A';           // einzelnes Unicode-Zeichen (in einfachen Anführungszeichen)
            bool   ok = true;          // true / false

            Console.WriteLine("--- Primitive Typen ---");
            Console.WriteLine($"byte:    {b}");
            Console.WriteLine($"short:   {s}");
            Console.WriteLine($"int:     {i}");
            Console.WriteLine($"long:    {l}");
            Console.WriteLine($"float:   {f}");
            Console.WriteLine($"double:  {d}");
            Console.WriteLine($"decimal: {m}");
            Console.WriteLine($"char:    {c}");
            Console.WriteLine($"bool:    {ok}");

            // ----------------------------------------------------------
            // 3. REFERENZTYP: string
            // ----------------------------------------------------------
            // string ist kein primitiver Typ, verhält sich aber wie einer.
            string name   = "Mustermann";
            string leer   = "";          // leerer String
            string? nulls = null;        // nullable: kann null sein (C# 8+)

            // String-Interpolation (empfohlen)
            Console.WriteLine($"\nHallo, {name}!");

            // Verbatim-String: Backslashes werden nicht als Escape behandelt
            string pfad = @"C:\Users\Mustermann\Desktop";
            Console.WriteLine($"Pfad: {pfad}");

            // ----------------------------------------------------------
            // 4. VARIABLEN DEKLARIEREN, INITIALISIEREN, ZUWEISEN
            // ----------------------------------------------------------
            int alter;          // Deklaration (noch kein Wert)
            alter = 25;         // Initialisierung (erstes Zuweisen)
            alter = 26;         // Zuweisung (Wert ändern)

            // Deklaration + Initialisierung in einer Zeile (üblich):
            int punkte = 100;

            Console.WriteLine($"\nalter:  {alter}");
            Console.WriteLine($"punkte: {punkte}");

            // ----------------------------------------------------------
            // 5. VAR – IMPLIZITE TYPISIERUNG
            // ----------------------------------------------------------
            // Der Compiler erkennt den Typ selbst → nur bei lokalen Variablen erlaubt
            var zahl    = 42;         // wird zu int
            var text    = "Hallo";    // wird zu string
            var komma   = 1.5;        // wird zu double
            // var x;   // FEHLER: ohne Initialisierung kein var

            Console.WriteLine($"\nvar zahl:  {zahl}  (Typ: {zahl.GetType()})");
            Console.WriteLine($"var text:  {text}  (Typ: {text.GetType()})");
            Console.WriteLine($"var komma: {komma}  (Typ: {komma.GetType()})");

            // ----------------------------------------------------------
            // 6. KONSTANTEN
            // ----------------------------------------------------------
            const double PI      = 3.14159265358979;
            const int    MAX_ALT = 120;
            // PI = 3.0;  // FEHLER: Konstante kann nicht geändert werden

            Console.WriteLine($"\nKonstante PI:      {PI}");
            Console.WriteLine($"Konstante MAX_ALT: {MAX_ALT}");

            // ----------------------------------------------------------
            // 7. TYPKONVERTIERUNG
            // ----------------------------------------------------------
            // a) Implizit (verlustfrei, automatisch)
            int    quelle  = 50;
            double ziel    = quelle;   // int → double OK (kein Datenverlust)

            // b) Explizit / Cast (ggf. Datenverlust!)
            double gross = 9.99;
            int    klein = (int)gross; // → 9  (Nachkommastellen abgeschnitten!)

            // c) Konvertierungsmethoden (sicherer)
            string numStr = "123";
            int    num    = int.Parse(numStr);         // Exception wenn ungültig
            bool   parsed = int.TryParse("abc", out int ergebnis); // kein Absturz

            // d) Convert-Klasse
            string boolStr = "True";
            bool   boolVal = Convert.ToBoolean(boolStr);

            Console.WriteLine("\n--- Typkonvertierung ---");
            Console.WriteLine($"int → double (implizit): {ziel}");
            Console.WriteLine($"double → int (Cast):     {klein}  (von {gross})");
            Console.WriteLine($"Parse:       {num}");
            Console.WriteLine($"TryParse OK: {parsed}, Ergebnis: {ergebnis}");
            Console.WriteLine($"Convert:     {boolVal}");

            // ----------------------------------------------------------
            // 8. NULLABLE TYPES (C# 2+ / verbessert in C# 8+)
            // ----------------------------------------------------------
            int? vielleichtNull = null;   // int? = Nullable<int>
            Console.WriteLine($"\nNullable int:  {vielleichtNull}");
            vielleichtNull = 7;
            Console.WriteLine($"Nullable int:  {vielleichtNull}");
            Console.WriteLine($"HasValue:      {vielleichtNull.HasValue}");
            Console.WriteLine($"Value:         {vielleichtNull.Value}");

            // Null-Coalescing-Operator ??
            int sicher = vielleichtNull ?? 0;  // 0 wenn null, sonst der Wert
            Console.WriteLine($"Null-Coalescing: {sicher}");

            // ----------------------------------------------------------
            // 9. SCOPE (GÜLTIGKEITSBEREICH)
            // ----------------------------------------------------------
            int aussen = 10;
            {
                int innen = 20; // nur in diesem Block sichtbar
                Console.WriteLine($"\nInnen sichtbar: aussen={aussen}, innen={innen}");
            }
            // Console.WriteLine(innen);  // FEHLER: innen existiert hier nicht mehr
            Console.WriteLine($"Aussen sichtbar: aussen={aussen}");

            // ----------------------------------------------------------
            // 10. BENENNUNGSKONVENTIONEN (C# Best Practices)
            // ----------------------------------------------------------
            // lokale Variablen / Parameter → camelCase:  meinWert, anzahlTiere
            // Konstanten                   → UPPER_CASE: MAX_SIZE, PI
            // Klassen, Properties          → PascalCase: MeinAuto, Vorname
            // Private Felder               → _camelCase: _name, _alter

            int    meinWert    = 42;
            string meinNachname = "Schmidt";
            Console.WriteLine($"\nBenennung – meinWert: {meinWert}, meinNachname: {meinNachname}");

            Console.WriteLine("\n=== ENDE: Variablen ===");
        }
    }
}