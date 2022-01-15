using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SQLite;

namespace GlobalHome_technicalExam.Models
{
    public class SalesRepository : ISalesRepository
    {
        SQLiteConnection conn;

        string connectionstring;

        public SalesRepository()
        {
            connectionstring = "Data Source=" + HttpContext.Current.Request.PhysicalApplicationPath + "\\SalesDb.db";
            try
            {
                conn = new SQLiteConnection(connectionstring);
                conn.Open();
            }
            catch (Exception ex)
            {

                throw;
            }
        }

        public void AddActivity(Activity inActivity)
        {
            string cmdstring = string.Format("INSERT INTO tbl_Activity(activityname,status,ProjectID) values('{0}',{1},{2})", inActivity.activityname, inActivity.activitystatus, inActivity.projectID);
            SQLiteCommand cmd = new SQLiteCommand(cmdstring, conn);
            cmd.ExecuteNonQuery();
        }

        public void AddActivityinProject(Activity inActivity, int inProjectID)
        {
            string cmdstring = string.Format("UPDATE tbl_Activity  SET activityname="+ inActivity.activityname +", status="+ inActivity.activitystatus +", ProjectID="+ inProjectID +" WHERE Id="+ inActivity.Id +")");
            SQLiteCommand cmd = new SQLiteCommand(cmdstring, conn);
            cmd.ExecuteNonQuery();
        }

        public void AddProject(Projects inproject)
        {
            //ADD PROJECT
            string cmdstring = string.Format("INSERT INTO tbl_Projects(projectname,userid,status) values('{0}',{1},{2})", inproject.projectname, inproject.UserID, inproject.projectstatus);
            SQLiteCommand cmd = new SQLiteCommand(cmdstring, conn);
            cmd.ExecuteNonQuery();
        }

        public void AddUser(Users inuser)
        {
            //ADD USER
            string cmdstring = string.Format("INSERT INTO tbl_Users(username,userlevel) Values('{0}',{1})", inuser.Name, inuser.Userlevel);
            SQLiteCommand cmd = new SQLiteCommand(cmdstring, conn);
            cmd.ExecuteNonQuery();

        }

        public void CloseProject(int inActivitystatus, int inUserLevel,int inProjectID)
        {
            SQLiteCommand cmd;
            cmd = new SQLiteCommand("UPDATE tbl_Projects SET status=1 WHERE Id=" + inProjectID);
            //0 Super user - 1 Sales lead- 2 Sales rep
            if (inUserLevel <= 1 )
            {
                cmd.ExecuteNonQuery();
            }
            else
            {
                //0 = 10%
                //1 = 50%
                //2 = 100%
                // for sales REP

                if (inActivitystatus >=1)
                {
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public IEnumerable<Activity> GetActivitiesByProject(int inProjectID)
        {
            List<Activity> listactivity = new List<Activity>();
            SQLiteCommand cmd = new SQLiteCommand("Select * FROM tbl_Activity WHERE ProjectID=" + inProjectID);
            SQLiteDataReader reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                Activity tempactivity = new Activity();
                tempactivity.Id = Convert.ToInt32(reader["Id"].ToString());
                tempactivity.activityname = reader["activityname"].ToString();
                tempactivity.activitystatus = Convert.ToInt32(reader["status"].ToString());
                tempactivity.projectID = Convert.ToInt32(reader["ProjectID"].ToString());

                listactivity.Add(tempactivity);
            }

            reader.Close();

            return listactivity;
        }

        public IEnumerable<Projects> GetAllProjects()
        {
            List<Projects> listprojects = new List<Projects>();

            SQLiteCommand cmd = new SQLiteCommand("Select * FROM tbl_Projects",conn);
            SQLiteDataReader reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                Projects tempproject = new Projects();
                tempproject.Id = Convert.ToInt32(reader["Id"].ToString());
                tempproject.projectname = reader["projectname"].ToString();
                tempproject.projectstatus = Convert.ToInt32(reader["status"].ToString());
                tempproject.UserID = Convert.ToInt32(reader["userID"].ToString());

                listprojects.Add(tempproject);
            }

            reader.Close();
            return listprojects;
        }

        public IEnumerable<Users> GetAlluser()
        {
            //get all users

            List<Users> listUsers = new List<Users>();
            SQLiteCommand cmd = new SQLiteCommand("Select * FROM tbl_Users", conn);

            SQLiteDataReader reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                Users tempuser = new Users();
                tempuser.Id = Convert.ToInt32(reader["Id"].ToString());
                tempuser.Name = reader["username"].ToString();
                tempuser.Userlevel = Convert.ToInt32(reader["userlevel"].ToString());

                listUsers.Add(tempuser);
            }
            reader.Close(); 

            return listUsers;
        }

        public IEnumerable<Projects> GetProjectsByUser(int inUserID)
        {
            List<Projects> listprojects = new List<Projects>();

            SQLiteCommand cmd = new SQLiteCommand("Select * FROM tbl_Projects WHERE userID=" + inUserID, conn);
            SQLiteDataReader reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                Projects tempproject = new Projects();
                tempproject.Id = Convert.ToInt32(reader["Id"].ToString());
                tempproject.projectname = reader["projectname"].ToString();
                tempproject.projectstatus = Convert.ToInt32(reader["status"].ToString());
                tempproject.UserID = Convert.ToInt32(reader["userID"].ToString());

                listprojects.Add(tempproject);
            }


            return listprojects;
        }

        
    }
}