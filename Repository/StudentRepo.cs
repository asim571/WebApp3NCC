using WebApp3ByAsim.Models;
using Microsoft.Data.SqlClient;

namespace WebApp3ByAsim.Repository
{
    public class StudentRepo
    {
        public void AddRecord(Student stu)
        {
            string conStr = @"Server= ASIM; database= AsimNCCLab; integrated security=SSPI;TrustServerCertificate=True";
            using (SqlConnection conn = new SqlConnection(conStr))
            {
                conn.Open();
                string myQuery = "INSERT INTO Students_ (Id, Name, Address, Faculty) VALUES (@Id, @Name, @Address, @Faculty)";
                SqlCommand cmd = new SqlCommand(myQuery, conn);
                cmd.Parameters.AddWithValue("@Id", stu.Id);
                cmd.Parameters.AddWithValue("@Name", stu.Name);
                cmd.Parameters.AddWithValue("@Address", stu.Address);
                cmd.Parameters.AddWithValue("@Faculty", stu.Faculty);
                cmd.ExecuteNonQuery();
            }
        }

        public IEnumerable<Student> GetAllStudentsRecords()
        {
            string conStr = @"Server= ASIM; database= AsimNCCLab; integrated security=SSPI;TrustServerCertificate=True";
            List<Student> students = new List<Student>();
            using (SqlConnection conn = new SqlConnection(conStr))
            {
                conn.Open();
                string myQuery = "SELECT * FROM Students_";
                SqlCommand cmd = new SqlCommand(myQuery, conn);
                SqlDataReader rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    Student stu = new Student();
                    stu.Id = Convert.ToInt32(rdr["Id"]);
                    stu.Name = Convert.ToString(rdr["Name"]);
                    stu.Address = Convert.ToString(rdr["Address"]);
                    stu.Faculty = Convert.ToString(rdr["Faculty"]);
                    students.Add(stu);
                }
            }
            return students;
        }

        public Student GetSingleStudentRecord(int id)
        {
            string conStr = @"Server= ASIM; database= AsimNCCLab; integrated security=SSPI;TrustServerCertificate=True";
            Student stu = new Student();
            using (SqlConnection conn = new SqlConnection(conStr))
            {
                conn.Open();
                string myQuery = "SELECT * FROM Students_ WHERE Id = @Id";
                SqlCommand cmd = new SqlCommand(myQuery, conn);
                cmd.Parameters.AddWithValue("@Id", id);
                SqlDataReader rdr = cmd.ExecuteReader();
                rdr.Read();
                stu.Id = Convert.ToInt32(rdr["Id"]);
                stu.Name = Convert.ToString(rdr["Name"]);
                stu.Address = Convert.ToString(rdr["Address"]);
                stu.Faculty = Convert.ToString(rdr["Faculty"]);
            }
            return stu;
        }

        public void EditRecord(Student stu)
        {
            string conStr = @"Server= ASIM; database= AsimNCCLab; integrated security=SSPI;TrustServerCertificate=True";

            string myQuery = "UPDATE Students_ SET Name = @Name, Address = @Address, Faculty = @Faculty WHERE Id = @Id";

            using (SqlConnection conn = new SqlConnection(conStr))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand(myQuery, conn);
                cmd.Parameters.AddWithValue("@Name", stu.Name);
                cmd.Parameters.AddWithValue("@Address", stu.Address);
                cmd.Parameters.AddWithValue("@Faculty", stu.Faculty);
                cmd.Parameters.AddWithValue("@Id", stu.Id);
                cmd.ExecuteNonQuery();
            }
        }

        public void DeleteRecord(Student stu)
        {
            string conStr = @"Server= ASIM; database= AsimNCCLab; integrated security=SSPI;TrustServerCertificate=True";
            using (SqlConnection conn = new SqlConnection(conStr))
            {
                conn.Open();
                string myQuery = "DELETE FROM Students_ WHERE Id = @Id";
                SqlCommand cmd = new SqlCommand(myQuery, conn);
                cmd.Parameters.AddWithValue("@Id", stu.Id);
                cmd.ExecuteNonQuery();
            }
        }


    }
}
