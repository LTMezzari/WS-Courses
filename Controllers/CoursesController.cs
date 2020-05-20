using System.Collections.Generic;
using System.Web.Http;
using System.Web.Http.Description;
using ws_courses.Models;

namespace ws_courses.Controllers
{
    public class CoursesController : ApiController {
        private DBCourseContext db = new DBCourseContext();

        [ResponseType(typeof(Course))]
        public IHttpActionResult PostCourse(Course course) {
            if (!ModelState.IsValid) {
                return BadRequest(ModelState);
            }

            db.Courses.Add(course);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = course.Id }, course);
        }

        [ResponseType(typeof(List<Course>))]
        public IHttpActionResult GetCourse() {
            return Ok(db.Courses);
        }

        [ResponseType(typeof(Course))]
        public IHttpActionResult PutCourse(Course course, int id) {
            if (!ModelState.IsValid || id < 0) {
                return BadRequest(ModelState);
            }

            var current = db.Courses.Find(id);
            current.PublicationDate = course.PublicationDate;
            current.Title = course.Title;
            current.Channel = course.Channel;
            current.URL = course.URL;
            current.WorkSchedule = course.WorkSchedule;

            db.SaveChanges();

            course.Id = id;
            return Ok(course);
        }

        [ResponseType(typeof(bool))]
        public IHttpActionResult DeleteCourse(int id) {
            if (!ModelState.IsValid || id < 0) {
                return BadRequest(ModelState);
            }

            var course = db.Courses.Find(id);
            db.Courses.Remove(course);
            db.SaveChanges();

            return Ok(new { success=true });
        }
    }
}
