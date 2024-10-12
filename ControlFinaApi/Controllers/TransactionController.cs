using Microsoft.AspNetCore.Mvc;
using Asp.Versioning;
using ControlFinaApi.Features.Transactions.Contracts.Requests;
using ControlFinaApi.Features.Transactions.Contracts.Responses;
using ControlFinaApi.Features.Transactions.Services;
using ControlFinaApi.Features;

namespace ControlFinaApi.Controllers
{
    [ApiVersion("1.0")]
    [ApiController]
    [Route("Api/v{version:apiVersion}/[controller]")]
    [Produces("application/json")]
    public class TransactionController : ControllerBase
    {
        private readonly ITransactionService _transacaoService;
        public TransactionController(ITransactionService transacaoService)
        {
            _transacaoService = transacaoService;
        }

        /// <summary>
        /// Create a new transaction
        /// </summary>
        /// <param name="request">Body request</param>
        /// <returns>Created transaction</returns>
        [HttpPost("Create")]
        [ProducesResponseType(typeof(Result<TransactionResponse>), StatusCodes.Status201Created)]
        [ProducesResponseType(typeof(Result<TransactionResponse>), StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<Result<TransactionResponse>>> Create(CreateTransactionRequest request)
        {

            var result = await _transacaoService.CreateAsync(request);

            if (!result.IsSuccess)
            {
                return BadRequest(result);
            }

            return CreatedAtAction(nameof(GetById), new { id = result.Content?.Id }, result);

        }

        /// <summary>
        /// Update a transaction
        /// </summary>
        /// <param name="request">Body request</param>
        /// <returns>Updated transaction</returns>
        [HttpPut("Update")]
        [ProducesResponseType(typeof(Result<TransactionResponse>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(Result<TransactionResponse>), StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<Result<TransactionResponse>>> Update(UpdateTransactionRequest request)
        {

            var result = await _transacaoService.UpdateAsync(request);

            if (!result.IsSuccess)
            {
                return BadRequest(result);
            }

            return Ok(result);
        }

        /// <summary>
        /// Delete a transaction
        /// </summary>
        /// <param name="id">Transaction Id</param>
        /// <returns></returns>
        [HttpDelete("Delete/{id}")]
        [ProducesResponseType(typeof(Result<TransactionResponse>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(Result<TransactionResponse>), StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<Result<TransactionResponse>>> Delete(Guid id)
        {

            var result = await _transacaoService.DeleteAsync(id);

            if (!result.IsSuccess)
            {
                return BadRequest(result);
            }

            return Ok(result);
        }

        /// <summary>
        /// Get all transactions
        /// </summary>
        /// <returns>Transaction list</returns>
        [HttpGet("GetAll")]
        [ProducesResponseType(typeof(Result<TransactionResponse>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(Result<TransactionResponse>), StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<Result<IEnumerable<TransactionResponse>>>> GetAll()
        {
            var result = await _transacaoService.GetAllAsync();

            if (!result.IsSuccess)
            {
                return BadRequest(result);
            }

            return Ok(result);
        }

        /// <summary>
        /// Get a transaction by id
        /// </summary>
        /// <returns>A transaction</returns>
        [HttpGet("GetById/{id}")]
        [ProducesResponseType(typeof(Result<TransactionResponse>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(Result<TransactionResponse>), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(Result<TransactionResponse>), StatusCodes.Status404NotFound)]
        public async Task<ActionResult<Result<IEnumerable<TransactionResponse>>>> GetById(Guid id)
        {
            var result = await _transacaoService.GetByIdAsync(id);

            if (!result.IsSuccess)
                return BadRequest(result);

            if (result.Content is null)
                return NotFound(result);

            return Ok(result);
        }
    }
}
