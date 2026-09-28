/****************/
// Mã sinh viên: 202418832
// Họ tên:       Bùi Ngọc Trâm Anh
/****************/
using System;

namespace LabProject
{
    public class Employee
    {
        private string id;
        private string fullName;
        private double baseSalary;

        public string Id 
        { 
            get => id; 
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                    throw new ArgumentException("Mã nhân sự không được để trống.");
                id = value;
            }
        }

        public string FullName 
        { 
            get => fullName; 
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                    throw new ArgumentException("Họ tên không được để trống.");
                fullName = value;
            }
        }

        public double BaseSalary 
        { 
            get => baseSalary; 
            protected set
            {
                if (value < 0)
                    throw new ArgumentOutOfRangeException("Lương cơ bản không được âm.");
                baseSalary = value;
            }
        }

        // Constructor 1: Mặc định
        public Employee() : this("UNKNOWN", "Unnamed employee", 0) { }

        // Constructor 2: 2 tham số
        public Employee(string id, string fullName) : this(id, fullName, 0) { }

        // Constructor 3: Đầy đủ tham số
        public Employee(string id, string fullName, double baseSalary)
        {
            Id = id;
            FullName = fullName;
            BaseSalary = baseSalary;
        }

        // Destructor (Finalizer) để quan sát vòng đời
        ~Employee()
        {
            Console.WriteLine($"[Hủy] Đối tượng Employee: {Id} - {FullName} được giải phóng.");
        }

        // Nạp chồng phương thức tăng lương 1: Tăng số tiền cố định
        public void IncreaseSalary(double amount)
        {
            if (amount <= 0)
                throw new ArgumentException("Giá trị tăng lương phải dương.");
            BaseSalary += amount;
            Console.WriteLine($"[Tăng lương] {FullName} (+{amount:N0}): Lương mới = {BaseSalary:N0}");
        }

        // Nạp chồng phương thức tăng lương 2: Tùy chọn theo tỷ lệ phần trăm
        public void IncreaseSalary(double value, bool byPercentage)
        {
            if (value <= 0)
                throw new ArgumentException("Giá trị tăng lương phải dương.");

            if (byPercentage)
            {
                BaseSalary += BaseSalary * (value / 100.0);
                Console.WriteLine($"[Tăng lương] {FullName} (+{value}%): Lương mới = {BaseSalary:N0}");
            }
            else
            {
                IncreaseSalary(value);
            }
        }

        // Phương thức virtual tính chi phí hàng tháng
        public virtual double CalculateMonthlyCost()
        {
            return BaseSalary;
        }

        // Phương thức virtual hiển thị thông tin
        public virtual void DisplayInfo()
        {
            Console.WriteLine($"  - [NV] ID: {Id} | Tên: {FullName,-18} | Lương CB: {BaseSalary,10:N0} | Chi phí/tháng: {CalculateMonthlyCost(),10:N0}");
        }
    }
}