using EasyCashIdentityProject.DataAccessLayerx.Abstract;
using EasyCashIdentityProject.DataAccessLayerx.Concrete;
using EasyCashIdentityProject.DataAccessLayerx.Repositores;
using EasyCashIdentityProject.EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasyCashIdentityProject.DataAccessLayerx.EntityFramework
{
    public class EfCustomerAccountDal : GenericRepository<CustomerAccount>, ICustomerAccountDal
    {
        public List<CustomerAccount> GetCustomerAccountsList(int id)
        {
            using var context = new Context();
            var values = context.customerAccounts.Where(x => x.AppUserID == id).ToList();
            return values;
        }
    }
}
