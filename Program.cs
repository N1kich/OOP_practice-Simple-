﻿// See https://aka.ms/new-console-template for more information
#region Description
//Задание 1


//Что нужно сделать
//Для банка «А» необходимо разработать программу консультанта для просмотра данных клиента.
//У консультанта нет прав для изменения или просмотра некоторых данных.
//Создайте класс, в котором будут содержаться следующие поля:

//Фамилия
//Имя
//Отчество
//Номер телефона
//Серия, номер паспорта
//Реализуйте методы доступа для следующих ситуаций:

//Консультант не имеет доступа к просмотру информации. Вместо серии и номера паспорта он видит
//символы: «******************», — если поле не пустое.
//Консультант не может изменять поля «Фамилия», «Имя», «Отчество», но может их просматривать.
//Консультант может изменить «Номер телефона», но при этом поле должно быть всегда заполнено.


//Советы и рекомендации
//Вы можете использовать как консольное приложение, так и приложение с графическим
//пользовательским интерфейсом. Укажите типы для данных по своему усмотрению.
//Также по своему усмотрению решите, где и как будут храниться данные. 



//Что оценивается
//Используется инкапсуляция.
//Корректное описание данных в классе.
//Наличие конструктора в классе.


//Задание 2



//Что нужно сделать
//Расширяем программу из задания 1. У нас есть класс для консультанта со своими методами и
//полями. Добавьте в программу новый класс для нового пользователя — менеджера.

//Менеджер наследует функционал консультанта в дополнение к собственному. При этом менеджер
//может добавлять только «Фамилию», «Имя», «Отчество», «Телефон», «Серию, номер паспорта».


//Советы и рекомендации
//Вы можете использовать как консольное приложение, так и приложение с графическим
//пользовательским интерфейсом. Укажите типы для данных на своё усмотрение, но так,
//чтобы типы подходили к данным. Также на ваше усмотрение, где и как будут храниться
//данные (рекомендуется текстовый файл с разделителем). Если реализация будет в консольном
//варианте, в таком случае при запуске должен быть выбор, кто работает в системе:
//консультант или менеджер. Если же будет использован графический интерфейс,
//то в таком случае можно использовать компонент WPF ComboBox.



//Что оценивается
//Используется наследование.
//Корректное описание данных в классе.
//Наличие конструктора в классе.


//Задание 3


//Что нужно сделать
//Расширяем и изменяем программу из задания 1 и 2. У нас есть два класса для консультанта
//и менеджера. У классов есть метод изменения данных.
//Исходя из этого, добавьте к данным из задания 1 дополнительные поля:

//дата и время изменения записи;
//какие данные изменены;
//тип изменений;
//кто изменил данные (консультант или менеджер).
//А также создайте интерфейсы и реализуйте в них методы по изменению существующей записи для
//консультанта и менеджера. Для менеджера разрешите добавление новой записи.
//Новые поля необходимо заполнять, как только записи клиентов были изменены.
//Теперь консультант может изменять только номер телефона клиента, а менеджер может
//изменять все данные. 



//Советы и рекомендации
//Вы можете использовать как консольное приложение, так и приложение с графическим
//пользовательским интерфейсом. Укажите типы данных на своё усмотрение,
//но так, чтобы типы подходили к данным. Так же на ваше усмотрение, где и как будут
//храниться данные (рекомендуется текстовый файл с разделителем).
//Если реализация будет в консольном варианте, в таком случае при запуске должен быть выбор,
//кто работает в системе: консультант или менеджер.
//Если же будет использован графический интерфейс, то в таком случае можно использовать
//компонент WPF ComboBox.



//Что оценивается
//Используется полиморфизм.
//Наличие интерфейсов.
//Корректное описание данных в классе.
//Наличие конструктора в классах.
#endregion
using Newtonsoft.Json;
using OOP_practice;
using OOP_practice.Source;

List<Client> clients = new List<Client>();
const string clientsPath = @"Employee.json";
clients = LoadClientsFromJson();
string shutDownCommand = "";





