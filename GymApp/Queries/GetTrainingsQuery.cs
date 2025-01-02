using GymApp.DTO;
using MediatR;

namespace GymApp.Queries
{
    public record GetTrainingsQuery : IRequest<List<GetTrainingsDTO>>;
    
}
