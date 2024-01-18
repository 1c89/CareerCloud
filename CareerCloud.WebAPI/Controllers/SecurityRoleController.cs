using CareerCloud.BusinessLogicLayer;
using CareerCloud.EntityFrameworkDataAccess;
using CareerCloud.Pocos;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CareerCloud.WebAPI.Controllers
{
    [Route("api/careercloud/security/v1/")]
    [ApiController]
    public class SecurityRoleController : ControllerBase
    {
        private SecurityRoleLogic _logicLayer;
        public SecurityRoleController()
        {
            _logicLayer = new SecurityRoleLogic(new EFGenericRepository<SecurityRolePoco>());
        }

        [HttpGet]
        [Route("role/{securityRoleId:guid}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(IEnumerable<SecurityRolePoco>))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public ActionResult GetSecurityRole(Guid securityRoleId)
        {

            try
            {
                var record = _logicLayer.Get(securityRoleId);

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
        [Route("role")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(SecurityRolePoco))]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public ActionResult GetAllSecurityRole()
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
        [Route("role")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public ActionResult PostSecurityRole(SecurityRolePoco[] pocos)
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
        [Route("role")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public ActionResult PutSecurityRole(SecurityRolePoco[] pocos)
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
        [Route("role")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public ActionResult DeleteSecurityRole(SecurityRolePoco[] pocos)
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

