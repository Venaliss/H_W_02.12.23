using Main_Home_Work.Main_DZ_2;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Main_Home_Work
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Задача 1 - Необходимо создать программу, которая будет из текстового файла считывать всех студентов\nи их принадлежность к группе.Далее пользователь создает мероприятие с необходимым\nколичеством участников, оно записывается в специально созданный файл.Далее дозаписать\nв файл с мероприятием всех участников мероприятия.\n");
            /*читаем всех студентов из файла*/
            List<Student> students = ReadStudentsFromFile("студенты.txt");

            /*вводим информацию о новом мероприятии*/
            Console.WriteLine("Введите название мероприятия:");
            string eventName = Console.ReadLine();

            Console.WriteLine("Введите дату мероприятия в формате xx.xx.xxxx:");
            DateTime eventDate = DateTime.Parse(Console.ReadLine());

            Console.WriteLine("Введите количество участников от каждой группы:");
            int participantsPerGroup = int.Parse(Console.ReadLine());

            Console.WriteLine("Введите количество групп:");
            int numberOfGroups = int.Parse(Console.ReadLine());

            /*розыгрыш участников мероприятия*/
            List<Student> eventParticipants = ChooseEventParticipants(students, participantsPerGroup, numberOfGroups);

            /*запись информации о мероприятии и выбранных студентах в файл*/
            WriteEventToFile(eventName, eventDate, eventParticipants);

            Console.WriteLine("Мероприятие создано и информация записана в файл.\n");



            Console.WriteLine("Задача 2 - У каждого есть хобби. Написать программу для слежения за интересующим вас событием(выход сериала, концерт и т.д.)");
            List<Person> people = new List<Person>()
            {
                new Person("Алексей", "компьютерные игры"),
                new Person("Мария", "кино"),
                new Person("Дмитрий", "спорт")
            };

            /*событие от пользователя*/
            Console.Write("Введите тематику события: ");
            string EVENT = Console.ReadLine();

            bool eventMatched = false;

            /*проверка у кого совпадает увлечение с введенным событием*/
            foreach (Person person in people)
            {
                if (person.Hobby == EVENT)
                {
                    Console.WriteLine(person.Name + " реагирует на событие: " + EVENT);
                    eventMatched = true;
                }
            }

            /* сообщение, если ни у кого не совпало увлечение с введенным событием*/
            if (!eventMatched)
            {
                Console.WriteLine("Ни у кого нет увлечения по данному событию.");
            }
            Console.ReadKey();
        }


        /*Задача 1*/
        static List<Student> ReadStudentsFromFile(string fileName)
        {
            List<Student> students = new List<Student>();

            /*исключения на случай, если файл не найден*/
            try
            {
                StreamReader reader = new StreamReader(fileName);
                string line;

                while ((line = reader.ReadLine()) != null)
                {
                    string[] data = line.Split(';');
                    Student student = new Student
                    {
                        Name = data[0],
                        Group = data[1],
                        ParticipateLastThreeEvents = bool.Parse(data[2]),
                        WantsToParticipateAlone = bool.Parse(data[3])
                    };
                    students.Add(student);
                }

                reader.Close();
            }
            catch (FileNotFoundException)
            {
                Console.WriteLine($"Файл {fileName} не найден.");
            }

            return students;
        }

        static List<Student> ChooseEventParticipants(List<Student> students, int participantsPerGroup, int numberOfGroups)
        {
            /* выбор студентов, не участвовавших в последних трех мероприятиях*/
            List<Student> eligibleStudents = students.Where(student => !student.ParticipateLastThreeEvents).ToList();

            /*желающих участвовать самостоятельно*/
            List<Student> soloParticipants = eligibleStudents.Where(student => student.WantsToParticipateAlone).ToList();

            /*для группового участия*/
            List<Student> groupParticipants = eligibleStudents.Where(student => !student.WantsToParticipateAlone).ToList();

            /*участники из каждой группы*/
            List<Student> eventParticipants = new List<Student>();

            Random random = new Random();

            for (int i = 1; i <= numberOfGroups; i++)
            {
                // Проверка, есть ли студенты для данной группы
                if (groupParticipants.Count(stud => stud.Group == i.ToString()) > 0)
                {
                    // Выбор случайных студентов из группы
                    List<Student> group = groupParticipants
                        .Where(stud => stud.Group == i.ToString())
                        .OrderBy(stud => random.Next())
                        .Take(participantsPerGroup)
                        .ToList();

                    eventParticipants.AddRange(group);
                }
            }

            /* оставшиеся места*/
            int remainingSpots = participantsPerGroup * numberOfGroups - eventParticipants.Count;
            List<Student> additionalParticipants = groupParticipants.OrderBy(stud => random.Next())
                .Take(remainingSpots)
                .ToList();

            eventParticipants.AddRange(additionalParticipants);

            /* желающих участвовать самостоятельно */
            eventParticipants.AddRange(soloParticipants);

            return eventParticipants;
        }

        static void WriteEventToFile(string eventName, DateTime eventDate, List<Student> eventParticipants)
        {
            string fileName = "события.txt";
        }
    }
}
