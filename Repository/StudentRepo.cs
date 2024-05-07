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
                string myQuery = $"INSERT INTO Students_(Id,Name,Address,Faculty) " +
                    $"VALUES({stu.Id},'{stu.Name}','{stu.Address}','{stu.Faculty}')";
                SqlCommand cmd = new SqlCommand(myQuery, conn);
                cmd.ExecuteNonQuery();
            }
        }
        //method for getting all records from table
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
        //to fetch single record detaial given the id value
        public Student GetSingleStudentRecord(int id)
        {
            string conStr = @"Server= ASIM; database= AsimNCCLab; integrated security=SSPI;TrustServerCertificate=True";
            Student stu = new Student();
            using (SqlConnection conn = new SqlConnection(conStr))
            {
                conn.Open();
                string myQuery = $"SELECT * FROM Students_ WHERE Id ={id}";
                SqlCommand cmd = new SqlCommand(myQuery, conn);
                SqlDataReader rdr = cmd.ExecuteReader();
                rdr.Read();
                stu.Id = Convert.ToInt32(rdr["Id"]);
                stu.Name = Convert.ToString(rdr["Name"]);
                stu.Address = Convert.ToString(rdr["Address"]);
                stu.Faculty = Convert.ToString(rdr["Faculty"]);
            }
            return stu;
        }
        //to update the given record 

        public void EditRecord(Student stu)
        {
            string conStr = @"Server= ASIM; database= AsimNCCLab; integrated security=SSPI;TrustServerCertificate=True";
            using (SqlConnection conn = new SqlConnection(conStr))
            {
                conn.Open();
                string myQuery = $"UPDATE Students_ SET Id ={stu.Id}, Name = '{stu.Name}'" +
                    $",Address = '{stu.Address}',Faculty = '{stu.Faculty}' WHERE Id ={stu.Id} ";
                SqlCommand cmd = new SqlCommand(myQuery, conn);
                cmd.ExecuteNonQuery();
            }
        }
        //delete

        public void DeleteRecord(Student stu)
        {
            string conStr = @"Server= ASIM; database= AsimNCCLab; integrated security=SSPI;TrustServerCertificate=True";
            using (SqlConnection conn = new SqlConnection(conStr))
            {
                conn.Open();
                string myQuery = $"DELETE FROM Students_ WHERE Id = {stu.Id} ";
                SqlCommand cmd = new SqlCommand(myQuery, conn);
                cmd.ExecuteNonQuery();
            }
        }

    }
}
