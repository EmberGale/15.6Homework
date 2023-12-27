namespace _15._6Homework
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string path = Path.GetFullPath(System.IO.Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"..\..\..\"));
            string file = path + @"\Data.txt";

            Repository repository = new Repository(file);
            Program program = new Program();

            program.StartProgram(file, repository);

        }

        void StartProgram(string file, Repository repository)
        {
            Console.WriteLine("Введите номер комманды:");
            Console.WriteLine("1: Вывести всех работников на экран");
            Console.WriteLine("2: Найти работника по ID");
            Console.WriteLine("3: Удалить работника по ID");
            Console.WriteLine("4: Добавить работника");
            Console.WriteLine("5: Загрузка записей в выбранном диапазоне дат");

            Console.WriteLine(file);
            while (true)
            {
                switch (ReadCommand())
                {
                    case 1:
                        ShowAllWorkers(repository);
                        break;
                    case 2:
                        FindID(repository);
                        break;
                    case 3:
                        DeleteByID(repository);
                        break;
                    case 4:
                        AddWorker(repository);
                        break;
                    case 5:
                        FindByDateRange(repository);
                        break;
                    default: break;
                }
                Console.WriteLine("\n Введите номер комманды:");
            }
        }

        byte ReadCommand()
        {
            byte choice;
            string input = Console.ReadLine();
            if (input == null) choice = 0; else choice = byte.Parse(input);
            return choice;
        }

        void ShowAllWorkers(Repository repository)
        {
            repository.ShowAllWorkers();
        }

        void FindID(Repository repository)
        {
            Console.WriteLine("Введите номер ID:");
            int id = int.Parse(Console.ReadLine());
            Console.WriteLine(repository.ShowWorkerById(id));
        }

        void DeleteByID(Repository repository)
        {
            Console.WriteLine("Введите номер ID:");
            int id = int.Parse(Console.ReadLine());
            repository.DeleteWorker(id);
        }

        void AddWorker(Repository repository)
        {
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
            string city = Console.ReadLine();

            Console.WriteLine("Введите Год Рождения:");
            int year = int.Parse(Console.ReadLine());

            Console.WriteLine("Введите Месяц Рождения (числом):");
            int month = int.Parse(Console.ReadLine());

            Console.WriteLine("Введите День Рождения:");
            int day = int.Parse(Console.ReadLine());

            DateTime birthDate = new(year, month, day, 00, 00, 00);

            repository.AddWorker(new Worker
            {
                AddedDate = DateTime.Now,
                FIO = fullname,
                Age = int.Parse(age),
                Height = int.Parse(height),
                BirthDate = birthDate,
                BirthPlace = city
            });

            Console.WriteLine("Добавлен");
        }

        void FindByDateRange(Repository repository)
        {
            Console.WriteLine("Введите Год Начала Отсчета");
            int year = int.Parse(Console.ReadLine());

            Console.WriteLine("Введите Месяц Начала Отсчета");
            int month = int.Parse(Console.ReadLine());

            Console.WriteLine("Введите День Начала Отсчета");
            int day = int.Parse(Console.ReadLine());

            DateTime dateFrom = new(year, month, day, 00, 00, 00);

            Console.WriteLine("Введите Год Конца Отсчета");
            year = int.Parse(Console.ReadLine());

            Console.WriteLine("Введите Месяц Конца Отсчета");
            month = int.Parse(Console.ReadLine());

            Console.WriteLine("Введите День Конца Отсчета");
            day = int.Parse(Console.ReadLine());

            DateTime dateTo = new(year, month, day, 00, 00, 00);

            repository.ShowWorkersBetweenDates(dateFrom, dateTo);
        }
    }
}
