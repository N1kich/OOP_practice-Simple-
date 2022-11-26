﻿using System;
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

        //public void SetUpClientDB(List<Client> clients)
        //{
        //    this.clients=clients;
        //}

        protected virtual string GetPassportData(int indexOfClient)
        {
            string passportData = clients[indexOfClient].PassportData;
            string[] splittedPassport = passportData.Split(separators);
            return String.Join("*", splittedPassport);
        }

        public void ChangeClientNumber(string newNumber, int indexOfClient)
        {
            if (isNewClientInfoCorrect(newNumber))
            {
                clients[indexOfClient].PhoneNumber = newNumber;
            }
        }

        protected bool isNewClientInfoCorrect(string newNumber)
        {
            string[] splittedStr = newNumber.Split(" ", StringSplitOptions.RemoveEmptyEntries);
            string tempStr = String.Join("", splittedStr);
            if (tempStr != "" && tempStr.Length == 10)
            {
                return true;
            }
            else
                return false;
        }

        public virtual string GetInfoAboutClient(int indexOfClient)
        {
            return ($"Name - {clients[indexOfClient].Name}\nSurname - {clients[indexOfClient].Surname}\n" +
               $"LastName - {clients[indexOfClient].LastName}\nPassport - " +
               $"{GetPassportData(indexOfClient)}\n" +
               $"phoneNumber - {clients[indexOfClient].PhoneNumber}\n" +
               $"{clients[indexOfClient].GetChangeLog()}");
        }

        public void PrintAllClients()
        {
            for (int i = 0; i < clients.Count; i++)
            {
                Console.WriteLine("\t" + i.ToString() + "\n" + GetInfoAboutClient(i)
                    + "\n--------------\n");
            }
        }

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
    }
}
