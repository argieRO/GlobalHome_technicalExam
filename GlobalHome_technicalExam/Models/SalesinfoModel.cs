using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GlobalHome_technicalExam.Models
{
    public class SalesinfoModel
    {

     
    }


    public class Users
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Userlevel { get; set; }
    }

    public class Projects
    {
        public int Id { get; set; }
        public string projectname { get; set; }
        public int projectstatus { get; set; }
        public int UserID { get; set; }

        
    }

    public class Activity
    {
        public int Id { get; set; }
        public string activityname { get; set; }
        public int activitystatus { get; set; }
        public int projectID { get; set; }
    }
}