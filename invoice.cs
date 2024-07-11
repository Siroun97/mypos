using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace mypos
{

    internal class invoice
    {
        public int InvoiceID { get; set; } // Example invoice identifier

        public bool discounted { get; set; }

        public invoice() { 
            this.InvoiceID = 0; 
            this.discounted = false;
        }














    }
   
}
