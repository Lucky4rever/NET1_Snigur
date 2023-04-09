namespace DOTNET.Examples.NET2
{
    class User
    {
        public string Name { get; set; }
        public string Company { get; set; }
        public int Age { get; set; }
        public User()
        {
        }
        /// <param name="name">Им'я</param>
        /// <param name="company">Компанія</param>
        /// <param name="age">Вік</param>
        public User(string name, string company, int age)
        {
            Name = name;
            Company = company;
            Age = age;
        }
    }
}
