﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WorkHardApp.Entities
{
    public enum Absence
    {
        noAbsence = 0,
        partlyAbsent = 1,
        Absent = 2
    }
    class CheckIn
    {
        private int id;
        private Employee employee;
        private DateTime checkInTime;
        private DateTime checkOutTime;
        private Enum absence;

        public CheckIn(int id, Employee employee, DateTime checkInTime)
            : this(employee, checkInTime)
        {
            Id = id;
        }

        public CheckIn(Employee employee, DateTime checkInTime)
        {
            Employee = employee;
            CheckInTime = checkInTime;
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
    }
}