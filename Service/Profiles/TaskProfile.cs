using AutoMapper;
using Data.Abstraction.Models;
using Service.Abstraction.RequestModels;
using Service.Abstraction.ResponseModels;

namespace Service.Profiles
{
    class TaskProfile : Profile
    {
        public TaskProfile()
        {
            CreateMap<UserTask, TaskResponse>();
            CreateMap<UserTask, TaskShortResponse>();

            CreateMap<CreateTaskRequest, UserTask>();
            CreateMap<UpdateTaskRequest, UserTask>();
            // CreateMap<TaskShortResponse, TaskResponse>();
        }
    }
}
