﻿using Domain.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Abtract
{
    public interface IUserTokenServices
    {
        Task CreateToken(UserToken userToken);
        Task<UserToken> GetUserToken(string serialNumber);
    }
}
