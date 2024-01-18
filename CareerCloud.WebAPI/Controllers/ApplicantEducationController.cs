using CareerCloud.BusinessLogicLayer;
using CareerCloud.DataAccessLayer;
using CareerCloud.EntityFrameworkDataAccess;
using CareerCloud.Pocos;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;

namespace CareerCloud.WebAPI.Controllers
{
    [Route("api/careercloud/applicant/v1")]
    [ApiController]
    public class ApplicantEducationController : ControllerBase
    {
        private ApplicantEducationLogic _logicLayer;
        public ApplicantEducationController()
        {
            _logicLayer = new ApplicantEducationLogic(new EFGenericRepository<ApplicantEducationPoco>());
        }

        [HttpGet]
        [Route("education/{applicantEducationId:guid}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type=typeof(IEnumerable<ApplicantEducationPoco>))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public ActionResult GetApplicantEducation(Guid applicantEducationId)
        {

            try
            {
                var record = _logicLayer.Get(applicantEducationId);

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
        [Route("education")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(ApplicantEducationPoco))]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public ActionResult GetAllApplicantEducation()
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
        [Route("education")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public ActionResult PostApplicantEducation(ApplicantEducationPoco[] pocos)
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
        [Route("education")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public ActionResult PutApplicantEducation(ApplicantEducationPoco[] pocos)
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
        [Route("education")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public ActionResult DeleteApplicantEducation(ApplicantEducationPoco[] pocos)
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
