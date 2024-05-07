using Microsoft.AspNetCore.Mvc;
using WebApp3ByAsim.Models;
using WebApp3ByAsim.Repository;
using Microsoft.Data.SqlClient;

namespace WebApp3ByAsim.Controllers
{
    public class StudentController : Controller
    {
        public IActionResult AllStudents()
        {
            StudentRepo st = new StudentRepo();
            try
            {
                IEnumerable<Student> listOfStudents = st.GetAllStudentsRecords();
                return View(listOfStudents);
            }
            catch (SqlException ex)
            {
                return Content("Error !!" + ex.Message);
            }
        }
        public IActionResult CreateStudentRecord()
        {
            return View();
        }
        [HttpPost]
        public IActionResult CreateStudentRecord(Student s)
        {
            StudentRepo st = new StudentRepo();
            try
            {
                st.AddRecord(s);
            }
            catch (SqlException ex)
            {
                return Content("Error !!" + ex.Message);
            }

            return Content("A record has been inserted !");
        }
        public IActionResult StudentDetail(int id)
        {
            StudentRepo st = new StudentRepo();
            try
            {
                Student s = st.GetSingleStudentRecord(id);
                return View(s);
            }
            catch (SqlException ex)
            {
                return Content("Error !!" + ex.Message);
            }
        }

        // edit
        public IActionResult EditStudentRecord(int id)
        {
            StudentRepo st = new StudentRepo();
            try
            {
                Student s = st.GetSingleStudentRecord(id);
                return View(s);
            }
            catch (SqlException ex)
            {
                return Content("Error !!" + ex.Message);
            }
        }
        [HttpPost]
        public IActionResult EditCollegeRecord(Student s)
        {
            StudentRepo st = new StudentRepo();
            try
            {
                st.EditRecord(s);
            }
            catch (SqlException ex)
            {
                return Content("Error !!" + ex.Message);
            }
            return Content("A record has been updated !");
        }

        public IActionResult DeleteStudentRecord(int id)
        {
            StudentRepo st = new StudentRepo();
            try
            {
                Student s = st.GetSingleStudentRecord(id);
                st.DeleteRecord(s);
                return Content("A record has been deleted !");
            }
            catch (SqlException ex)
            {
                return Content("Error !!" + ex.Message);
            }
        }

    }
}
