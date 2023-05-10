using Microsoft.AspNetCore.Mvc;
using Users.Controllers.DTO;
using Users.Models.DTO;
using Users.Models.Entities;
using Users.Models.Repositories;

namespace Users.Controllers
{
    public class UsersController : Controller
    {
        private Repository _repository;
        private SemaphoreSlim _semaphore;

        public UsersController()
        {
            _repository = new Repository();
            _semaphore = new SemaphoreSlim(1, 1);
        }

        [HttpGet]
        public async Task<JsonResult> GetAllUsers()
        {
            List<User> result = await Task.Run(() => _repository.GetAllUsers());
            List<UserDTO> resultDTO = new List<UserDTO>();
            foreach (var user in result)
            {
                resultDTO.Add(new UserDTO(user));
            }
            return Json(resultDTO);
        }
        [HttpGet]
        public async Task<JsonResult> GetUserById(int userId)
        {
            User? result = await Task.Run(() => _repository.GetUser(userId));
            if (result == null)
                return Json("User does not exist");
            return Json(new UserDTO(result));
        }

        [HttpDelete]
        public async Task<JsonResult> RemoveUser(int userId)
        {
            try
            {
                await Task.Run(() => _repository.RemoveUser(userId));
            } catch (Exception ex)
            {
                return Json(ex.Message);
            }
            return Json("Successfully!");
        }

        [HttpPost]
        public async Task<JsonResult> AddUser(string login, string password, int groupId)
        {
            await _semaphore.WaitAsync();
            try
            {
                if (_repository.FindUserByLogin(login) != null)
                {
                    throw new ArgumentException("User with this login already exist");
                }
                await Task.Delay(5000);
                await Task.Run(() => _repository.AddUser(login, password, groupId));
            }
            catch(Exception ex)
            {
                return Json(ex.Message);
            }
            finally
            {
                _semaphore.Release();
            }

            return Json("Successfully!");
        }
    }
}
