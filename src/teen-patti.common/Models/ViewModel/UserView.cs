﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace teen_patti.common.Models.ViewModel
{
    public class UserView
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
    }
    public static class UserViewExtensions
    {
        public static UserView MapToView(this Persistence.User user) => new UserView()
        {
            Id = user.Id,
            Name = user.UserName
        };
    }
}
