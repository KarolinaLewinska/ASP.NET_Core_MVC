using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using StudentsDataSystem.Models;

namespace StudentsDataSystem.Controllers
{
    [Authorize]
    public class StudentsController : Controller
    {
        private readonly StudentsSystemContext _context;

        public StudentsController(StudentsSystemContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index(string searchBy, string currentFilter, string search, string sortBy, int? pageNumber)
        {
            ViewBag.Message = HttpContext.Session.GetString("SessionVar1");
            ViewBag.CurrentSort = sortBy;
            ViewBag.sortBySurname = string.IsNullOrEmpty(sortBy) ? "surname_desc" : "";  
            ViewBag.sortByNames = sortBy == "names" ? "names_desc" : "names";
            ViewBag.sortBysType = sortBy == "stype" ? "stype_desc" : "stype";
            ViewBag.sortByDegree = sortBy == "degree" ? "degree_desc" : "degree";
            ViewBag.sortByField = sortBy == "field" ? "field_desc" : "field";
            ViewBag.sortBySpecialization = sortBy == "spec" ? "spec_desc" : "spec";
            ViewBag.sortBySemester = sortBy == "semester" ? "semester_desc" : "semester";
            ViewBag.sortByGroup = sortBy == "group" ? "group_desc" : "group";
            ViewBag.sortByIndex = sortBy == "studentIndex" ? "studentIndex_desc" : "studentIndex";

            if (search != null)
            {
                pageNumber = 1;
            }
            else
            {
                search = currentFilter;
            }

            ViewBag.currentFilter = search;

            var students = _context.Students.AsQueryable();

            if (searchBy == "stype")
            {
                students = students.Where(s => s.studiesType.StartsWith(search) || search == null); 
            }
            else if (searchBy == "degree")
            {
                students = students.Where(s => s.degree.Equals(search) || search == null);
            }
            else if (searchBy == "field")
            {
                students = students.Where(s => s.fieldOfStudy.StartsWith(search) || search == null);
            }
            else if (searchBy == "specialization")
            {
                students = students.Where(s => s.specialization.StartsWith(search) || search == null);
            }
            else if (searchBy == "semester")
            {
                students = students.Where(s => s.semester.StartsWith(search) || search == null);
            }
            else if (searchBy == "group")
            {
                students = students.Where(s => s.studentsGroup.Contains(search) || search == null);
            }
            else if(searchBy == "studentIndex")
            {
                students = students.Where(s => s.studentIdNumber.StartsWith(search) || search == null);
            }
            else
            {
                students = students.Where(s => s.surname.StartsWith(search) || search == null);
            }

            switch (sortBy)
            {
                case "surname_desc":
                    students = students.OrderByDescending(s => s.surname);
                    break;
                case "names_desc":
                    students = students.OrderByDescending(s => s.names);
                    break;
                case "names":
                    students = students.OrderBy(s => s.names);
                    break;
                case "stype_desc":
                    students = students.OrderByDescending(s => s.studiesType);
                    break;
                case "stype":
                    students = students.OrderBy(s => s.studiesType);
                    break;
                case "degree_desc":
                    students = students.OrderByDescending(s => s.degree);
                    break;
                case "degree":
                    students = students.OrderBy(s => s.degree);
                    break;
                case "field_desc":
                    students = students.OrderByDescending(s => s.fieldOfStudy);
                    break;
                case "field":
                    students = students.OrderBy(s => s.fieldOfStudy);
                    break;
                case "spec_desc":
                    students = students.OrderByDescending(s => s.specialization);
                    break;
                case "spec":
                    students = students.OrderBy(s => s.specialization);
                    break;
                case "semester_desc":
                    students = students.OrderByDescending(s => s.semester);
                    break;
                case "semester":
                    students = students.OrderBy(s => s.semester);
                    break;
                case "group_desc":
                    students = students.OrderByDescending(s => s.studentsGroup);
                    break;
                case "group":
                    students = students.OrderBy(s => s.studentsGroup);
                    break;
                case "studentIndex_desc":
                    students = students.OrderByDescending(s => s.studentIdNumber);
                    break;
                case "studentIndex":
                    students = students.OrderBy(s => s.studentIdNumber);
                    break;
                default:
                    students = students.OrderBy(s => s.surname);
                    break;
            }
            int pageSize = 20;

            return View(await Paging<Student>.CreateAsync(students.AsNoTracking(), pageNumber ?? 1, pageSize));
        }

     
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                Response.StatusCode = 404;
                return View("idNullError");
            }

            var student = await _context.Students
                .FirstOrDefaultAsync(m => m.id == id);

