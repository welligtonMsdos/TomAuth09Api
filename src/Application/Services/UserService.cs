using AutoMapper;
using FluentValidation.Results;
using TomAuthApi.src.Application.Dtos;
using TomAuthApi.src.Application.Interfaces;
using TomAuthApi.src.Domain.Interfaces;
using TomAuthApi.src.Domain.Model;
using TomAuthApi.src.Domain.Validation;

namespace TomAuthApi.src.Application.Services;

public class UserService: IUserService
{
    private readonly IUserRepository _repository;
    private readonly IMapper _mapper;

    public UserService(IUserRepository repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }

    public async Task<ICollection<UserDto>> GetAll()
    {
        return _mapper.Map<ICollection<UserDto>>(await _repository.GetAll());
    }

    public async Task<UserDto> GetById(string id)
    {
        return _mapper.Map<UserDto>(await _repository.GetById(id));
    }

    public async Task<UserDto> GetByEmail(string email)
    {
        return _mapper.Map<UserDto>(await _repository.GetByEmail(email));
    }

    public async Task<UserDto> Post(UserCreateDto userCreateDto)
    {
        var user = _mapper.Map<User>(userCreateDto);

        ValidationResult valid = new UserCreateValidation().Validate(user);

        string[] erros = valid.ToString("~").Split('~');

        if (!valid.IsValid) throw new Exception(erros[0]);

        user.Active = true;

        user.LastAccess = DateTime.Now;       

        user.Password = BCrypt.Net.BCrypt.HashPassword(user.Password);

        return _mapper.Map<UserDto>(await _repository.Post(user));
    }

    public async Task<bool> DeleteById(string id)
    {
        var user = await _repository.GetById(id);

        if (user == null) throw new Exception("User not found");

        return await _repository.DeleteById(id);
    }

    public async Task<UserDto> Put(string id, UserUpdateDto userUpdateDto)
    {
        var user = _mapper.Map<User>(userUpdateDto);

        ValidationResult valid = new UserUpdateValidation().Validate(user);

        string[] erros = valid.ToString("~").Split('~');

        if (!valid.IsValid) throw new Exception(erros[0]);

        user.Active = true;

        user.LastAccess = DateTime.Now;        

        return _mapper.Map<UserDto>(await _repository.Put(id, user));
    }
}
