namespace P04_WorkForce.Models.Employees
{
    public abstract class Employee
    {     

        public Employee(string name, int workingHoursPerWeek)
        {
            this.Name = name;
            this.WorkingHoursPerWeek = workingHoursPerWeek;
        }
        public string Name { get; }
        public int WorkingHoursPerWeek { get; }
    }
}
