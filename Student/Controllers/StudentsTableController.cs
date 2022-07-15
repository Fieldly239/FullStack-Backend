using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Student.Models;
using Student.Services;

namespace Student.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentsTableController : ControllerBase
    {
        private readonly IStudentsTableService _studentsTableService;

        public StudentsTableController(IStudentsTableService studentsTableService)
        {
            _studentsTableService = studentsTableService;
        }
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            try
            {
                var res = await _studentsTableService.GetAll();
                return Ok(new { isSuccess = true, data = res });
            }
            catch (Exception ex)
            {
                return new JsonResult(new
                {
                    isSuccess = false,
                    status = 500,
                    message = ex.Message
                });
            }
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            try
            {
                var res = await _studentsTableService.GetById(id);
                return Ok(new { isSuccess = true, data = res });
            }
            catch (Exception ex)
            {
                return new JsonResult(new
                {
                    isSuccess = false,
                    status = 500,
                    message = ex.Message
                });
            }

        }

        [HttpGet]
        [Route("getbyuserid/{id}")]
        public async Task<IActionResult> GetByUserId(int id)
        {
            try
            {
                var res = await _studentsTableService.GetByUserId(id);
                return Ok(new { isSuccess = true, data = res });
            }
            catch (Exception ex)
            {
                return new JsonResult(new
                {
                    isSuccess = false,
                    status = 500,
                    message = ex.Message
                });
            }

        }

        [HttpPost]
        public async Task<IActionResult> Add(StudentsTable studentsTable)
        {
            try
            {
                var res = await _studentsTableService.Add(studentsTable);
                return Ok(new { isSuccess = true, data = res });
            }
            catch (Exception ex)
            {
                return new JsonResult(new
                {
                    isSuccess = false,
                    status = 500,
                    message = ex.Message
                });
            }

        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, StudentsTable studentsTable)
        {
            try
            {
                var res = await _studentsTableService.Update(studentsTable);
                return Ok(new { isSuccess = true, data = res });
            }
            catch (Exception ex)
            {
                return new JsonResult(new
                {
                    isSuccess = false,
                    status = 500,
                    message = ex.Message
                });
            }

        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                var res = await _studentsTableService.Delete(id);
                return Ok(new { isSuccess = true, data = res });
            }
            catch (Exception ex)
            {
                return new JsonResult(new
                {
                    isSuccess = false,
                    status = 500,
                    message = ex.Message
                });
            }

        }
    }
}

