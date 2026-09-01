namespace Klassen.cs
{
        // ============================================================
    //  06 – KLASSEN IN C#
    //  Lernprogramm für die Ausbildung Fachinformatiker AE
    // ============================================================
    
    using System;
    using System.Collections.Generic;
    
    // ============================================================
    // TEIL 1: GRUNDKLASSE
    // ============================================================
    
    // Eine Klasse ist ein Bauplan (Schablone) für Objekte.
    // Ein Objekt ist eine konkrete Instanz dieser Klasse.
    // Klassen bündeln zusammengehörige Daten (Felder/Properties)
    // und Verhalten (Methoden).
    
    class Person
    {
        // ----------------------------------------------------------
        // FELDER (private – nur innerhalb der Klasse sichtbar)
        // Konvention: _camelCase
        // ----------------------------------------------------------
        private string _name;
        private int    _alter;
    
        // ----------------------------------------------------------
        // PROPERTIES (öffentliche Schnittstelle zu den Feldern)
        // get = lesen, set = schreiben
        // ----------------------------------------------------------
        public string Name
        {
            get { return _name; }
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                    throw new ArgumentException("Name darf nicht leer sein.");
                _name = value;
            }
        }
    
        public int Alter
        {
            get => _alter;
            set => _alter = value >= 0 ? value : throw new ArgumentException("Alter muss >= 0 sein.");
        }
    
        // Auto-Property (Compiler erzeugt Feld automatisch)
        public string Email { get; set; } = "unbekannt@example.com";
    
        // Read-only Property (nur get, kein set)
        public bool IstVolljährig => _alter >= 18;
    
        // ----------------------------------------------------------
        // KONSTRUKTOREN (werden beim new aufgerufen)
        // ----------------------------------------------------------
    
        // Standardkonstruktor (kein Parameter)
        public Person()
        {
            _name  = "Unbekannt";
            _alter = 0;
        }
    
        // Parametrisierter Konstruktor
        public Person(string name, int alter)
        {
            Name  = name;   // Property nutzen → Validierung greift!
            Alter = alter;
        }
    
        // Konstruktor-Verkettung mit : this(...)
        public Person(string name) : this(name, 0) { }
    
        // ----------------------------------------------------------
        // METHODEN
        // ----------------------------------------------------------
        public void Vorstellen()
        {
            Console.WriteLine($"Ich bin {_name}, {_alter} Jahre alt. Volljährig: {IstVolljährig}");
        }
    
        public void Geburtstag()
        {
            _alter++;
            Console.WriteLine($"{_name} hat Geburtstag! Jetzt {_alter} Jahre alt.");
        }
    
        // ToString überschreiben (aus object-Basisklasse)
        public override string ToString() => $"Person({_name}, {_alter})";
    }
    
    // ============================================================
    // TEIL 2: VERERBUNG
    // ============================================================
    // Eine abgeleitete Klasse erbt alle public/protected Member
    // der Basisklasse und kann sie erweitern oder überschreiben.
    
    class Mitarbeiter : Person   // Mitarbeiter "ist ein" Person
    {
        // Eigene Property
        public string Abteilung { get; set; }
        public double Gehalt    { get; private set; }
    
        // Konstruktor ruft Basis-Konstruktor auf
        public Mitarbeiter(string name, int alter, string abteilung, double gehalt)
            : base(name, alter)   // base(...) = Konstruktor der Elternklasse
        {
            Abteilung = abteilung;
            Gehalt    = gehalt;
        }
    
        // Methode hinzufügen
        public void Gehaltserhöhung(double prozent)
        {
            Gehalt *= 1 + prozent / 100;
            Console.WriteLine($"{Name} bekommt {prozent}% mehr → {Gehalt:C}");
        }
    
        // Methode überschreiben (override) – Basis hatte virtual
        public override string ToString() =>
            $"Mitarbeiter({Name}, Abteilung: {Abteilung}, Gehalt: {Gehalt:C})";
    }
    
    // ============================================================
    // TEIL 3: ABSTRAKTE KLASSEN
    // ============================================================
    // abstract: Klasse kann nicht direkt instanziiert werden.
    // Abstrakte Methoden MÜSSEN in abgeleiteten Klassen implementiert werden.
    
    abstract class Form
    {
        public string Farbe { get; set; } = "Schwarz";
    
        // Abstrakte Methode (kein Körper)
        public abstract double Flaeche();
        public abstract double Umfang();
    
        // Konkrete Methode (geerbt wie sie ist)
        public void Beschreiben()
        {
            Console.WriteLine($"{GetType().Name} | Farbe: {Farbe} | Fläche: {Flaeche():F2} | Umfang: {Umfang():F2}");
        }
    }
    
    class Kreis : Form
    {
        public double Radius { get; set; }
        public Kreis(double radius) => Radius = radius;
    
        public override double Flaeche() => Math.PI * Radius * Radius;
        public override double Umfang()  => 2 * Math.PI * Radius;
    }
    
    class Rechteck : Form
    {
        public double Breite  { get; set; }
        public double Hoehe   { get; set; }
        public Rechteck(double breite, double hoehe) { Breite = breite; Hoehe = hoehe; }
    
        public override double Flaeche() => Breite * Hoehe;
        public override double Umfang()  => 2 * (Breite + Hoehe);
    }
    
    // ============================================================
    // TEIL 4: INTERFACE
    // ============================================================
    // Ein Interface definiert einen Vertrag (welche Methoden/Properties
    // muss eine Klasse anbieten?), aber keine Implementierung.
    // Eine Klasse kann mehrere Interfaces implementieren.
    
    interface ISpeicherbar
    {
        void Speichern();
        bool Laden(int id);
    }
    
    interface IDruckbar
    {
        void Drucken();
    }
    
    class Dokument : ISpeicherbar, IDruckbar
    {
        public string Titel   { get; set; }
        public string Inhalt  { get; set; }
    
        public Dokument(string titel, string inhalt)
        {
            Titel  = titel;
            Inhalt = inhalt;
        }
    
        public void Speichern()         => Console.WriteLine($"[DB] '{Titel}' gespeichert.");
        public bool Laden(int id)       { Console.WriteLine($"[DB] Lade Dokument #{id}"); return true; }
        public void Drucken()           => Console.WriteLine($"[Drucker] '{Titel}': {Inhalt}");
    }
    
    // ============================================================
    // TEIL 5: STATISCHE KLASSE
    // ============================================================
    // static-Klassen können nicht instanziiert werden.
    // Nützlich für Hilfsmethoden (z.B. Math, Convert).
    
    static class Rechner
    {
        public static double Potenz(double basis, int exp)
        {
            double ergebnis = 1;
            for (int i = 0; i < exp; i++) ergebnis *= basis;
            return ergebnis;
        }
    
        public static bool IstPrimzahl(int n)
        {
            if (n < 2) return false;
            for (int i = 2; i <= Math.Sqrt(n); i++)
                if (n % i == 0) return false;
            return true;
        }
    }
    
    // ============================================================
    // TEIL 6: RECORD (C# 9+) – für reine Datenhaltung
    // ============================================================
    // Records sind immutable (unveränderlich) by default,
    // haben automatisch Equals, GetHashCode, ToString.
    
    record Punkt(double X, double Y)
    {
        public double Abstand(Punkt anderer) =>
            Math.Sqrt(Math.Pow(X - anderer.X, 2) + Math.Pow(Y - anderer.Y, 2));
    }
    
    // ============================================================
    // HAUPTPROGRAMM
    // ============================================================
    
    class Klassen
    {
        static void Main()
        {
            Console.WriteLine("=== KLASSEN IN C# ===\n");
    
            // ----------------------------------------------------------
            // 1. OBJEKTE ERSTELLEN (Instanziierung mit new)
            // ----------------------------------------------------------
            Console.WriteLine("--- Grundklasse Person ---");
    
            Person p1 = new Person("Anna", 22);
            Person p2 = new Person("Bene");        // Alter = 0 durch Kettenkonstruktor
            Person p3 = new Person();              // Standardkonstruktor
    
            p1.Vorstellen();
            p2.Vorstellen();
            p3.Name = "Chris";
            p3.Alter = 30;
            p3.Vorstellen();
    
            p1.Geburtstag();
            Console.WriteLine($"ToString: {p1}");
    
            // Property mit Validierung testen
            try
            {
                p1.Alter = -5; // Exception!
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine($"Fehler: {ex.Message}");
            }
    
            // ----------------------------------------------------------
            // 2. VERERBUNG
            // ----------------------------------------------------------
            Console.WriteLine("\n--- Vererbung: Mitarbeiter ---");
    
            Mitarbeiter m1 = new Mitarbeiter("Diana", 35, "IT", 3500.00);
            m1.Vorstellen();                // geerbte Methode
            m1.Gehaltserhöhung(10);
            Console.WriteLine(m1);         // überschriebenes ToString
    
            // Polymorphismus: Basistyp-Variable hält abgeleitetes Objekt
            Person alsPerson = m1;
            alsPerson.Vorstellen();         // ruft Person.Vorstellen auf
            Console.WriteLine(alsPerson);  // ruft Mitarbeiter.ToString() auf (Polymorphismus!)
    
            // ----------------------------------------------------------
            // 3. ABSTRAKTE KLASSEN & POLYMORPHISMUS
            // ----------------------------------------------------------
            Console.WriteLine("\n--- Abstrakte Klasse: Formen ---");
    
            List<Form> formen = new List<Form>
            {
                new Kreis(5)       { Farbe = "Rot"  },
                new Rechteck(4, 6) { Farbe = "Blau" },
                new Kreis(2.5)     { Farbe = "Grün" }
            };
    
            foreach (Form f in formen)
                f.Beschreiben();   // jede Form berechnet Fläche/Umfang selbst
    
            // ----------------------------------------------------------
            // 4. INTERFACE
            // ----------------------------------------------------------
            Console.WriteLine("\n--- Interface ---");
    
            Dokument doc = new Dokument("Lernplan", "C# Grundlagen bis KW 30");
            doc.Speichern();
            doc.Laden(42);
            doc.Drucken();
    
            // Interface als Typ (nur Interface-Methoden sichtbar)
            ISpeicherbar speicherbar = doc;
            speicherbar.Speichern();
    
            // ----------------------------------------------------------
            // 5. STATISCHE KLASSE
            // ----------------------------------------------------------
            Console.WriteLine("\n--- Statische Klasse ---");
            Console.WriteLine($"2^10 = {Rechner.Potenz(2, 10)}");
            Console.WriteLine($"17 ist Primzahl: {Rechner.IstPrimzahl(17)}");
            Console.WriteLine($"18 ist Primzahl: {Rechner.IstPrimzahl(18)}");
    
            // ----------------------------------------------------------
            // 6. RECORD (C# 9+)
            // ----------------------------------------------------------
            Console.WriteLine("\n--- Record ---");
    
            var a = new Punkt(0, 0);
            var b = new Punkt(3, 4);
            Console.WriteLine($"Punkt a: {a}");
            Console.WriteLine($"Punkt b: {b}");
            Console.WriteLine($"Abstand: {a.Abstand(b)}");
    
            // Records: Gleichheit über Werte, nicht Referenz
            var c = new Punkt(3, 4);
            Console.WriteLine($"b == c (Wertegleichheit): {b == c}");   // true
            Console.WriteLine($"b.Equals(c):              {b.Equals(c)}"); // true
    
            // with-Ausdruck: Kopie mit geändertem Wert
            var d = b with { X = 10 };
            Console.WriteLine($"b with X=10: {d}");
    
            // ----------------------------------------------------------
            // 7. OBJECT INITIALIZER SYNTAX
            // ----------------------------------------------------------
            Console.WriteLine("\n--- Object Initializer ---");
            var p4 = new Person("Eva", 28) { Email = "eva@example.com" };
            Console.WriteLine($"{p4.Name}, E-Mail: {p4.Email}");
    
            // ----------------------------------------------------------
            // 8. ZUSAMMENFASSUNG: OOP-PRINZIPIEN
            // ----------------------------------------------------------
            Console.WriteLine("\n--- OOP-Prinzipien ---");
            Console.WriteLine("Kapselung:    Daten (private) + Methoden in einer Klasse bündeln.");
            Console.WriteLine("Vererbung:    Klasse erbt von Basisklasse (': BasisKlasse').");
            Console.WriteLine("Polymorphismus: Basistyp-Variable kann abgeleitetes Objekt halten;");
            Console.WriteLine("              überschriebene Methoden laufen trotzdem korrekt.");
            Console.WriteLine("Abstraktion:  Abstrakte Klassen / Interfaces definieren Verträge,");
            Console.WriteLine("              verstecken Implementierungsdetails.");
    
            Console.WriteLine("\n=== ENDE: Klassen ===");
        }
    }
}