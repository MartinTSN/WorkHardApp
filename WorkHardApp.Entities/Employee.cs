using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WorkHardApp.Entities
{
    public class Employee
    {
        private int id;
        private string firstName;
        private string lastName;

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

        public string FirstName
        {
            get
            {
                return firstName;
            }
            set
            {
                if (!String.IsNullOrEmpty(value))
                {
                    firstName = value;
                }
                else
                {
                    throw new ArgumentNullException();
                }
            }
        }

        public string LastName
        {
            get
            {
                return lastName;
            }
            set
            {
                if (!String.IsNullOrEmpty(value))
                {
                    lastName = value;
                }
                else
                {
                    throw new ArgumentNullException();
                }
            }
        }
    }
}