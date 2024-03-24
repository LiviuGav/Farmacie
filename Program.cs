using System;
using System.Collections.Generic;

class Farmacie
{
    static List<Medicament> medicamente = new List<Medicament>();

    static void Main(string[] args)
    {
        bool exit = false;

        while (!exit)
        {
            Console.WriteLine("Selectati o optiune:");
            Console.WriteLine("1. Adaugare medicament");
            Console.WriteLine("2. Editare/Stergere medicament");
            Console.WriteLine("3. Afisare lista de medicamente");
            Console.WriteLine("4. Cautare medicament");
            Console.WriteLine("5. Iesire");

            int optiune;
            if (!int.TryParse(Console.ReadLine(), out optiune))
            {
                Console.WriteLine("Optiune invalida. Va rugam sa selectati din nou.");
                continue;
            }

            switch (optiune)
            {
                case 1:
                    Adauga_med();
                    break;
                case 2:
                    Editeaza_sterge_med();
                    break;
                case 3:
                    Afisare_lista();
                    break;
                case 4:
                    Cauta_med();
                    break;
                case 5:
                    exit = true;
                    break;
                default:
                    Console.WriteLine("Optiune invalida. Va rugam sa selectati din nou.");
                    break;
            }
        }
    }

    static void Adauga_med()
    {
        Console.WriteLine("Introduceti numele medicamentului:");
        string nume = Console.ReadLine();

        Console.WriteLine("Introduceti pretul medicamentului:");
        double pret;
        while (!double.TryParse(Console.ReadLine(), out pret))
        {
            Console.WriteLine("Pret invalid. Va rugam sa introduceti un pret numeric.");
        }

        Medicament newMedicament = new Medicament(nume, pret);
        medicamente.Add(newMedicament);

        Console.WriteLine("Medicamentul a fost adaugat cu succes.");
    }

    static void Editeaza_sterge_med()
    {
        Console.WriteLine("Introduceti numele medicamentului pentru editare/stergere:");
        string nume = Console.ReadLine();

        Medicament medicament = medicamente.Find(m => m.Nume == nume);
        if (medicament != null)
        {
            Console.WriteLine("Medicament gasit:");
            Console.WriteLine($"Nume: {medicament.Nume}, Pret: {medicament.Pret}");

            Console.WriteLine("Selectati o optiune:");
            Console.WriteLine("1. Editare");
            Console.WriteLine("2. Stergere");

            int optiune;
            if (!int.TryParse(Console.ReadLine(), out optiune))
            {
                Console.WriteLine("Optiune invalida. Va rugam sa selectati din nou.");
                return;
            }

            switch (optiune)
            {
                case 1:
                    Console.WriteLine("Introduceti noul pret:");
                    double newPret;
                    while (!double.TryParse(Console.ReadLine(), out newPret))
                    {
                        Console.WriteLine("Pret invalid. Va rugam sa introduceti un pret numeric.");
                    }
                    medicament.Pret = newPret;
                    Console.WriteLine("Medicamentul a fost actualizat cu succes.");
                    break;
                case 2:
                    medicamente.Remove(medicament);
                    Console.WriteLine("Medicamentul a fost sters cu succes.");
                    break;
                default:
                    Console.WriteLine("Optiune invalida. Va rugam sa selectati din nou.");
                    break;
            }
        }
        else
        {
            Console.WriteLine("Medicamentul nu a fost gasit.");
        }
    }

    static void Afisare_lista()
    {
        if (medicamente.Count == 0)
        {
            Console.WriteLine("Nu exista medicamente inregistrate.");
        }
        else
        {
            Console.WriteLine("Lista de medicamente:");
            foreach (var medicament in medicamente)
            {
                Console.WriteLine($"Nume: {medicament.Nume}, Pret: {medicament.Pret}");
            }
        }
    }

    static void Cauta_med()
    {
        Console.WriteLine("Introduceti numele medicamentului cautat:");
        string nume = Console.ReadLine();

        Medicament medicament = medicamente.Find(m => m.Nume == nume);
        if (medicament != null)
        {
            Console.WriteLine("Medicament gasit:");
            Console.WriteLine($"Nume: {medicament.Nume}, Pret: {medicament.Pret}");
        }
        else
        {
            Console.WriteLine("Medicamentul nu a fost gasit.");
        }
    }
}

class Medicament
{
    public string Nume { get; set; }
    public double Pret { get; set; }

    public Medicament(string nume, double pret)
    {
        Nume = nume;
        Pret = pret;
    }
}

