using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chat
{
    public enum Type {feature = 0, testing = 1};
    public class Worker
    {
        private string fullName;
        private int id;
        private double salary; 
        public Type type;
        public string FullName
        {
            get { return fullName; }
            set { fullName = value; }
        }
        public int Id
        {
            get { return id; }
            set { id = value; }
        }
        public double Salary
        {
            get { return salary; }
            set { salary = value; }
        }

        public Worker(int id, string fullName, double salary, Type type)
        {
            this.id = id;
            this.fullName = fullName;
            this.salary = salary;
            this.type = type;
        }
        public Worker()
        {
            id = 1;
            fullName = "Proba";
            salary = 0;
        }
    }
}
