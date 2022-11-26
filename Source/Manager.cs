using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP_practice.Source
{
    public  class Manager : Consultant
    {
        public Manager(string name, byte age, List<Client> clients) :
            base(name, age, clients)
        {

        }

        protected override string GetPassportData(int indexOfClient)
        {
            return clients[indexOfClient].PassportData;
        }

        public override bool ChangeClientInfo(int indexOfClient, string newData, string clientField = "PhoneNumber")
        {

            string oldData = "";
            if (isNewClientInfoCorrect(newData, clientField))
            {
                switch (clientField)
                {
                    case "Name":
                        oldData = clients[indexOfClient].Name;
                        clients[indexOfClient].Name = newData;                        
                        break;
                    case "Surname":
                        oldData = clients[indexOfClient].Surname;
                        clients[indexOfClient].Surname = newData;
                        break;
                    case "LastName":
                        oldData = clients[indexOfClient].LastName;
                        clients[indexOfClient].LastName = newData;
                        break;
                    case "PassportData":
                        oldData=clients[indexOfClient].PassportData;
                        clients[indexOfClient].PassportData = newData;
                        break;
                    case "PhoneNumber":
                        oldData = clients[indexOfClient].PhoneNumber;
                        clients[indexOfClient].PhoneNumber = newData;
                        break;
                    default:

                        break;
                }
                clients[indexOfClient].SetChangeData(clientField, this, Changetype.Rewrite, oldData);
                return true;
            }
            else return false;
            
        }

        public string AddNewClient(string Name, string Surname, string LastName, string PassportData,
            string PhoneNumber )
        {
            if (isNewClientInfoCorrect(Name) && isNewClientInfoCorrect(Surname) && isNewClientInfoCorrect(LastName) && isNewClientInfoCorrect(PassportData, "PassportData")
                && isNewClientInfoCorrect(PhoneNumber,"PhoneNumber"))
            {
                clients.Add(new Client(Name, Surname, LastName, PassportData, PhoneNumber));
                return "A new client succesfully added!";
            }
            else
            {
                return "Something gone wrong, try again and type correct Client Data";
            }
        }
        
        bool isNewClientInfoCorrect(string newClientInfo, string clientField="Name")
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
