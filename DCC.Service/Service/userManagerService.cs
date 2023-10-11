using AutoMapper;
using DCC.ModelSQL.GenericRepository.Repository;
using DCC.ModelSQL.Models;
using DCC.Service.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DCC.Service.Service
{
    public class userManagerService : IuserManager
    {
        private IRepository _repository;
       

        public userManagerService(IRepository repository)
        {
            _repository = repository;
          

        }
        public bool CheckPasswordAsync(DccUser user, string Password)
        {
            var users = _repository.GetQueryable<DccUser>().Where(a => a.UserName == user.UserName && a.Password==Password);
            if (user != null)
            {
                return true;
            }
            return false ; 
        }

        public DccUser FindByNameAsync(string UserName)
        {

            var IQusers = _repository.GetQueryable<DccUser>();
            var users = IQusers.Where(a => a.UserName == UserName);
          

            DccUser obj = new DccUser();

            foreach (var item in users.ToList())
            {
                obj.Id = item.Id;
                obj.Name = item.Name;
                obj.UserName = item.UserName;
               
            }

                return obj;
        }
    }
}
