using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Grpc.Core;

namespace Simon.GrpcService.GrpcService.Services
{
    public class DemoService : Demo.DemoBase
    {
        public override Task<ResponseModel> DemoMethod(RequestParam request, ServerCallContext context)
        {
            ResponseModel response = new ResponseModel { Id = 1, Name = "Simon" };
            return Task.FromResult(response);
        }
    }
}
