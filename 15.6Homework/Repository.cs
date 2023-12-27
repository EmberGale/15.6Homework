using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _15._6Homework
{
    internal class Repository
    {
        private Worker[] workers;
        private string filePath;

        public Repository(string filePath)
        {
            this.filePath = filePath;

            // Создаем файл, если его нет
            if (!File.Exists(filePath))
            {
                File.Create(filePath).Close();
            }
        }

        public void ShowAllWorkers()
        {
            try
            {
                foreach (Worker worker in workers = GetAllWorkers())
                {
                    ShowWorker(worker);
                }
            }
            catch 
            {
                Console.WriteLine("Пусто");
            }
        }

        public void DeleteWorker(int id)
        {
            Worker[] workers = GetAllWorkers().Where(w => w.Id != id).ToArray();
            WriteWorkersToFile(workers);
        }

        public void AddWorker(Worker worker)
        {
            worker.Id = GetAllWorkers().Max(w => w.Id) + 1;
            string line = FormatWorker(worker);

            using (StreamWriter writer = File.AppendText(filePath))
            {
                writer.WriteLine(line);
            }
        }

        public string ShowWorkerById(int id)
        {
            Worker worker;
            string[] lines = File.ReadAllLines(filePath);

            foreach (string line in lines)
            {
                worker = ParseWorker(line);
                if (worker.Id == id)
                {
                    ShowWorker(worker);
                    return "";
                }
            }

            return "Не найдено";
        }

        public void ShowWorkersBetweenDates(DateTime dateFrom, DateTime dateTo)
        {
            Worker[] workers = GetWorkersBetweenTwoDates(dateFrom, dateTo);
            foreach (Worker worker in workers)
            {
                ShowWorker(worker);
            }
        }

        private Worker ParseWorker(string line)
        {
            string[] parts = line.Split('#');
            return new Worker
            {
                Id = int.Parse(parts[0]),
                AddedDate = DateTime.Parse(parts[1]),
                FIO = parts[2],
                Age = int.Parse(parts[3]),
                Height = int.Parse(parts[4]),
                BirthDate = DateTime.Parse(parts[5]),
                BirthPlace = parts[6]
            };
        }

        private string FormatWorker(Worker worker)
        {
            return $"{worker.Id}#{worker.AddedDate:dd.MM.yyyy HH:mm}#{worker.FIO}#{worker.Age}#{worker.Height}#{worker.BirthDate:dd.MM.yyyy}#{worker.BirthPlace}";
        }

        private void ShowWorker(Worker worker)
        {
            Console.WriteLine($"ID: {worker.Id}");
            Console.WriteLine($"Дата добавления: {worker.AddedDate:dd.MM.yyyy HH:mm}");
            Console.WriteLine($"Ф.И.О.: {worker.FIO}");
            Console.WriteLine($"Возраст: {worker.Age}");
            Console.WriteLine($"Рост: {worker.Height}");
            Console.WriteLine($"Дата рождения: {worker.BirthDate:dd.MM.yyyy}");
            Console.WriteLine($"Место рождения: {worker.BirthPlace}\n");
        }

        private Worker[] GetWorkersBetweenTwoDates(DateTime dateFrom, DateTime dateTo)
        {
            Worker[] workers = GetAllWorkers().Where(w => w.AddedDate >= dateFrom && w.AddedDate <= dateTo).ToArray();
            return workers;
        }

        private Worker[] GetAllWorkers()
        {
            string[] lines = File.ReadAllLines(filePath);

            return lines.Select(ParseWorker).ToArray();
        }

        private void WriteWorkersToFile(Worker[] workers)
        {
            File.WriteAllLines(filePath, workers.Select(FormatWorker));
        }
    }
}
