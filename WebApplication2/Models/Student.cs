using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace WebApplication2.Models
{
    public class Student
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Display(Name = "Number")]
        public int Id { get; set; }


        [Display(Name = "Last Name")]
        public string Name { get; set; }

        public string Email { get; set; }

        public string Address { get; set; }

        public string Telephone { get; set; }

       //public  List<Student> ListStudent { get; set; }
      //  IList<Student> st = new List<Student>();
      //  Student st1 = new Student();
      //st .add      //  IList<Student> st = new List<Student>();
      //  Student st1 = new Student();
      //st .add
             
    }
   
   
}