            if (student == null)
            {
               Response.StatusCode = 404;
               return View("StudentNotFound", id.Value);
            }

            return View(student);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create( Student student)
        {
            bool isEmailNotUnique = _context.Students.Any(x => x.email == student.email);
            bool isPhoneNumNotUnique = _context.Students.Any(x => x.phoneNumber == student.phoneNumber);
            bool isPeselNotUnique = _context.Students.Any(x => x.pesel == student.pesel);
            bool isIndexNumNotUnique = _context.Students.Any(x => x.studentIdNumber == student.studentIdNumber);

            if (isEmailNotUnique)
            {
               ModelState.AddModelError("email", "Podany adres email istnieje już w bazie!");
            }
            if (isPhoneNumNotUnique)
            {
                ModelState.AddModelError("phoneNumber", "Podany numer telefonu istnieje już w bazie!");
            }
            if (isPeselNotUnique)
            {
                ModelState.AddModelError("pesel", "Podany numer PESEL istnieje już w bazie!");
            }
            if (isIndexNumNotUnique)
            {
                ModelState.AddModelError("studentIdNumber", "Podany numer indexu istnieje już w bazie!");
            }

            try
            {
                if (ModelState.IsValid)
                {
                    _context.Add(student);
                    await _context.SaveChangesAsync();
                    TempData["Message"] = "Dane studenta: " + student.names + " " + student.surname + " zostały pomyślnie dodane do bazy";
                    var names = student.names;
                    var surname = student.surname;
                    HttpContext.Session.SetString("SessionVar1", "Ostatnio dodano dane studenta: " + names + " " + surname);
                    return RedirectToAction(nameof(Create));
                }
            }
            catch (System.Data.DataException)
            {
                ModelState.AddModelError("", "Nie udało się dodać danych. Spróbuj ponownie");
            };
            return View(student);
        }

        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                Response.StatusCode = 404;
                return View("idNullError");
            }

            var student = await _context.Students.FindAsync(id);
            if (student == null)
            {
                Response.StatusCode = 404;
                return View("StudentNotFound", id.Value);
            }
            return View(student);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id,  Student student)
        {
            if (id != student.id)
            {
                Response.StatusCode = 404;
                return View("wrongIdError");
            }

            bool isEmailNotUnique = _context.Students.Any(x => x.email == student.email && x.id != id);
            bool isPhoneNumNotUnique = _context.Students.Any(x => x.phoneNumber == student.phoneNumber && x.id != id);
            bool isPeselNotUnique = _context.Students.Any(x => x.pesel == student.pesel && x.id != id);
            bool isIndexNumNotUnique = _context.Students.Any(x => x.studentIdNumber == student.studentIdNumber && x.id != id);

            if (isEmailNotUnique)
            {
                ModelState.AddModelError("email", "Podany adres email istnieje już w bazie!");
            }
            if (isPhoneNumNotUnique)
            {
                ModelState.AddModelError("phoneNumber", "Podany numer telefonu istnieje już w bazie!");
            }
            if (isPeselNotUnique)
            {
                ModelState.AddModelError("pesel", "Podany numer PESEL istnieje już w bazie!");
            }
            if (isIndexNumNotUnique)
            {
                ModelState.AddModelError("studentIdNumber", "Podany numer indexu istnieje już w bazie!");
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(student);
                    await _context.SaveChangesAsync();
                    TempData["Message"] = "Edycja danych studenta: " + student.names + " " + student.surname + " przebiegła pomyślnie";
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!StudentExists(student.id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }

                var names = student.names;
                var surname = student.surname;
                HttpContext.Session.SetString("SessionVar1", "Ostatnio zaktualizowano dane studenta: " + names + " " + surname);
                return RedirectToAction(nameof(Edit));
            }
            return View(student);
        }

        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                Response.StatusCode = 404;
                return View("idNullError");
            }

            var student = await _context.Students
                .FirstOrDefaultAsync(m => m.id == id);
            if (student == null)
            {
                Response.StatusCode = 404;
                return View("StudentNotFound", id.Value);
            }

            return View(student);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete (int id)
        {
            try
            {
                Student studentToDelete = new Student { id = id };
                _context.Entry(studentToDelete).State = EntityState.Deleted;
                await _context.SaveChangesAsync();
                TempData["Message"] = "Dane studenta zostały usunięte";
                return RedirectToAction(nameof(Index));
            }

            catch (DbUpdateException)
            {
                return RedirectToAction("Delete", new { id = id, saveChangesError = true });
            }
        }

        private bool StudentExists(int id)
        {
            return _context.Students.Any(e => e.id == id);
        }
    }
}
