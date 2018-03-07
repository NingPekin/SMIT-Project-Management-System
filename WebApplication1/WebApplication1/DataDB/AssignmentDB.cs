using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebApplication1.Modules;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace WebApplication1.DataDB
{
    public class AssignmentDB
    {
        public static int RandomNumber(int min, int max)
        {
            Random random = new Random();
            return random.Next(min, max);
        }
        public static void AssignProject(int stuId,string projCode)
        {
            try
            {
                if (ListAssignmentByStudents(stuId).Count < 4)
                {
                    //Students student = new Students();
                    //Projects project = new Projects();
                    SqlConnection conn = UtilityDB.GetConn();
                    conn.Open();
                    string sqlcmdAssignProject = "Insert into Assignments Values (@studentid,@projectcode,@grade,@date);";
                    SqlCommand sqlcmd = new SqlCommand(sqlcmdAssignProject, conn);
                    //sqlcmd.Parameters.AddWithValue("assid", RandomNumber(0,1000));
                    sqlcmd.Parameters.AddWithValue("studentid", stuId);
                    sqlcmd.Parameters.AddWithValue("projectcode", projCode);
                    sqlcmd.Parameters.AddWithValue("grade", RandomNumber(0, 100));
                    sqlcmd.Parameters.AddWithValue("date", DateTime.Today);
                    int success = sqlcmd.ExecuteNonQuery();
                    if (success >= 1)
                    {
                        MessageBox.Show("insert successfully");
                    }
                    else { MessageBox.Show("insert fail"); }
                    conn.Close();
                }
                else
                {
                    MessageBox.Show("one student can only have up to 3 projects!");
                }
            }
            catch
            {
                MessageBox.Show("this student has already been assigned to this project");
            }
          


        }

        public static List<Assignments> ListAssignmentByStudents(int stuId)
        {
            List<Assignments> assignmentList = new List<Assignments>();
            SqlConnection conn = UtilityDB.GetConn();
            conn.Open();
            String query = "select * from assignments where StudentId=@stuid";
            SqlCommand sqlcommand = new SqlCommand(query, conn);
            sqlcommand.Parameters.AddWithValue("stuid",stuId);
            SqlDataReader reader = sqlcommand.ExecuteReader();
     
            while(reader.Read())
            {
                Assignments ass = new Assignments();
                ass.AssignmentId =Convert.ToInt32(reader["AssignmentId"]);
                ass.StudentId = Convert.ToInt32(reader["StudentId"]);
                ass.ProjectId = reader["ProjectId"].ToString();
                ass.AssignmentDate = Convert.ToDateTime(reader["AssignmentDate"]);
                ass.Grade = Convert.ToInt32(reader["Grade"]);
                assignmentList.Add(ass);
                
            }
            return assignmentList;

        }

    }
}