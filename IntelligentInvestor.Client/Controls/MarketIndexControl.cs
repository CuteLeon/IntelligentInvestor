﻿using IntelligentInvestor.Client.Themes;
using IntelligentInvestor.Domain.Quotes;
using IntelligentInvestor.Domain.Stocks;

namespace IntelligentInvestor.Client.Controls;

public partial class MarketIndexControl : StockControlBase
{
    public IUIThemeHandler ThemeHandler { get; set; }

    public MarketIndexControl()
    {
        this.InitializeComponent();
    }

    public override void SetLabelForecolor(Color color)
    {
        this.CountLabel.ForeColor = color;
        this.AmountLabel.ForeColor = color;
        this.QuoteTimeLabel.ForeColor = color;
        this.CodeValueLabel.ForeColor = color;
        this.MarketValueLabel.ForeColor = color;
        this.StockNameValueLabel.ForeColor = color;
        this.QuoteTimeValueLabel.ForeColor = color;
    }

    public override void SetValueForecolor(Color color)
    {
        this.CurrentPriceValueLabel.ForeColor = color;
        this.FluctuatingRangeValueLabel.ForeColor = color;
        this.FluctuatingRateValueLabel.ForeColor = color;
        this.CountValueLabel.ForeColor = color;
        this.AmountValueLabel.ForeColor = color;
    }

    public override void StockToFace(Stock stock)
    {
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

    public override void EntityToFace(StockBase? entity)
    {
        var quote = (Quote?)entity;
        if (quote == null)
        {
            this.CurrentPriceValueLabel.ForeColor = this.ValueForecolor;
            this.FluctuatingRangeValueLabel.ForeColor = this.ValueForecolor;
            this.FluctuatingRateValueLabel.ForeColor = this.ValueForecolor;

            this.CurrentPriceValueLabel.Text = "-";
            this.FluctuatingRangeValueLabel.Text = "-";
            this.FluctuatingRateValueLabel.Text = "-";
            this.CountValueLabel.Text = "-";
            this.AmountValueLabel.Text = "-";
            this.QuoteTimeValueLabel.Text = "-";
        }
        else
        {
            var quoteForecolor = this.ThemeHandler?.GetQuoteForecolor(quote.FluctuatingRange) ?? Color.Black;
            this.CurrentPriceValueLabel.ForeColor = quoteForecolor;
            this.FluctuatingRangeValueLabel.ForeColor = quoteForecolor;
            this.FluctuatingRateValueLabel.ForeColor = quoteForecolor;

            this.CurrentPriceValueLabel.Text = quote.CurrentPrice.ToString("N4");
            this.FluctuatingRangeValueLabel.Text = quote.FluctuatingRange.ToString("N4");
            this.FluctuatingRateValueLabel.Text = $"{quote.FluctuatingRate:N4} %";
            this.CountValueLabel.Text = quote.Volume.ToString("N0");
            this.AmountValueLabel.Text = quote.Amount.ToString("N0");
            this.QuoteTimeValueLabel.Text = quote.QuoteTime.ToString("HH:mm:ss");
        }
    }
}
