using Microsoft.AspNetCore.Mvc;
using System;

namespace Odev1.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class InterestController : ControllerBase
    {
        [HttpGet("GetInterest")]
        public ActionResult<Interest> Get([FromQuery] double principal, double interestRate, double expiry) //Request body (ana para, faiz orani ve vade alindi)
        {
            Interest interest = new(); //yeni liste
            if (principal > 0 && interestRate > 0 && expiry > 0) //girilen degerlerin eksi veya 0 olup olmadigi kontrol edildi
            {
                double totalBalance = principal * Math.Pow((1 + interestRate), expiry); //bilesik faiz hesabi
                double interestAmount = totalBalance - principal;  //faiz getirisi hesabi
                interest.TotalBalance = totalBalance;  //Interest sinifindaki TotalBalance ile InterestController sinifindaki totalBalance parametreleri esitlendi
                interest.InterestAmount = interestAmount; //Interest sinifindaki InterestAmount ile InterestController sinifindaki interestAmount parametreleri esitlendi
                interest.InterestRate = interestRate; //Interest sinifindaki InterestRate ile InterestController sinifindaki interestRate parametreleri esitlendi
                return Ok(interest); //response body (toplam bakiye, faiz getirisi ve faiz orani donduruldu)
            }
            else
            {
                return BadRequest("Lütfen 0'dan büyük değerler giriniz!!"); //400 kodu ve hata mesaji donduruldu
            }
        }
    }
}
