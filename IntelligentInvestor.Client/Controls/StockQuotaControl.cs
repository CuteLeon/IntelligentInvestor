using IntelligentInvestor.Client.Themes;
using IntelligentInvestor.Domain.Quotas;
using IntelligentInvestor.Domain.Stocks;

namespace IntelligentInvestor.Client.Controls;

public partial class StockQuotaControl : StockAttachControlBaseGeneric<Quota>
{
    private readonly IUIThemeHandler themeHandler;

    public StockQuotaControl(
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
        this.UpdateTimeValueLabel.ForeColor = color;
    }

    public override void SetValueForecolor(Color color)
    {
        this.CurrentPriceValueLabel.StaticForecolor = color;
        this.ClosingPriceYesterdayValueLabel.ForeColor = color;
        this.OpeningPriceTodayValueLabel.ForeColor = color;
        this.DayHighPriceValueLabel.ForeColor = this.themeHandler.GetQuotaForecolor(1);
        this.DayLowPriceValueLabel.ForeColor = this.themeHandler.GetQuotaForecolor(-1);
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

    public override void AttachEntityToFace(Quota quota)
    {
        if (quota == null)
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
            this.UpdateTimeValueLabel.Text = "-";
        }
        else
        {
            if (quota.OpenningPrice > quota.ClosingPriceYesterday)
            {
                this.OpeningPriceTodayValueLabel.ForeColor = this.themeHandler.GetQuotaForecolor(1);
                this.ClosingPriceYesterdayValueLabel.ForeColor = this.themeHandler.GetQuotaForecolor(-1);
            }
            else
            {
                this.OpeningPriceTodayValueLabel.ForeColor = this.themeHandler.GetQuotaForecolor(-1);
                this.ClosingPriceYesterdayValueLabel.ForeColor = this.themeHandler.GetQuotaForecolor(1);
            }

            this.CurrentPriceValueLabel.BasePrice = quota.OpenningPrice;
            this.CurrentPriceValueLabel.Price = quota.CurrentPrice;
            this.ClosingPriceYesterdayValueLabel.Text = quota.ClosingPriceYesterday.ToString("N4");
            this.OpeningPriceTodayValueLabel.Text = quota.OpenningPrice.ToString("N4");
            this.DayHighPriceValueLabel.Text = quota.HighestPrice.ToString("N4");
            this.DayLowPriceValueLabel.Text = quota.LowestPrice.ToString("N4");
            this.CountValueLabel.Text = quota.Volume.ToString("N0");
            this.AmountValueLabel.Text = quota.Amount.ToString("N0");
            this.UpdateTimeValueLabel.Text = quota.QuotaTime.ToString();
        }
    }
}
