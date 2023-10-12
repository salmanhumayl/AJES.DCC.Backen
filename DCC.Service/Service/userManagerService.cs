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

              var dccUsers= _repository.GetQueryable<DccUser>().ToList().Where(a => a.UserName == UserName).SingleOrDefault();

            List<DccUser> IQusers = _repository.GetQueryable<DccUser>().ToList();
             var users = IQusers.Where(a => a.UserName == UserName).SingleOrDefault();

            // var IQusers = _repository.GetQueryable<DccUser>();

            //  var users = IQusers.Where(a => a.UserName == UserName).Select(x => new users { Id = x.Id, Name = x.Name, UserName = x.UserName });
            return dccUsers;
        }

        public List<string> Test(string UserName)
        {

            var IQusers = _repository.GetQueryable<DccUser>().ToList();

            var users = IQusers.Where(a => a.UserName == UserName).Select(a=>a.UserName).ToList();
            return users;
            
        }
    }

    public class users 
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string UserName { get; set; }
    }
}

