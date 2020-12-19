using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CsvHelper;
using CsvHelper.Configuration.Attributes;

namespace InterviewAssignment.Models
{
    public class Classes
    {
        public string ClassID { get; set; }
        public int ClassCapacity { get; set; }
        public string CourseID { get; set; }
        public string CourseTitle { get; set; }
        private float oldStyleCredits;
        public float Credits 
        {
            get { return oldStyleCredits / 10.0f; }
            set { oldStyleCredits = value; } 
        }
        public int DayID { get; set; } 
        public int StudentsEnrolled { get; set; }
        public string Modality { get; set; }
        public string SectionStatusID1 { get; set; }
        [Ignore]
        public string Quarter { get { return ClassID.Substring(ClassID.Length - 4, 4); } }
        [Ignore]
        public string ItemNumber { get { return ClassID.Substring(0, 4); } }
        [Ignore]
        public string Status
        {
            get
            {
                if (SectionStatusID1 == "X")
                {
                    return "Cancelled";
                }
                else if (StudentsEnrolled >= ClassCapacity)
                {
                    return "Closed";
                }
                else
                {
                    return $"Open - [{ClassCapacity - StudentsEnrolled}]";
                }
            }
        }
        [Ignore]
        public string DisplayModality  
        { 
            get 
            {
                switch (Modality)
                {
                    case "80":
                        return "Hybrid";
                    case "50":
                        return "Virtual";
                    case "51":
                        return "Virtual Hybrid";
                    case "3C":
                        return "Online";
                    default:
                        return "Face to Face";
                }
            }
        }
    }
}
