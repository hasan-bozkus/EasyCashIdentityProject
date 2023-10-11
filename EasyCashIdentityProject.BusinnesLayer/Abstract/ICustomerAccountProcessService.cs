﻿using EasyCashIdentityProject.EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasyCashIdentityProject.BusinnesLayer.Abstract
{
    public interface ICustomerAccountProcessService : IGenericService<CustomerAccountProcess>
    {
        List<CustomerAccountProcess> TMyLastProcess(int id);
    }
}
