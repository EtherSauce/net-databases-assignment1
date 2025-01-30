string? choice;
string file = "marioRoster.txt";
do
{
    // ask user a question
    Console.WriteLine("1) Show current roster.");
    Console.WriteLine("2) Add character to roster.");
    Console.WriteLine("Enter any other key to exit.");
    // input response
    choice = Console.ReadLine();

    if (choice == "1")
    {
        // read data from file
        if (File.Exists(file))
        {
            StreamReader sr = new(file);
            while (!sr.EndOfStream)
            {
                string? line = sr.ReadLine();
                // convert string to array
                string[] arr = String.IsNullOrEmpty(line) ? [] : line.Split('|');
                // display array data
                Console.WriteLine("ID: {0}, Name: {1}, Relationship to Mario: {2}", arr[0], arr[1], arr[2]);
            }
            sr.Close();
        }
        else
        {
            Console.WriteLine("File does not exist");
        }
    }
    else if (choice == "2")
    {
        // create file from data
        StreamWriter sw = new(file);

        sw.WriteLine("1|Luigi|Twin brother");
        sw.WriteLine("2|Wario|Archnemesis");
        sw.WriteLine("3|Princess Peach|Romantic Interest");
        for (int i = 0; i < 7; i++)
        {
            // ask a question
            Console.WriteLine("Enter a Character (Y/N)?");
            // input the response
            string? resp = Console.ReadLine()?.ToUpper();
            // if the response is anything other than "Y", stop asking
            if (resp != "Y") { break; }
            // prompt for course name
            Console.WriteLine("Enter the ID.");
            // save the course name
            string? id = Console.ReadLine();
            // prompt for course grade
            Console.WriteLine("Enter the Name.");
            // save the course grade
            string? name = Console.ReadLine()?.ToUpper();
            Console.WriteLine("Enter the Relationship to Mario.");
            string? relationship = Console.ReadLine()?.ToUpper();
            sw.WriteLine("{0}|{1}|{2}", id, name, relationship);
        }
        sw.Close();
    }
} while (choice == "1" || choice == "2");