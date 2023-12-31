﻿using Microsoft.EntityFrameworkCore;
using Tournonamemt.Models;
using Tournonamemt.Repository.Interface;

namespace Tournonamemt.Repository
{
    public class UserRepository : IUserRepository
    {
        private readonly ApplicationContext _context;
        public UserRepository(ApplicationContext context)
        {
            _context = context;
        }
        public async Task<User?> GetAsync(int playerId)
        {
            return await _context.Users.FirstOrDefaultAsync(x => x.Id == playerId);
        }

        public async Task<User?> GetByLoginAsync(string login)
        {
            return await _context.Users.FirstOrDefaultAsync(x => x.Login == login);
        }

        public async Task<List<Match>> GetMatchies(int userId)
        {
            return await _context.matches
                .Where(x => x.Participants.Any(x => x.Id == userId))
                .ToListAsync();
        }

        public async Task<List<Tournament>> GetTournaments(int userId)
        {
            return await _context.tournaments
               .Where(x => x.Participants.Any(x => x.Id == userId))
               .ToListAsync();
        }

        public async Task<User> Save(User player)
        {
            await _context.Users.AddAsync(player);
            await _context.SaveChangesAsync();
            return player;
        }

        public async Task Update(User user)
        {
            await _context.SaveChangesAsync();
        }
    }
}
