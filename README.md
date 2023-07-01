# OOP_practice-Simple-
OOP_Practice that represents 3 basic paradigms of OOP on simple Informational System example
Test task description:
Что нужно сделать
Для банка «А» необходимо разработать программу консультанта для просмотра данных клиента.
У консультанта нет прав для изменения или просмотра некоторых данных.
Создайте класс, в котором будут содержаться следующие поля:

Фамилия
Имя
Отчество
Номер телефона
Серия, номер паспорта
Реализуйте методы доступа для следующих ситуаций:

Консультант не имеет доступа к просмотру информации. Вместо серии и номера паспорта он видит
символы: «******************», — если поле не пустое.
Консультант не может изменять поля «Фамилия», «Имя», «Отчество», но может их просматривать.
Консультант может изменить «Номер телефона», но при этом поле должно быть всегда заполнено.

Задание 2

Что нужно сделать
Расширяем программу из задания 1. У нас есть класс для консультанта со своими методами и
полями. Добавьте в программу новый класс для нового пользователя — менеджера.

Менеджер наследует функционал консультанта в дополнение к собственному. При этом менеджер
может добавлять только «Фамилию», «Имя», «Отчество», «Телефон», «Серию, номер паспорта».

Задание 3

Что нужно сделать
Расширяем и изменяем программу из задания 1 и 2. У нас есть два класса для консультанта
и менеджера. У классов есть метод изменения данных.
Исходя из этого, добавьте к данным из задания 1 дополнительные поля:

дата и время изменения записи;
какие данные изменены;
тип изменений;
кто изменил данные (консультант или менеджер).
А также создайте интерфейсы и реализуйте в них методы по изменению существующей записи для
консультанта и менеджера. Для менеджера разрешите добавление новой записи.
Новые поля необходимо заполнять, как только записи клиентов были изменены.
Теперь консультант может изменять только номер телефона клиента, а менеджер может
изменять все данные. 
