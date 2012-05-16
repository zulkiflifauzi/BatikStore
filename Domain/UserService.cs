using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Domain.Interfaces;
using Repository;
using Repository.Interfaces;
using Ninject;

namespace Domain
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;        

        [Inject]
        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public User GetUserByEmail(string email)
        {
            return _userRepository.GetUserByEmail(email);
        }
    }
}
