//GlobalUsing
//Net v.6

namespace LINQ07
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<Soldier> soldiers1 = new List<Soldier>()
            {
                new Soldier("Багратион А.В.", "АК-74", "Полковник", 221),
                new Soldier("Тургоев И.Я.", "ПК", "Прапор", 182),
                new Soldier("Кольцевой П.А.", "Вал", "Лейтенант", 106),
                new Soldier("Булкин И.И.", "СВДС", "Сержант", 35),
                new Soldier("Колев Ю.М.", "Сапёрная лопата", "Рядовой", 6),
            };

            List<Soldier> soldiers2 = new List<Soldier>()
            {
                new Soldier("Витоев В.И.", "АК-74", "Полковник", 189),
                new Soldier("Корневой М.П.", "ПК", "Прапор", 167),
                new Soldier("Белых А.П.", "Вал", "Лейтенант", 95),
                new Soldier("Петров И.Р.", "СВДС", "Сержант", 42),
                new Soldier("Бубенцов М.А.", "Сапёрная лопата", "Рядовой", 9),
            };

            char symbol = 'б';

            var selectedSoldiers = soldiers1
                .Where(soldier => soldier.Name
                    .ToLower()
                    .StartsWith(symbol))
                .ToList();

            soldiers1 = soldiers1.Except(selectedSoldiers).ToList();
            soldiers2 = soldiers2.Union(selectedSoldiers).ToList();

            soldiers2.ForEach(soldier => Console.WriteLine(soldier.Name));

            Console.WriteLine("\nВсего доброго");
            Console.ReadKey();
        }
    }

    public class Soldier
    {
        public Soldier(string name, string weapon, string rank, int workingLife)
        {
            Name = name;
            Weapon = weapon;
            Rank = rank;
            WorkingLife = workingLife;
        }

        public string Name { get; }
        public string Weapon { get; }
        public string Rank { get; }
        public int WorkingLife { get; }
    }
}