namespace _15._6Homework
{
    struct Worker
    {
        public int id { get; set; }
        public string dateString { get; set; }
        public string fullName { get; set; }
        public int age { get; set; }
        public int height { get; set; }
        public string birthdayString { get; set; }
        public string city { get; set; }

        public Worker(int id, string dateString, string fullName, int age, int height, string birthdayString, string city)
        {
            this.id = id;
            this.dateString = dateString;
            this.fullName = fullName;
            this.age = age;
            this.height = height;
            this.birthdayString = birthdayString;
            this.city = city;
        }

        public string Print()
        {
            return ("ID: " + id + ", Дата записи: " + dateString + ", ФИО: " + fullName + ", Возраст: " + age + ", Рост: " + height + ", День рождения: " + birthdayString + ", " + city);
        }
    }
}
