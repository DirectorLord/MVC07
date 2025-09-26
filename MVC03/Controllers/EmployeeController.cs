using BLL.DataTransferObject.Employee;
using Microsoft.AspNetCore.Mvc.ViewFeatures;

namespace MVC04.Controllers;

public class EmployeeController(IEmployeeService EmployeeService,
    ILogger<EmployeeController> logger, IWebHostEnvironment env) : Controller
{
    [HttpGet]
    public IActionResult Index()
    {
        var Employees = EmployeeService.GetAll();
        return View(Employees);
    }

    #region Create
    [HttpGet]
    public IActionResult Create()
    {
        return View();
    }
    [HttpPost]
    public IActionResult Create(EmployeeRequest request)
    {
        //server side validation
        if (!ModelState.IsValid)
        {
            return View(request);
        }
        try
        {
            var result = EmployeeService.Add(request);
            //throw new Exception();

            if (result > 0)
            {
                TempData["Message"] = $"Employee with Name {request.Name} has created";
                return RedirectToAction(nameof(Index));
            }
            else
            {
                TempData["Message"] = $"Can not create Employee with name {request.Name}";
                return RedirectToAction(nameof(Index));
            }
        }
        catch (Exception ex)
        {
            if (env.IsDevelopment())
            {
                ModelState.AddModelError(string.Empty, ex.Message);
            }
            else
            {
                logger.LogError(ex, ex.Message);
            }
        }
        return View(request);
    }
    #endregion

    #region Details

    [HttpGet]
    public IActionResult Details(int? id)
    {
        //doesnt have a value
        if (!id.HasValue) return BadRequest();

        var employee = EmployeeService.GetById(id.Value); // Changed variable name to lowercase
        //if null
        if (employee == null) return NotFound();
        return View(employee); // Updated to use the correct variable name
    }

    #endregion

    #region Edit
    [HttpGet]
    public IActionResult Edit(int? id)
    {
        //doesnt have a value
        if (!id.HasValue) return BadRequest();

        var employee = EmployeeService.GetById(id.Value); // Changed variable name to lowercase
        //if null
        if (employee == null) return NotFound();
        return View(employee); // Updated to use the correct variable name
    }
    [HttpPost]
    public IActionResult Edit([FromRoute] int? id, EmployeeUpdateRequest request)
    {
        //server side validation
        if (!id.HasValue)
        {
            return BadRequest();
        }
        if (id != request.Id)
        {
            return BadRequest();
        }
        if (ModelState.IsValid)
        {
            return View(request);
        }
        try
        {
            var result = EmployeeService.Update(request);

            if (result > 0)
            {
                return RedirectToAction(nameof(Index));
            }
            ModelState.AddModelError(string.Empty, "Can't Employee now");
        }
        catch (Exception ex)
        {
            if (env.IsDevelopment())
            {
                ModelState.AddModelError(string.Empty, ex.Message);
            }
            else
            {
                logger.LogError(ex, ex.Message);
            }
        }
        return View(request);
    }
    #endregion

    #region Delete
    [HttpGet]
    public IActionResult Delete(int? id)
    {
        //doesnt have a value
        if (!id.HasValue) return BadRequest();

        var employee = EmployeeService.GetById(id.Value); // Changed variable name to lowercase
        //if null
        if (employee == null) return NotFound();
        return View(employee); // Updated to use the correct variable name
    }

    [HttpPost, ActionName("Delete")]
    public IActionResult ConfirmDelete(int? id)
    {
        //server side validation
        if (!id.HasValue) { return BadRequest(); }
        try
        {
            var employee = EmployeeService.GetById(id.Value); // Changed variable name to lowercase
            var IsDeleted = EmployeeService.Delete(id.Value);
            //throw new Exception();

            if (IsDeleted)
            {
                return RedirectToAction(nameof(Index));
            }
            ModelState.AddModelError(string.Empty, "Can't Employee now");
        }
        catch (Exception ex)
        {
            if (env.IsDevelopment())
            {
                ModelState.AddModelError(string.Empty, ex.Message);
            }
            else
            {
                logger.LogError(ex, ex.Message);
            }
        }
        return View(Employee);
    }

    #endregion : Controller

}
