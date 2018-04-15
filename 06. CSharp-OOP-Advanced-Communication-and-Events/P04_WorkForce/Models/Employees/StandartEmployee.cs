namespace P04_WorkForce.Models.Employees
{
    class StandartEmployee : Employee
    {
        private const int WorkHoursPerWeek = 40;

        public StandartEmployee(string name) : base(name, WorkHoursPerWeek)
        {
        }
    }
}
