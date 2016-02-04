using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AngularJS.Model.Generic;

namespace AngularJS.Model.Model
{
     public class Person:  Entity<int>
   {       
       public string Name { get; set; }
 
       public decimal Revenue { get; set; }

       public string  Comment { get; set; }
   }
}
