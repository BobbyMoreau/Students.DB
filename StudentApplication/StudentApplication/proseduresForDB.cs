using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentApplication
{
    internal class proseduresForDB
    {
        public static void AddItem(MySqlConnection connection)
        {
            //Hämta data från användaren - Namn
            Console.WriteLine("Ange studentens förnamn: ");
            string namn = Console.ReadLine();
            Console.WriteLine("Ange studentens efternamn: ");
            string surname = Console.ReadLine();
            //Hämta data från användaren - Kurs
            Console.WriteLine("Ange kursen: (Ange med siffra)");
            Console.WriteLine("1. Databasteknik");
            Console.WriteLine("2. Javascript");
            Console.WriteLine("3. Java");
            Console.WriteLine("4. Agilt arbete");
            int course = int.Parse(Console.ReadLine());
            //Hämta data från användaren - Betyg
            Console.WriteLine("Ange vilket betyg studenten fick: ");
            Console.WriteLine("Betygsskalan: IG, G, VG eller MVG.");
            string grade = Console.ReadLine();
            //Kovertera användarens svar till databasenligt svar
            int gradeID = convertGrade(grade);


            string sqlQuery = $"CALL createnewstudent('{namn}', '{surname}', '{course}', '{gradeID}');";
            // Öppna datatbasen och mata in queryn
            connection.Open();
            MySqlCommand cmd = new MySqlCommand(sqlQuery, connection);

            cmd.ExecuteReader();
            //Stänga databasen
            connection.Close();
        }
        public static int convertGrade(string grade)
        {
            //Konvertering av betygen då de i databasen representeras av nummer 1-4.
            switch (grade.ToUpper())
            {
                case "IG":
                    return 1;
                    break;
                case "G":
                    return 2;
                    break;
                case "VG":
                    return 3;
                    break;
                case "MVG":
                    return 4;
                    break;
                default:
                    Console.WriteLine("Försök igen..");
                    return -1;
                    break;
            }
            
        }
        public static void ReadDB(MySqlConnection connection)
        {
            //Query för att läsa in procedure
            string sqlQuery = $"CALL readstudentcourseandgrade();";

            //öppna och mata in query till db
            connection.Open();
            MySqlCommand cmd = new MySqlCommand(sqlQuery, connection);

            MySqlDataReader reader = cmd.ExecuteReader();
            int count = 1;
            Student.students.Clear();

            while (reader.Read())
            {
                Console.WriteLine($"Nr {count}:   Förnamn: {reader["student_name"]} Efternamn: {reader["student_surname"]} \n        Kurs: {reader["course_name"]} \n        Antal veckor: {reader["course_weeks"]} \n        Betyg: {reader["grade_grading"]}");
                count++;
                new Student(reader["student_name"].ToString(), reader["student_surname"].ToString());
            }

            connection.Close();

            Console.WriteLine("Detta var all relevant data i databasen. (tryck på valfri tangent för att komma tillbaka till menyn)");
            Console.ReadKey();
        }
        public static void ReadItAll(MySqlConnection connection)
        {
            //Query för att läsa in procedure
            string sqlQuery = $"call students.readAll();";

            //öppna och mata in query till db
            connection.Open();
            MySqlCommand cmd = new MySqlCommand(sqlQuery, connection);

            MySqlDataReader reader = cmd.ExecuteReader();
            int count = 1;
            Student.students.Clear();
            while (reader.Read())
            {
                Console.WriteLine($"Nr {count} Förnamn: {reader["student_name"]} Efternamn: {reader["student_surname"]}");
                count++;
              
            }

            connection.Close();

            Console.WriteLine("Detta var allt i databasen. (tryck på valfri tangent för att komma tillbaka till menyn)");
            Console.ReadKey();

        }

    }
}
