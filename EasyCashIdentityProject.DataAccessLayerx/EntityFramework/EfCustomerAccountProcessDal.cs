﻿using EasyCashIdentityProject.DataAccessLayerx.Abstract;
using EasyCashIdentityProject.DataAccessLayerx.Concrete;
using EasyCashIdentityProject.DataAccessLayerx.Repositores;
using EasyCashIdentityProject.EntityLayer.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasyCashIdentityProject.DataAccessLayerx.EntityFramework
{
    public class EfCustomerAccountProcessDal : GenericRepository<CustomerAccountProcess>, ICustomerAccountProcessDal
    {
        public List<CustomerAccountProcess> MyLastProcess(int id)
        {
            using var context = new Context();
            var values = context.customerAccountProcesses.Include(y => y.SenderCustomer).Include(w => w.ReceiverCustomer).ThenInclude(z => z.AppUser).Where(x => x.ReceiverID == id || x.SenderID == id).ToList();
            return values;
        }
    }
}
