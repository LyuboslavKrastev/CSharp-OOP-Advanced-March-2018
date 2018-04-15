using BashSoft.Contracts;
using BashSoft.Contracts.RepositoryContracts;
using BashSoft.DataStructures;
using BashSoft.Exceptions;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;

namespace BashSoft.Repository
{
    public class StudentsRepository : IDatabase
    {
        private bool isDatainitialized = false;
        private Dictionary<string, ICourse> courses;
        private Dictionary<string, IStudent> students;
        private IDataFilter filter;
        private IDataSorter sorter;

        public StudentsRepository(IDataFilter filter, IDataSorter sorter)
        {
            this.filter = filter;
            this.sorter = sorter;
        }

        public void LoadData(string fileName)
        {
            if (this.isDatainitialized)
            {
                throw new ArgumentException(ExceptionMessages.DataAlreadyInitializedException);
            }

            this.students = new Dictionary<string, IStudent>();
            this.courses = new Dictionary<string, ICourse>();

            OutputWriter.WriteMessageOnNewLine("Reading data...");
            this.ReadData(fileName);
        }

        public void UnloadData()
        {
            if (!this.isDatainitialized)
            {
                throw new ArgumentException(ExceptionMessages.DataNotInitializedExceptionMessage);
            }

            this.students = null;
            this.courses = null;
            this.isDatainitialized = false;
        }

        private void ReadData(string fileName)
        {
            string path = SessionData.currentPath + "\\" + fileName;

            if (File.Exists(path))
            {
                string pattern = @"(?<course>[A-Z][a-zA-Z#\+]*_[A-Z][a-z]{2}_\d{4})\s+(?<username>[A-Za-z]+\d{2}_\d{2,4})\s(?<score>[\s0-9]+)";

                Regex rgx = new Regex(pattern);
                string[] allInputLines = File.ReadAllLines(path);

                for (int line = 0; line < allInputLines.Length; line++)
                {
                    if (!string.IsNullOrEmpty(allInputLines[line]) && rgx.IsMatch(allInputLines[line]))
                    {
                        Match currentMatch = rgx.Match(allInputLines[line]);
                        string courseName = currentMatch.Groups["course"].Value;
                        string username = currentMatch.Groups["username"].Value;
                        string scoreStr = currentMatch.Groups["score"].Value;


                        try
                        {
                            int[] scores = scoreStr.Split(' ', System.StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();

                            if (scores.Any(x => x > 100 || x < 0))
                            {
                                OutputWriter.DisplayException(ExceptionMessages.InvalidScore);
                                continue;
                            }

                            if (scores.Length > Course.NumberOfTasksOnExam)
                            {
                                OutputWriter.DisplayException(InvalidNumberOfScoresException.InvalidNumberOfScores);
                                continue;
                            }

                            if (!this.students.ContainsKey(username))
                            {
                                this.students.Add(username, new Student(username));
                            }

                            if (!this.courses.ContainsKey(courseName))
                            {
                                this.courses.Add(courseName, new Course(courseName));
                            }

                            ICourse course = this.courses[courseName];
                            IStudent student = this.students[username];

                            student.EnrollInCourse(course);
                            student.SetMarkOnCourse(courseName, scores);

                            course.EnrollStudent(student);
                        }
                        catch (FormatException fex)
                        {
                            OutputWriter.DisplayException(fex.Message + $"at line : {line}");
                            throw;
                        }
                    }
                }
                isDatainitialized = true;
                OutputWriter.WriteMessageOnNewLine("Data read!");
            }
            else
            {
                throw new InvalidPathException();
            }
        }

        private bool IsQueryForCoursePossible(string courseName)
        {
            if (isDatainitialized)
            {
                if (this.courses.ContainsKey(courseName))
                {
                    return true;
                }
                else
                {
                    OutputWriter.DisplayException(ExceptionMessages.InexistingCourseInDataBase);
                }
            }
            else
            {
                OutputWriter.DisplayException(ExceptionMessages.DataNotInitializedExceptionMessage);
            }

            return false;
        }

        private bool IsQueryForStudentPossiblе(string courseName, string studentUsername)
        {
            if (IsQueryForCoursePossible(courseName) && this.courses[courseName].StudentsByName.ContainsKey(studentUsername))
            {
                return true;
            }
            else
            {
                OutputWriter.DisplayException(ExceptionMessages.InexistingStudentInDataBase);
            }

            return false;
        }

        public void GetStudentScoresFromCourse(string courseName, string username)
        {
            if (IsQueryForStudentPossiblе(courseName, username))
            {
                OutputWriter.PrintStudent(new KeyValuePair<string, double>(username, 
                    this.courses[courseName].StudentsByName[username].MarksByCourseName[courseName]));
            }
        }

        public void GetAllStudentsFromCourse(string courseName)
        {
            if (IsQueryForCoursePossible(courseName))
            {
                OutputWriter.WriteMessageOnNewLine($"{courseName}:");
                foreach (var studentMarksEntry in this.courses[courseName].StudentsByName)
                {
                    this.GetStudentScoresFromCourse(courseName, studentMarksEntry.Key);
                }
            }
        }

        public void FilterAndTake(string courseName, string givenFilter, int? studentsToTake = null)
        {
            if (IsQueryForCoursePossible(courseName))
            {
                if (studentsToTake == null)
                {
                    studentsToTake = this.courses[courseName].StudentsByName.Count;
                }

                Dictionary<string, double> marks = this.courses[courseName].StudentsByName
                     .ToDictionary(x => x.Key, x => x.Value.MarksByCourseName[courseName]);

                filter.FilterAndTake(marks, givenFilter, studentsToTake.Value);
            }
        }

        public void OrderAndTake(string courseName, string comparison, int? studentsToTake = null)
        {
            if (IsQueryForCoursePossible(courseName))
            {
                if (studentsToTake == null)
                {
                    studentsToTake = this.courses[courseName].StudentsByName.Count;
                }

                Dictionary<string, double> marks = this.courses[courseName].StudentsByName
                    .ToDictionary(x => x.Key, x => x.Value.MarksByCourseName[courseName]);

                sorter.OrderAndTake(marks, comparison, studentsToTake.Value);
            }
        }

        public ISimpleOrderedBag<ICourse> GetAllCoursesSorted(IComparer<ICourse> cmp)
        {
            SimpleSortedList<ICourse> sortedCourses = new SimpleSortedList<ICourse>(cmp);

            if (this.courses == null)
            {
                throw new NullReferenceException(ExceptionMessages.DataNotInitializedExceptionMessage);
            }

            sortedCourses.AddAll(this.courses.Values);

            return sortedCourses;
        }

        public ISimpleOrderedBag<IStudent> GetAllStudentsSorted(IComparer<IStudent> cmp)
        {
            SimpleSortedList<IStudent> sortedStudents = new SimpleSortedList<IStudent>(cmp);

            if (this.students == null)
            {
                throw new NullReferenceException(ExceptionMessages.DataNotInitializedExceptionMessage);
            }

            sortedStudents.AddAll(this.students.Values);

            return sortedStudents;
        }
    }
}
