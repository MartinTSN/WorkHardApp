using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WorkHardApp.Entities
{
    public enum Absence
    {
        NoAbsence = 0,
        PartlyAbsent = 1,
        Absent = 2
    }
    public class CheckIn
    {
        private int id;
        private Employee employee;
        private DateTime checkInTime;
        private DateTime checkOutTime;
        private Absence absence;

        public CheckIn(int id, Employee employee, DateTime checkInTime, Absence absence)
            : this(employee, checkInTime, absence)
        {
            Id = id;
        }

        public CheckIn(Employee employee, DateTime checkInTime, Absence absence)
        {
            Employee = employee;
            CheckInTime = checkInTime;
            Absence = absence;
        }

        public int Id
        {
            get
            {
                return id;
            }
            set
            {
                if (value >= 0)
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
                if (value != null)
                {
                    employee = value;
                }
                else
                {
                    throw new ArgumentNullException();
                }
            }
        }

        public DateTime CheckInTime
        {
            get
            {
                return checkInTime;
            }
            set
            {
                if (value != null && value <= DateTime.Now)
                {
                    checkInTime = value;
                }
                else
                {
                    throw new ArgumentNullException();
                }
            }
        }

        public DateTime CheckOutTime
        {
            get
            {
                return checkOutTime;
            }
            set
            {
                if (value != null && value > checkInTime)
                {
                    checkOutTime = value;
                }
                else
                {
                    throw new ArgumentNullException();
                }
            }
        }

        public Absence Absence
        {
            get
            {
                return absence;
            }
            set
            {
                absence = value;
            }
        }

    }
}