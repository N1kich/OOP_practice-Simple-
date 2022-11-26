using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP_practice.Source
{
    public interface IWorkWithClient
    {
        public bool ChangeClientInfo(int indexOfClient, string newData, string clientField = "PhoneNumber");
        public void PrintAllClients();
        public string GetInfoAboutClient(int indexOfClient);
    }
}
