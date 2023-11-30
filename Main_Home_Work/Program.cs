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
            string EventName = Console.ReadLine();

            Console.WriteLine("Введите дату мероприятия в формате xx.xx.xxxx:");
            DateTime EventDate = DateTime.Parse(Console.ReadLine());

            Console.WriteLine("Введите количество участников от каждой группы:");
            int ParticipantsPerGroup = int.Parse(Console.ReadLine());

            Console.WriteLine("Введите количество групп:");
            int NumberOfGroups = int.Parse(Console.ReadLine());

            /*розыгрыш участников мероприятия*/
            List<Student> EventParticipants = ChooseEventParticipants(students, ParticipantsPerGroup, NumberOfGroups);

            /*запись информации о мероприятии и выбранных студентах в файл*/
            WriteEventToFile(EventName, EventDate, EventParticipants);

            Console.WriteLine("Мероприятие создано и информация записана в файл.\n");


            /*Задача 2 Написать программу для слежения за интересующим вас событием.*/
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

            bool EventMatched = false;

            /*проверка у кого совпадает увлечение с введенным событием*/
            foreach (Person person in people)
            {
                if (person.Hobby == EVENT)
                {
                    Console.WriteLine(person.Name + " реагирует на событие: " + EVENT);
                    EventMatched = true;
                }
            }

            /* сообщение, если ни у кого не совпало увлечение с введенным событием*/
            if (!EventMatched)
            {
                Console.WriteLine("Ни у кого нет увлечения по данному событию.");
            }
            Console.ReadKey();
        }
        /*Задача 1*/
        static List<Student> ReadStudentsFromFile(string FileName)
        {
            List<Student> students = new List<Student>();

            /*исключения на случай, если файл не найден*/
            try
            {
                StreamReader reader = new StreamReader(FileName);
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
                Console.WriteLine($"Файл {FileName} не найден.");
            }

            return students;
        }

        static List<Student> ChooseEventParticipants(List<Student> students, int ParticipantsPerGroup, int NumberOfGroups)
        {
            /* выбор студентов, не участвовавших в последних трех мероприятиях*/
            List<Student> EligibleStudents = students.Where(student => !student.ParticipateLastThreeEvents).ToList();

            /*желающих участвовать самостоятельно*/
            List<Student> SoloParticipants = EligibleStudents.Where(student => student.WantsToParticipateAlone).ToList();

            /*для группового участия*/
            List<Student> GroupParticipants = EligibleStudents.Where(student => !student.WantsToParticipateAlone).ToList();

            /*участники из каждой группы*/
            List<Student> EventParticipants = new List<Student>();

            Random random = new Random();

            for (int i = 1; i <= NumberOfGroups; i++)
            {
                // Проверка, есть ли студенты для данной группы
                if (GroupParticipants.Count(stud => stud.Group == i.ToString()) > 0)
                {
                    // Выбор случайных студентов из группы
                    List<Student> group = GroupParticipants
                        .Where(stud => stud.Group == i.ToString())
                        .OrderBy(stud => random.Next())
                        .Take(ParticipantsPerGroup)
                        .ToList();

                    EventParticipants.AddRange(group);
                }
            }

            /* оставшиеся места*/
            int RemainingSpots = ParticipantsPerGroup * NumberOfGroups - EventParticipants.Count;
            List<Student> AdditionalParticipants = GroupParticipants.OrderBy(stud => random.Next())
                .Take(RemainingSpots)
                .ToList();

            EventParticipants.AddRange(AdditionalParticipants);

            /* желающие участвовать самостоятельно */
            EventParticipants.AddRange(SoloParticipants);

            return EventParticipants;
        }

        static void WriteEventToFile(string EventName, DateTime EventDate, List<Student> EventParticipants)
        {
            string EventFileName = "события.txt";
        }
    }
}
