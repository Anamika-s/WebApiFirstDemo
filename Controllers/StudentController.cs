using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApiDemo.Models;

namespace WebApiDemo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentController : ControllerBase
    {
        static List<Student> Students = null;
        public StudentController()
        {
            if (Students == null)
            {
                Students = new List<Student>()
                {
                     new Student() { Id=1, Name="Ajay" , Batch="B001", Marks=90},

                     new Student() { Id=2, Name="Deepak" , Batch="B002", Marks=90},

                     new Student() { Id=3, Name="Bhagya" , Batch="B001", Marks=90},

                     new Student() { Id=4, Name="Meenu" , Batch="B002", Marks=90},
                };
            }


        }
        [HttpGet]
        public IEnumerable<Student> List()
        {
            return Students.ToList();

        }
        [HttpGet]
        [Route("{id:int}")]
        public Student GetById(int id)
        {
            return Students.FirstOrDefault(x => x.Id == id);
        }
        [HttpPost]
        public void Create(Student student)
        {
            Students.Add(student);
        }
        [HttpPut]
        [Route("{id:int}")]
        public void Edit(int id, Student student)
        {
            //Student obj = Students.FirstOrDefault(x => x.Id == id);
            //if(obj!=null)
            //{
            //    foreach(Student temp in Students)
            //    {
            //        if(temp.Id== id)
            //        {
            //            temp.Name = student.Name;
            //            temp.Batch = student.Batch;
            //            temp.Marks = student.Marks;
            //        }
            //    }
            //}
            (from p in Students
             where p.Id == id
             select p).ToList()
            .ForEach(x =>
                    {
                        x.Name = student.Name;
                        x.Batch = student.Batch;
                        x.Marks = student.Marks;
                    }
                 );


        }

        [HttpDelete]
        public void Delete(int id)
        {
            Student obj = Students.FirstOrDefault(x => x.Id == id);
            if (obj != null)
            {
                Students.Remove(obj);
            }
        }
    }
}