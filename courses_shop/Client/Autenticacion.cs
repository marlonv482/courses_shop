
using System.Security.Claims;
using Microsoft.AspNetCore.Components.Authorization;

namespace courses_shop.Client{
    public class Autenticacion : AuthenticationStateProvider
    {
        public override async Task<AuthenticationState> GetAuthenticationStateAsync()
        {
           var sinAutenticar=new ClaimsIdentity();
           return await Task.FromResult(new AuthenticationState(new ClaimsPrincipal(sinAutenticar)));
        }
    }
}