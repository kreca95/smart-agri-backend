using Microsoft.Extensions.Configuration;
using SmartAgri.DataBase.Communication.Helpers;
using SmartAgri.DataBase.Models.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace SmartAgri.DataBase.Communication.Interfaces
{
    public interface ITokenService
    {
        TokenResponse GenerateToken(User user,IConfiguration configuration);
        string GenerateRefreshToken();
    }
}
