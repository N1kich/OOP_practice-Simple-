using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP_practice.Source
{
    public  class Manager : Consultant
    {
        public Manager(string name, int age, List<Client> clients) :
            base(name, age, clients)
        {

        }

        protected override string GetPassportData(int indexOfClient)
        {
            return clients[indexOfClient].PassportData;
        }

        public void ChangeClientInfo(int indexOfClient, string clientField, string newData)
        {
            if (isNewClientInfoCorrect(newData, clientField))
            {
                switch (clientField)
                {
                    case "Name":
                        clients[indexOfClient].Name = newData;
                        break;
                    case "Surname":
                        clients[indexOfClient].Surname = newData;
                        break;
                    case "LastName":
                        clients[indexOfClient].LastName = newData;
                        break;
                    case "PassportData":
                        clients[indexOfClient].PassportData = newData;
                        break;
                    case "PhoneNumber":
                        clients[indexOfClient].PhoneNumber = newData;
                        break;
                    default:
                        break;
                }
            }
            
        }

        
        bool isNewClientInfoCorrect(string newClientInfo, string clientField)
        {
            if (clientField == "PassportData" || clientField == "PhoneNumber")
            {
                return base.isNewClientInfoCorrect(newClientInfo);
            }
            else
            {
                string[] splittedStr = newClientInfo.Split(" ", StringSplitOptions.RemoveEmptyEntries);
                string tempStr = String.Join("", splittedStr);
                if (tempStr != "")
                {
                    return true;
                }
                else
                    return false;
            }
            
        }

        
    }   
    
}
