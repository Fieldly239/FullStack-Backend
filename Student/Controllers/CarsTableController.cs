using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Student.Models;
using Student.Services;

namespace Student.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CarsTableController : ControllerBase
    {
        private readonly ICarsTableService _carsTableService;

        public CarsTableController(ICarsTableService carsTableService)
        {
            _carsTableService = carsTableService;
        }
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            try
            {
                var res = await _carsTableService.GetAll();
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
                var res = await _carsTableService.GetById(id);
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
                var res = await _carsTableService.GetByUserId(id);
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
        public async Task<IActionResult> Add(CarsTable carsTable)
        {
            try
            {
                var res = await _carsTableService.Add(carsTable);
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
        public async Task<IActionResult> Update(int id, CarsTable carsTable)
        {
            try
            {
                var res = await _carsTableService.Update(carsTable);
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
                var res = await _carsTableService.Delete(id);
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
