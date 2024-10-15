using Asp.Versioning;
using ControlFinaApi.Abstractions;
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
    public class HistoryController : AbstractController
    {
        private readonly IHistoryService _service;

        public HistoryController(IHistoryService historicoService)
        {
            _service = historicoService;
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
        public async Task<IActionResult> Create(CreateHistoryRequest request)
        {
            var result = await _service.CreateAsync(request);
            return HandleResponse(result);
        }

        /// <summary>
        /// Update a history
        /// </summary>
        /// <param name="request">Body request</param>
        /// <returns>Updated history</returns>
        [HttpPut("Update")]
        [ProducesResponseType(typeof(Result<HistoryResponse>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(Result<HistoryResponse>), StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Update(UpdateHistoryRequest request)
        {
            var result = await _service.UpdateAsync(request);
            return HandleResponse(result);
        }

        /// <summary>
        /// Delete a history
        /// </summary>
        /// <param name="id">history id</param>
        /// <returns></returns>
        [HttpDelete("Delete/{id}")]
        [ProducesResponseType(typeof(Result<HistoryResponse>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(Result<HistoryResponse>), StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Delete(Guid id)
        {
            var result = await _service.DeleteAsync(id);
            return HandleResponse(result);
        }

        /// <summary>
        /// Get all histories
        /// </summary>
        /// <returns>History list</returns>
        [HttpGet("GetAll")]
        [ProducesResponseType(typeof(Result<HistoryResponse>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(Result<HistoryResponse>), StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> GetAll()
        {
            var result = await _service.GetAllAsync();
            return HandleResponse(result);
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
        public async Task<IActionResult> GetById(Guid id)
        {
            var result = await _service.GetByIdAsync(id);
            return HandleResponse(result);
        }
    }
}
