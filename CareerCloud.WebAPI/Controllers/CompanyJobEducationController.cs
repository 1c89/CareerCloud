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
    public class CompanyJobEducationController : ControllerBase
    {
        private CompanyJobEducationLogic _logicLayer;
        public CompanyJobEducationController()
        {
            _logicLayer = new CompanyJobEducationLogic(new EFGenericRepository<CompanyJobEducationPoco>());
        }

        [HttpGet]
        [Route("jobeducation/{companyJobEducationId:guid}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(IEnumerable<CompanyJobEducationPoco>))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public ActionResult GetCompanyJobEducation(Guid companyJobEducationId)
        {

            try
            {
                var record = _logicLayer.Get(companyJobEducationId);

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
        [Route("jobeducation")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(CompanyJobEducationPoco))]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public ActionResult GetAllCompanyJobEducation()
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
        [Route("jobeducation")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public ActionResult PostCompanyJobEducation(CompanyJobEducationPoco[] pocos)
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
        [Route("jobeducation")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public ActionResult PutCompanyJobEducation(CompanyJobEducationPoco[] pocos)
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
        [Route("jobeducation")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public ActionResult DeleteCompanyJobEducation(CompanyJobEducationPoco[] pocos)
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
