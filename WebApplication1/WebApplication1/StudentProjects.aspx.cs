using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Windows.Forms;
using System.Configuration;
using WebApplication1.Modules;
using WebApplication1.DataDB;

namespace WebApplication1
{
    public partial class WebForm1 : System.Web.UI.Page
    {

        protected void Page_Load(object sender, EventArgs e)
        {
            //only run once(when load the first time
            if (!Page.IsPostBack)
            {
                List<Projects> projectList = new List<Projects>();
                projectList = ProjectDB.SearchAllProject();
                foreach (Projects project in projectList)
                {
                    DropDownListProjets.Items.Add(project.ProjectCode);
                }

                List<Students> studentList = new List<Students>();
                studentList = StudentDB.GetStudentList();
                foreach (Students student in studentList)
                {
                    DropDownListStudents.Items.Add(student.StudentNumber.ToString());
                }
            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {

        }

        //list student info
        protected void Button1_Click1(object sender, EventArgs e)
        {         
            int searchedStudentId = Convert.ToInt32(DropDownListStudents.SelectedItem.Text);
            GridView1.DataSource = StudentDB.SearchStudentByNum(searchedStudentId);
            GridView1.DataBind();

        }

        protected void ListView2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void SqlDataSource1_Selecting(object sender, SqlDataSourceSelectingEventArgs e)
        {

        }

        protected void ButtonAssign_Click(object sender, EventArgs e)
        {
            int studentid = Convert.ToInt32(DropDownListStudents.SelectedItem.Text);
            string projectCode = DropDownListProjets.SelectedItem.Text;
            AssignmentDB.AssignProject(studentid, projectCode);
            GridView3.DataSource = AssignmentDB.ListAssignmentByStudents(studentid);
            GridView3.DataBind();

        }

        protected void ButtonListStudent_Click(object sender, EventArgs e)
        {
            string projectCode = (DropDownListProjets.SelectedItem.Text);
            GridView2.DataSource = ProjectDB.SearchProjectByCode(projectCode);
            GridView2.DataBind();

        }

        protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void DropDownListProjets_SelectedIndexChanged(object sender, EventArgs e)
        {


        }
    }
}