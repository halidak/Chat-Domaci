using System;

namespace Chat
{
    class Program
    {
        private static Company company = new Company();

        static void Main(string[] args)
        {
            while (true)
            {
                var isRuning = true;
                Console.WriteLine("Enter number:\n 1 - Change \n 2 - Send Message");
                var num = int.Parse(Console.ReadLine());
                Console.Clear();

                if (num == 1)
                {
                    Console.WriteLine("Enter number:\n 1 - Add new Developer\n 2 - Change Developer\n 3 - Remove Developer\n 4 - Add new QA\n 5 - Change QA\n 6 - Remove QA\n 0 - Exit");

                    while (isRuning)
                    {
                        var input = int.Parse(Console.ReadLine());
                        switch (input)
                        {
                            case 0:
                                isRuning = false;
                                Console.Clear();
                                break;
                            case 1:
                                CreateNewDeveloper();
                                company.Display();
                                break;
                            case 2:
                                Console.WriteLine("Enter id:");
                                var i = int.Parse(Console.ReadLine());
                                Console.WriteLine("Enter new name:");
                                var newName = Console.ReadLine();
                                Console.WriteLine("Enter new salary");
                                var newSalary = double.Parse(Console.ReadLine());
                                company.ChangeDeveloper(i, newName, newSalary);
                                company.Display();
                                break;
                            case 3:
                                Console.WriteLine("Enter id:");
                                var ine = int.Parse(Console.ReadLine());
                                company.RemoveDeveloper(ine);
                                company.Display();
                                break;
                            case 4:
                                CreateNewQa();
                                company.Display();
                                break;
                            case 5:
                                Console.WriteLine("Enter id:");
                                var ie = int.Parse(Console.ReadLine());
                                Console.WriteLine("Enter new name:");
                                var newName1 = Console.ReadLine();
                                Console.WriteLine("Enter new salary");
                                var newSalary1 = int.Parse(Console.ReadLine());
                                company.ChangeQa(ie, newName1, newSalary1);
                                company.Display();
                                break;
                            case 6:
                                Console.WriteLine("Enter id:");
                                var io = Console.ReadLine();
                                company.RemoveQa(int.Parse(io));
                                company.Display();
                                break;

                            default:
                                Console.WriteLine("Pogresan input!");
                                break;
                        }
                    }
                }
                else if (num == 2)
                {
                    SendMessage();
                }
                else
                    Console.WriteLine("Wrong input!");

            }
        }

        private static void CreateNewDeveloper()
        {
            var newWorker = new Worker();
            Console.WriteLine("Enter id:");
            newWorker.Id = int.Parse(Console.ReadLine());
            Console.WriteLine("Enter Name:");
            newWorker.FullName = Console.ReadLine();
            Console.WriteLine("Enter salary:");
            newWorker.Salary = double.Parse(Console.ReadLine());
            newWorker.type = Type.feature;
            company.AddWorkers(newWorker);
        }
        private static void CreateNewQa()
        {
           var newWorker = new Worker();
            Console.WriteLine("Enter id:");
            newWorker.Id = int.Parse(Console.ReadLine());
            Console.WriteLine("Enter Name:");
            newWorker.FullName = Console.ReadLine();
            Console.WriteLine("Enter salary:");
            newWorker.Salary = double.Parse(Console.ReadLine());
            newWorker.type = Type.testing;
            company.AddWorkers(newWorker);
        }

        private static void SendMessage()
        {
            Console.WriteLine("Unesite id korisnika kome saljete poruku");
            var toID =int.Parse(Console.ReadLine());
            Console.WriteLine("Unesite id korisnika koji salje poruku");
            var fromID =int.Parse(Console.ReadLine());
            Console.WriteLine("Unesite poruku");
            var message = Console.ReadLine();

             if (message.StartsWith("feature/"))
            {
                var newMessage = new Message();
                var toWorker = company.developers.Find(x => x.Id == toID);
                var fromWorker = company.developers.Find(x => x.Id == fromID);

                if (fromWorker == null)
                {
                    fromWorker = company.qa.Find(x => x.Id == fromID);
                    if (fromWorker == null)
                    {
                        Console.WriteLine($"Ne postoji korsnik sa id: {fromID}");
                        return;
                    }
                }
               
                if(toWorker == null)
                {
                   toWorker = company.qa.Find(x => x.Id == toID);
                   if (toWorker == null)
                    {
                        Console.WriteLine($"Ne postoji korsnik sa id: {toID}");
                        return;
                    }
                }


                newMessage.To = toWorker;
                newMessage.From = fromWorker;
                newMessage.message = message;
                company.SendMessage(newMessage);
            }
             else if (message.StartsWith("testing/"))
            {
                var newMessage = new Message();
                var toWorker = company.qa.Find(x => x.Id == toID);
                var fromWorker = company.qa.Find(x => x.Id == fromID);
                if (fromWorker == null)
                {
                    company.developers.Find(x => x.Id == fromID);
                }
                newMessage.To = toWorker;
                newMessage.From = fromWorker;
                newMessage.message = message;

                company.SendMessage(newMessage);
            }
            else
            {
                var newMessage = new Message();
                newMessage.isForEveryone = true;
                var fromWorker = company.qa.Find(x => x.Id == fromID);

                newMessage.From = fromWorker;
                newMessage.message = message;
                newMessage.isForEveryone = true;
                company.SendMessage(newMessage);
            }
        }
    }
}