while (shutDownCommand.ToLower() != "exit")
{
    Console.WriteLine("Welcome to IS from 'A' Bank. To log in this IS. Please choose your role :\n1 - Consultant\n2 - Manager");

    Consultant worker;
   
    while (true)
    {
        string userRole = Console.ReadLine();
        string correctUserRole = DeleteSpaceInStr(userRole);

        if (correctUserRole == "1" || correctUserRole == "2")
        {
            worker = CreateNewWorker(userRole);
            break;
        }
        else
        {
            Console.WriteLine("Your role selection isnt' correct. Please try again");
        }
    }
    Console.Clear();
    
    while (shutDownCommand.ToLower() != "e")
    {
        Console.WriteLine(worker.WhatCanIDo());
        string workerCommand = DeleteSpaceInStr(Console.ReadLine());
        WorkerExecution(workerCommand,worker);
        Console.WriteLine("To return to main menu type 'e' or press Enter to continue");
        shutDownCommand = Console.ReadLine();
    }


    Console.WriteLine("To close programm type 'exit' or press Enter to Continue");
    shutDownCommand = Console.ReadLine();
}


#region Create and load clients dataBase
//-------------------------------------------------------------------------------------------
void CreateJson()
{
    string relativePath = @"Employee";
   
    JsonSerializer serializer = new JsonSerializer();
    serializer.NullValueHandling = NullValueHandling.Ignore;
    using (StreamWriter sw = new StreamWriter(Path.GetFullPath(relativePath)+".json"))
    using (JsonWriter writer = new JsonTextWriter(sw))
    {
        writer.Formatting = Formatting.Indented;
        serializer.Serialize(writer, clients);

    }
    
}

List<Client> LoadClientsFromJson()
{

    List<Client> client1 = new List<Client>();
    // deserialize JSON directly from a file
    using (StreamReader file = File.OpenText(Path.GetFullPath(clientsPath)))
    {
        JsonSerializer serializer = new JsonSerializer();
        serializer.NullValueHandling = NullValueHandling.Ignore;
        client1 = (List<Client>)serializer.Deserialize(file, typeof(List<Client>));
    }
    return client1;
}

void ReadAllClients()
{
    string path = @"C:\Users\funn1\source\repos\OOP_practice\employees.txt";
    string[] file = File.ReadAllLines(path);
    foreach (var item in file)
    {
        string tempstr;
        string name = item.Substring(0, item.IndexOf(','));
        tempstr = item.Substring(item.IndexOf(',') + 1);
        string surname = tempstr.Substring(0, tempstr.IndexOf(','));
        tempstr = tempstr.Substring(tempstr.IndexOf(',') + 1);
        string lastname = tempstr.Substring(0, tempstr.IndexOf(','));
        tempstr = tempstr.Substring(tempstr.IndexOf(',') + 1);
        string passport = tempstr.Substring(0, tempstr.IndexOf(','));
        tempstr = tempstr.Substring(tempstr.IndexOf(',') + 1);
        string phonenumber = tempstr.Substring(0, tempstr.IndexOf(','));

        clients.Add(new Client(name, surname, lastname, passport, phonenumber));


    }

}

#endregion
#region IS work methods

string DeleteSpaceInStr(string baseStr)
{
    if (!String.IsNullOrEmpty(baseStr))
    {
        string[] separatedStr = baseStr.Split(" ", StringSplitOptions.RemoveEmptyEntries);
        string newStr = String.Join("", separatedStr);
        return newStr;
    }

    return String.Empty;
}


bool isWorkerDataCorrect(string userNewName, string userAgeStr)
{

    if ((!String.IsNullOrEmpty(userNewName) && !String.IsNullOrEmpty(userAgeStr)))
    {
        return true;
    }
    else
    {
        return false;
    }
}

byte ConvertStrToInt(string stringToConvert, byte startRange, byte endRange)
{
    byte convertedNumber;

    if (byte.TryParse(stringToConvert, out convertedNumber) && convertedNumber >= startRange && convertedNumber <= endRange)
    {
        return convertedNumber;
    }
    else
    {
        return 0;
    }
}

void EntryWorkerData(out string workerName, out byte workerAge)
{
    bool flag = true;

    workerName = "";
    string workerAgeStr = "";
    workerAge = 0;

    while (flag)
    {
        Console.WriteLine("Entry Name");
        workerName = DeleteSpaceInStr(Console.ReadLine());

        Console.WriteLine("Entry Age");
        workerAgeStr = DeleteSpaceInStr(Console.ReadLine());

        if (isWorkerDataCorrect(workerName, workerAgeStr))
        {
            workerAge = ConvertStrToInt(workerAgeStr, 18, 65);
            if (workerAge != 0)
            {
                flag = false;
            }
            else Console.WriteLine("Age is not a number || out the range between 18 and 65, try again");
        }
        else 
            Console.WriteLine("Your input data is null/empty/ invalid string format to convert, try again:\nName - entry a not null str\nAge - a random number between 18 and 65");
    }
}

