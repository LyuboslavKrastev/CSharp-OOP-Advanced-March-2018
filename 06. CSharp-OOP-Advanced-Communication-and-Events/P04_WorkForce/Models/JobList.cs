
using System.Collections.Generic;

namespace P04_WorkForce.Models
{
    public class JobList : List<Job>
    {
        public void OnJobDone(object sender, JobEventArgs jea)
        {
            this.Remove(jea.job);
        }
    }
}
