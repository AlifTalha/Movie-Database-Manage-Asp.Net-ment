﻿
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.EF.Tables;

namespace DAL.Interfaces
{
    public interface IUserRepo
    {
        User GetByUsername(string username);
        bool Create(User user);
    }
}