Consultant CreateNewWorker(string userRole)
{
    Consultant worker;

    string workerName;
    byte workerAge;

    EntryWorkerData(out workerName, out workerAge);
    if (userRole == "1")
    {
        worker = new Consultant(workerName, workerAge, clients);        
    }
    else
    {
        worker = new Manager(workerName, workerAge, clients);
    }
 
    return worker;
}

void WorkerExecution(string workerCommand, Consultant worker)
{

    byte indexOfClient = default(byte);

    if (!String.IsNullOrEmpty(workerCommand))
    {
        switch (workerCommand)
        {
            case "1":
                worker.PrintAllClients();
                break;
            case "2":
                indexOfClient = GetIndexOfClientFromConsole(worker);
                Console.WriteLine(worker.GetInfoAboutClient(indexOfClient));
                break;
            case "3":

                indexOfClient = GetIndexOfClientFromConsole(worker);

                if (worker is Consultant)
                    ChangeClientDataMode(indexOfClient, worker);
                else 
                    ChangeClientDataMode(indexOfClient, worker as Manager);               
                break;
            case "4":
                AddNewClient(worker as Manager);
                break;
            default:
                break;
        }

    }
    else
    {
        Console.WriteLine("Unexpected input command, try again");
    }
}


void ChangeTheClientData(Consultant worker, int indexOfClient, string clientField = "PhoneNumber")
{
    Console.WriteLine($"Input the new {clientField} of choosen client");
    string newData = Console.ReadLine();
    bool isExecutionIsCorrect = worker.ChangeClientInfo(indexOfClient, newData, clientField);
    if (isExecutionIsCorrect)
    {
        Console.WriteLine($"Data is changed!\nNew clientData - \n" +
        $"{worker.GetInfoAboutClient(indexOfClient)}"); 
    } else Console.WriteLine("Something gone wrong. Avoid the empty strings and follow instructions above"); ;

}

byte GetIndexOfClientFromConsole(Consultant worker)
{
    Console.WriteLine($"Please type the index of client in clentDB\nTotal clients - {worker.CountClients}\nIndex starts from 0 to {worker.CountClients - 1}");
    byte indexOfClient = default(byte);

    while (true)
    {
        string indexStr = Console.ReadLine();
        indexOfClient = ConvertStrToInt(indexStr, 0, worker.CountClients);
        if (indexOfClient != 0)
        {

            break;
        }
        else Console.WriteLine("Your input index isn't correct, please try again");
    }

    return indexOfClient;

}

void ChangeClientDataMode(byte indexOfClient, Consultant worker)
{
    if (worker is Manager)
    {
        string exitCommand = "";
        while (exitCommand.ToLower() != "exit")
        {
            Console.WriteLine("As Manager you can change all clientData\nSo type the following field you want to change\n" +
            "1 - Name\n2 - Surname\n3 - LastName\n4 - PassportData\n5 - PhoneNumber");
            string clientField = Console.ReadLine();

            ChangeTheClientData(worker as Manager, indexOfClient, clientField);

            Console.WriteLine("Type exit to close the ChangeClientDataMode or press Enter to Continue");
            exitCommand = Console.ReadLine();

        }
    }
    else if (worker is Consultant)
    {
        Console.WriteLine("As Consultant you can change only PhoneNumber of choosen client\nPlease type the new PhoneNumber." +
            " PhoneNumber contains only digits and its length == 10");
        ChangeTheClientData(worker, indexOfClient);

    }
}

void AddNewClient(Manager worker)
{
    Console.WriteLine("Add new client to clientsDB requires the following parameters:\nEnter Name");
    string newName = Console.ReadLine();
    Console.WriteLine("Enter Surname");
    string newSurname = Console.ReadLine();
    Console.WriteLine("Enter LastName");
    string newLastName = Console.ReadLine();
    Console.WriteLine("Enter the PassportData. Remember it contains only digits and its length == 10");
    string newPassportData = Console.ReadLine();
    Console.WriteLine("Enter the PhoneNumber. Remember it contains only digits and its length == 10");
    string newPhoneNumber = Console.ReadLine();
    string message = worker.AddNewClient(newName,newSurname, newLastName, newPassportData, newPhoneNumber);
    Console.WriteLine(message);
}
#endregion