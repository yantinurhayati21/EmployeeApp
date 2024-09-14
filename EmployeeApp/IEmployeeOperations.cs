namespace EmployeeApp
{
    // Interface untuk operasi CRUD pada data karyawan
    public interface IEmployeeOperations
    {
        void AddEmployee(Employee employee);   // Method menambahkan data karyawan (parameter dari object class employee)
        void ShowEmployees();                 // Method menampilkan daftar karyawan
        void DeleteEmployee(string employeeID); // method menghapus data karyawan berdasarkan ID
    }
}
