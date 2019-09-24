using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Windows.Forms;
using ClassLibraryHiTech.Bussines;

namespace ClassLibraryHiTech.DataAcces
{
    public class EmployeeDA
    {
        private static string filePath = Application.StartupPath + @"\Employee.dat";
        private static string fileTemp = Application.StartupPath + @"\Temp.dat";

        public static void Save(Employee Emp)

        {
            StreamWriter sWriter = new StreamWriter(filePath, true);
            sWriter.WriteLine(Emp.EmployeeID + "," + Emp.FirstName + "," + Emp.LastName + "," + Emp.PhoneNumber + "," + Emp.Email + "," + Emp.JobTitle);
            sWriter.Close();
            MessageBox.Show("Employee Data has been saved");
        }

        public static void ListEmployee(ListView listViewEmployee)
        {
            StreamReader sReader = new StreamReader(filePath);
            listViewEmployee.Items.Clear();

            string line = sReader.ReadLine();
            while (line != null)
            {
                string[] fields = line.Split(',');
                ListViewItem item = new ListViewItem(fields[0]);
                item.SubItems.Add(fields[1]);
                item.SubItems.Add(fields[2]);
                item.SubItems.Add(fields[3]);
                item.SubItems.Add(fields[4]);
                item.SubItems.Add(fields[5]);
                listViewEmployee.Items.Add(item);
                line = sReader.ReadLine();
            }
            sReader.Close();
        }

        public static Employee Search(int EmpID)
        {
            Employee Emp = new Employee();

            StreamReader sReader = new StreamReader(filePath);
            string line = sReader.ReadLine();

            while (line != null)
            {
                string[] fields = line.Split(',');
                if (EmpID == Convert.ToInt32(fields[0]))
                {
                    Emp.EmployeeID = Convert.ToInt32(fields[0]);
                    Emp.FirstName = fields[1];
                    Emp.LastName = fields[2];
                    Emp.PhoneNumber = fields[3];
                    Emp.Email = fields[4];
                    Emp.JobTitle = fields[5];
                    sReader.Close();
                    return Emp;
                }
                line = sReader.ReadLine();
            }
            sReader.Close();
            return null;
        }
        public static Employee SearchJobTitle(string EmpJOB)
        {
            Employee Emp = new Employee();

            StreamReader sReader = new StreamReader(filePath);
            string line = sReader.ReadLine();

            while (line != null)
            {
                string[] fields = line.Split(',');
                if (EmpJOB == Convert.ToString(fields[5]))
                {
                    Emp.EmployeeID = Convert.ToInt32(fields[0]);
                    Emp.FirstName = fields[1];
                    Emp.LastName = fields[2];
                    Emp.PhoneNumber = fields[3];
                    Emp.Email = fields[4];
                    Emp.JobTitle = fields[5];
                    sReader.Close();
                    return Emp;
                }
                line = sReader.ReadLine();
            }
            sReader.Close();
            return null;
        }

        public static void Delete(int EmpID)
        {
            StreamReader sReader = new StreamReader(filePath);
            string line = sReader.ReadLine();
            StreamWriter sWriter = new StreamWriter(fileTemp, true);
            while (line != null)
            {
                string[] fields = line.Split(',');
                if ((EmpID) != (Convert.ToInt32(fields[0])))
                {
                    sWriter.WriteLine(fields[0] + "," + fields[1] + "," + fields[2] + "," + fields[3] + "," + fields[4] + "," + fields[5]);
                }
                line = sReader.ReadLine();
            }
            sReader.Close();
            sWriter.Close();

            File.Delete(filePath);
            File.Move(fileTemp, filePath);
        }

        public static void Update(Employee employee)
        {
            StreamReader sReader = new StreamReader(filePath);
            StreamWriter sWriter = new StreamWriter(fileTemp, true);
            string line = sReader.ReadLine();

            while (line != null)
            {
                string[] fields = line.Split(',');
                if ((Convert.ToInt32(fields[0]) != (employee.EmployeeID)))
                {
                    sWriter.WriteLine(fields[0] + "," + fields[1] + "," + fields[2] + "," + fields[3] + "," + fields[4] + "," + fields[5]);
                }

                line = sReader.ReadLine();
            }
            sWriter.WriteLine(employee.EmployeeID + "," + employee.FirstName + ","
            + employee.LastName + "," + employee.PhoneNumber + "," + employee.Email + "," + employee.JobTitle);
            sReader.Close();
            sWriter.Close();
            File.Delete(filePath);
            File.Move(fileTemp, filePath);
        }
    }
}
