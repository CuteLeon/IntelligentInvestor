using IntelligentInvestor.Client.Themes;
using IntelligentInvestor.Domain.Quotes;
using IntelligentInvestor.Domain.Stocks;

namespace IntelligentInvestor.Client.Controls;

public partial class StockQuoteControl : StockControlBase
{
    public IUIThemeHandler ThemeHandler { get; set; }

    public StockQuoteControl()
    {
        this.InitializeComponent();
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
        this.CurrentPriceValueLabel.RiseForeColor = this.ThemeHandler?.GetQuoteForecolor(1) ?? Color.Crimson;
        this.CurrentPriceValueLabel.FallForeColor = this.ThemeHandler?.GetQuoteForecolor(-1) ?? Color.LimeGreen;
        this.DayHighPriceValueLabel.ForeColor = this.ThemeHandler?.GetQuoteForecolor(1) ?? Color.Crimson;
        this.DayLowPriceValueLabel.ForeColor = this.ThemeHandler?.GetQuoteForecolor(-1) ?? Color.LimeGreen;
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

    public override void EntityToFace(StockBase? entity)
    {
        var quote = (Quote?)entity;
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
                this.OpeningPriceTodayValueLabel.ForeColor = this.ThemeHandler?.GetQuoteForecolor(1) ?? Color.Crimson;
                this.ClosingPriceYesterdayValueLabel.ForeColor = this.ThemeHandler?.GetQuoteForecolor(-1) ?? Color.LimeGreen;
            }
            else
            {
                this.OpeningPriceTodayValueLabel.ForeColor = this.ThemeHandler?.GetQuoteForecolor(-1) ?? Color.LimeGreen;
                this.ClosingPriceYesterdayValueLabel.ForeColor = this.ThemeHandler?.GetQuoteForecolor(1) ?? Color.Crimson;
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
