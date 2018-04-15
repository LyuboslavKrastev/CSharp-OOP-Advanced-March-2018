using System;
using System.Collections.Generic;
using System.Text;

namespace P04_WorkForce.Models
{
    public class JobEventArgs : EventArgs
    {
        public JobEventArgs(Job job)
        {
            this.job = job;
        }

        public Job job { get; set; }
    }
}
