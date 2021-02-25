using Business.Abstract;
using Business.Constants;
using Core.Utilities.Results;
using DataAccsess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
    public class UserManager : IUserService
    {
        IUserDal _userDal;

        public UserManager(IUserDal userDal)
        {
            _userDal = userDal;
        }

        public IResult Add(User user)
        {
            if (user.FirstName.Length >= 2 && user.LastName.Length >= 2 && user.Password.Length >= 8)
            {
                _userDal.Add(user);
                return new SuccessResult(Messages.UserAdded);
            }
            return new ErrorResult(Messages.UserDetailsInvalid);
        }

        public IResult Delete(User user)
        {
            _userDal.Delete(user);
            return new SuccessResult(Messages.UserDeleted);
        }

        public IDataResult<List<User>> GetAll()
        {
            return new SuccessDataResult<List<User>>(_userDal.GetAll(), Messages.UsersListed);
        }

        public IDataResult<User> GetById(int userId)
        {
            return new SuccessDataResult<User>(_userDal.Get(u => u.UserId == userId), Messages.UserListed);
        }

        public IResult Update(User user)
        {
            _userDal.Update(user);
            return new SuccessResult(Messages.UserUpdated);
        }
    }
}
