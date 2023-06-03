//GlobalUsing
//Net v.6

namespace LINQ03
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<Diseased> patients = new List<Diseased>()
            {
                new Diseased("Эктор Луис Саласар", 35, "Аллергия"),
                new Diseased("Сальваторе Тури Джулиано", 54, "Шизофрения"),
                new Diseased("Эриберто Ласкано Ласкано", 76, "Катаракта"),
                new Diseased("Матео Мессина Денаро", 23, "Педикулёз"),
                new Diseased("Давуд Ибрагим", 31, "Вывих"),
                new Diseased("Джон Герберт Диллинджер", 26, "Педикулёз"),
                new Diseased("Педро Родригес Фильо", 64, "Шизофрения"),
                new Diseased("Эжен Франсуа Видок", 57, "Аллергия"),
                new Diseased("Ильзе Ренате Краузе", 34, "Вывих"),
                new Diseased("Наполеон I Бонапарт", 47, "Шизофрения"),
                new Diseased("Колтон Харрис-Мур", 54, "Катаракта"),
            };

            Hospital hospital = new Hospital(patients);
            hospital.Work();

            Console.WriteLine("\nВсего доброго");
            Console.ReadKey();
        }
    }

    public class Hospital
    {
        private List<Diseased> _patients;

        public Hospital(List<Diseased> patients)
        {
            _patients = patients;
        }

        public void Work()
        {
            const ConsoleKey CommandFilterByFullName = ConsoleKey.D1;
            const ConsoleKey CommandFilterByAge = ConsoleKey.D2;
            const ConsoleKey CommandFilterByDisease = ConsoleKey.D3;
            const ConsoleKey CommandExit = ConsoleKey.Escape;

            List<Diseased> sorted = new List<Diseased>();
            bool isWork = true;

            while (isWork)
            {
                Console.Clear();
                Console.WriteLine($"[{CommandFilterByFullName}] - список пациентов по ФИО");
                Console.WriteLine($"[{CommandFilterByAge}] - список пациентов по возрасту");
                Console.WriteLine($"[{CommandFilterByDisease}] - список пациентов с болезнью");
                Console.WriteLine($"[{CommandExit}] - выход");

                ConsoleKey key = Console.ReadKey(true).Key;

                switch (key)
                {
                    case CommandFilterByFullName:
                        sorted = ShowPatientsByFullName();
                        break;

                    case CommandFilterByAge:
                        sorted = ShowPatientsByAge();
                        break;

                    case CommandFilterByDisease:
                        sorted = ShowPatientsByDisease();
                        break;

                    case CommandExit:
                        isWork = false;
                        break;
                }

                if (isWork)
                    PrintInfo(sorted);
            }
        }

        private List<Diseased> ShowPatientsByFullName() =>
            _patients.OrderBy(diseased => diseased.FullName).ToList();

        private List<Diseased> ShowPatientsByAge() =>
            _patients.OrderBy(diseased => diseased.Age).ToList();

        private List<Diseased> ShowPatientsByDisease()
        {
            Console.Clear();

            var diseases = _patients
                .Select(patient => patient.Disease)
                .Distinct()
                .OrderBy(disease => disease)
                .ToList();

            diseases.ForEach(disease => Console.WriteLine(disease));

            Console.Write("\nВыберите заболевание из списка: ");
            string input = Console.ReadLine();

            return _patients
                .Where(diseased => diseased.Disease.Equals(input, StringComparison.OrdinalIgnoreCase))
                .ToList();
        }

        private void PrintInfo(List<Diseased> patients)
        {
            Console.Clear();
            Console.WriteLine("Список пациентов:");

            patients.ForEach(diseased => diseased.ShowInfo());

            Console.ReadKey();
        }
    }

    public class Diseased
    {
        public Diseased(string fullName, int age, string disease)
        {
            FullName = fullName;
            Age = age;
            Disease = disease;
        }

        public string FullName { get; }
        public int Age { get; }
        public string Disease { get; }

        public void ShowInfo()
        {
            const int Width1 = -25;
            const int Width2 = 2;

            Console.WriteLine($"{FullName,Width1} | возраст: {Age,Width2} | заболевание: {Disease}");
        }
    }
}