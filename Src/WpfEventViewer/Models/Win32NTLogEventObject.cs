using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Management;


// MSDN ライブラリ
// Win32_NTLogEvent class
// https://msdn.microsoft.com/ja-jp/library/aa394226(v=vs.85).aspx

// ManagementDateTimeConverter.ToDateTime メソッドで、独自文字列型の日付を DateTime 型に変換できる
// http://stackoverflow.com/questions/23816470/c-sharp-wmi-reading-remote-event-log

// Win32_NTLogEvent をデータクラスとして扱う
// http://www.pine4.net/Memo/Article/Archives/102



namespace WpfEventViewer.Models
{
    public class Win32NTLogEventObject
    {
        public UInt16 Category { get; set; }
        public string CategoryString { get; set; }
        public string ComputerName { get; set; }
        public byte[] Data { get; set; }
        public UInt16 EventCode { get; set; }
        public UInt32 EventIdentifier { get; set; }
        public byte EventType { get; set; }
        public string[] InsertionStrings { get; set; }
        public string Logfile { get; set; }
        public string Message { get; set; }
        public UInt32 RecordNumber { get; set; }
        public string SourceName { get; set; }
        public DateTime TimeGenerated { get; set; }
        public DateTime TimeWritten { get; set; }
        public string Type { get; set; }
        public string User { get; set; }

        public Win32NTLogEventObject(ManagementObject obj)
        {
            this.Category = (UInt16)obj.GetPropertyValue("Category");
            this.CategoryString = (string)obj.GetPropertyValue("CategoryString");
            this.ComputerName = (string)obj.GetPropertyValue("ComputerName");
            this.Data = (byte[])obj.GetPropertyValue("Data");
            this.EventCode = (UInt16)obj.GetPropertyValue("EventCode");
            this.EventIdentifier = (UInt32)obj.GetPropertyValue("EventIdentifier");
            this.EventType = (byte)obj.GetPropertyValue("EventType");
            this.InsertionStrings = (string[])obj.GetPropertyValue("InsertionStrings");
            this.Logfile = (string)obj.GetPropertyValue("Logfile");
            this.Message = (string)obj.GetPropertyValue("Message");
            this.RecordNumber = (UInt32)obj.GetPropertyValue("RecordNumber");
            this.SourceName = (string)obj.GetPropertyValue("SourceName");
            this.TimeGenerated = ManagementDateTimeConverter.ToDateTime(obj.GetPropertyValue("TimeGenerated") as string);
            this.TimeWritten = ManagementDateTimeConverter.ToDateTime(obj.GetPropertyValue("TimeWritten") as string);
            this.Type = (string)obj.GetPropertyValue("Type");
            this.User = (string)obj.GetPropertyValue("User");
            this.User = string.IsNullOrWhiteSpace(this.User) ? "N/A" : this.User;
        }

    }
}
