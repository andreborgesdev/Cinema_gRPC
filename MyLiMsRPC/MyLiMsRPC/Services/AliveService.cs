using Grpc.Core;
using Microsoft.AspNetCore.Authorization;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyLiMsRPC.Services
{
    public class AliveService : Alive.AliveBase
    {
        private readonly ILogger<AliveService> _logger;

        public AliveService(ILogger<AliveService> logger)
        {
            _logger = logger;
        }

        [Authorize]
        public override Task<SumReply> Sum(SumRequest request, ServerCallContext context)
        {
            var user = context.GetHttpContext().User;

            SumReply reply = new SumReply();
            reply.Message = request.Number1 + request.Number2;
            return Task.FromResult(reply);
        }
    }
}
