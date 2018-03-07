using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebApplication1.Modules;
using System.Data.SqlClient;
using WebApplication1.DataDB;
using System.Windows.Forms;
using System.Configuration;

namespace WebApplication1.DataDB
{
    public class ProjectDB
    {
        public static List<Projects> SearchProjectByCode(string projCode)
        {
            List<Projects> projList = new List<Projects>();
            Projects project = new Projects();
            SqlConnection conn = UtilityDB.GetConn();
            conn.Open();
            string sqlCommandSearchProjectByCode = "select * from Projects where ProjectCode='" + projCode+"'";
            SqlCommand sqlcommand = new SqlCommand(sqlCommandSearchProjectByCode, conn);
            SqlDataReader sqlReader = sqlcommand.ExecuteReader();
            if (sqlReader.Read())
            {
                project.ProjectCode = sqlReader["ProjectCode"].ToString();
                project.ProjectTitle = sqlReader["ProjectTitle"].ToString();
                project.DueDate = Convert.ToDateTime(sqlReader["DueDate"]);
                projList.Add(project);
            }            
            return projList;

        }
        //list all projects and return to dropdown list
        public static List<Projects> SearchAllProject()
        {
            List<Projects> projList = new List<Projects>();
            SqlConnection conn = UtilityDB.GetConn();
            conn.Open();
            string sqlCommandSearchAllProject = "select * from Projects;";
            SqlCommand sqlcommand = new SqlCommand(sqlCommandSearchAllProject, conn);
            SqlDataReader sqlReader = sqlcommand.ExecuteReader();
            while (sqlReader.Read())
            {
                Projects project = new Projects();
                project.ProjectCode = sqlReader["ProjectCode"].ToString();
                project.ProjectTitle = sqlReader["ProjectTitle"].ToString();
                project.DueDate = Convert.ToDateTime(sqlReader["DueDate"]);
                projList.Add(project);
            }
            return projList;

        }



    }
}