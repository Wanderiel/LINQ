//GlobalUsing
//Net v.6

namespace LINQ05
{
    internal class Program
    {
        static void Main(string[] args)
        {
            PreserveFactory factory = new PreserveFactory();
            int count = 12;
            List<Preserve> preserves = factory.CreateBox(count);

            DateOnly currentDate = DateOnly.FromDateTime(DateTime.Now);
            Console.WriteLine($"Сегодня: {currentDate}");

            Console.WriteLine("Имеющиеся запасы консерв:");
            Print(preserves);

            var overdue = preserves
                .Where(preserve => preserve.ExpirationDate < currentDate)
                .ToList();

            Console.WriteLine("\nПросроченные запасы:");
            Print(overdue);

            Console.WriteLine("\nВсего доброго");
            Console.ReadKey();
        }

        public static void Print(List<Preserve> preserves)
        {
            const int Width = -16;

            Console.WriteLine($"{"Название",Width} | дата произ.| срок годн.");
            preserves.ForEach(preserve => preserve.ShowInfo());
        }
    }

    public class Preserve
    {
        private string _title = "Говядина тушёная";

        public Preserve(DateOnly manufacturedDate, int shelfLife)
        {
            ManufacturedDate = manufacturedDate;
            ExpirationDate = ManufacturedDate.AddMonths(shelfLife);
        }

        public DateOnly ManufacturedDate { get; }
        public DateOnly ExpirationDate { get; }

        public void ShowInfo() =>
            Console.WriteLine($"{_title} | {ManufacturedDate} | {ExpirationDate}");
    }

    public class PreserveFactory
    {
        private readonly Random _random = new Random();

        public List<Preserve> CreateBox(int count)
        {
            List<Preserve> box = new List<Preserve>();

            for (int i = 0; i < count; i++)
                box.Add(Create());

            return box;
        }

        private Preserve Create()
        {
            int minYear = 2020;
            int maxYear = DateTime.Now.Year;
            int maxMount = 12;
            int maxDay = 31;
            int[] mounts = { 12, 18, 24, 30, 36, 42, 48, 54, 60 };

            int year = _random.Next(minYear, maxYear);

            DateOnly manufacturedDate = DateOnly
                .FromDateTime(new DateTime(year, 1, 1))
                .AddMonths(_random.Next(maxMount))
                .AddDays(_random.Next(maxDay));

            int shelfLife = mounts[_random.Next(mounts.Length)];

            return new Preserve(manufacturedDate, shelfLife);
        }
    }
}