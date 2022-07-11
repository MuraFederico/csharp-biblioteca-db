﻿// See https://aka.ms/new-console-template for more information

//una serie di istanze per "popolare" il nostro "fake db"
// 2 o 3 utenti -> registrati
// 2 o 3 libri --> tutti disponibili
// Gli utenti si possono registrare specificando i dati ...


// Biblioteca online
// 1. registrati
// 2. login

//login 
// email: ..
// passowrd: ..

// Biblioteca online
// 1. Cerca libri
// 2. Cerca dvd

// Registrazione
// Scrivmi il nome: 
// scrivimi il cognome.. etc
// scrivi la passowrd: 

// Menu libro (titolo)
// 1. visualizza dettagli libro
// 2. richiedi prestito
// 3. restitutisci


// tutti i menu hanno esci o torna indietro


using csharp_biblioteca;

UsersList users = new UsersList();
ItemsList items = new ItemsList();
LoansList loans = new LoansList();

/*users.RegisterUser("Mura", "Federico", "federico@mail.it", "asdfasdf", "123456789");
users.RegisterUser("Alessio", "Vitiello", "alessio@mail.it", "asdfasdf", "123456789");
users.RegisterUser("Margherita", "Laura", "laura@mail.it", "asdfasdf", "123456789");*/

/*items.AddItem("0", 120, "Interstellar", "Christopher Nolan", new DateTime(2014), "fantascienza", true, 3);
items.AddItem("978-3-16-148410-0", 900, "Dune", "Frank Herbert", new DateTime(1973), "fantascienza", true, 3);
items.AddItem("1", 155, "Dune", "Denis Villeneuve", new DateTime(2021), "fantascienza", true, 3);*/


User logged = null;

PrintHome(logged);



/*loans.PrintLoans();*/

/*users.PrintUsers();*/

void PrintHome(User logged)
{
    Console.Clear();
    Console.WriteLine("########");
    Console.WriteLine("# HOME #");
    Console.WriteLine("########\n");

    Console.WriteLine("1. registrati");
    Console.WriteLine("2. login\n");

    string choice = Console.ReadLine();

    if(choice == "1")
    {
        Console.Clear();
        PrintRegister();
    }else if (choice == "2")
    {
        Console.Clear();
        PrintLogin(logged);
    }else
    {
        Console.WriteLine("invalid input, try again");
        PrintHome(logged);
    }
}

void PrintRegister()
{
    Console.WriteLine("############");
    Console.WriteLine("# REGISTER #");
    Console.WriteLine("############\n");

    Console.Write("Name: ");
    string name = Console.ReadLine();
    Console.Write("Surname: ");
    string surname = Console.ReadLine();
    Console.Write("Email: ");
    string email = Console.ReadLine();
    Console.Write("Password: ");
    string password = Console.ReadLine();


    users.RegisterUser(surname,name,email,password);
}


void PrintLogin(User logged)
{
    Console.WriteLine("#########");
    Console.WriteLine("# LOGIN #");
    Console.WriteLine("#########\n");

    Console.Write("Email: ");
    string email = Console.ReadLine();
    Console.Write("Password: ");
    string password = Console.ReadLine();
    logged = users.LogIn(email, password);
    if (logged.isLogged)
    {
        LoggedHome(logged);
    }
    else
    {
        PrintHome(logged);
    }
}

void LoggedHome(User logged)
{

    Console.WriteLine($"****** Welcome {logged.name} ******\n");

    MenuActions(logged);

}

void MenuActions(User logged)
{
    Console.WriteLine("###########");
    Console.WriteLine("# ACTIONS #");
    Console.WriteLine("###########\n");

    Console.WriteLine("1. loan");
    Console.WriteLine("2. ");
    Console.WriteLine("3. give back\n");

    string choice = Console.ReadLine();

    if(choice == "1")
    {
        Console.Write("type book title or ISBN: ");
        string srcString = Console.ReadLine();
        List<Item> results = items.FindItem(srcString);
        int i = 1;
        foreach (Item book in results)
        {
            Console.WriteLine($"{i}. {book.title}");
        }

        Console.WriteLine();
        Console.Write("Select a book ");
        int index = int.Parse(Console.ReadLine()) - 1;
        int id = results[index].id;

        DateTime start = DateTime.Now;
        //Console.Write("End rent date (gg/mm/yyyy)");
        DateTime end = start.AddMonths(3);
        Console.WriteLine(start.ToString());
        Console.WriteLine(end.ToString());

        int z = 0;
        loans.MakeLoan(logged, id, start, end);

    }
    else if(choice == "2")
    {
        
    }else if(choice == "3")
    {
        Console.WriteLine("not implemented");
        MenuActions(logged);

    }
    else
    {
        Console.WriteLine("invalid input");
        MenuActions(logged);
    }
}