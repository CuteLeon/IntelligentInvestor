﻿using IntelligentInvestor.Domain.Stocks;

namespace IntelligentInvestor.Spider.Stocks;

public interface IStockSpider
{
    Task<IEnumerable<Stock>> SearchStocksAsync(string keyword);
}
