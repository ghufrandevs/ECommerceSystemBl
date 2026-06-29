using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Authorization;

namespace ECommerceSystemBl.Helpers
{
    public static class AdminAuthorizationHelper
    {
        public static async Task<bool> IsAdminAsync(
            AuthenticationStateProvider authenticationStateProvider,
            NavigationManager navigation)
        {
            var authState =
                await authenticationStateProvider.GetAuthenticationStateAsync();

            var user = authState.User;

            if (user.Identity?.IsAuthenticated != true)
            {
                navigation.NavigateTo("/login");
                return false;
            }

            if (!user.IsInRole("Admin"))
            {
                navigation.NavigateTo("/");
                return false;
            }

            return true;
        }
    }
}