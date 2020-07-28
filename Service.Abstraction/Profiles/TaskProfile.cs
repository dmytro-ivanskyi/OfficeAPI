using AutoMapper;
using Data.Abstraction.Models;
using Service.Abstraction.ResponseModels;

namespace Data.Abstraction.Profiles
{
    class TaskProfile : Profile
    {
        public TaskProfile()
        {
            CreateMap<UserTask, TaskResponse>();
        }
    }
}
