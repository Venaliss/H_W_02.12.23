using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Main_Home_Work;

namespace Main_Home_Work
{
    class Program
    {
        static void Main(string[] args)
        {

            // Чтение всех студентов из файла
            List<Student> students = ReadStudentsFromFile("студенты.txt");

            // Ввод информации о новом мероприятии
            Console.WriteLine("Введите название мероприятия:");
            string eventName = Console.ReadLine();

            Console.WriteLine("Введите дату мероприятия в формате xx.xx.xxxx:");
            DateTime eventDate = DateTime.Parse(Console.ReadLine());

            Console.WriteLine("Введите количество участников от каждой группы:");
            int participantsPerGroup = int.Parse(Console.ReadLine());

            Console.WriteLine("Введите количество групп:");
            int numberOfGroups = int.Parse(Console.ReadLine());

            // Розыгрыш участников мероприятия
            List<Student> eventParticipants = ChooseEventParticipants(students, participantsPerGroup, numberOfGroups);

            // Запись информации о мероприятии и выбранных студентах в файл
            WriteEventToFile(eventName, eventDate, eventParticipants);

            Console.WriteLine("Мероприятие создано и информация записана в файл.");
        }

        static List<Student> ReadStudentsFromFile(string fileName)
        {
            List<Student> students = new List<Student>();

            // Обработка исключения на случай, если файл не найден
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
            // Выбор студентов, не участвовавших в последних трех мероприятиях
            List<Student> eligibleStudents = students.Where(student => !student.ParticipateLastThreeEvents).ToList();

            // Выбор студентов, желающих участвовать самостоятельно
            List<Student> soloParticipants = eligibleStudents.Where(student => student.WantsToParticipateAlone).ToList();

            // Выбор студентов для группового участия
            List<Student> groupParticipants = eligibleStudents.Where(student => !student.WantsToParticipateAlone).ToList();

            // Выбор участников из каждой группы
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

            // Заполнение оставшихся мест случайными студентами
            int remainingSpots = participantsPerGroup * numberOfGroups - eventParticipants.Count;
            List<Student> additionalParticipants = groupParticipants.OrderBy(stud => random.Next())
                .Take(remainingSpots)
                .ToList();

            eventParticipants.AddRange(additionalParticipants);

            // Добавление участников, желающих участвовать самостоятельно
            eventParticipants.AddRange(soloParticipants);

            return eventParticipants;
        }

        static void WriteEventToFile(string eventName, DateTime eventDate, List<Student> eventParticipants)
        {
            string fileName = "события.txt";
        }
    }
}
