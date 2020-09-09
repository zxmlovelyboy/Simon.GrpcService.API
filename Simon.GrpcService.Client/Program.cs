using System;
using System.Text.Json;
using System.Text.Json.Serialization;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using Simon.GrpcService.API;
using Simon.GrpcService.GrpcService;
using Simon.GrpcService.GrpcService.Services;

namespace Simon.GrpcService.Client
{
    class Program
    {
        //private static Grpc.Core.Server _server;

        private static readonly ILogger<GreeterService> _logger;

        static void Main(string[] args)
        {
            #region 服务实现

            HelloRequest request = new HelloRequest();
            request.Name = "Simon";

            var reply = new GreeterService(_logger).SayHello(request, null);
            Console.WriteLine("服务1：");
            Console.WriteLine("Grpc ServerListening On Port 5001,Out put:" + reply.Result.Message);//Grpc ServerListening On Port 8088,Out put:Hello Simon 
            #endregion

            #region Demo 服务实现

            ResponseModel respModel = new ResponseModel();
            respModel.Id = 2;
            respModel.Name = "Acadsoc";

            var resp = new DemoService().DemoMethod(null, null);
            Console.WriteLine("服务2：根据获取名称");
            Console.WriteLine(resp.Result);

            #endregion

            #region 获取人员信息


            RequestUserId uid = new RequestUserId { Id = 2 };
            var person = new PersonInfoService().GetPersonInfoById(uid, null);
            Console.WriteLine("服务3：根据ID获取对象信息");
            Console.WriteLine("获取用户信息为：" + JsonConvert.SerializeObject(person));

            // 获取用户信息为：{ "Result":{ "Person":{ "Id":2,"Name":"Lily","Age":30,"Gender":1,"Weight":158.5,"EmailVerified":false,"Phone":[],"Salary":3200.0,"MyAdd":[]} },"Id":1,"Exception":null,"Status":5,"IsCanceled":false,"IsCompleted":true,"IsCompletedSuccessfully":true,"CreationOptions":0,"AsyncState":null,"IsFaulted":false}

            #endregion

            Console.WriteLine("任意键退出...");
            Console.ReadKey();
        }
    }
}

/*
{
    "Result":{
        "Person":{
            "Id":2,
            "Name":"Lily",
            "Age":30,
            "Gender":1,
            "Weight":158.5,
            "EmailVerified":false,
            "Phone":[
                "1392856236",
                "1873569874",
                "0755-32156988"
            ],
            "Salary":3200,
            "MyAdd":[
                {
                    "Province":"广东",
                    "City":"深圳",
                    "Area":"罗湖区",
                    "ZipCode":"518034",
                    "Street":"梅园路",
                    "Number":"112号"
                },
                {
                    "Province":"湖北",
                    "City":"荆州",
                    "Area":"路决区",
                    "ZipCode":"256158",
                    "Street":"中心街",
                    "Number":"1028"
                }
            ]
        }
    },
    "Id":1,
    "Exception":null,
    "Status":5,
    "IsCanceled":false,
    "IsCompleted":true,
    "IsCompletedSuccessfully":true,
    "CreationOptions":0,
    "AsyncState":null,
    "IsFaulted":false
}
*/