using System;
using System.Threading.Tasks;
using AspNetCoreTodo.Models;
using AspNetCoreTodo.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;


namespace AspNetCoreTodo.Controllers
{
    [Authorize]
    public class TodoController : Controller
    {
    private readonly ITodoItemService _todoItemService;
    
    public TodoController(ITodoItemService todoItemService)
    {
        _todoItemService = todoItemService;
    }
        public async Task<IActionResult> Index()
        {
           var items = await _todoItemService.GetIncompleteItemsAsync();

           var model = new TodoViewModel()
           {
               Items = items
           };

           return View(model);
        }

        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AddItem(TodoItem newItem)
        {
            if (!ModelState.IsValid)
            {
                return RedirectToAction("Index");
            }

            var successful = await _todoItemService.AddItemAsync(newItem);
            if (!successful)
            {
                return BadRequest("Could not add item.");
            }
            return RedirectToAction("Index");
        }

        [ValidateAntiForgeryToken]
        public async Task<IActionResult> MarkDone(Guid id)
        {
            if (id == Guid.Empty)
            {
                return RedirectToAction("Index");
            }

            var successful = await _todoItemService.MarkDoneAsync(id);
            if (!successful)
            {
                return BadRequest("Could not mark item as done.");
            }
            return RedirectToAction("Index");
        }


        // [ValidateAntiForgeryToken]
        // public async Task<IActionResult> SetDueDate(TodoItem newItem)
        // {
        //     if (!ModelState.IsValid)
        //     {
        //         return RedirectToAction("Index");
            }

            // var dateTime = await _todoItemService.SetDueDateAsync(newItem);
            // if (dateTime)
            // {
            //     return BadRequest("Could not add item.");
            // }
            // return RedirectToAction("Index");
           
        // }}
    
}