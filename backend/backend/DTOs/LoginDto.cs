﻿namespace backend.DTOs
{
    /// <summary>
    /// DTO for user login requests
    /// </summary>
    public class LoginDto
    {
        public string Username { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;
    }
}