//<summary>
//This class is actually a stripped-down version of the actual Appointment class, which was generated using the 
//Linq-to-SQL Designer (essentially a Linq ORM to the Appointments table in the db)
//</summary>
//<remarks>Obviously, you should use your own appointment object/classes, and change the code-behind in MonthView.xaml.vb to
//support a List(Of T) where T is whatever the System.Type is for your appointment class.
//</remarks>
//<author>Kirk Davis, February 2009 (in like, 4 hours, and it shows!)</author>
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PLWPF
{
    class Appointment
    {

        private int _AppointmentID;
        public int AppointmentID
        {
            get => _AppointmentID;
            set
            {
                if ((_AppointmentID == value) == false)
                    _AppointmentID = value;
            }
        }

        private string _Subject;
        public string Subject
        {
            get => _Subject;
            set
            {
                if ((_Subject == value) == false)
                    _Subject = value;
            }
        }

        private string _Location;
        public string Location
        {
            get => _Location;
            set
            {
                if ((_Location == value) == false)
                    _Location = value;
            }
        }

        private string _Details;
        public string Details
        {
            get => _Details;
            set
            {
                if ((_Details == value) == false)
                    _Details = value;
            }
        }

        private DateTime _StartTime;
        public DateTime StartTime
        {
            get => _StartTime;
            set
            {
                if ((_StartTime == value) == false)
                    _StartTime = value;
            }
        }

        private DateTime _EndTime;
        public DateTime EndTime
        {
            get => _EndTime;
            set
            {
                if ((_EndTime == value) == false)
                    _EndTime = value;
            }
        }

        private DateTime _ReccreatedDate;
        public DateTime ReccreatedDate
        {
            get => _ReccreatedDate;
            set
            {
                if ((_ReccreatedDate == value) == false)
                    _ReccreatedDate = value;
            }
        }
    }
}
