using Microsoft.AspNetCore.Mvc;
using ToDoListWithLambdaAndLinq.Interfaces;
using ToDoListWithLambdaAndLinq.Models;
using Microsoft.AspNetCore.Authorization;
using System.Security.Claims;

namespace ToDoListWithLambdaAndLinq.Controllers
{
    [Authorize]
    public class NoteController : Controller
    {
        private readonly INoteRepository _noteRepository;
        private readonly ICategoryRepository _categoryRepository;
        private readonly ITagRepository _tagRepository;

        public NoteController(INoteRepository noteService, ICategoryRepository categoryService, ITagRepository tagService)
        {
            _noteRepository = noteService;
            _categoryRepository = categoryService;
            _tagRepository = tagService;
        }

        public IActionResult Index()
        {
            var userIdString = User.FindFirstValue(ClaimTypes.NameIdentifier);
            if (string.IsNullOrEmpty(userIdString))
            {
                return RedirectToAction("Login", "Account");
            }

            var userId = int.Parse(userIdString);
            var notes = _noteRepository.GetNotesByUserId(userId);
            return View(notes);
        }

        public IActionResult Details(int id)
        {
            var note = _noteRepository.GetNoteById(id);
            if (note == null)
            {
                return NotFound();
            }
            return View(note);
        }

        public IActionResult Create()
        {
            ViewBag.Categories = _categoryRepository.GetAllCategories();
            ViewBag.Tags = _tagRepository.GetAllTags();
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Note note, int[] tagIds)
        {
            var userIdString = User.FindFirstValue(ClaimTypes.NameIdentifier);
            if (string.IsNullOrEmpty(userIdString))
            {
                return RedirectToAction("Login", "Login");
            }

            if (!int.TryParse(userIdString, out int userId))
            {
                return RedirectToAction("Login", "Login");
            }

            note.UserId = userId;

            if (ModelState.IsValid)
            {
                _noteRepository.CreateNote(note, tagIds);
                return RedirectToAction(nameof(Index));
            }

            ViewBag.Categories = _categoryRepository.GetAllCategories();
            ViewBag.Tags = _tagRepository.GetAllTags();
            return View(note);
        }

        public IActionResult Edit(int id)
        {
            var note = _noteRepository.GetNoteById(id);
            if (note == null)
            {
                return NotFound();
            }
            ViewBag.Categories = _categoryRepository.GetAllCategories();
            ViewBag.Tags = _tagRepository.GetAllTags();
            return View(note);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Note note, int[] tagIds)
        {
            if (ModelState.IsValid)
            {
                _noteRepository.UpdateNote(note, tagIds);
                return RedirectToAction(nameof(Index));
            }
            ViewBag.Categories = _categoryRepository.GetAllCategories();
            ViewBag.Tags = _tagRepository.GetAllTags();
            return View(note);
        }

        public IActionResult Delete(int id)
        {
            var note = _noteRepository.GetNoteById(id);
            if (note == null)
            {
                return NotFound();
            }
            return View(note);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            _noteRepository.DeleteNote(id);
            return RedirectToAction(nameof(Index));
        }
    }
}
