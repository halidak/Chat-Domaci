using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chat
{
     public class Message
    {
        public Worker To { get; set;}
        public Worker From { get; set;}
        public string message { get; set;}

        public bool isForEveryone { get; set; } = false;

        public void DisplayMessage()
        {
            if (isForEveryone)
            {
                Console.WriteLine($" For everyone : {From.FullName}  -  Message: {message}");
                return;
            }

            if (To.type == Type.feature)
            {
                Console.WriteLine($"{To.FullName} DEV : {From.FullName}  -  Message: {message}");
            }

            else
            {
                Console.WriteLine($"{To.FullName} QA : {From.FullName}  -  Message: {message}");
            }
        }
    }

    public class Company 
    {
        public List<Worker> developers = new List<Worker>();
        public List<Worker> qa = new List<Worker>();
        public List<Message> messages = new List<Message>();

        public void AddWorkers(Worker worker)
        {
            if (worker.type == Type.feature)
                developers.Add(worker);
            else
                qa.Add(worker);
        }

        public void RemoveDeveloper(int id) 
        {
            Worker d = developers.Find(w => w.Id.Equals(id));
            if (d != null)
                developers.Remove(d);
            else
                Console.WriteLine("-> Worker doesn't exist");         
        }

        public void RemoveQa(int id)
        {
            Worker q = qa.Find(w => w.Id.Equals(id));
            if(q != null)
                qa.Remove(q);
            else
                Console.WriteLine("-> Worker doesn't exist");     
        }

        public void ChangeDeveloper(int id, string name, double salary)
        {

          Worker d = developers.Find(w => w.Id.Equals(id));
            if (d != null)
            { 
                d.Salary = salary;
                d.FullName = name;
            }
            else
                Console.WriteLine("-> Worker doesn't exist");   
        }

        public void ChangeQa(int id, string name, double salary)
        {
                Worker q = qa.Find(w => w.Id.Equals(id));
             if ( q != null)
            { 
                q.Salary = salary;
                q.FullName = name; 
            }
            else
                Console.WriteLine("-> Worker doesn't exist");  
        }

        public void Display()
        {
            Console.WriteLine("Developers");
            foreach(Worker d in developers)
            {
                Console.WriteLine($"ID: {d.Id}     First and Last Name: {d.FullName}     Salary: {d.Salary}");
              
            }
            Console.WriteLine("-----------------------------");
            Console.WriteLine("QA");
            foreach(Worker q in qa)
            {
                Console.WriteLine($"ID: {q.Id}     First and Last Name: {q.FullName}     Salary: {q.Salary}");
            }
            Console.WriteLine("-----------------------------");
        }
        public void SendMessage(Message m)
        {
            m.DisplayMessage();
            messages.Add(m);
        }
    }
}
