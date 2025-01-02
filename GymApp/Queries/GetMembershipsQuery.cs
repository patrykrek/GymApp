using GymApp.DTO;
using MediatR;

namespace GymApp.Queries
{
    public record GetMembershipsQuery : IRequest<List<GetMembershipsDTO>>;
    
    
}
