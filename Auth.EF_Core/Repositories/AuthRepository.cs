using Auth.App.Repositories;
using Auth.App.Services;
using Auth.Domain.Models;
using Auth.Domain.ViewModels.AddUser;
using Auth.EF_Core.Context;
using Auth.EF_Core.Dbo;
using AutoMapper;
using Microsoft.EntityFrameworkCore;

namespace Auth.EF_Core.Repositories
{
    public class AuthRepository : IAuthRepository
    {
        private readonly AuthContext _context;
        private readonly IEncodePasswordService _passwordService;
        private readonly IMapper _mapper;

        public AuthRepository(AuthContext context, IEncodePasswordService passwordService, IMapper mapper)
        {
            _context = context;
            _passwordService = passwordService;
            _mapper = mapper;
        }

        public async Task<User?> GetUserByToken(string token)
        {
            var tokenDbo = await _context.Tokens.FirstOrDefaultAsync(x => x.TokenData == token);
            if (tokenDbo == null)
            {
                return null;
            }

            return _mapper.Map<User>(tokenDbo.User);
        }

        public async Task<User?> AddUserAsync(RegisterViewModel vm)
        {
            var userToAdd = _mapper.Map<UserDbo>(vm);

            userToAdd.PasswordHash = await _passwordService.EncodePasswordAsync(vm.Password);

            await _context.Users.AddAsync(userToAdd);
            var res = await _context.SaveChangesAsync();

            if (res > 0)
            {
                return _mapper.Map<User>(userToAdd);
            }
            else
            {
                return null;
            }
        }

        public async Task<List<User>> GetUsersAsync()
        {
            return await _context.Users.Select(x => _mapper.Map<User>(x)).ToListAsync();
        }

        public async Task<List<Token>> GetTokensAsync()
        {
            //Should Change
            return await _context.Tokens.Select(x => _mapper.Map<Token>(x)).ToListAsync();
        }

        public async Task<Token?> AddTokenAsync(string token, DateTime expiredAt, int userId)
        {
            var userDbo = await _context.Users.FirstOrDefaultAsync(x => x.Id == userId);

            if (userDbo == null)
            {
                return null;
            }
            TokenDbo tokenToAdd;

            tokenToAdd = await _context.Tokens.FirstOrDefaultAsync(x => x.UserId == userDbo.Id);

            if(tokenToAdd == null)
            {
                tokenToAdd = new TokenDbo()
                {
                    TokenData = token,
                    ExpiredAt = expiredAt,
                    UserId = userId
                };

                await _context.Tokens.AddAsync(tokenToAdd);
            }
            else
            {
                tokenToAdd.TokenData = token;
                tokenToAdd.ExpiredAt = expiredAt;
            }

            var res = await _context.SaveChangesAsync();

            if (res > 0)
            {
                return _mapper.Map<Token>(tokenToAdd);
            }
            else
            {
                return null;
            }
        }

        public async Task<Token?> RemoveTokenAsync(string token)
        {
            var tokenDbo = await _context.Tokens.FirstOrDefaultAsync(x => x.TokenData == token);

            if (tokenDbo == null)
            {
                return null;
            }

            var res = _context.Tokens.Remove(tokenDbo);

            return _mapper.Map<Token>(res);
        }

        public async Task<User?> GetUserByEmailAsync(string email)
        {
            return _mapper.Map<User>(await _context.Users.FirstOrDefaultAsync(x => x.Email == email));
        }

        public async Task<User?> GetUserByPhoneAsync(string phone)
        {
            return _mapper.Map<User>(await _context.Users.FirstOrDefaultAsync(x => x.Phone == phone));
        }

        public async Task<string?> GetUserPasswordAsync(int id)
        {
            var userDbo = await _context.Users.FirstOrDefaultAsync(x => x.Id == id);

            return userDbo?.PasswordHash;
        }
    }
}
