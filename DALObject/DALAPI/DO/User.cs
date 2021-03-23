using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DALAPI.DO;

namespace DO
{
    public class User
    {
       
        public string userName { get; set; }
        public string password { get; set; }
        public bool admin { get; set; }
        public string email { get; set; }

        public override string ToString() => this.ToStringProperty();
    }
}
