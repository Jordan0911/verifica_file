namespace verifica_file
{
    internal class Program
    {
        static Random rand = new Random();
        static void Lotto(string[]cities)
        { int placeholder = 0;        
            int[] rolls = new int[5];
            File.Delete("lotto.csv");
            using (StreamWriter sw = new StreamWriter("lotto.csv", true))
            {
                for (int j = 0; j < cities.Length; j++)
                {
                    for (int i = 0; i < rolls.Length; i++)
                    {
                        placeholder = rand.Next(1, 91);
                        if (rolls.Contains(placeholder) == true)
                        {
                            placeholder = rand.Next(1, 91);
                            rolls[i]=placeholder;
                        }
                        else
                        {
                            rolls[i] = placeholder;
                        }
                    }
                    sw.Write($"{cities[j]} ");
                    for (int i = 0; i < rolls.Length; i++)
                    {
                        sw.Write($"{rolls[i]}, ");
                    }
                    sw.WriteLine();
                }
            }
        }
        static void Winner_finder(string[] cities)
        {
            string[] momentary = new string[3];
            List<string> names = new List<string>();
            List<string> cities_tried = new List<string>();
            List<string> number = new List<string>();
            using (StreamReader sw =new StreamReader("giocatelotto.csv"))
            {                
                string line = sw.ReadLine();
                while (line != null) 
                {
                    momentary = line.Split(',');
                    names.Add(momentary[0]);
                    cities_tried.Add(momentary[1]);
                    number.Add(momentary[2]);
                }
            }
            using (StreamReader ws = new StreamReader("lotto.csv"))
            {
                string line = ws.ReadLine();
                while (line != null) 
                { 
                
                }
            }
        }
            static void Suspect_messages()
            {
                string[] split_message = new string[2];
                List<string> names = new List<string>();
                List<string> messages = new List<string>();
                using (StreamReader sw = new StreamReader("messages.csv"))
                {
                    string line = sw.ReadLine();
                    while (line != null)
                    {
                        split_message = line.Split(',');
                        if (line.Contains("Vinci") == true)
                        {
                            messages.Add(split_message[1]);
                            names.Add(split_message[0]);
                        }
                        else if (line.Contains("Offerta") == true)
                        {
                            messages.Add(split_message[1]);
                            names.Add(split_message[0]);
                        }
                        else if (line.Contains("Compra") == true)
                        {
                            messages.Add(split_message[1]);
                            names.Add(split_message[0]);
                        }
                        line = sw.ReadLine();
                    }
                }

                File.Delete("suspect_messages.csv");
                using (StreamWriter ws = new StreamWriter("suspect_messages.csv", true))
                {
                    ws.Write("sender");
                    ws.Write("mittent");
                    ws.WriteLine();
                    for (int i = 0; i < messages.Count; i++)
                    {
                        ws.WriteLine($"{names[i]},{messages[i]}");
                    }
                }
            }
            static void Main(string[] args)
            {
            string[] cities = { "Bari", "Cagliari", "Firenze", "Genova", "Milano", "Napoli", "Palermo", " Roma", "Torino", "Venezia", "Nazionale" };
            Console.WriteLine("Hello, World!");
                Suspect_messages();
                Lotto(cities);
            Winner_finder(cities);
            }
        
    }
}
