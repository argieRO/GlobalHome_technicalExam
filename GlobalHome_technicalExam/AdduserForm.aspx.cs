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
    public partial class AdduserForm : System.Web.UI.Page
    {
        SalesController controler = new SalesController();
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btAddUser_Click(object sender, EventArgs e)
        {

            Users newuser = new Users();
            newuser.Name = tbUsername.Text;
            newuser.Userlevel = cbUserlevel.SelectedIndex;
            //controler.Adduser(newuser);

        }

    }

    public enum Userlevel { Superuser = 0, Saleslead = 1, SalesRep = 2 };

}