﻿using Application.Library.BaseModel.BaseDTO;
using Application.Library.Repositories.SEC.UserRepositories.Models.DTOs;

namespace Application.Library.Repositories.SEC.UserRepositories.Commands
{
    public interface IUserCreateRepository
    {
        Task<Result<UserDTO>> Execute(UserDTO user);
    }
}
