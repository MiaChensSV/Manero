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


	public async Task<bool> AssignPromoCodeToUserAsync(string userId, string promoCodeTitle)
	{
		using var transaction = await _context.Database.BeginTransactionAsync();

		try
		{
			// 1. Kontrollera om promocoden existerar.
			var promoCodeEntity = await _context.Promocodes
				.Where(x => x.PromocodeTitle == promoCodeTitle)
				.FirstOrDefaultAsync();

			if (promoCodeEntity == null)
			{
				return false; // Promocode finns inte.
			}

			// 2. Kontrollera om användaren redan har den promocoden.
			var existingUserPromo = await _context.UserPromocodes
				.Where(x => x.UserId == userId && x.PromocodeId == promoCodeEntity.PromocodeId)
				.FirstOrDefaultAsync();

			if (existingUserPromo != null)
			{
				return false; // Användaren har redan denna promocode.
			}

			// 3. Lägg till en ny post för att koppla användaren med promocoden.
			var newUserPromo = new UserPromocodesEntity
			{
				UserId = userId,
				PromocodeId = promoCodeEntity.PromocodeId
			};

			_context.UserPromocodes.Add(newUserPromo);
			await _context.SaveChangesAsync();

			await transaction.CommitAsync();

			return true; // Allt gick bra.
		}
		catch (Exception ex)
		{
			await transaction.RollbackAsync();
			throw; 
		}
	}

}

