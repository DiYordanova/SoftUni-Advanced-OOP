using System;
using System.Collections.Generic;
using System.Linq;

namespace PersonInfo2
{
   public class StartUp
    {
       public static void Main(string[] args)
        {
            Dictionary<string, IBuyer> bayersByName = new Dictionary<string, IBuyer>();         

            int n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                string[] parts = Console.ReadLine().Split();

                if (parts.Length == 3)
                {
                    string name = parts[0];
                    int age = int.Parse(parts[1]);
                    string group = parts[2];

                    bayersByName[name] = new Rebel(name, age, group);
                }

                else 
                {
                    string name = parts[0];
                    int age = int.Parse(parts[1]);
                    string id = parts[2];
                    string birthday = parts[3];

                    bayersByName[name] = new Citizen(name, age, id, birthday);

                }
            }

            while (true)
            {
                string line = Console.ReadLine();

                if (line == "End")
                {
                    break;
                }

                if (!bayersByName.ContainsKey(line))
                {
                    continue;
                }

                else
                {
                    IBuyer bayer = bayersByName[line];
                    bayer.BuyFood();
                }
            }

            var total = bayersByName.Values.Sum(b => b.Food);

            Console.WriteLine(total);
        }
    }
}
