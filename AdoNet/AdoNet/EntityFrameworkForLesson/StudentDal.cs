using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

namespace EntityFrameworkForLesson
{
    public class StudentDal
    {
        public List<Student> GetAll()
        {
            using(NotesClassContext context = new NotesClassContext())
            {
                return context.Students.ToList();
            }
        }

        public void Add(Student student)
        {
            using(NotesClassContext context = new NotesClassContext())
            {
                context.Students.Add(student);
                context.SaveChanges();
            }
        }

        public void Update(Student student)
        {
            using (NotesClassContext context = new NotesClassContext())
            {
                var entity = context.Entry(student);
                entity.State = EntityState.Modified;
                context.SaveChanges();
            }
        }

        public void Delete(Student student)
        {
            using (NotesClassContext context = new NotesClassContext())
            {
                var entity = context.Entry(student);
                entity.State =EntityState.Deleted;
                context.SaveChanges();
            }
        }

        public List<Student> GetByName(string key)
        {
            using(NotesClassContext context = new NotesClassContext())
            {
                return context.Students.Where(i => i.Name.Contains(key)).ToList();
            }
        }

    }
}
