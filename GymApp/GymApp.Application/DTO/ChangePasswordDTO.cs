﻿namespace GymApp.GymApp.Application.DTO
{
    public class ChangePasswordDTO
    {
        public string Email { get; set; }
        public string NewPassword { get; set; }
        public string ConfirmNewPassword { get; set; }
    }
}
