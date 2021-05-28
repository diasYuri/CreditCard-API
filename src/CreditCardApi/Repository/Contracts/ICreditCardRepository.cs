using System.Collections.Generic;
using CreditCardApi.Dto;
using CreditCardApi.Models;

namespace CreditCardApi.Repository
{

  public interface ICreditCardRepository
  {
    CardDto StoreCard(CreditCard card);
    List<CardDto> GetCardsByEmail(string email);

  }

}