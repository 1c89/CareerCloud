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
    public class CompanyProfileController : ControllerBase
    {
        private CompanyProfileLogic _logicLayer;
        public CompanyProfileController()
        {
            _logicLayer = new CompanyProfileLogic(new EFGenericRepository<CompanyProfilePoco>());
        }

        [HttpGet]
        [Route("profile/{companyProfileId:guid}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(IEnumerable<CompanyProfilePoco>))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public ActionResult GetCompanyProfile(Guid companyProfileId)
        {

            try
            {
                var record = _logicLayer.Get(companyProfileId);

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
        [Route("profile")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(CompanyProfilePoco))]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public ActionResult GetAllCompanyProfile()
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
        [Route("profile")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public ActionResult PostCompanyProfile(CompanyProfilePoco[] pocos)
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
        [Route("profile")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public ActionResult PutCompanyProfile(CompanyProfilePoco[] pocos)
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
        [Route("profile")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public ActionResult DeleteCompanyProfile(CompanyProfilePoco[] pocos)
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

