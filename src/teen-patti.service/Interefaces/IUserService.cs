﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace teen_patti.service.Interefaces
{
    public interface IUserService
    {
        Task<ICollection<common.Models.ViewModel.UserView>> GetUsers();
    }
}
