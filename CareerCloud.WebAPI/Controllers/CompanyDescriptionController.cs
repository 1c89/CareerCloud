using CareerCloud.BusinessLogicLayer;
using CareerCloud.EntityFrameworkDataAccess;
using CareerCloud.Pocos;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CareerCloud.WebAPI.Controllers
{
    [Route("api/careercloud/company/v1")]
    [ApiController]
    public class CompanyDescriptionController : ControllerBase
    {
        private CompanyDescriptionLogic _logicLayer;
        public CompanyDescriptionController()
        {
            _logicLayer = new CompanyDescriptionLogic(new EFGenericRepository<CompanyDescriptionPoco>());
        }

        [HttpGet]
        [Route("description/{companyDescriptionId:guid}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(IEnumerable<CompanyDescriptionPoco>))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public ActionResult GetCompanyDescription(Guid companyDescriptionId)
        {

            try
            {
                var record = _logicLayer.Get(companyDescriptionId);

                if (record is null)
                {
                    return NotFound();
                }
                return Ok(record);
            }
            catch (Exception e)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, $"Internal Server Error: {e.Message}");
            }
        }

        [HttpGet]
        [Route("description")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(CompanyDescriptionPoco))]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public ActionResult GetAllCompanyDescription()
        {

            try
            {
                var pocos = _logicLayer.GetAll();

                return Ok(pocos);
            }
            catch (Exception e)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, $"Internal Server Error: {e.Message}");
            }
        }


        [HttpPost]
        [Route("description")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public ActionResult PostCompanyDescription(CompanyDescriptionPoco[] pocos)
        {
            try
            {
                _logicLayer.Add(pocos);
                return Ok();
            }
            catch (AggregateException ae)
            {
                string errorMessage = string.Join(Environment.NewLine, ae.Flatten().InnerExceptions.Select(ex => ex.Message));
                return BadRequest(errorMessage);
            }
            catch (DbUpdateException due)
            {
                return BadRequest($"Database error {due.Message}");
            }
            catch (Exception e)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, $"Internal Server Error: {e.Message}");
            }
        }


        [HttpPut]
        [Route("description")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public ActionResult PutCompanyDescription(CompanyDescriptionPoco[] pocos)
        {
            try
            {
                _logicLayer.Update(pocos);
                return Ok();
            }
            catch (AggregateException ae)
            {
                string errorMessage = string.Join(Environment.NewLine, ae.Flatten().InnerExceptions.Select(ex => ex.Message));
                return BadRequest(errorMessage);
            }
            catch (DbUpdateException due)
            {
                return BadRequest($"Database error {due.Message}");
            }
            catch (Exception e)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, $"Internal Server Error: {e.Message}");
            }


        }

        [HttpDelete]
        [Route("description")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public ActionResult DeleteCompanyDescription(CompanyDescriptionPoco[] pocos)
        {
            try
            {
                _logicLayer.Delete(pocos);
                return Ok();
            }
            catch (DbUpdateException due)
            {
                return BadRequest($"Database error {due.Message}");
            }
            catch (Exception e)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, $"Internal Server Error: {e.Message}");
            }

        }
    }


}
