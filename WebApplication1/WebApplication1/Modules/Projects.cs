using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication1.Modules
{
    public class Projects
    {
        string projectCode;
        string projectTitle;
        DateTime dueDate;

        public string ProjectCode
        {
            get
            {
                return projectCode;
            }

            set
            {
                projectCode = value;
            }
        }

        public string ProjectTitle
        {
            get
            {
                return projectTitle;
            }

            set
            {
                projectTitle = value;
            }
        }

        public DateTime DueDate
        {
            get
            {
                return dueDate;
            }

            set
            {
                dueDate = value;
            }
        }
    }
}