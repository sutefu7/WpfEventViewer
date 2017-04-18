using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfEventViewer.Models
{
    public class DateObject
    {
        public bool ThisMonthMember { get; set; } = true;
        public DateTime Date { get; set; } = DateTime.MinValue;

        public int InformationCount { get; set; } = 0;
        public int WarningCount { get; set; } = 0;
        public int ErrorCount { get; set; } = 0;

        public List<Win32NTLogEventObject> EventLogItems { get; set; } = null;

    }
}
