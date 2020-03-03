using _6SemCursach.Data.Models;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Xml;
using System.Xml.Serialization;

namespace ForLab45
{
    class Program
    {
        private static Settings _setting;
        static void Main(string[] args)
        {
            Setup();
            GetRole();
            SetSem();
            Console.WriteLine("Ok");
        }

        private static void Setup()
        {
            _setting = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .Build()
                .Get<Settings>();
        }

        private static void GetRole()
        { 
            using (ApplicationContext db = new ApplicationContext())
            {
                 var roles = db.Roles.ToList();

                var formatter = new XmlSerializer(roles.GetType());

                using (FileStream fs = new FileStream("D:\\lab45bibd\\role.xml", FileMode.OpenOrCreate))
                {
                    foreach (var r in roles)
                        Console.WriteLine(r.Title);

                    formatter.Serialize(fs, roles);
                }
            }
        }

        private static void SetSem()
        {
            using (ApplicationContext db = new ApplicationContext())
            {
                var sem = new List<Semester>();
                var formatter = new XmlSerializer(sem.GetType());
                using (FileStream fs = new FileStream("D:\\lab45bibd\\sem.xml", FileMode.OpenOrCreate))
                {
                    sem = (List<Semester>)formatter.Deserialize(fs);
                }

                db.Semesters.AddRange(sem);
                db.SaveChanges();
           }
                
        }
    }
}
