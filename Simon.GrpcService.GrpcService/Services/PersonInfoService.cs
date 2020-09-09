using Google.Protobuf.WellKnownTypes;
using Grpc.Core;
using Simon.GrpcService.API;
using System.Linq;
using System.Threading.Tasks;

namespace Simon.GrpcService.GrpcService.Services
{
    public class PersonInfoService : PersonService.PersonServiceBase
    {
        public override Task<ResponseUserInfo> GetPersonInfoById(RequestUserId request, ServerCallContext context)
        {
            var list = new PersonRepository().GetAllPersons().Result.Person;
            var currPerson = list.FirstOrDefault(p => p.Id == request.Id);
            return Task.FromResult(new ResponseUserInfo
            {
                Person = currPerson
            });
        }

        public override async Task<ReponsePersonList> GetAll(Empty request, ServerCallContext context)
        {
            //var list = new PersonRepository().GetAllPersons().Result.Person;

            return new PersonRepository().GetAllPersons().Result;
        }

        public interface IPersonRepository
        {
            Task<ReponsePersonList> GetAllPersons();
        }

        public class PersonRepository : IPersonRepository
        {
            public Task<ReponsePersonList> GetAllPersons()
            {
                var personList = new ReponsePersonList();
                personList.Person.Add(
                    new Person
                    {
                        Id = 1,
                        Name = "Simon",
                        Age = 34,
                        Gender = Gender.Man,
                        Salary = 2600,
                        Weight = 168.3f
                    });
                personList.Person.Add(new Person
                {
                    Id = 2,
                    Name = "Lily",
                    Age = 30,
                    Gender = Gender.Female,
                    Salary = 3200,
                    Weight = 158.5f,
                    Phone = { "1392856236", "1873569874", "0755-32156988" },
                    MyAdd =
                        {
                            new Address
                            {
                                Province = "广东",
                                City = "深圳",
                                Area = "罗湖区",
                                ZipCode = "518034",
                                Street = "梅园路",
                                Number = "112号",
                            },
                            new Address
                            {
                                Province = "湖北",
                                City = "荆州",
                                Area = "路决区",
                                ZipCode = "256158",
                                Street = "中心街",
                                Number = "1028",
                            }
                        }
                });
                personList.Person.Add(new Person
                {
                    Id = 3,
                    Name = "Tom",
                    Age = 31,
                    Gender = Gender.Male,
                    Salary = 3600,
                    Weight = 18.5f
                });
                return Task.FromResult(personList);
            }
        }

        //private static List<Person> PersonList()
        //{
        //    var list = new List<Person>
        //    {
        //        new Person
        //        {
        //            Id = 1,
        //            Name = "Simon",
        //            Age = 34,
        //            Gender = Gender.Man,
        //            Salary = 2600,
        //            Weight = 168.3f
        //        },
        //        new Person
        //        {
        //            Id = 2,
        //            Name = "Lily",
        //            Age = 30,
        //            Gender = Gender.Female,
        //            Salary = 3200,
        //            Weight = 158.5f,
        //            Phone = { "1392856236","1873569874", "0755-32156988" },
        //            MyAdd =
        //            {
        //                new Address
        //                {
        //                    Province = "广东",
        //                    City = "深圳",
        //                    Area = "罗湖区",
        //                    ZipCode = "518034",
        //                    Street = "梅园路",
        //                    Number = "112号",
        //                },
        //                new Address
        //                {
        //                    Province = "湖北",
        //                    City = "荆州",
        //                    Area = "路决区",
        //                    ZipCode = "256158",
        //                    Street = "中心街",
        //                    Number = "1028",
        //                }
        //            }
        //        },
        //        new Person
        //        {
        //            Id = 3,
        //            Name = "Tom",
        //            Age = 31,
        //            Gender = Gender.Male,
        //            Salary = 3600,
        //            Weight = 18.5f
        //        }
        //    };
        //    return list;
        //}
    }
}