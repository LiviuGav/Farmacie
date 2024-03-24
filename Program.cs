using System;
using System.Collections.Generic;

class Farmacie
{
    static List<Medicament> medicamente = new List<Medicament>(); //salvarea datelor într-un vector de obiecte
    static List<Client> clienti = new List<Client>();
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
            Console.WriteLine("5. Adaugare client");
            Console.WriteLine("6. Afisare lista de clienti");
            Console.WriteLine("7. Cautare client");
            Console.WriteLine("8. Iesire");

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
                    Adauga_client();
                    break;
                case 6:
                    Afisare_client();
                    break;
                case 7:
                    Cauta_client();
                    break;
                case 8:
                    exit = true;
                    break;
                default:
                    Console.WriteLine("Optiune invalida. Va rugam sa selectati din nou.");
                    break;
            }
        }
    }

    static void Adauga_med() // citirea datelor de la tastatura
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

    static void Afisare_lista() //afișarea datelor dintr-un vector de obiecte
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

    static void Cauta_med() //căutarea după anumite criterii
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

    static void Adauga_client()
    {
        Console.WriteLine("Introduceti numele clientului:");
        string nume = Console.ReadLine();

        Console.WriteLine("Introduceti numarul de telefon al clientului:");
        string telefon = Console.ReadLine();

        Client newClient = new Client(nume, telefon);
        clienti.Add(newClient);
        Console.WriteLine("Clientul a fost adaugat cu succes.");
    }

    static void Afisare_client()
    {
        if (clienti.Count == 0)
        {
            Console.WriteLine("Nu exista clienti inregistrati.");
        }
        else
        {
            Console.WriteLine("Lista de clienti:");
            foreach (var client in clienti)
            {
                Console.WriteLine($"Nume: {client.Nume}, Telefon: {client.Telefon}");
            }
        }
    }

    static void Cauta_client()
    {
        Console.WriteLine("Introduceti numele clientului cautat:");
        string nume = Console.ReadLine();

        Client client = clienti.Find(c => c.Nume == nume);
        if (client != null)
        {
            Console.WriteLine("Client gasit:");
            Console.WriteLine($"Nume: {client.Nume}, Telefon: {client.Telefon}");
        }
        else
        {
            Console.WriteLine("Clientul nu a fost gasit.");
        }
    }
}

class Medicament
{
    //Modificați clasele proiectate astfel încât să se folosească proprietăți
    //auto-implemented în loc de câmpuri private și metodele separate de „get” si „set”.
    public string Nume { get; set; }
    public double Pret { get; set; }

    public Medicament(string nume, double pret)
    {
        Nume = nume;
        Pret = pret;
    }
}

class Client
{
    public string Nume { get; set; }
    public string Telefon { get; set; }

    public Client(string nume, string telefon)
    {
        Nume = nume;
        Telefon = telefon;
    }
}

