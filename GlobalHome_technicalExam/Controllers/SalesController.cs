using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Http;
using GlobalHome_technicalExam.Models;

namespace GlobalHome_technicalExam.Controllers
{

    public class SalesController : ApiController
    {
        // GET: Sales
        public static readonly ISalesRepository salesRepo = new SalesRepository();

        public IEnumerable<Users> GetUsers()
        {
            return salesRepo.GetAlluser();
        }

        public void Adduser(Users inusers)
        {
            salesRepo.AddUser(inusers);
        }


        public IEnumerable<Projects> GetAllProjects()
        {
            return salesRepo.GetAllProjects();
        }

        public void AddProject(Projects inProject)
        {
            salesRepo.AddProject(inProject);
        }

        public IEnumerable<Projects> GetProjectbyUserID(int inUserid)
        {
            return salesRepo.GetProjectsByUser(inUserid);
        }


        public void AddActivityinProject(Activity inActivity, int inProjectID)
        {
            salesRepo.AddActivityinProject(inActivity, inProjectID);
        }


        public void Closeproject(int inActivitystatus, int inUserlevel, int inProjectID)
        {
            salesRepo.CloseProject(inActivitystatus, inUserlevel, inProjectID);
        }

        public IEnumerable<Activity> GetActivitiesByProject(int inProjectID)
        {
            return  salesRepo.GetActivitiesByProject(inProjectID);
        }


    }
}