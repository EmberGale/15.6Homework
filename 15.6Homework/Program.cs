namespace _15._6Homework
{
    internal class Program
    {
        private static Repository repository = new Repository();
        static void Main(string[] args)
        {

            Console.WriteLine("Введите номер комманды:");
            Console.WriteLine("1: Вывести всех работников на экран");
            Console.WriteLine("2: Найти работника по ID");
            Console.WriteLine("3: Удалить работника по ID");
            Console.WriteLine("4: Добавить работника");
            Console.WriteLine("5: Загрузка записей в выбранном диапазоне дат");
            byte choice = byte.Parse(Console.ReadLine());
            string path = Path.GetFullPath(System.IO.Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"..\..\..\"));
            string file = path + @"\Data.txt";
            int id;
            Console.WriteLine(file);
            while (choice < 6 && choice > 0)
            {
                switch (choice)
                {
                    case 1:
                        if (File.Exists(file))
                        {
                            for (int i = 0; i < File.ReadAllLines(file).Length; i++)
                            {
                                Console.WriteLine(repository.GetAllWorkers(i).Print());
                            }
                        } else 
                            Console.WriteLine("Файла не существует");
                        break;
                    case 2:
                        Console.WriteLine("Введите номер ID:");
                        id = int.Parse(Console.ReadLine());
                        Console.WriteLine(repository.GetWorkerById(id).Print());
                        break;
                    case 3:
                        Console.WriteLine("Введите номер ID:");
                        id = int.Parse(Console.ReadLine());
                        repository.DeleteWorker(id);
                        break;
                    case 4:
                        InputData(file);
                        break;
                    case 5:
                        Console.WriteLine("Выберите начальную дату:");
                        DateTime dateFrom = DateTime.Parse(Console.ReadLine());
                        Console.WriteLine("Выберите конечную:");
                        DateTime dateTo = DateTime.Parse(Console.ReadLine());
                        repository.GetWorkersBetweenTwoDates(dateFrom, dateTo);
                        File.ReadAllLines(repository.time_file);
                        for (int i = 0; i < File.ReadAllLines(repository.time_file).Length; i++)
                        {
                            Console.WriteLine(repository.GetAllWorkers(i).Print());
                        }
                        File.Delete(repository.time_file);
                        break;
                    default: break;
                }
                Console.WriteLine("\n Введите номер комманды:");
                choice = byte.Parse(Console.ReadLine());
            }
        }

        static byte ReadCommand()
        {
            byte choice;
            string input = Console.ReadLine();
            if (input == null) choice = 0; else choice = byte.Parse(input);
            return choice;
        }

        static void InputData(string file)
        {
            int id = CreateId(file);
            string dateString = CreateCurrentDate();
            string[] humanValues = CreateHumanValues();

            string fullName = humanValues.First();
            int age = int.Parse(humanValues[1]);
            int height = int.Parse(humanValues[2]);
            string birthdayString = CreateBirthday();
            string city = humanValues.Last();
            Worker worker = new Worker(id, dateString, fullName, age, height, birthdayString, city);
            repository.AddWorker(worker);
        }

        static int CreateId(string file)
        {
            int id;
            if (File.Exists(file))
            {
                var lines = File.ReadAllLines(file);
                id = lines.Length + 1;
            }
            else
            {
                id = 1;
            }
            return id;
        }

        static string CreateCurrentDate()
        {
            DateTime date = DateTime.Now;
            string dateString = date.ToString(System.Globalization.CultureInfo.CreateSpecificCulture("ru-RU"));
            return _ = dateString.Remove(dateString.Length - 3);
        }

        static string[] CreateHumanValues()
        {
            string[] name;

            Console.WriteLine("Введите Фамилию:");
            string lastname = Console.ReadLine();

            Console.WriteLine("Введите Имя:");
            string firstname = Console.ReadLine();

            Console.WriteLine("Введите Отчество:");
            string middlename = Console.ReadLine();

            string fullname = lastname + " " + firstname + " " + middlename;

            Console.WriteLine("Введите Возраст:");
            string age = Console.ReadLine();

            Console.WriteLine("Введите Рост:");
            string height = Console.ReadLine();

            Console.WriteLine("Введите Город:");
            string city = "город " + Console.ReadLine();

            return name = [fullname, age, height, city];
        }

        static string CreateBirthday()
        {
            Console.WriteLine("Введите Год Рождения:");
            int year = int.Parse(Console.ReadLine());

            Console.WriteLine("Введите Месяц Рождения (числом):");
            int month = int.Parse(Console.ReadLine());

            Console.WriteLine("Введите День Рождения:");
            int day = int.Parse(Console.ReadLine());

            DateTime birthDate = new(year, month, day, 00, 00, 00);
            string birthdayString = birthDate.ToString(System.Globalization.CultureInfo.CreateSpecificCulture("ru-RU"));
            return birthdayString = birthdayString.Remove(birthdayString.Length - 9);
        }
    }
}
