﻿namespace Product_Management.Interfaces
{
    public interface IAuthService
    {
        bool ValidateUser(string username, string password);
    }
}
