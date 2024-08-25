using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ice_Task_3
{
    public class RoyalFamilyMember
    {
        public string Name { get; set; }
        public DateTime DateOfBirth { get; set; }
        public bool IsAlive { get; set; }

        public RoyalFamilyMember(string name, DateTime dateOfBirth, bool isAlive)
        {
            Name = name;
            DateOfBirth = dateOfBirth;
            IsAlive = isAlive;
        }
    }
}