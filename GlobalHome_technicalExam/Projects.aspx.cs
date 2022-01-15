using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using GlobalHome_technicalExam.Controllers;
using GlobalHome_technicalExam.Models;

namespace GlobalHome_technicalExam
{
    public partial class SalesHome : System.Web.UI.Page
    {

        SalesController controller = new SalesController();
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btAddProject_Click(object sender, EventArgs e)
        {
            Projects tempProject = new Projects();

            int UID;
            int.TryParse(cbUsers.SelectedItem.Value, out UID);

            tempProject.projectname = tbProjectname.Text;
            tempProject.UserID = UID;
            tempProject.projectstatus = 0;


            controller.AddProject(tempProject);
        }

        protected void cbUsers_SelectedIndexChanged(object sender, EventArgs e)
        {
            GridView1.DataSource = SourceByUser;
        }
    }
}