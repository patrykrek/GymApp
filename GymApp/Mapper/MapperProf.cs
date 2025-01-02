using AutoMapper;
using GymApp.DTO;
using GymApp.Models;

namespace GymApp.Mapper
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
