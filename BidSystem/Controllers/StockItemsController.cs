using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using BidSystem.Data;
using BidSystem.Models;
using BidSystem.Services;

namespace BidSystem.Controllers
{
    public class StockItemsController : Controller
    {
        private readonly StockItemService _stockItemService;

        public StockItemsController(StockItemService stockItemService)
        {
            _stockItemService = stockItemService;
        }
    }
}
