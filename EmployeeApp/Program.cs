using System;

namespace EmployeeApp
{
    // Program utama untuk menjalankan aplikasi CRUD karyawan
    internal class Program
    {
        static void Main(string[] args)
        {
            // Membuat instance EmployeeManager yang mengimplementasikan operasi CRUD
            IEmployeeOperations employeeManager = new EmployeeManager();

            Console.WriteLine("==================================");
            Console.WriteLine("          Add Employee            ");
            Console.WriteLine("==================================");

            // Menambahkan data karyawan secara hardcode untuk demonstrasi
            // Umur dihitung secara dinamis menggunakan metode CalculateAge
            employeeManager.AddEmployee(new Employee("1001", "Adit", CalculateAge(new DateTime(1954, 8, 17)), new DateTime(1954, 8, 17)));
            employeeManager.AddEmployee(new Employee("1002", "Anton", CalculateAge(new DateTime(1954, 8, 18)), new DateTime(1954, 8, 18)));
            employeeManager.AddEmployee(new Employee("1003", "Amir", CalculateAge(new DateTime(1954, 8, 19)), new DateTime(1954, 8, 19)));

            // Menampilkan daftar karyawan
            employeeManager.ShowEmployees();

            Console.WriteLine("==================================");
            Console.WriteLine("     Delete Employee (1003)       ");
            Console.WriteLine("==================================");
            // Menghapus karyawan dengan EmployeeID "1003"
            employeeManager.DeleteEmployee("1003");

            // Menampilkan daftar karyawan setelah penghapusan
            employeeManager.ShowEmployees();

            Console.WriteLine("==================================");
            Console.WriteLine("        Add Duplicate Data        ");
            Console.WriteLine("==================================");
            // Mencoba menambahkan karyawan dengan EmployeeID yang sudah ada (harus menghasilkan error)
            employeeManager.AddEmployee(new Employee("1001", "Adi", CalculateAge(new DateTime(1960, 1, 1)), new DateTime(1960, 1, 1)));

            // Menampilkan daftar karyawan final
            employeeManager.ShowEmployees();

            Console.ReadKey(); // Menunggu input dari pengguna untuk menutup aplikasi
        }

        // Metode pembantu untuk menghitung umur berdasarkan tanggal lahir
        static int CalculateAge(DateTime birthDate)
        {
            int age = DateTime.Now.Year - birthDate.Year;
            if (DateTime.Now.DayOfYear < birthDate.DayOfYear)
                age--; // Mengurangi umur jika belum melewati hari lahir tahun ini
            return age;
        }
    }
}
