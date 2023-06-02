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
                new Criminal("Петров Александр Викторович", "кража"),
                new Criminal("Сальваторе «Тури» Джулиано", "убийство"),
                new Criminal("Эрибе́рто Ласка́но Ласкано", "кража"),
                new Criminal("Давуд Ибрагим", "убийство"),
                new Criminal("Джон Герберт Диллинджер", "поджог"),
                new Criminal("Педро Родригес Фильо", "поджог"),
            };

            Jail jail = new Jail(new List<Criminal>(criminals));

            jail.ShowPrisoners();
            Console.WriteLine();

            string crimeAmnesty = "кража";
            jail.ReleaseOnAmnesty(crimeAmnesty);

            jail.ShowPrisoners();

            Console.ReadKey();
        }
    }

    public class Jail
    {
        private List<Criminal> _criminals;

        public Jail(List<Criminal> criminals)
        {
            _criminals = criminals;
        }

        public void ShowPrisoners()
        {
            Console.WriteLine("В заключении:");

            foreach (Criminal criminal in _criminals)
                Console.WriteLine($"{criminal.FullName} [{criminal.Crime}]");
        }

        public void ReleaseOnAmnesty(string crimeAmnesty)
        {
            Console.WriteLine($"Объявлена амнистия по преступлению: {crimeAmnesty}");

            var result = from Criminal criminal in _criminals
                         where criminal.Crime != crimeAmnesty
                         select criminal;

            _criminals = new List<Criminal>(result);
        }
    }

    public class Criminal
    {
        public Criminal(string fullName, string crime)
        {
            FullName = fullName;
            Crime = crime;
        }

        public string FullName { get; }
        public string Crime { get; }
    }

}