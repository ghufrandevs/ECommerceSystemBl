using Microsoft.AspNetCore.Components.Authorization;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

namespace ECommerceSystemBl.Services
{
    public class CustomAuthenticationStateProvider
        : AuthenticationStateProvider
    {
        private ClaimsPrincipal _anonymous =
            new(new ClaimsIdentity());

        private ClaimsPrincipal _currentUser =
            new(new ClaimsIdentity());

        public override Task<AuthenticationState> GetAuthenticationStateAsync()
        {
            return Task.FromResult(
                new AuthenticationState(_currentUser));
        }

        public void MarkUserAsAuthenticated(string token)
        {
            var handler = new JwtSecurityTokenHandler();

            var jwt = handler.ReadJwtToken(token);

            var identity = new ClaimsIdentity(
                jwt.Claims,
                "jwt");

            _currentUser = new ClaimsPrincipal(identity);

            NotifyAuthenticationStateChanged(
                Task.FromResult(
                    new AuthenticationState(_currentUser)));
        }

        public void Logout()
        {
            _currentUser = _anonymous;

            NotifyAuthenticationStateChanged(
                Task.FromResult(
                    new AuthenticationState(_currentUser)));
        }
    }
}