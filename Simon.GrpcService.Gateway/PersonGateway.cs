using System;
using System.Threading.Tasks;
using Grpc.Net.Client;
using Simon.GrpcService.GrpcService;

namespace Simon.GrpcService.Gateway
{
    public class PersonGateway
    {
        private readonly PersonServic.PersonServicClient _client;

        public PersonGateway()
        {
            AppContext.SetSwitch("System.Net.Http.SocketsHttpHandler.Http2UnencryptedSupport", true);
            //TODO 根据动态配置
            _client = new PersonServic.PersonServicClient(GrpcChannel.ForAddress("http://localhost:8081"));
        }

        /// <summary>
        /// 根据用户Id 获取用户对象
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        public async Task<ResponseUserInfo> GetUserInfoById(RequestUserId userId)
        {
            return await _client.GetPersonInfoByIdAsync(userId);
        }
    }
}
