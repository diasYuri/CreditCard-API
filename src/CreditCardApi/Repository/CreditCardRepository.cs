using System.Collections.Generic;
using System.Linq;
using CreditCardApi.Data;
using CreditCardApi.Dto;
using CreditCardApi.Models;

namespace CreditCardApi.Repository
{

  public class CreditCardRepository : ICreditCardRepository
  {
    private readonly AppDbContext _dbcontext;
    public CreditCardRepository(AppDbContext dbcontext)
    {
      _dbcontext = dbcontext;
    }
    public CardDto StoreCard(CreditCard card)
    {
      _dbcontext.Add(card);
      _dbcontext.SaveChanges();
      return Mapper.ModelToDto(card);
    }

    public List<CardDto> GetCardsByEmail(string email)
    {
      List<CardDto> cardsDto = new List<CardDto>();

      _dbcontext.CreditCards
        .Where(c => c.OwnerEmail == email)
        .OrderBy(c => c.CreatedAt)
        .ToList()
        .ForEach(c => cardsDto.Add(Mapper.ModelToDto(c)));

      return cardsDto;
    }
  }

}