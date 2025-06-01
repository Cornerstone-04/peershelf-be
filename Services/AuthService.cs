using AcademicResourceApp.Data;
using Microsoft.AspNetCore.Identity;
using AcademicResourceApp.Models;
using AcademicResourceApp.DTOs;
using Microsoft.EntityFrameworkCore;


namespace AcademicResourceApp.Services
{
    public class AuthService
    {
        private readonly AppDbContext _context;
        private readonly IPasswordHasher<User> _passwordHasher;

        public AuthService(AppDbContext context, IPasswordHasher<User> passwordHasher)
        {
            _context = context;
            _passwordHasher = passwordHasher;
        }
        public IPasswordHasher<User> PasswordHasher => _passwordHasher;

        public async Task<string> RegisterAsync(RegisterDto request)
        {
            var exists = await _context.Users.AnyAsync(u => u.Email == request.Email);
            if (exists) throw new ApplicationException("Email already exists");

            var user = new User
            {
                FirstName = request.FirstName,
                LastName = request.LastName,
                Email = request.Email,
                SchoolEmail = request.SchoolEmail
            };

            user.PasswordHash = _passwordHasher.HashPassword(user, request.Password);

            _context.Users.Add(user);
            await _context.SaveChangesAsync();

            return "Registration successful!";
        }
    }

}
