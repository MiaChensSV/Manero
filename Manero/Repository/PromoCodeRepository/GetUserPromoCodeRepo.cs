using Manero.Context;
using Manero.Models.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;

namespace Manero.Repository.PromoCodeRepo;

public class GetUserPromoCodeRepo : GeneralRepo<PromocodesEntity>
{
    private readonly DataContext _context;

    public GetUserPromoCodeRepo(DataContext context) : base(context)
    {
        _context = context;
    }

    public async Task<IEnumerable<PromocodesEntity>> GetUserPromocodesAsync(string specificUserId)
    {
        var user = await _context.Users
                                 .Include(x => x.Promocodes)
                                 .ThenInclude(x => x.Promocode)
                                 .FirstOrDefaultAsync(x => x.Id == specificUserId);

        if (user != null && user.Promocodes != null)
        {
            return user.Promocodes.Select(x => x.Promocode);
        }

        return new List<PromocodesEntity>();
    }
}

