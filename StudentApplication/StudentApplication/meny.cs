using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentApplication
{
    public class meny
    {
        public static void menu() 
        {
            Console.WriteLine("MENY FÖR DB");
            Console.WriteLine("Välj något av följande val:");
            Console.WriteLine("1. Lägg till en rad i databasen.");
            Console.WriteLine("2. Hämta data.");
            Console.WriteLine("3. Avsluta programmet");
        }
    }
}
