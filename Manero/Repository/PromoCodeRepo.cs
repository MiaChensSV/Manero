using Manero.Context;
using Manero.Models.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;

namespace Manero.Repository;

public interface IPromoCodeRepo
{
    Task<IEnumerable<PromocodesEntity>> GetUserPromocodesAsync(string specificUserId);
    Task<bool> AssignPromoCodeToUserAsync(string userId, string promoCodeTitle);
}


public class PromoCodeRepo : GeneralRepo<PromocodesEntity>, IPromoCodeRepo
{
    private readonly DataContext _context;

    public PromoCodeRepo(DataContext context) : base(context)
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


    public async Task<bool> AssignPromoCodeToUserAsync(string userId, string promoCodeTitle)
    {
        var promoCodeEntity = await _context.Promocodes
            .Where(x => x.PromocodeTitle == promoCodeTitle)
            .FirstOrDefaultAsync();

        if (promoCodeEntity == null)
        {
            return false;
        }

        var existingUserPromoCode = await _context.UserPromocodes
            .Where(x => x.UserId == userId && x.PromocodeId == promoCodeEntity.PromocodeId)
            .FirstOrDefaultAsync();

        if (existingUserPromoCode != null)
        {
            return false;
        }

        var newUserPromoCode = new UserPromocodesEntity
        {
            UserId = userId,
            PromocodeId = promoCodeEntity.PromocodeId
        };

        _context.UserPromocodes.Add(newUserPromoCode);
        await _context.SaveChangesAsync();

        return true;
    }
}

