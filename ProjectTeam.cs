/****************/
// Mã sinh viên: 202418832
// Họ tên:       Bùi Ngọc Trâm Anh
/****************/
using System;
using System.Collections;

namespace LabProject
{
    public class ProjectTeam
    {
        public string ProjectCode { get; private set; }
        public string ProjectName { get; private set; }
        public Employee Leader { get; private set; }

        // Sử dụng ArrayList để tránh triệt để lỗi generic type arguments
        private ArrayList members = new ArrayList();

        public ProjectTeam(string projectCode, string projectName)
        {
            ProjectCode = projectCode;
            ProjectName = projectName;
            Leader = null;
        }

        public ProjectTeam(string projectCode, string projectName, Employee leader)
        {
            ProjectCode = projectCode;
            ProjectName = projectName;
            AddMember(leader, true);
        }

        ~ProjectTeam()
        {
            Console.WriteLine("[Huy] Nhom du an [" + ProjectCode + "] bi huy. (Nhan su van ton tai)");
            members.Clear();
        }

        public bool Contains(string employeeId)
        {
            foreach (object obj in members)
            {
                Employee emp = obj as Employee;
                if (emp != null && emp.Id.Equals(employeeId, StringComparison.OrdinalIgnoreCase))
                {
                    return true;
                }
            }
            return false;
        }

        public bool AddMember(Employee employee)
        {
            return AddMember(employee, false);
        }

        public bool AddMember(Employee employee, bool makeLeader)
        {
            if (employee == null) return false;

            if (Contains(employee.Id))
            {
                if (makeLeader)
                {
                    Leader = employee;
                    return true;
                }
                return false;
            }

            members.Add(employee);
            if (makeLeader)
            {
                Leader = employee;
            }
            return true;
        }

        public bool RemoveMember(string employeeId)
        {
            if (Leader != null && Leader.Id.Equals(employeeId, StringComparison.OrdinalIgnoreCase))
            {
                Console.WriteLine("[Loi] Khong the xoa " + employeeId + " vi dang la Truong nhom.");
                return false;
            }

            Employee target = null;
            foreach (object obj in members)
            {
                Employee emp = obj as Employee;
                if (emp != null && emp.Id.Equals(employeeId, StringComparison.OrdinalIgnoreCase))
                {
                    target = emp;
                    break;
                }
            }

            if (target != null)
            {
                members.Remove(target);
                return true;
            }
            return false;
        }

        public void ChangeLeader(Employee newLeader)
        {
            if (newLeader == null) return;

            if (!Contains(newLeader.Id))
            {
                AddMember(newLeader, true);
            }
            else
            {
                Leader = newLeader;
            }
        }

        public double CalculateTotalMonthlyCost()
        {
            double total = 0;
            foreach (object obj in members)
            {
                Employee emp = obj as Employee;
                if (emp != null)
                {
                    total += emp.CalculateMonthlyCost();
                }
            }
            return total;
        }

        public void DisplayTeam()
        {
            Console.WriteLine();
            Console.WriteLine("================== DU AN: " + ProjectCode + " - " + ProjectName + " ==================");
            string leaderStr = (Leader != null) ? (Leader.FullName + " (" + Leader.Id + ")") : "Chua co";
            Console.WriteLine("Truong nhom: " + leaderStr);
            Console.WriteLine("Danh sach thanh vien:");
            foreach (object obj in members)
            {
                Employee emp = obj as Employee;
                if (emp != null)
                {
                    emp.DisplayInfo();
                }
            }
            Console.WriteLine("=> Tong chi phi hang thang: " + CalculateTotalMonthlyCost().ToString("N0") + " VND");
            Console.WriteLine("========================================================================");
            Console.WriteLine();
        }
    }
}