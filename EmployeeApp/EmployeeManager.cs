using System;
using System.Collections.Generic;
using System.Linq;

namespace EmployeeApp
{
    public class EmployeeManager : IEmployeeOperations
    {
        //List untuk meyimpan data employee
        private List<Employee> employees = new List<Employee>(); // Daftar karyawan dalam memori

        // Menambahkan karyawan dengan validasi
        public void AddEmployee(Employee employee)
        {
            try
            {
                // Validasi untuk menghindari EmployeeID duplikat
                if (employees.Any(e => e.EmployeeID == employee.EmployeeID))
                    throw new Exception($"EmployeeID {employee.EmployeeID} already exists.");

                // Validasi panjang nama
                if (employee.FullName.Length > 50)
                    throw new ArgumentException("FullName cannot exceed 50 characters.");

                // Validasi untuk field yang tidak boleh kosong
                if (string.IsNullOrEmpty(employee.EmployeeID) || string.IsNullOrEmpty(employee.FullName))
                    throw new ArgumentNullException("EmployeeID and FullName cannot be null or empty.");

                // Validasi untuk tanggal lahir yang tidak valid
                if (employee.BirthDate == default)
                    throw new ArgumentException("Invalid BirthDate.");

                employees.Add(employee); // Menambahkan karyawan ke daftar
                Console.WriteLine($"Success: Employee {employee.FullName} added successfully.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error adding employee: {ex.Message}");
            }
        }

        // Menampilkan daftar karyawan dengan format tabel yang menarik
        public void ShowEmployees()
        {
            Console.WriteLine("Employee List:");
            Console.WriteLine(new string('-', 60)); // Garis batas atas tabel

            // Menampilkan header tabel
            Console.WriteLine(
                $"{"EmployeeID",-15}{"FullName",-30}{"Age",-5}{"BirthDate",-10}"
            );
            Console.WriteLine(new string('-', 60)); // Garis batas bawah header

            // Menampilkan data karyawan
            foreach (var employee in employees)
            {
                Console.WriteLine(
                    $"{employee.EmployeeID,-15}{employee.FullName,-30}{employee.Age,-5}{employee.BirthDate:dd-MMM-yy}"
                );
            }

            Console.WriteLine(new string('-', 60)); // Garis batas bawah tabel
        }

        // Menghapus karyawan berdasarkan EmployeeID
        public void DeleteEmployee(string employeeID)
        {
            try
            {
                // Mencari karyawan berdasarkan EmployeeID
                var employee = employees.FirstOrDefault(e => e.EmployeeID == employeeID);
                if (employee == null)
                    throw new Exception($"Employee with ID {employeeID} does not exist.");

                employees.Remove(employee); // Menghapus karyawan dari daftar
                Console.WriteLine($"Success: Employee with ID {employeeID} deleted.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
        }
    }
}
