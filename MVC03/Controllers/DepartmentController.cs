global using Azure.Core;
global using BLL.DataTransferObject.Department;
global using BLL.Services;
global using DAL.Entities;
global using Microsoft.AspNetCore.Mvc;

namespace MVC03.Controllers;

public class DepartmentController(IDepartmentService departmentService,
    ILogger<DepartmentController> logger, IWebHostEnvironment env ) : Controller
{
    [HttpGet]
    public IActionResult Index()
    {
        var departments = departmentService.GetAll();

        return View(departments);
    }

    #region Create
    [HttpGet]
    public IActionResult Create()
    {
        return View();
    }
    [HttpPost]
    public IActionResult Create(DepartmentRequest request)
    {
        //server side validation
        if (ModelState.IsValid)
        {
            return View(request);
        }
        try
        {
            var result = departmentService.Add(request);
            //throw new Exception();

            if(result > 0)
            {
                return RedirectToAction(nameof(Index));
            }
            ModelState.AddModelError(string.Empty, "Can't department now");
        }
        catch (Exception ex) {
            if (env.IsDevelopment()) {
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
        if(!id.HasValue) return BadRequest();

        var department = departmentService.GetById(id.Value);
        //if null
        if(department ==null)  return NotFound();
        return View(department);
    }

    #endregion

    #region Edit
    [HttpGet]
    public IActionResult Edit(int? id)
    {
        //doesnt have a value
        if (!id.HasValue) return BadRequest();

        var department = departmentService.GetById(id.Value);
        //if null
        if (department == null) return NotFound();
        return View(department);
    }
    [HttpPost]
    public IActionResult Edit([FromRoute] int? id, DepartmentUpdateRequest request)
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
            var result = departmentService.Update(request);

            if (result > 0)
            {
                return RedirectToAction(nameof(Index));
            }
            ModelState.AddModelError(string.Empty, "Can't department now");
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

        var department = departmentService.GetById(id.Value);
        //if null
        if (department == null) return NotFound();
        return View(department);
    }

    [HttpPost, ActionName("Delete")]
    public IActionResult ConfirmDelete(int? id)
    {
        //server side validation
        if (!id.HasValue) { return BadRequest(); }
        try
        {
            var department = departmentService.GetById(id.Value);
            var IsDeleted = departmentService.Delete(id.Value) > 0; 

            if (IsDeleted)
            {
                return RedirectToAction(nameof(Index));
            }
            ModelState.AddModelError(string.Empty, "Can't department now");
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
        return View();
    }
    #endregion
}
