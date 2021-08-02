using System;
using System.Security.Claims;
using System.Threading.Tasks;
using FinanceSystem.Application.Interfaces.Base;
using FinanceSystem.Infrastructure.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;

namespace FinanceSystem.Application.Services.Security
{
    public class TransactionByIdRequirement : IAuthorizationRequirement
    {
    }

    public class IsUserRequirementHandler : AuthorizationHandler<TransactionByIdRequirement>
    {
        private readonly IGenericAction<Transaction> _genericAction;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public IsUserRequirementHandler(IHttpContextAccessor httpContextAccessor,
            IGenericAction<Transaction> genericAction)
        {
            _httpContextAccessor = httpContextAccessor;
            _genericAction = genericAction;
        }

        protected override Task HandleRequirementAsync(AuthorizationHandlerContext context,
            TransactionByIdRequirement byIdRequirement)
        {
            var userId = context.User.FindFirst(ClaimTypes.NameIdentifier);
            if (userId == null) return Task.CompletedTask;

            var transactionId = new Guid();

            var transaction = _genericAction.GetById(transactionId).Result;

            if (transaction == null) return Task.CompletedTask;

            if (userId.Value == transaction.AppUser.Id) context.Succeed(byIdRequirement);
            return Task.CompletedTask;
        }
    }
}