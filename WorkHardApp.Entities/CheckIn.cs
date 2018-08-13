using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WorkHardApp.Entities
{
    class CheckIn
    {
        private int id;
        private Employee employee;
        private DateTime checkInTime;
        private DateTime checkOutTime;

        public int Id
        {
            get
            {
                return id;
            }
            set
            {
                if(value >= 0)
                {
                    id = value;
                }
                else
                {
                    throw new ArgumentOutOfRangeException();
                }
            }
        }

        public Employee Employee
        {
            get
            {
                return employee;
            }
            set
            {
                if()
            }
        }
    }
}
