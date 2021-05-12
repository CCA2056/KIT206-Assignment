using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RAP
{
    public enum EmploymentLevel { student, A, B, C, D, E}
    class Position
    {
        public EmploymentLevel Level { get; set; }
        public DateTime Start { get; set; }
        public DateTime End { get; set; }

    }
}
