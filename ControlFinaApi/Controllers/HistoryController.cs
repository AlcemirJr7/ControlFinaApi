using Asp.Versioning;
using ControlFinaApi.Features;
using ControlFinaApi.Features.Histories.Contracts.Requests;
using ControlFinaApi.Features.Histories.Contracts.Responses;
using ControlFinaApi.Features.Histories.Services;
using Microsoft.AspNetCore.Mvc;

namespace ControlFinaApi.Controllers
{
    [ApiVersion("1.0")]
    [ApiController]
    [Route("Api/v{version:apiVersion}/[controller]")]
    [Produces("application/json")]
    public class HistoryController : ControllerBase
    {
        private readonly IHistoryService _historicoService;
        public HistoryController(IHistoryService historicoService)
        {
            _historicoService = historicoService;
        }

        /// <summary>
        /// Create a new history
        /// </summary>
        /// <param name="request">
        /// Body request
        /// 
        /// type: Credit = 1 | Debit = 2
        /// 
        /// </param>
        /// <returns>Created history</returns>
        [HttpPost("Create")]
        [ProducesResponseType(typeof(Result<HistoryResponse>), StatusCodes.Status201Created)]
        [ProducesResponseType(typeof(Result<HistoryResponse>), StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<Result<HistoryResponse>>> Create(CreateHistoryRequest request)
        {
            var result = await _historicoService.CreateAsync(request);

            if (!result.IsSuccess)
            {
                return BadRequest(result);
            }

            return CreatedAtAction(nameof(GetById), new { id = result.Content?.Id }, result);
        }

        /// <summary>
        /// Update a history
        /// </summary>
        /// <param name="request">Body request</param>
        /// <returns>Updated history</returns>
        [HttpPut("Update")]
        [ProducesResponseType(typeof(Result<HistoryResponse>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(Result<HistoryResponse>), StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<Result<HistoryResponse>>> Update(UpdateHistoryRequest request)
        {
            var result = await _historicoService.UpdateAsync(request);

            if (!result.IsSuccess)
            {
                return BadRequest(result);
            }

            return Ok(result);
        }

        /// <summary>
        /// Delete a history
        /// </summary>
        /// <param name="id">history id</param>
        /// <returns></returns>
        [HttpDelete("Delete/{id}")]
        [ProducesResponseType(typeof(Result<HistoryResponse>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(Result<HistoryResponse>), StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<Result<HistoryResponse>>> Delete(Guid id)
        {
            var result = await _historicoService.DeleteAsync(id);

            if (!result.IsSuccess)
            {
                return BadRequest(result);
            }

            return Ok(result);
        }

        /// <summary>
        /// Get all histories
        /// </summary>
        /// <returns>History list</returns>
        [HttpGet("GetAll")]
        [ProducesResponseType(typeof(Result<HistoryResponse>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(Result<HistoryResponse>), StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<Result<IEnumerable<HistoryResponse>>>> GetAll()
        {
            var result = await _historicoService.GetAllAsync();

            if (!result.IsSuccess)
            {
                return BadRequest(result);
            }

            return Ok(result);
        }

        /// <summary>
        /// Get a history by id
        /// </summary>
        /// <param name="id">history id</param>
        /// <returns>A hitory</returns>
        [HttpGet("GetById/{id}")]
        [ProducesResponseType(typeof(Result<HistoryResponse>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(Result<HistoryResponse>), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(Result<HistoryResponse>), StatusCodes.Status404NotFound)]
        public async Task<ActionResult<Result<HistoryResponse>>> GetById(Guid id)
        {
            var result = await _historicoService.GetByIdAsync(id);

            if (result.Content is null)
                return NotFound(result);

            if (!result.IsSuccess)
                return BadRequest(result);

            return Ok(result);
        }
    }
}
