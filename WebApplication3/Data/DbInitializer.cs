//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Threading.Tasks;
//using WebApplication3.Models;

//namespace WebApplication3.Data
//{
//    public class DbInitializer
//    {
//        public static void Initialize(ApplicationDbContext context)
//        {
//            context.Database.EnsureCreated();

//            if (context.Users.Any())
//            {
//                return;
//            }

//            var Users = new ApplicationUser[]
//            {
//                new ApplicationUser{ Id="12we12ew", Email="e@mail.com", PasswordHash="AQAAAAEAACcQAAAAEIiTyoCXVDl4e+e8b6jPOfj12fsLrlkkWhpswSZ1ziwx6JOwaWrczs1kLyN7y2DPHw==",  }
//            };

//            foreach (ApplicationUser u in Users)
//            {
//                context.Users.Add(u);
//            }

//            context.SaveChanges();

//            var trainings = new Training[]
//            {
//                new Training{ TrainingID=1, HoursTraining=4, ApplicationUserID="12we12ew" },
//                new Training{ TrainingID=2, HoursTraining=3, ApplicationUserID="12we12ew" },
//                new Training{ TrainingID=3, HoursTraining=5, ApplicationUserID="12we12ew" }
//            };

//            foreach (Training h in trainings)
//            {
//                context.Trainings.Add(h);
//            }

//            context.SaveChanges();
//        }
//    }
//}
