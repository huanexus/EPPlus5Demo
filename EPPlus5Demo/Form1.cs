using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using System.IO;

using OfficeOpenXml.Drawing;
using OfficeOpenXml;



namespace EPPlus5Demo
{
    public partial class Form1 : Form
    {
        public Huanexus.MessageLogger MyLog { get; set; }
        public Form1()
        {
            InitializeComponent();
            MyLog = new Huanexus.MessageLogger(richTextBox1);
        }

        private void button1_Click(object sender, EventArgs e)
        {

            MyLog.OnMessage("1");
            SaveData();
            MyLog.OnMessage("5");           
        }

        private void SaveData()
        {
            var fi = new FileInfo("MyWorkbook.xlsx");

            if (fi.Exists)
            {
                fi.Delete();
            }
            using (var package = new ExcelPackage(fi))
            {
                package.Workbook.Worksheets.Add("a");
                var sheet = package.Workbook.Worksheets[0];
                for (int i = 1; i < 100; i++)
                {
                    for (int j = 1; j < 100; j++ )
                    {
                        sheet.Cells[i, j].Value = i + j;
                    }                        
                }
                MyLog.OnMessage("2");
                package.SaveAsync().ContinueWith(x => MyLog.OnMessage("3"));
                MyLog.OnMessage("4");
            }
        }
    }
}
