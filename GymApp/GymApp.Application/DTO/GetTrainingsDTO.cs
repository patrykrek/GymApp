﻿using GymApp.GymApp.Domain.Models;

namespace GymApp.GymApp.Application.DTO
{
    public class GetTrainingsDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime StartDate { get; set; }
        public int Duration { get; set; }
        public int TrainerId { get; set; }
        public Trainer Trainer { get; set; }
    }
}
