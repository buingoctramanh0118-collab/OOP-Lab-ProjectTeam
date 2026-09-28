/****************/
// Mã sinh viên: 202418832
// Họ tên:       Bùi Ngọc Trâm Anh
/****************/
using System;

namespace LabProject
{
    public class SoftwareEngineer : Employee
    {
        private string primaryLanguage;
        private double technicalAllowance;

        public string PrimaryLanguage
        {
            get => primaryLanguage;
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                    throw new ArgumentException("Ngôn ngữ chính không được để trống.");
                primaryLanguage = value;
            }
        }

        public double TechnicalAllowance
        {
            get => technicalAllowance;
            set
            {
                if (value < 0)
                    throw new ArgumentOutOfRangeException("Phụ cấp kỹ thuật không được âm.");
                technicalAllowance = value;
            }
        }

        // Constructor 1
        public SoftwareEngineer(string id, string fullName, string primaryLanguage)
            : base(id, fullName, 0)
        {
            PrimaryLanguage = primaryLanguage;
            TechnicalAllowance = 0;
        }

        // Constructor 2
        public SoftwareEngineer(string id, string fullName, double baseSalary, string primaryLanguage, double technicalAllowance)
            : base(id, fullName, baseSalary)
        {
            PrimaryLanguage = primaryLanguage;
            TechnicalAllowance = technicalAllowance;
        }

        ~SoftwareEngineer()
        {
            Console.WriteLine($"[Hủy] Đối tượng SoftwareEngineer: {Id} - {FullName} được giải phóng.");
        }

        // Ghi đè tính chi phí: Lương CB + Phụ cấp
        public override double CalculateMonthlyCost()
        {
            return BaseSalary + TechnicalAllowance;
        }

        // Ghi đè hiển thị thông tin
        public override void DisplayInfo()
        {
            Console.WriteLine($"  - [SE] ID: {Id} | Tên: {FullName,-18} | Ngôn ngữ: {PrimaryLanguage,-6} | Lương: {BaseSalary,10:N0} | Phụ cấp: {TechnicalAllowance,10:N0} | Chi phí: {CalculateMonthlyCost(),10:N0}");
        }
    }
}