using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP_practice.Source
{
    public class Client
    {

        List<ChangeLog> _changeLog;

        string _name;
        public string Name {
            get { return _name;} 
            set
            {
                _name = value;
            } 
        }

        string _surname;
        public string Surname {
            get { return _surname; }
            set
            {
                _surname = value;
            }
        }

        string _lastName;
        public string LastName {
            get { return _lastName; }
            set
            {
                _lastName = value;
            }
        }

        string _passportData;

        
        public string PassportData {
            get
            {
                return _passportData;
            }
            set
            {
                _passportData = value;
            }
        }

        string _phoneNumber;
        public string PhoneNumber { 
            get { return _phoneNumber; }
            set { _phoneNumber = value; }
        }

        public void SetChangeData(string clientFieldName, IWorkWithClient workWithClient, Changetype changetype, string oldData)
        {
           _changeLog.Add(new ChangeLog(DateTime.Now, clientFieldName, oldData, workWithClient, changetype));

        }

        public string GetChangeLog()
        {
            string changeLog = "";
            if (_changeLog != default(List<ChangeLog>))
            {
                
                foreach (var note in _changeLog)
                {
                    changeLog += note.GetChangeLog();
                }
            }
            else
            {
                changeLog = "ChangeLog is empty!";
            }
           
            return changeLog;
        }

        public Client(string name, string surname, string lastName, string passportData,
            string phoneNumber)
        {
            _name = name;
            _surname = surname;
            _lastName = lastName;
            _passportData = passportData;
            _phoneNumber = phoneNumber;
            _changeLog = new List<ChangeLog>();

            
        }
    }
}
