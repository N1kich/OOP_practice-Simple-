// See https://aka.ms/new-console-template for more information
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

Consultant consultant = new Consultant("Tom", 24, clients);
Manager manager = new Manager("Tom", 24, clients);

manager.PrintAllClients();

//foreach (var client in clients)
//{
//    Console.WriteLine($"Name - {client.Name}\n Surname - {client.Surname}\n" +
//    $" LastName - {client.LastName}\nPassport - {client.PassportData}\n" +
//    $"phoneNumber - {client.PhoneNumber}");
//}


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