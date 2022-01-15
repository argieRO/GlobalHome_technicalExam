using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GlobalHome_technicalExam.Models
{
    public interface ISalesRepository
    {
        void AddUser(Users inuser);
        IEnumerable<Users> GetAlluser();

        void AddProject(Projects inproject);
        IEnumerable<Projects> GetAllProjects();        
        IEnumerable<Projects> GetProjectsByUser(int inUserID);
        void AddActivity(Activity inActivity);
        void AddActivityinProject(Activity inActivity,int inProjectID);
        IEnumerable<Activity> GetActivitiesByProject(int inProjectID);
        void CloseProject(int inActivitystatus,int inUserLevel, int InProjectID);


    }
}
