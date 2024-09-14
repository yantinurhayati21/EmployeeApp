using System;

namespace EmployeeApp
{
    // Kelas untuk menyimpan data karyawan
    public class Employee
    {
        public string EmployeeID { get; set; }  // Property untuk ID Karyawan
        public string FullName { get; set; }    // Property untuk Nama Lengkap
        public int Age { get; set; }            // Property untuk Umur
        public DateTime BirthDate { get; set; } // Property untuk Tanggal Lahir

        // Konstruktor untuk menginisialisasi objek Employee
        public Employee(string employeeID, string fullName, int age, DateTime birthDate)
        {
            //Inisialisasi dengan nilai parameter yang diberikan

            EmployeeID = employeeID;
            FullName = fullName;
            Age = age;
            BirthDate = birthDate;
        }
    }
}
