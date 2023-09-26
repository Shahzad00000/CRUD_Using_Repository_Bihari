using CRUD_Using_Repository_Bihari.Models;
using CRUD_Using_Repository_Bihari.Repository.Interface;
using Microsoft.AspNetCore.Mvc;

namespace CRUD_Using_Repository_Bihari.Controllers
{
    public class UserController : Controller
    {
        private readonly IUser _UserRepository;

        public UserController(IUser userRepository)
        {
            _UserRepository = userRepository;
        }

        public async Task<IActionResult> GetUserList()
        {
            var Data = await _UserRepository.GetUsers();
            return View(Data);
        }
        [HttpGet]
        public async Task<IActionResult> AddUser()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> AddUser(User user)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return View(user);
                }
                else
                {
                    await _UserRepository.AddUser(user);
                    if (user.UserId == 0)
                    {
                        TempData["userError"] = "Record Not Save!";
                    }
                    else
                    {
                        TempData["UserError"] = "Record Successfully Save!";
                    }
                }
            }
            catch (Exception)
            {

                throw;
            }
            return RedirectToAction("GetUserList");
        }
        public async Task<IActionResult> Edit(int Id)
        {
            User user = new User();
            try
            {
                if (Id == 0)
                {
                    return BadRequest();
                }
                else
                {
                    user = await _UserRepository.GetUserById(Id);
                    if (user == null)
                    {
                        return NotFound();
                    }
                }
                return View(user);

            }
            catch (Exception ex)
            {

                TempData["UserError"] = "An error occurred while loading the user data: " + ex.Message;
                return RedirectToAction("GetUserList");
            }
        }
        [HttpPost]
        public async Task<IActionResult>Edit(User user)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    // Log or debug ModelState errors
                    var errors = ModelState.Values.SelectMany(v => v.Errors);
                    foreach (var error in errors)
                    {
                        // Log or debug the error here
                    }

                    return View(user);
                }
                else
                {
                    bool status=await _UserRepository.UpdateRecord(user);
                    if(status)
                    {
                        TempData["UserError"] = "Your Record has been Successfully Updated!";

                    }
                    else
                    {
                        TempData["userError"] = "Record been Not be Updated!";

                    }
                }
                return RedirectToAction("GetUserList");
            }
            catch (Exception ex)
            {

                TempData["UserError"] = "An error occurred while loading the user data: " + ex.Message;
                return RedirectToAction("GetUserList");
            } 
            
        }

        public  async Task<IActionResult> DeleteRecord(int id)
        {
            try
            {
                if(id==0)
                {
                 return BadRequest();
                }
                else
                {
                    bool status=await _UserRepository.DeleteRecord(id); 
                    if(status)
                    {
                        TempData["UserError"] = "Your Record has been Successfully Deleted!";

                    }
                    else
                    {
                        TempData["userError"] = "Record been Not be Delete!";

                    }
                }
            return RedirectToAction("GetUserList");
            }
            catch (Exception ex)
            {
                TempData["UserError"] = "An error occurred while updating the record: " + ex.Message;
                return RedirectToAction("GetUserList");
            }
        }
    }
}
