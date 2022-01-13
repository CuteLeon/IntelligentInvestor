using IntelligentInvestor.Client.Themes;
using IntelligentInvestor.Domain.Quotas;
using IntelligentInvestor.Domain.Stocks;

namespace IntelligentInvestor.Client.Controls;

public partial class MarketQuotaControl : StockAttachControlBaseGeneric<Quota>
{
    private readonly IUIThemeHandler themeHandler;

    public MarketQuotaControl(
        IUIThemeHandler themeHandler)
    {
        this.InitializeComponent();
        this.themeHandler = themeHandler;
    }

    public override void SetLabelForecolor(Color color)
    {
        this.CountLabel.ForeColor = color;
        this.AmountLabel.ForeColor = color;
        this.QuotaTimeLabel.ForeColor = color;
        this.CodeValueLabel.ForeColor = color;
        this.MarketValueLabel.ForeColor = color;
        this.StockNameValueLabel.ForeColor = color;
        this.QuotaTimeValueLabel.ForeColor = color;
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

    public override void AttachEntityToFace(Quota quota)
    {
        if (quota == null)
        {
            this.CurrentPriceValueLabel.ForeColor = this.ValueForecolor;
            this.FluctuatingRangeValueLabel.ForeColor = this.ValueForecolor;
            this.FluctuatingRateValueLabel.ForeColor = this.ValueForecolor;

            this.CurrentPriceValueLabel.Text = "-";
            this.FluctuatingRangeValueLabel.Text = "-";
            this.FluctuatingRateValueLabel.Text = "-";
            this.CountValueLabel.Text = "-";
            this.AmountValueLabel.Text = "-";
            this.QuotaTimeValueLabel.Text = "-";
        }
        else
        {
            Color quotaForecolor = themeHandler.GetQuotaForecolor(quota.FluctuatingRange);
            this.CurrentPriceValueLabel.ForeColor = quotaForecolor;
            this.FluctuatingRangeValueLabel.ForeColor = quotaForecolor;
            this.FluctuatingRateValueLabel.ForeColor = quotaForecolor;

            this.CurrentPriceValueLabel.Text = quota.CurrentPrice.ToString("N4");
            this.FluctuatingRangeValueLabel.Text = quota.FluctuatingRange.ToString("N4");
            this.FluctuatingRateValueLabel.Text = $"{quota.FluctuatingRate.ToString("N4")} %";
            this.CountValueLabel.Text = quota.Volume.ToString("N0");
            this.AmountValueLabel.Text = quota.Amount.ToString("N0");
            this.QuotaTimeValueLabel.Text = quota.QuotaTime.ToString("HH:mm:ss");
        }
    }
}
