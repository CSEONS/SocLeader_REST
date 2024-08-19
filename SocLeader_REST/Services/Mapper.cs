using AutoMapper;
using SocLeader_REST.Domain.Entities;
using SocLeader_REST.Models;

namespace SocLeader_REST.Services
{
    public class Mapper : Profile
    {
        public Mapper()
        {
            CreateMap<Gathering, GatheringListViewModel>();
        }
    }
}
