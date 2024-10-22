using Microsoft.AspNetCore.Mvc;
using Asp.Versioning;
using ControlFinaApi.Features.Transactions.Contracts.Requests;
using ControlFinaApi.Features.Transactions.Contracts.Responses;
using ControlFinaApi.Features.Transactions.Services;
using ControlFinaApi.Features;
using ControlFinaApi.Abstractions;

namespace ControlFinaApi.Features.Transactions.Controllers
{
    [ApiVersion("1.0")]
    [ApiController]
    [Route("Api/v{version:apiVersion}/[controller]")]
    public class TransactionController : AbstractController
    {
        private readonly ITransactionService _service;
        public TransactionController(ITransactionService transacaoService)
        {
            _service = transacaoService;
        }

        /// <summary>
        /// Create a new transaction
        /// </summary>
        /// <param name="request">Body request</param>
        /// <returns>Created transaction</returns>
        [HttpPost("Create")]
        [ProducesResponseType(typeof(Result<TransactionResponse>), StatusCodes.Status201Created)]
        [ProducesResponseType(typeof(Result<TransactionResponse>), StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Create(CreateTransactionRequest request)
        {
            var result = await _service.CreateAsync(request);
            return HandleResponse(result);
        }

        /// <summary>
        /// Update a transaction
        /// </summary>
        /// <param name="request">Body request</param>
        /// <returns>Updated transaction</returns>
        [HttpPut("Update")]
        [ProducesResponseType(typeof(Result<TransactionResponse>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(Result<TransactionResponse>), StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Update(UpdateTransactionRequest request)
        {
            var result = await _service.UpdateAsync(request);
            return HandleResponse(result);
        }

        /// <summary>
        /// Delete a transaction
        /// </summary>
        /// <param name="id">Transaction Id</param>
        /// <returns></returns>
        [HttpDelete("Delete/{id}")]
        [ProducesResponseType(typeof(Result<TransactionResponse>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(Result<TransactionResponse>), StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Delete(Guid id)
        {
            var result = await _service.DeleteAsync(id);
            return HandleResponse(result);
        }

        /// <summary>
        /// Get all transactions
        /// </summary>
        /// <returns>Transaction list</returns>
        [HttpGet("GetAll")]
        [ProducesResponseType(typeof(Result<TransactionResponse>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(Result<TransactionResponse>), StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> GetAll()
        {
            var result = await _service.GetAllAsync();
            return HandleResponse(result);
        }

        /// <summary>
        /// Get a transaction by id
        /// </summary>
        /// <returns>A transaction</returns>
        [HttpGet("GetById/{id}")]
        [ProducesResponseType(typeof(Result<TransactionResponse>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(Result<TransactionResponse>), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(Result<TransactionResponse>), StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetById(Guid id)
        {
            var result = await _service.GetByIdAsync(id);
            return HandleResponse(result);
        }
    }
}
