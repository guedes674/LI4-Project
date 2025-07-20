using System;
using Microsoft.AspNetCore.Components;

namespace ComplicadaMente.Services
{
    public class UserStateService
    {
        public event Action? OnChange;

        public string UserId { get; private set; } = string.Empty;
        public string UserName { get; private set; } = string.Empty;
        public string UserType { get; private set; } = string.Empty;
        public string UserEmail { get; private set; } = string.Empty;

        public bool IsLoggedIn => !string.IsNullOrEmpty(UserId);
        public bool IsFuncionario => UserType == "admin";
        public bool IsUtilizador => UserType == "client";
        public bool IsAdmin => UserType == "admin";

        // set user details so they can be accessed throughout the application
        public void SetUser(string id, string name, string type, string email)
        {
            UserId = id ?? string.Empty;
            UserName = name ?? string.Empty;
            UserType = type ?? string.Empty;
            UserEmail = email ?? string.Empty;

            Console.WriteLine($"SetUser called - Type: {UserType}, Name: {UserName}");
            NotifyStateChanged();
        }

        // clear user details when logging out
        public void ClearUser()
        {
            UserId = string.Empty;
            UserName = string.Empty;
            UserType = string.Empty;
            UserEmail = string.Empty;
            NotifyStateChanged();
        }

        // notify components that the user state has changed
        public void NotifyStateChanged()
        {
            OnChange?.Invoke();
        }
    }
}