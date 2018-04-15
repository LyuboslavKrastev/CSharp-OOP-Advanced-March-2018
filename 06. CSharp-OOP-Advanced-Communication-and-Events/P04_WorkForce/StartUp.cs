using P04_WorkForce.Models;
using P04_WorkForce.Models.Employees;
using System;
using System.Collections.Generic;
using System.Linq;

namespace P04_WorkForce
{
   
   public class StartUp
    {
        public delegate void JobDoneEventHandler(object sender, JobEventArgs jea);

        static void Main(string[] args)
        {
            JobList jobs = new JobList();

            List<Employee> employees = new List<Employee>();

            string input;

            while ((input = Console.ReadLine())!= "End")
            {
                string[] inputArgs = input.Split();
                string command = inputArgs[0];
                inputArgs = inputArgs.Skip(1).ToArray();

                switch (command)
                {
                    case "Job":
                        string jobName = inputArgs[0];
                        int workingHours = int.Parse(inputArgs[1]);
                        string employeeName = inputArgs[2];
                        Employee employee = employees.FirstOrDefault(e => e.Name == employeeName);
                        Job currentJob = new Job(jobName, workingHours, employee);
                        jobs.Add(currentJob);
                        currentJob.JobDone += currentJob.OnJobDone;
                        break;

                    case "StandardEmployee":
                        string standartEmployeeName = inputArgs[0];
                        employees.Add(new StandartEmployee(standartEmployeeName));
                        break;

                    case "PartTimeEmployee":
                        string partTimeEmployeeName = inputArgs[0];
                        employees.Add(new PartTimeEmployee(partTimeEmployeeName));
                        break;

                    case "Pass":
                        foreach (var job in jobs)
                        {
                            job.Update();
                            if (!jobs.Any())
                            {
                                break;
                            }
                        }
                        break;

                    case "Status":
                        foreach (var job in jobs.Where(j => j.IsDone == false))
                        {
                            Console.WriteLine(job.ToString());
                        }
                        break;
                }
            }
        }
    }
}
