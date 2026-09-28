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

            Console.WriteLine("--- 1. Tạo hai Employee bằng 2 constructor khác nhau ---");
            Employee emp1 = new Employee(); // Mặc định
            Employee emp2 = new Employee("NV01", "Trần Văn An", 10_000_000);

            Console.WriteLine("\n--- 2. Tạo hai SoftwareEngineer bằng 2 constructor khác nhau ---");
            SoftwareEngineer se1 = new SoftwareEngineer("SE01", "Lê Thị Bình", "C#");
            SoftwareEngineer se2 = new SoftwareEngineer("SE02", "Nguyễn Văn Cường", 15_000_000, "Python", 3_000_000);

            Console.WriteLine("\n--- 3. Tăng lương một nhân sự bằng số tiền cố định ---");
            emp2.IncreaseSalary(2_000_000);

            Console.WriteLine("\n--- 4. Tăng lương một nhân sự khác theo phần trăm ---");
            se2.IncreaseSalary(10, true);

            Console.WriteLine("\n--- 5. Tạo nhóm dự án không có trưởng nhóm ---");
            ProjectTeam teamA = new ProjectTeam("DA01", "Hệ Thống ERP Doanh Nghiệp");

            Console.WriteLine("\n--- 6. Thêm một nhân sự vào nhóm bằng addMember(employee) ---");
            teamA.AddMember(emp2);

            Console.WriteLine("\n--- 7. Thêm một kỹ sư bằng addMember(employee, true) làm trưởng nhóm ---");
            teamA.AddMember(se2, true);

            Console.WriteLine("\n--- 8. Thử thêm lại một thành viên đã tồn tại ---");
            bool added = teamA.AddMember(emp2);
            Console.WriteLine($"Kết quả thêm lại NV01: {(added ? "Thành công" : "Bị từ chối do đã tồn tại")}");

            Console.WriteLine("\n--- 9 & 10. Hiển thị danh sách bằng lời gọi đa hình & Tính tổng chi phí ---");
            teamA.DisplayTeam();

            Console.WriteLine("--- 11. Thử xóa trưởng nhóm hiện tại và kiểm tra thao tác bị từ chối ---");
            teamA.RemoveMember(se2.Id);

            Console.WriteLine("\n--- 12. Đổi trưởng nhóm rồi xóa người từng là trưởng nhóm ---");
            teamA.ChangeLeader(emp2);
            Console.WriteLine("Đã chuyển trưởng nhóm sang emp2. Tiến hành xóa cựu trưởng nhóm se2:");
            teamA.RemoveMember(se2.Id);
            teamA.DisplayTeam();

            Console.WriteLine("--- 13. Tạo nhóm thứ 2 và thêm nhân sự đã có ở nhóm 1 (Quan hệ kết tập) ---");
            // emp2 đang ở teamA, đưa tiếp vào team B
            ProjectTeam teamB = new ProjectTeam("DA02", "App Di Động Bán Hàng", emp2);
            teamB.AddMember(se1);
            teamB.DisplayTeam();

            Console.WriteLine("--- 14 & 15. Hủy nhóm thứ hai trong khối lệnh cục bộ và chứng minh nhân sự vẫn còn tồn tại ---");
            ExecuteLocalScope(emp2);

            // Kiểm tra đối tượng emp2 sau khi khối scope bị hủy
            Console.WriteLine($"Sau khi Team bị hủy, nhân sự ngoài scope vẫn tồn tại:");
            emp2.DisplayInfo();

            Console.WriteLine("\nKết thúc chương trình kiểm thử.");
        }

        static void ExecuteLocalScope(Employee sharedEmp)
        {
            Console.WriteLine(">> Bắt đầu Scope cục bộ:");
            ProjectTeam tempTeam = new ProjectTeam("DA_TEMP", "Dự Án Tạm Thời", sharedEmp);
            tempTeam.DisplayTeam();
            Console.WriteLine(">> Kết thúc Scope cục bộ, giải phóng biến tempTeam...");
        }
    }
}
