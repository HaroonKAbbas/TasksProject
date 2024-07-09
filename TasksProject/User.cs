using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TasksProject
{
    public class User
    {
        public int Id { get; set; }
        public string Fulname { get; set; }
        public string Authan { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public Nullable<int> Userid { get; set; }
        public Nullable<double> Price { get; set; }
        public Nullable<double> PriceRate { get; set; }
    }

}
