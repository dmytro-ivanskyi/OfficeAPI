using AutoMapper;
using Data.Abstraction.Models;
using Data.Abstraction.ResponseModels;

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
