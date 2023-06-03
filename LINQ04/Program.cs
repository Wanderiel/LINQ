//GlobalUsing
//Net v.6

namespace LINQ03
{
    internal class Program
    {
        static void Main(string[] args)
        {
            PlayerFilter filter = new PlayerFilter();
            List<Player> players = new List<Player>()
            {
                new Player("Эктор", 1, 0),
                new Player("Сальваторе", 54, 542),
                new Player("Эриберто", 76, 1587),
                new Player("Матео", 23, 235),
                new Player("Давуд", 31, 317),
                new Player("Джон", 19, 198),
                new Player("Педро", 64, 809),
                new Player("Эжен", 57, 612),
                new Player("Ильзе", 34, 341),
                new Player("НаполеонI", 80, 6004),
                new Player("Колтон", 42, 421),
            };
            int count = 3;

            Console.WriteLine("Список всех игроков: ");
            filter.Print(players);

            filter.PrintTopByLevel(new List<Player>(players), count);
            filter.PrintTopByPower(new List<Player>(players), count);

            Console.WriteLine("\nВсего доброго");
            Console.ReadKey();
        }
    }

    public class PlayerFilter
    {
        public void PrintTopByLevel(List<Player> players, int count)
        {
            count = Math.Min(players.Count, count);

            var topPlayers = players
                .OrderByDescending(player => player.Level)
                .Take(count);

            Console.WriteLine(new string('*', Console.WindowWidth));
            Console.WriteLine($"Топ {count} игроков по уровню:");
            Print(topPlayers);
        }

        public void PrintTopByPower(List<Player> players, int count)
        {
            count = Math.Min(players.Count, count);

            var topPlayers = players
                .OrderByDescending(player => player.Power)
                .Take(count);

            Console.WriteLine(new string('*', Console.WindowWidth));
            Console.WriteLine($"Топ {count} игроков по Силе:");
            Print(topPlayers);
        }

        public void Print(IEnumerable<Player> players)
        {
            const int Width1 = -20;
            const int Width2 = 3;

            Console.WriteLine($"{"NickName",Width1} | {"Lvl",Width2} | {"Pow",Width2}");

            foreach (Player player in players)
                player.ShowInfo();
        }
    }

    public class Player
    {
        public Player(string nickName, int level, int power)
        {
            NickName = nickName;
            Level = level;
            Power = power;
        }

        public string NickName { get; }
        public int Level { get; }
        public int Power { get; }

        public void ShowInfo()
        {
            const int Width1 = -20;
            const int Width2 = 3;

            Console.WriteLine($"{NickName,Width1} | {Level,Width2} | {Power,Width2}");
        }
    }
}