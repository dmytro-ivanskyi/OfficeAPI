using AutoMapper;
using Data.Abstraction.Models;
using Service.Abstraction.ResponseModels;

namespace Data.Profiles
{
    class TaskProfile : Profile
    {
        public TaskProfile()
        {
            CreateMap<UserTask, TaskResponse>();
        }
    }
}
