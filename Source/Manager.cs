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

        /// <summary>
        /// return passport data for Manager
        /// </summary>
        /// <param name="indexOfClient"></param>
        /// <returns></returns>
        protected override string GetPassportData(int indexOfClient)
        {
            return clients[indexOfClient].PassportData;
        }

        /// <summary>
        /// Change the client info by choosen parameter and new data. Returns true if rewrite is done
        ///and false if something gone wrong
        /// </summary>
        /// <param name="indexOfClient"></param>
        /// <param name="newData"></param>
        /// <param name="clientField"></param>
        /// <returns></returns>
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

        /// <summary>
        /// Add new client by new data to the clientsDB. Returns string that represents the result
        /// </summary>
        /// <param name="Name"></param>
        /// <param name="Surname"></param>
        /// <param name="LastName"></param>
        /// <param name="PassportData"></param>
        /// <param name="PhoneNumber"></param>
        /// <returns></returns>
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
        
        /// <summary>
        /// check if incoming data is not empty or null or whitespace and contains in special cases only digits
        /// </summary>
        /// <param name="newClientInfo"></param>
        /// <param name="clientField"></param>
        /// <returns></returns>
        bool isNewClientInfoCorrect(string newClientInfo, string clientField="Name")
        {
            if (clientField == "PassportData" || clientField == "PhoneNumber")
            {
                return base.isNewClientInfoCorrect(newClientInfo);
            }
            else
            {
                return !String.IsNullOrWhiteSpace(newClientInfo);
            }
            
        }

        /// <summary>
        /// return string that represents what can do this worker
        /// </summary>
        /// <returns></returns>
        public override string WhatCanIDo()
        {
            return base.WhatCanIDo() + $"4 - Add new Client";
        }


    }   
    
}
