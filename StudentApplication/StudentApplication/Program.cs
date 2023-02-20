using MySql.Data.MySqlClient;
using System.ComponentModel.Design;

namespace StudentApplication
{
    internal class Program
    {
        static void Main(string[] args)
        {

            //Skapar kopplig med databasen
            // Initsierar & deklarerar variabler 
             string server = "LOCALHOST";
             string database = "students";
             string username = "root";
             string password = "";

             string connectingStr = $"SERVER={server}; DATABASE={database}; " +
                 $"UID={username};PASSWORD={password};";

             MySqlConnection connection = new MySqlConnection(connectingStr);
             Console.WriteLine($"Välkommen till databasen {database}!");
             Thread.Sleep(1500);  


            ConsoleKeyInfo input;
            
            do
            {
                Console.Clear();

                //Skriv ut menyn
                meny.menu();

                //Användarens val sparas  i input
                input = Console.ReadKey();

                switch (input.KeyChar.ToString())
                {
                    case "1":
                        Console.Clear();
                        //Addera data
                        proseduresForDB.AddItem( connection);
                        break;
                    case "2":
                        Console.Clear();
                        //Hämta data
                        proseduresForDB.ReadDB(connection);
                        break;
                    case "3":
                        //Avsluta programmet
                        break;
                    default:
                        Console.WriteLine("Du har matat in ett felaktigt värde. Var snäll och välj något i menyn. (tryck på valfri tangent för att komma tillbaka till menyn)");
                        Console.ReadKey();
                        break;
                }

                } while (input.KeyChar.ToString() != "3");
        }
    }
}