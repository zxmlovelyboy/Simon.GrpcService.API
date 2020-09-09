using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Grpc.Core;
using Simon.GrpcService.GrpcService;

namespace Simon.GrpcService.Client
{
    public class HelloServerClient
    {
        private readonly GreeterService _greeterService;

        //private static readonly Channel _channel;
        //private static GreeterService _client;

        public HelloServerClient(GreeterService greeterService)
        {
            _greeterService = greeterService;
        }

        public Task<HelloReply> GetSayHello(HelloRequest name, ServerCallContext msg)
        {
            return _greeterService.SayHello(name, msg);
        }
    }
}
