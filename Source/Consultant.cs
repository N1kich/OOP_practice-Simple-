using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP_practice.Source
{
    public class Consultant: IWorkWithClient
    {
        protected List<Client> clients;

        char[] separators;

        public byte CountClients => (byte)clients.Count;

        string _name;
        public string Name { get { return _name; } set { _name = value; } }

        int _age;
        public byte Age { get; set; }

        public Consultant()
        {
            _name = "Tom";
            _age = 24;
            clients = new List<Client>();
            separators = new char[] { '0', '1', '2', '3', '4', '5', '6', '7', '8', '9', };
        }

        public Consultant(string _name, byte age, List<Client> clients)
        {
            this._name=_name;
            _age = age;
            this.clients = clients;
            separators = new char[] { '0', '1', '2', '3', '4', '5', '6', '7', '8', '9', };

        }


        /// <summary>
        /// Get PassportData for Consultant. Replace passportData by *
        /// </summary>
        /// <param name="indexOfClient"></param>
        /// <returns></returns>
        protected virtual string GetPassportData(int indexOfClient)
        {
            string passportData = clients[indexOfClient].PassportData;
            string[] splittedPassport = passportData.Split(separators);
            return String.Join("*", splittedPassport);
        }


        /// <summary>
        /// check if str contains digits
        /// </summary>
        /// <param name="strToCheck"></param>
        /// <returns></returns>
        bool isStrContainsDigits(string strToCheck)
        {
            bool isStrContainsDigits = true;
            foreach (char ch in strToCheck)
            {
                if (!Char.IsDigit(ch))
                {
                    isStrContainsDigits = false;
                    break;
                }
            }
            return isStrContainsDigits;
        }

        /// <summary>
        /// check if client info correct
        /// </summary>
        /// <param name="newNumber"></param>
        /// <returns></returns>
        protected bool isNewClientInfoCorrect(string newNumber)
        {
            
            if (!String.IsNullOrWhiteSpace(newNumber) && newNumber.Length == 10 
                && isStrContainsDigits(newNumber))
            {
                return true;
            }
            else
                return false;
        }

        /// <summary>
        /// return str that represents all info about client by index
        /// </summary>
        /// <param name="indexOfClient"></param>
        /// <returns></returns>
        public virtual string GetInfoAboutClient(int indexOfClient)
        {
            return ($"Name - {clients[indexOfClient].Name}\nSurname - {clients[indexOfClient].Surname}\n" +
               $"LastName - {clients[indexOfClient].LastName}\nPassport - " +
               $"{GetPassportData(indexOfClient)}\n" +
               $"phoneNumber - {clients[indexOfClient].PhoneNumber}\n" +
               $"{clients[indexOfClient].GetChangeLog()}");
        }

        /// <summary>
        /// print all clients from clientsDB
        /// </summary>
        public void PrintAllClients()
        {
            for (int i = 0; i < clients.Count; i++)
            {
                Console.WriteLine("\t" + i.ToString() + "\n" + GetInfoAboutClient(i)
                    + "\n--------------\n");
            }
        }

        /// <summary>
        /// Change the client info and return bool result if its done or not 
        /// </summary>
        /// <param name="indexOfClient"></param>
        /// <param name="newData"></param>
        /// <param name="clientField"></param>
        /// <returns></returns>
        public virtual bool ChangeClientInfo(int indexOfClient, string newData, string clientField = "PhoneNumber")
        {
            if (isNewClientInfoCorrect(newData))
            {
                string oldData = clients[indexOfClient].PhoneNumber;
                clients[indexOfClient].PhoneNumber = newData;
                clients[indexOfClient].SetChangeData(clientField,this,Changetype.Rewrite,oldData); 
                return true;
            } else return false;

        }

        /// <summary>
        /// return string that represents what can do this worker
        /// </summary>
        /// <returns></returns>
        public virtual string WhatCanIDo()
        {
            string description = $"User {this.GetType().Name} has the following abilities:\n" +
                $"1 - Print the clients list\n" +
                $"2 - Choose the client by index\n" +
                $"3 - Edit client Info\n";
            return description;
        }
    }
}
