using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication1.Modules
{
    public class Assignments
    {
        int assignmentId;
        int studentId;
        String projectId;
        int grade;
        DateTime assignmentDate;

        public int AssignmentId
        {
            get
            {
                return assignmentId;
            }

            set
            {
                assignmentId = value;
            }
        }

        public int StudentId
        {
            get
            {
                return studentId;
            }

            set
            {
                studentId = value;
            }
        }

        public String ProjectId
        {
            get
            {
                return projectId;
            }

            set
            {
                projectId = value;
            }
        }

        public int Grade
        {
            get
            {
                return grade;
            }

            set
            {
                grade = value;
            }
        }

        public DateTime AssignmentDate
        {
            get
            {
                return assignmentDate;
            }

            set
            {
                assignmentDate = DateTime.Today ;
            }
        }

    }
}