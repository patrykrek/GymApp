﻿namespace GymApp.GymApp.Domain.Models
{
    public class Membership
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal PricePerMonth { get; set; }

        public ICollection<UserMembership> UserMemberships { get; set; }
    }
}
