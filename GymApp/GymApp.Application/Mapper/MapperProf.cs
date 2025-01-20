using AutoMapper;
using GymApp.GymApp.Application.DTO;
using GymApp.GymApp.Domain.Models;

namespace GymApp.GymApp.Application.Mapper
{
    public class MapperProf : Profile
    {
        public MapperProf()
        {
            CreateMap<Trainer, GetTrainersDTO>();
            CreateMap<Training, GetTrainingsDTO>();
            CreateMap<Membership, GetMembershipsDTO>();
            CreateMap<Reservation, GetUsersReservationsDTO>();
            CreateMap<Reservation, GetReservationsDTO>();
            CreateMap<UserMembership, GetUserMembershipDTO>();
        }
    }
}
