
using StudentSystemManagement.DAL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StudentSystemManagement;
using School;

namespace StudentSystemManagement.BLL
{
    public class SSMBLL
    {
        public static School.TAIKHOAN IsAccount(string username, string password)
        {
            var Accounts = GetAccounts();
            foreach (School.TAIKHOAN item in Accounts)
            {
                if (item.USERNAME.TrimEnd() == username && item.PASSWORD.TrimEnd() == password)
                {
                    return item;
                }
            }
            return null;
        }

        public static List<School.TAIKHOAN> GetAccounts()
        {
            var Connection = SSMDAL.GetConnection();
            Connection.Open();
            SqlDataAdapter DataAdapter = new SqlDataAdapter("SELECT * FROM TAIKHOAN", Connection);
            Connection.Close();

            DataSet data = new DataSet();
            DataAdapter.Fill(data, "TAIKHOAN");
            var AccountList = new List<School.TAIKHOAN>();
            for (int i = 0; i < data.Tables["TAIKHOAN"].Rows.Count; i++)
            {
                var Account = new School.TAIKHOAN()
                {
                    USERNAME = data.Tables["TAIKHOAN"].Rows[i]["USERNAME"].ToString().TrimEnd(),
                    PASSWORD = data.Tables["TAIKHOAN"].Rows[i]["PASSWORD"].ToString().TrimEnd(),
                };
                if (int.Parse(data.Tables["TAIKHOAN"].Rows[i]["TYPE"].ToString()) == 0)
                {
                    Account.TYPE = School.LoginType.ACADEMICSTAFF;
                }
                else
                {
                    Account.TYPE = School.LoginType.STUDENT;
                }
                AccountList.Add(Account);
            }
            return AccountList;
        }

        public static List<School.Student> GetSinhViens()
        {
            var Connection = SSMDAL.GetConnection();
            Connection.Open();
            SqlDataAdapter DataAdapter = new SqlDataAdapter("SELECT * FROM SINHVIEN", Connection);
            Connection.Close();
            DataSet data = new DataSet();
            DataAdapter.Fill(data, "SINHVIEN");
            var StudentList = new List<School.Student>();
            for (int i = 0; i < data.Tables["SINHVIEN"].Rows.Count; i++)
            {
                var Student = new School.Student()
                {
                    MSSV = int.Parse(data.Tables["SINHVIEN"].Rows[i]["MSSV"].ToString()),
                    HoTen = data.Tables["SINHVIEN"].Rows[i]["HoTen"].ToString().TrimEnd(),
                    CMND = data.Tables["SINHVIEN"].Rows[i]["CMND"].ToString().TrimEnd(),
                    MaLop = data.Tables["SINHVIEN"].Rows[i]["MaLop"].ToString().TrimEnd()
                };
                if (data.Tables["SINHVIEN"].Rows[i]["GioiTinh"].ToString().TrimEnd().Equals("Nam"))
                {
                    Student.GioiTinh = School.GENDER.MALE;
                }
                else
                {
                    Student.GioiTinh = School.GENDER.FEMALE;
                }
                StudentList.Add(Student);
            }
            return StudentList;
        }

        public static List<School.Class> GetLopHocs()
        {
            var Connection = SSMDAL.GetConnection();
            Connection.Open();
            SqlDataAdapter DataAdapter = new SqlDataAdapter("SELECT * FROM LOPHOC", Connection);
            Connection.Close();
            DataSet data = new DataSet();
            DataAdapter.Fill(data, "LOP");
            var ClassList = new List<School.Class>();
            for (int i = 0; i < data.Tables["LOP"].Rows.Count; i++)
            {
                var Class = new School.Class()
                {
                    MaLop = data.Tables["LOP"].Rows[i]["MaLop"].ToString().TrimEnd(),
                    TenLop = data.Tables["LOP"].Rows[i]["TenLop"].ToString().TrimEnd()
                };
                ClassList.Add(Class);
            }
            return ClassList;
        }

        internal static bool IsExistCourse(string v, List<Subject> monHocs)
        {
            throw new NotImplementedException();
        }

        internal static bool IsExistStudentInCourse(int mssv, string maMonHoc, List<School.CHITIETMONHOC> chiTietMonHocs)
        {
            return chiTietMonHocs.Exists(x => x.MSSV == mssv && x.MaMonHoc == maMonHoc);
        }

