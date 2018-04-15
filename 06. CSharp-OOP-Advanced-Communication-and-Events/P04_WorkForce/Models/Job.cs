using P04_WorkForce.Models.Employees;
using System;

namespace P04_WorkForce.Models
{
    public class Job
    {
        public event StartUp.JobDoneEventHandler JobDone;

        public Job(string name, int hoursRequired, Employee employee)
        {
            this.Name = name;
            this.HoursRequired = hoursRequired;
            this.Employee = employee;
            this.IsDone = false;
        }

        public string Name { get; }

        public int HoursRequired { get; private set; }

        public Employee Employee { get; }

        public bool IsDone { get; private set; }

        public void Update()
        {
            this.HoursRequired -= Employee.WorkingHoursPerWeek;
            if (this.HoursRequired <= 0 && !this.IsDone)
            {
                if (JobDone != null)
                {
                    this.JobDone(this, new JobEventArgs(this));
                }
            }
        }

        public void OnJobDone(object sender, EventArgs e)
        {
            Console.WriteLine($"Job {this.Name} done!");
            this.IsDone = true;
        }

        public override string ToString()
        {
            return $"Job: {this.Name} Hours Remaining: {this.HoursRequired}";
        }
    }
}
