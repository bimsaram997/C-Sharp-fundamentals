using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Genrics_and_collections
{
    public class Employee
    {
    
        public Employee(string name)
        {
            Name= name;
        }

        public string Name { get; set; }

        // Override Equals and GetHashCode to compare by the Name property
        public override bool Equals(object obj)
        {
            if (obj == null || GetType() != obj.GetType())
            {
                return false;
            }
            return Name == ((Employee)obj).Name;
        }

        public override int GetHashCode()
        {
            return Name.GetHashCode();
        }
    }
}
