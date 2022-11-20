using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP_practice.Source
{
    internal class Client
    {
        string _name;
        public string Name { get { return _name; } }

        string _surname;
        public string Surname { get { return _surname; } }

        string _lastName;
        public string LastName { get { return _lastName; } }

        string _passportData;

        char[] separators;
        public string PassportData {
            get
            {
                string[] splittedPassport = _passportData.Split(separators);
                return String.Join("*", splittedPassport);
            }
        }

        string _phoneNumber;
        public string PhoneNumber { 
            get { return _phoneNumber; }
            set 
            {
                if (value == null)
                {
                    Console.WriteLine("Phone number can't be null");
                }
                else
                {
                    _phoneNumber = value;
                }
            }
        }

        public Client(string name, string surname, string lastName, string passportData,
            string phoneNumber)
        {
            _name = name;
            _surname = surname;
            _lastName = lastName;
            _passportData = passportData;
            _phoneNumber = phoneNumber;

            separators = new char[]  { '0','1','2','3', '4','5', '6', '7', '8', '9', };
        }
    }
}
