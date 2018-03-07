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
    public class StudentDB
    {
        public static List<Students> GetStudentList()
        {
            List<Students> userList = new List<Students>();
            Students student = new Students();
            //connect to db
            SqlConnection conn = UtilityDB.GetConn();
            conn.Open();
            //selected query
            string selectedStudent = "SELECT * From Students";
            SqlCommand sqlcommandStudent = new SqlCommand(selectedStudent, conn);
      
            SqlDataReader sqlreaderStudent = sqlcommandStudent.ExecuteReader();

            while (sqlreaderStudent.Read())
            {
                student = new Students();
                student.StudentNumber = Convert.ToInt32(sqlreaderStudent["StudentNumber"]);
                student.FirstName = sqlreaderStudent["FirstName"].ToString();
                student.LastName = sqlreaderStudent["LastName"].ToString();
                student.Email = (sqlreaderStudent["Email"]).ToString();
                userList.Add(student);
                //MessageBox.Show(student.FirstName);

            }

            conn.Close();
            return userList;

        }

        public static List<Students> SearchStudentByNum(int stuNum)
        {
            List<Students> stuList = new List<Students>();
            Students student = new Students();
            SqlConnection conn = UtilityDB.GetConn();
            conn.Open();
            string sqlCommandSearchStudentByNum = "select * from Students where studentNumber=" + stuNum+";";
            SqlCommand sqlcommand = new SqlCommand(sqlCommandSearchStudentByNum, conn);
            SqlDataReader sqlReader = sqlcommand.ExecuteReader();
            if(sqlReader.Read())
            {
                student.FirstName = sqlReader["FirstName"].ToString();
                student.LastName = sqlReader["LastName"].ToString();
                student.StudentNumber =Convert.ToInt32(sqlReader["StudentNumber"].ToString());
                student.Email = sqlReader["Email"].ToString();

            }
            else
            {
                student = null;
            }
            stuList.Add(student);
            return stuList;

        }
    }
}