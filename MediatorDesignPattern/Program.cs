using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MediatorDesignPattern
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Mediator mediator = new Mediator();
            Teacher ali = new Teacher(mediator);
            Student student = new Student(mediator);
            Student student1 = new Student(mediator);
            student.name = "ishak";
            student1.name = "adil";
            mediator.students = new List<Student>();

            mediator.teacher = ali;
            mediator.students.Add(student);
            mediator.students.Add(student1);

            ali.RecieveQuestion("anlıyor muyumu acaba?", student);
            ali.AnswerQuestion("anlayacaksınız inşallah",student);
            

            ali.SendNewImage("ders1.jpg");

            Console.ReadLine();
        }
    }

    abstract class CourseMember
    {
        protected Mediator Mediator;

        protected CourseMember(Mediator mediator)
        {
            Mediator = mediator;
        }
    }

    class Teacher : CourseMember
    {
        public Teacher(Mediator mediator) : base(mediator)
        {
        }

        public void RecieveQuestion(string question, Student student)
        {
            Console.WriteLine("Teacher recieved a question from {0}, soru: {1}",student.name,question);
        }

        public void SendNewImage(string Url)
        {
            Console.WriteLine("Teacher changed slide: {0}",Url);
            Mediator.UpdateImage(Url);
        }
        public void AnswerQuestion(string answer,Student student)
        {
            Console.WriteLine("Teacher answered quesiton {0},{1}",student.name,answer);
        }
    }
    class Student : CourseMember
    {
        public string name;

        public Student(Mediator mediator) : base(mediator)
        {
        }

        public void RecieveImage(string url)
        {
            Console.WriteLine("{1} received image: {0} ",url,name);
        }

        public void RecievAnswer(string answer)
        {
            Console.WriteLine("Students received answer: {0}",answer);
        }
    }

    class Mediator
    {
        public Teacher teacher { get; set; }
        public List<Student> students { get; set; }
        public void UpdateImage(string Url)
        {
            foreach (var student in students)
            {
                student.RecieveImage(Url);
            }
        }

        public void SendQuestion(string question,Student student)
        {
            teacher.RecieveQuestion(question, student);
        }
        public void SendAnswer(string answer, Student student)
        {
            student.RecievAnswer(answer);
        }
    }
}
