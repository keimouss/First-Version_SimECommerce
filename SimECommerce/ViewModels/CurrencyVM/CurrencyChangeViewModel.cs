using Microsoft.AspNetCore.Mvc.Rendering;
using SimECommerce.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SimECommerce.ViewModels
{
    public class CurrencyChangeViewModel
    {
        public Currency Currency { get; set; }
        public CurrencyChangeViewModel()
        {
            Currency = new Currency();
            CurrencyList = new List<Currency>();
            ChangeCurrencyListItem = Enum.GetValues(typeof(Currency)).Cast<Currency>().Select(x => new SelectListItem { Text = x.Name, Value = (x.Id).ToString() }).ToList();
            ChangeCurrencyList = new SelectList(ChangeCurrencyListItem, "Value", "Text");
        }
        public List<Currency> CurrencyList { get; set; }
        public SelectList ChangeCurrencyList { get; set; }
        IList<SelectListItem> ChangeCurrencyListItem { get; set; }

        public int Id { get; set; }
        public string Name { get; set; }

        //public string CurrencyCode { get; set; }
        //public decimal Rate { get; set; }
        //public string DisplayLocale { get; set; }
        //public string CustomFormatting { get; set; }
        //public bool LimitedToStores { get; set; }
        //public bool Published { get; set; }
        //public int DisplayOrder { get; set; }
        //public DateTime CreatedOnUtc { get; set; }
        //public DateTime UpdatedOnUtc { get; set; }
    }
}
