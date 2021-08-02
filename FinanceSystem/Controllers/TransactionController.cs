using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using FinanceSystem.Application.Interfaces.Base;
using FinanceSystem.Controllers.Base;
using FinanceSystem.DtoModels.Transaction;
using FinanceSystem.Infrastructure.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace FinanceSystem.Controllers
{
    public class TransactionController : BaseApiController
    {
        private readonly IGenericAction<Transaction> _genericAction;
        private readonly IMapper _mapper;

        public TransactionController(IGenericAction<Transaction> genericAction, IMapper mapper)
        {
            _genericAction = genericAction;
            _mapper = mapper;
        }

        [Authorize(Roles = "Admin")]
        [HttpGet]
        public async Task<IActionResult> GetAllTransactions()
        {
            var transactions = _genericAction.GetAll();
            if (transactions.Result == null) return NotFound();
            var result = _mapper.Map<IEnumerable<TransactionGetDto>>(transactions.Result);
            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetTransactionById(Guid id)
        {
            var transaction = _genericAction.GetById(id);
            if (transaction.Result == null) return NotFound();
            var result = _mapper.Map<TransactionType>(transaction.Result);
            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> AddTransaction(TransactionDto model)
        {
            var transaction = _mapper.Map<Transaction>(model);

            if (!await _genericAction.Post(transaction)) return BadRequest();

            return Ok(model);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> EditTransaction(Guid id, TransactionDto model)
        {
            model.Id = id;
            var transaction = _mapper.Map<Transaction>(model);
            if (!await _genericAction.Put(transaction)) return BadRequest();

            return NoContent();
        }

        [Authorize(Roles = "Admin")]
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTransaction(Guid id)
        {
            var transaction = _genericAction.GetById(id);
            if (transaction.Result == null) return NotFound();

            if (!await _genericAction.Delete(id)) return BadRequest();

            return NoContent();
        }
    }
}