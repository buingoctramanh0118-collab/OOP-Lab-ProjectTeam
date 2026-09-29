/****************/
// Mã sinh viên: 202418832
// Họ tên:       Bùi Ngọc Trâm Anh
/****************/
using System;

namespace LabProject
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;
            Console.WriteLine("                KỊCH BẢN KIỂM THỬ                   ");
            Console.WriteLine("--- 1. Tao 2 Employee bang 2 constructor ---");
            // Constructor 2 tham số: id, fullName (lương mặc định = 0)
            Employee emp1 = new Employee("NV101", "Hoàng Nhật Minh");
            // Constructor 3 tham số: id, fullName, baseSalary
            Employee emp2 = new Employee("NV102", "Vũ Thùy Linh", 12_000_000);
            emp1.DisplayInfo();
            emp2.DisplayInfo();

            Console.WriteLine("\n--- 2. Tao 2 SoftwareEngineer bang 2 constructor ---");
            // Constructor 1 của SE: id, fullName, primaryLanguage
            SoftwareEngineer se1 = new SoftwareEngineer("SE201", "Đỗ Tuấn Kiệt", "Golang");
            // Constructor 2 của SE: id, fullName, baseSalary, primaryLanguage, technicalAllowance
            SoftwareEngineer se2 = new SoftwareEngineer("SE202", "Bùi Mai Phương", 18_000_000, "TypeScript", 4_500_000);
            se1.DisplayInfo();
            se2.DisplayInfo();

            Console.WriteLine("\n--- 3. Tang luong co dinh ---");
            emp2.IncreaseSalary(2_500_000);

            Console.WriteLine("\n--- 4. Tang luong theo phan tram ---");
            se2.IncreaseSalary(15, true);

            Console.WriteLine("\n--- 5. Tao nhom du an khong co truong nhom ---");
            ProjectTeam teamA = new ProjectTeam("DA_CLOUD", "Nền Tảng Đám Mây AI");
            Console.WriteLine("Đã khởi tạo thành công dự án [DA_CLOUD].");

            Console.WriteLine("\n--- 6. Them mot nhan su vao nhom bang addMember(employee) ---");
            teamA.AddMember(emp2);
            Console.WriteLine($"Đã bổ sung nhân sự {emp2.FullName} vào dự án.");

            Console.WriteLine("\n--- 7. Them mot ky su bang addMember(employee, true) lam truong nhom ---");
            teamA.AddMember(se2, true);
            Console.WriteLine($"Đã bổ sung kỹ sư {se2.FullName} và chỉ định làm Trưởng nhóm.");

            Console.WriteLine("\n--- 8. Thu them lai mot thanh vien da ton tai ---");
            bool added = teamA.AddMember(emp2);
            Console.WriteLine($"Thử thêm lại nhân sự {emp2.Id}: {(added ? "Thành công" : "Bị từ chối (Nhân sự đã tồn tại trong nhóm)")}");

            Console.WriteLine("\n--- 9 & 10. Hien thi danh sach bang loi goi da hinh & Tinh tong chi phi ---");
            teamA.DisplayTeam();

            Console.WriteLine("--- 11. Thu xoa truong nhom hien tai va kiem tra thao tac bi tu choi ---");
            teamA.RemoveMember(se2.Id);

            Console.WriteLine("\n--- 12. Doi truong nhom roi xoa nguoi tung la truong nhom ---");
            teamA.ChangeLeader(emp2);
            Console.WriteLine($"Đã bổ nhiệm Trưởng nhóm mới: {emp2.FullName} ({emp2.Id})");
            Console.WriteLine($"Tiến hành rút cựu trưởng nhóm {se2.FullName} khỏi dự án:");
            teamA.RemoveMember(se2.Id);
            teamA.DisplayTeam();

            Console.WriteLine("--- 13. Tao nhom thu 2 va them nhan su da co o nhom 1 (Quan he ket tap) ---");
            // Nhân sự emp2 vừa có ở teamA, vừa tham gia teamB
            ProjectTeam teamB = new ProjectTeam("DA_SECURITY", "Bảo Mật Hệ Thống", emp2);
            teamB.AddMember(se1);
            teamB.DisplayTeam();

            Console.WriteLine("--- 14 & 15. Huy nhom thu 2 trong khoi lenh cuc bo va chung minh nhan su van con ton tai ---");
            ExecuteLocalScope(emp2);

            Console.WriteLine("Sau khi dự án tạm thời bị hủy, đối tượng nhân sự bên ngoài phạm vi vẫn tồn tại:");
            emp2.DisplayInfo();

            Console.WriteLine("\nHoàn tất kiểm thử.");
        }

        static void ExecuteLocalScope(Employee sharedEmp)
        {
            Console.WriteLine(">> [Scope Cục bộ] Khởi tạo dự án nội bộ tạm thời:");
            ProjectTeam tempTeam = new ProjectTeam("DA_PILOT", "Dự Án Thử Nghiệm", sharedEmp);
            tempTeam.DisplayTeam();
            Console.WriteLine(">> [Scope Cục bộ] Kết thúc scope -> Thu hồi biến tempTeam...");
        }
    }
}
