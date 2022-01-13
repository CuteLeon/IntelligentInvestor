﻿using IntelligentInvestor.Client.Themes;
using IntelligentInvestor.Domain.Quotes;
using IntelligentInvestor.Domain.Stocks;

namespace IntelligentInvestor.Client.Controls;

public partial class StockQuoteControl : StockAttachControlBaseGeneric<Quote>
{
    private readonly IUIThemeHandler themeHandler;

    public StockQuoteControl(
        IUIThemeHandler themeHandler)
    {
        this.InitializeComponent(themeHandler);

        if (this.DesignMode)
        {
            return;
        }

        this.themeHandler = themeHandler;
    }

    public override void SetLabelForecolor(Color color)
    {
        this.DayHighPriceLabel.ForeColor = color;
        this.DayLowPriceLabel.ForeColor = color;
        this.ClosingPriceYesterdayLabel.ForeColor = color;
        this.OpeningPriceTodayLabel.ForeColor = color;
        this.CountLabel.ForeColor = color;
        this.AmountLabel.ForeColor = color;

        this.CodeValueLabel.ForeColor = color;
        this.MarketValueLabel.ForeColor = color;
        this.StockNameValueLabel.ForeColor = color;
        this.QuoteTimeValueLabel.ForeColor = color;
    }

    public override void SetValueForecolor(Color color)
    {
        this.CurrentPriceValueLabel.StaticForecolor = color;
        this.ClosingPriceYesterdayValueLabel.ForeColor = color;
        this.OpeningPriceTodayValueLabel.ForeColor = color;
        this.DayHighPriceValueLabel.ForeColor = this.themeHandler.GetQuoteForecolor(1);
        this.DayLowPriceValueLabel.ForeColor = this.themeHandler.GetQuoteForecolor(-1);
        this.CountValueLabel.ForeColor = color;
        this.AmountValueLabel.ForeColor = color;
    }

    public override void StockToFace(Stock stock)
    {
        this.CurrentPriceValueLabel.ClearPrice();

        if (stock == null)
        {
            this.CodeValueLabel.Text = "-";
            this.MarketValueLabel.Text = "-";
            this.StockNameValueLabel.Text = "-";
        }
        else
        {
            this.CodeValueLabel.Text = stock.StockCode;
            this.MarketValueLabel.Text = stock.StockMarket.ToString();
            this.StockNameValueLabel.Text = stock.StockName;
        }
    }

    public override void AttachEntityToFace(Quote quote)
    {
        if (quote == null)
        {
            this.CurrentPriceValueLabel.Price = null;
            this.OpeningPriceTodayValueLabel.ForeColor = this.ValueForecolor;
            this.ClosingPriceYesterdayValueLabel.ForeColor = this.ValueForecolor;

            this.ClosingPriceYesterdayValueLabel.Text = "-";
            this.OpeningPriceTodayValueLabel.Text = "-";
            this.DayHighPriceValueLabel.Text = "-";
            this.DayLowPriceValueLabel.Text = "-";
            this.CountValueLabel.Text = "-";
            this.AmountValueLabel.Text = "-";
            this.QuoteTimeValueLabel.Text = "-";
        }
        else
        {
            if (quote.OpenningPrice > quote.ClosingPriceYesterday)
            {
                this.OpeningPriceTodayValueLabel.ForeColor = this.themeHandler.GetQuoteForecolor(1);
                this.ClosingPriceYesterdayValueLabel.ForeColor = this.themeHandler.GetQuoteForecolor(-1);
            }
            else
            {
                this.OpeningPriceTodayValueLabel.ForeColor = this.themeHandler.GetQuoteForecolor(-1);
                this.ClosingPriceYesterdayValueLabel.ForeColor = this.themeHandler.GetQuoteForecolor(1);
            }

            this.CurrentPriceValueLabel.BasePrice = quote.OpenningPrice;
            this.CurrentPriceValueLabel.Price = quote.CurrentPrice;
            this.ClosingPriceYesterdayValueLabel.Text = quote.ClosingPriceYesterday.ToString("N4");
            this.OpeningPriceTodayValueLabel.Text = quote.OpenningPrice.ToString("N4");
            this.DayHighPriceValueLabel.Text = quote.HighestPrice.ToString("N4");
            this.DayLowPriceValueLabel.Text = quote.LowestPrice.ToString("N4");
            this.CountValueLabel.Text = quote.Volume.ToString("N0");
            this.AmountValueLabel.Text = quote.Amount.ToString("N0");
            this.QuoteTimeValueLabel.Text = quote.QuoteTime.ToString();
        }
    }
}