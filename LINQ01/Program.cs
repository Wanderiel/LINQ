//GlobalUsing
//Net v.6

using System.Linq;

namespace LINQ01
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<Criminal> criminals = new List<Criminal>()
            {
                new Criminal("Петров Александр Викторович", 159, 72, "русский", false),
                new Criminal("Сальваторе «Тури» Джулиано", 165, 56, "итальянец", true),
                new Criminal("Эрибе́рто Ласка́но Ласка́но", 170, 58, "мексиканец", false),
                new Criminal("Давуд Ибрагим", 168, 67, "индиец", true),
                new Criminal("Джон Герберт Ди́ллинджер", 178, 85, "американец", true),
                new Criminal("Педро Родригес Фильо", 162, 70, "бразилец", false),
            };

            Detective detective = new Detective();
            detective.FindCriminal(new List<Criminal>(criminals));

            Console.ReadKey();
        }
    }

    public class Detective
    {
        public void FindCriminal(List<Criminal> criminals)
        {
            Console.Write("Введите рост преступника: ");
            int heigth = GetNumber(Console.ReadLine());

            Console.Write("Введите вес преступника: ");
            int weight = GetNumber(Console.ReadLine());

            Console.Write("Введите национальность: ");
            string nationality = Console.ReadLine();

            var result = from Criminal criminal in criminals
                         where
                            nationality != null &&
                            criminal.IsConcluded == false &&
                            criminal.Height == heigth &&
                            criminal.Weight == weight &&
                            criminal.Nationality.ToLower() == nationality.ToLower()
                        select criminal;

            Console.WriteLine();

            foreach (var criminal in result)
                Console.WriteLine($"{criminal.FullName}");
        }

        private int GetNumber(string input)
        {
            if (int.TryParse(input, out int number) == false)
                Console.WriteLine("Ожидалось число.");

            return number;
        }
    }

    public class Criminal
    {
        public Criminal(string fullName, int height, int weight, string nationality, bool isConcluded)
        {
            FullName = fullName;
            Height = height;
            Weight = weight;
            Nationality = nationality;
            IsConcluded = isConcluded;
        }

        public string FullName { get; }
        public int Height { get; }
        public int Weight { get; }
        public string Nationality { get; }
        public bool IsConcluded { get; }
    }
}