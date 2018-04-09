namespace P02_ExtendedDatabase
{
    public class Person
    {
        public int Id { get; }
        public string UserName { get; }

        public Person(int id, string userName)
        {
            this.Id = id;
            this.UserName = userName;
        }

    }
}
