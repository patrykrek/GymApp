using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace GymApp.GymApp.Domain.Models
{
    public class User : IdentityUser
    {
        public ICollection<Reservation> Reservations { get; set; }
        public ICollection<UserMembership> UserMemberships { get; set; }
    }
}
