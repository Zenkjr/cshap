using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Student
{
    class Students
    {
        private string rollNumber;
        private string name;
        private string email;
        private string phone;

        public Students(string rollNumber, string name, string email, string phone)
        {
            this.RollNumber = rollNumber;
            this.Name = name;
            this.Email = email;
            this.Phone = phone;
        }

        public string RollNumber { get => rollNumber; set => rollNumber = value; }
        public string Name { get => name; set => name = value; }
        public string Email { get => email; set => email = value; }
        public string Phone { get => phone; set => phone = value; }
    }
}
