using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TournamentTracker.Data;

namespace TournamentTracker.Services
{
    public class EFAuthService
    {
        public List<AspNetUser> GetAllUsers()
        {
            List<AspNetUser> allUsers = new List<AspNetUser>();

            using (var db = new TournamentTrackerEntities())
            {
                var query = db.AspNetUsers.Select(u => u);
                
                for (int i = 0; i < query.ToList().Count(); i++)
                {
                    var user = query.ToList().ElementAt(i);
                    allUsers.Add(user);
                }
            }

            return allUsers;
        }

        public AspNetUser GetUserFromId(string id)
        {
            AspNetUser user;

            using (var db = new TournamentTrackerEntities())
            {
                user = db.AspNetUsers.Single(u => u.Id == id);
            }

            return user;
        }

        public void DeleteUserById(string id)
        {
            using (var db = new TournamentTrackerEntities())
            {
                AspNetUser user = db.AspNetUsers.Single(u => u.Id == id);

                db.AspNetUsers.Attach(user);
                db.AspNetUsers.Remove(user);

                db.SaveChanges();
            }
        }

        public void UpdateUser(AspNetUser user)
        {
            using (var db = new TournamentTrackerEntities())
            {
                db.AspNetUsers.Attach(user);

                var obj = db.AspNetUsers.FirstOrDefault(u => u.Id == user.Id);

                obj.AspNetRoles = user.AspNetRoles;

                db.Entry(obj).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();
            }
        }
    }
}