using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Template
{
    abstract class DataExporter
    {
        // This will not vary as the data is read from sql only
        public void ReadData()
        {
            Console.WriteLine("Reading the data from SqlServer");
        }

        // This will not vary as the format of report is fixed.
        public void FormatData()
        {
            Console.WriteLine("Formating the data as per requriements.");
        }

        // This may vary based on target file type choosen
        public abstract void ExportData();

        // This is the template method that the client will use.
        public void ExportFormatedData()
        {
            this.ReadData();
            this.FormatData();
            this.ExportData();
        }
    }

    class ExcelExporter : DataExporter
    {
        public override void ExportData()
        {
            Console.WriteLine("Exporting the data to an Excel file.");
        }
    }

    class PDFExporter : DataExporter
    {
        public override void ExportData()
        {
            Console.WriteLine("Exporting the data to a PDF file.");
        }
    }


    class Program
    {
        static void Main(string[] args)
        {
            DataExporter exporter = null;

            // Lets export the data to Excel file
            exporter = new ExcelExporter();
            exporter.ExportFormatedData();

            Console.WriteLine();

            // Lets export the data to PDF file
            exporter = new PDFExporter();
            exporter.ExportFormatedData();
        }
    }
}
