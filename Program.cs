using System;
using System.Collections.Generic;
using System.IO;

public class Farmacie
{
    public static List<Medicament> medicamente = new List<Medicament>();
    public static List<Client> clienti = new List<Client>();

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
                    ScrieInFisierMedicamente();
                    break;
                case 2:
                    Editeaza_sterge_med();
                    ScrieInFisierMedicamente();
                    break;
                case 3:
                    CitesteDinFisierMedicamente();
                    Afisare_lista();
                    break;
                case 4:
                    CitesteDinFisierMedicamente();
                    Cauta_med();
                    break;
                case 5:
                    Adauga_client();
                    ScrieInFisierClienti();
                    break;
                case 6:
                    CitesteDinFisierClienti();
                    Afisare_client();
                    break;
                case 7:
                    CitesteDinFisierClienti();
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

    static void Adauga_med()
    {
        Console.WriteLine("Introduceti numele medicamentului:");
        string nume = Console.ReadLine().Trim(); 

        if (string.IsNullOrEmpty(nume))
        {
            Console.WriteLine("Numele medicamentului nu poate fi gol. Va rugam sa introduceti un nume valid.");
            return; 
        }

        Console.WriteLine("Introduceti pretul medicamentului:");
        double pret;
        if (!double.TryParse(Console.ReadLine(), out pret) || pret <= 0)
        {
            Console.WriteLine("Pretul medicamentului trebuie sa fie un numar pozitiv. Va rugam sa introduceti un pret valid.");
            return; 
        }

        Console.WriteLine("Selectati categoria medicamentului:");
        foreach (CategorieMedicament categorie in Enum.GetValues(typeof(CategorieMedicament)))
        {
            Console.WriteLine($"{(int)categorie}. {categorie}");
        }

        CategorieMedicament selectedCategorie;
        if (!Enum.TryParse(Console.ReadLine(), out selectedCategorie) || !Enum.IsDefined(typeof(CategorieMedicament), selectedCategorie))
        {
            Console.WriteLine("Categoria selectata nu este valida.");
            return; 
        }

        Console.WriteLine("Selectati forma medicamentului:");
        foreach (FormaMedicament forma in Enum.GetValues(typeof(FormaMedicament)))
        {
            Console.WriteLine($"{(int)forma}. {forma}");
        }

        FormaMedicament selectedForma;
        if (!Enum.TryParse(Console.ReadLine(), out selectedForma) || !Enum.IsDefined(typeof(FormaMedicament), selectedForma))
        {
            Console.WriteLine("Forma selectata nu este valida.");
            return; 
        }

       
        Medicament newMedicament = new Medicament(nume, pret, selectedCategorie, selectedForma);
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
            Console.WriteLine($"Nume: {medicament.Nume}, Pret: {medicament.Pret}, Categorie: {medicament.Categorie}, Forma: {medicament.Forma}");

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
                Console.WriteLine($"Nume: {medicament.Nume}, Pret: {medicament.Pret}, Categorie: {medicament.Categorie}, Forma: {medicament.Forma}");
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
            Console.WriteLine($"Nume: {medicament.Nume}, Pret: {medicament.Pret}, Categorie: {medicament.Categorie}, Forma: {medicament.Forma}");
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

        Console.WriteLine("Selectati genul clientului:");
        foreach (GenClient gen in Enum.GetValues(typeof(GenClient)))
        {
            Console.WriteLine($"{(int)gen}. {gen}");
        }

        GenClient genClient;
        if (!Enum.TryParse(Console.ReadLine(), out genClient) || !Enum.IsDefined(typeof(GenClient), genClient))
        {
            Console.WriteLine("Genul selectat nu este valid.");
            return; 
        }

        Client newClient = new Client(nume, telefon, genClient);
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
                Console.WriteLine($"Nume: {client.Nume}, Telefon: {client.Telefon}, Gen: {client.Gen}");
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
            Console.WriteLine($"Nume: {client.Nume}, Telefon: {client.Telefon}, Gen: {client.Gen}");
        }
        else
        {
            Console.WriteLine("Clientul nu a fost gasit.");
        }
    }

    public static void ScrieInFisierMedicamente()
    {
        using (StreamWriter sw = new StreamWriter("medicamente.txt"))
        {
            foreach (Medicament medicament in medicamente)
            {
                sw.WriteLine($"{medicament.Nume},{medicament.Pret},{medicament.Categorie},{medicament.Forma}");
            }
        }
    }

    public static void CitesteDinFisierMedicamente()
    {
        medicamente.Clear();

        if (File.Exists("medicamente.txt"))
        {
            using (StreamReader sr = new StreamReader("medicamente.txt"))
            {
                string line;
                while ((line = sr.ReadLine()) != null)
                {
                    string[] parts = line.Split(',');
                    if (parts.Length >= 3)
                    {
                        string nume = parts[0];
                        double pret;
                        if (double.TryParse(parts[1], out pret))
                        {
                            CategorieMedicament categorie;
                            if (Enum.TryParse(parts[2], out categorie) && Enum.IsDefined(typeof(CategorieMedicament), categorie))
                            {
                                FormaMedicament forma;
                                if (Enum.TryParse(parts[3], out forma) && Enum.IsDefined(typeof(FormaMedicament), forma))
                                {
                                    medicamente.Add(new Medicament(nume, pret, categorie, forma));
                                }
                            }
                        }
                    }
                }
            }
            Console.WriteLine("Datele despre medicamente au fost încarcate din fisier.");
        }
        else
        {
            Console.WriteLine("Fisierul pentru medicamente nu exista. Nu sunt date disponibile.");
        }
    }


    public static void ScrieInFisierClienti()
    {
        using (StreamWriter sw = new StreamWriter("clienti.txt"))
        {
            foreach (Client client in clienti)
            {
                sw.WriteLine($"{client.Nume},{client.Telefon},{client.Gen}");
            }
        }
        Console.WriteLine("Datele despre clienti au fost salvate în fisier.");
    }

    public static void CitesteDinFisierClienti()
    {
        clienti.Clear();

        if (File.Exists("clienti.txt"))
        {
            using (StreamReader sr = new StreamReader("clienti.txt"))
            {
                string line;
                while ((line = sr.ReadLine()) != null)
                {
                    string[] parts = line.Split(',');
                    if (parts.Length >= 3)
                    {
                        string nume = parts[0];
                        string telefon = parts[1];
                        GenClient gen;
                        if (Enum.TryParse(parts[2], out gen) && Enum.IsDefined(typeof(GenClient), gen))
                        {
                            clienti.Add(new Client(nume, telefon, gen));
                        }
                    }
                }
            }
            Console.WriteLine("Datele despre clienti au fost incarcate din fisier.");
        }
        else
        {
            Console.WriteLine("Fisierul pentru clienti nu exista. Nu sunt date disponibile.");
        }
    }

}

public class Medicament
{
    public string Nume { get; set; }
    public double Pret { get; set; }
    public CategorieMedicament Categorie { get; set; }
    public FormaMedicament Forma { get; set; }

    public Medicament(string nume, double pret, CategorieMedicament categorie, FormaMedicament forma)
    {
        Nume = nume;
        Pret = pret;
        Categorie = categorie;
        Forma = forma;
    }
}


//Laborator 5
public enum CategorieMedicament
{
    Antipiretic,
    Analgezic,
    Antibiotic,
    Antidepresiv,
    Antihistaminic,
    Altele
}

public enum FormaMedicament
{
    Tableta,
    Capsula,
    Sirop,
    Gel,
    Crema,
    Altele
}

public class Client
{
    public string Nume { get; set; }
    public string Telefon { get; set; }
    public GenClient Gen { get; set; }

    public Client(string nume, string telefon, GenClient gen)
    {
        Nume = nume;
        Telefon = telefon;
        Gen = gen;
    }
}

public enum GenClient
{
    Masculin,
    Feminin,
    Altul
}
