//GlobalUsing
//Net v.6

namespace LINQ06
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<Soldier> soldiers = new List<Soldier>()
            {
                new Soldier("Батя", "АК-74", "Полковник", 221),
                new Soldier("Серый", "ПК", "Прапор", 182),
                new Soldier("Глухарь", "Вал", "Лейтенант", 106),
                new Soldier("Заря", "СВДС", "Сержант", 35),
                new Soldier("Первак", "Сапёрная лопата", "Рядовой", 6),
            };

            var newInfo = soldiers
                .Select(soldier => new { soldier.CallSign, soldier.Rank})
                .ToList();

            foreach (var info in newInfo)
                Console.WriteLine($"{info.CallSign} - {info.Rank}");

            Console.WriteLine("\nВсего доброго");
            Console.ReadKey();
        }
    }

    public class Soldier
    {
        public Soldier(string callSign, string weapon, string rank, int workingLife)
        {
            CallSign = callSign;
            Weapon = weapon;
            Rank = rank;
            WorkingLife = workingLife;
        }

        public string CallSign { get; }
        public string Weapon { get; }
        public string Rank { get; }
        public int WorkingLife { get; }
    }
}