        public static List<School.Subject> GetMonHocs()
        {
            var Connection = SSMDAL.GetConnection();
            Connection.Open();
            SqlDataAdapter DataAdapter = new SqlDataAdapter("SELECT * FROM MONHOC", Connection);
            Connection.Close();
            DataSet data = new DataSet();
            DataAdapter.Fill(data, "MONHOC");
            var CourseList = new List<School.Subject>();
            for (int i = 0; i < data.Tables["MONHOC"].Rows.Count; i++)
            {
                var Course = new School.Subject()
                {
                    MaMonHoc = data.Tables["MONHOC"].Rows[i]["MaMonHoc"].ToString().TrimEnd(),
                    TenMonHoc = data.Tables["MONHOC"].Rows[i]["TenMonHoc"].ToString().TrimEnd()
                };
                CourseList.Add(Course);
            }
            return CourseList;
        }

        public static List<School.Score> GetDiems()
        {
            var Connection = SSMDAL.GetConnection();
            Connection.Open();
            SqlDataAdapter DataAdapter = new SqlDataAdapter("SELECT * FROM DIEM", Connection);
            Connection.Close();
            DataSet data = new DataSet();
            DataAdapter.Fill(data, "DIEM");
            var ScoreList = new List<School.Score>();
            for (int i = 0; i < data.Tables["DIEM"].Rows.Count; i++)
            {
                var Score = new School.Score()
                {
                    MSSV = int.Parse(data.Tables["DIEM"].Rows[i]["MSSV"].ToString()),
                    MaMonHoc = data.Tables["DIEM"].Rows[i]["MaMonHoc"].ToString().TrimEnd(),
                    DIEMGIUAKY = float.Parse(data.Tables["DIEM"].Rows[i]["DiemGK"].ToString()),
                    DIEMCUOIKY = float.Parse(data.Tables["DIEM"].Rows[i]["DiemCK"].ToString()),
                    DIEMKHAC = float.Parse(data.Tables["DIEM"].Rows[i]["DiemKhac"].ToString())
                };

                ScoreList.Add(Score);
            }
            return ScoreList;
        }

        public static void SaveDatabase(string Command)
        {
            SqlConnection conn = SSMDAL.GetConnection();
            conn.Open();
            SqlCommand cmd = new SqlCommand(Command, conn);
            cmd.ExecuteNonQuery();
            conn.Close();
        }

        public static bool IsExistStudent(int mssv, List<School.Student> SinhViens)
        {
            foreach (var item in SinhViens)
            {
                if (item.MSSV == mssv)
                {
                    return true;
                }
            }
            return false;
        }

        public static bool IsExistClass(string classCode, List<School.Class> LopHocs)
        {
            foreach (var item in LopHocs)
            {
                if (item.MaLop.Equals(classCode))
                {
                    return true;
                }
            }
            return false;
        }

        internal static List<School.CHITIETMONHOC> GetChiTietMonHoc()
        {
            var Connection = SSMDAL.GetConnection();
            Connection.Open();
            SqlDataAdapter DataAdapter = new SqlDataAdapter("SELECT * FROM CHITIETMONHOC", Connection);
            Connection.Close();
            DataSet data = new DataSet();
            DataAdapter.Fill(data, "CHITIETMONHOC");
            var CourseDetailList = new List<School.CHITIETMONHOC>();
            for (int i = 0; i < data.Tables["CHITIETMONHOC"].Rows.Count; i++)
            {
                var CourseDetail = new School.CHITIETMONHOC()
                {
                    MSSV = int.Parse(data.Tables["CHITIETMONHOC"].Rows[i]["MSSV"].ToString()),
                    MaMonHoc = data.Tables["CHITIETMONHOC"].Rows[i]["MaMonHoc"].ToString().TrimEnd(),
                    PhongHoc = data.Tables["CHITIETMONHOC"].Rows[i]["PhongHoc"].ToString().TrimEnd()
                };

                CourseDetailList.Add(CourseDetail);
            }
            return CourseDetailList;
        }

        internal static bool IsExistCourse(string courseCode, List<School.CHITIETMONHOC> Courses)
        {
            return Courses.Find(x => x.MaMonHoc == courseCode) != null;
        }

        internal static List<School.TKB> GetThoiKhoaBieu()
        {
            var Connection = SSMDAL.GetConnection();
            Connection.Open();
            SqlDataAdapter DataAdapter = new SqlDataAdapter("SELECT * FROM THOIKHOABIEU", Connection);
            Connection.Close();
            DataSet data = new DataSet();
            DataAdapter.Fill(data, "THOIKHOABIEU");
            var ScheduleList = new List<School.TKB>();
            for (int i = 0; i < data.Tables["THOIKHOABIEU"].Rows.Count; i++)
            {
                var Schedule = new School.TKB()
                {
                    MaLop = data.Tables["THOIKHOABIEU"].Rows[i]["MaLop"].ToString().TrimEnd(),
                    MaMonHoc = data.Tables["THOIKHOABIEU"].Rows[i]["MaMonHoc"].ToString().TrimEnd()
                };

                ScheduleList.Add(Schedule);
            }
            return ScheduleList;
        }
    }
}
