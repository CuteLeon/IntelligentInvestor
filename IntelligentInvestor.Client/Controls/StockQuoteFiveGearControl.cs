using IntelligentInvestor.Client.Themes;
using IntelligentInvestor.Domain.Trades;

namespace IntelligentInvestor.Client.Controls;

public partial class StockQuoteFiveGearControl : StockAttachControlBaseGeneric<TradeStrand>
{
    private readonly IUIThemeHandler themeHandler;

    public StockQuoteFiveGearControl(
        IUIThemeHandler themeHandler)
    {
        this.InitializeComponent();
        this.themeHandler = themeHandler;
    }

    public override void SetLabelForecolor(Color color)
    {
        this.BiddingPriceLabel.ForeColor = color;
        this.AuctionPriceLabel.ForeColor = color;

        this.Buy1Label.ForeColor = color;
        this.Buy2Label.ForeColor = color;
        this.Buy3Label.ForeColor = color;
        this.Buy4Label.ForeColor = color;
        this.Buy5Label.ForeColor = color;

        this.Sell1Label.ForeColor = color;
        this.Sell2Label.ForeColor = color;
        this.Sell3Label.ForeColor = color;
        this.Sell4Label.ForeColor = color;
        this.Sell5Label.ForeColor = color;
    }

    public override void SetValueForecolor(Color color)
    {
        this.BiddingPriceValueLabel.ForeColor = this.themeHandler.GetQuoteForecolor(1);
        this.AuctionPriceValueLabel.ForeColor = this.themeHandler.GetQuoteForecolor(-1);

        this.Buy1StrandValueLabel.ForeColor = color;
        this.Buy2StrandValueLabel.ForeColor = color;
        this.Buy3StrandValueLabel.ForeColor = color;
        this.Buy4StrandValueLabel.ForeColor = color;
        this.Buy5StrandValueLabel.ForeColor = color;

        this.Buy1PriceValueLabel.ForeColor = this.themeHandler.GetQuoteForecolor(1);
        this.Buy2PriceValueLabel.ForeColor = this.themeHandler.GetQuoteForecolor(1);
        this.Buy3PriceValueLabel.ForeColor = this.themeHandler.GetQuoteForecolor(1);
        this.Buy4PriceValueLabel.ForeColor = this.themeHandler.GetQuoteForecolor(1);
        this.Buy5PriceValueLabel.ForeColor = this.themeHandler.GetQuoteForecolor(1);

        this.Sell1StrandValueLabel.ForeColor = color;
        this.Sell2StrandValueLabel.ForeColor = color;
        this.Sell3StrandValueLabel.ForeColor = color;
        this.Sell4StrandValueLabel.ForeColor = color;
        this.Sell5StrandValueLabel.ForeColor = color;

        this.Sell1PriceValueLabel.ForeColor = this.themeHandler.GetQuoteForecolor(-1);
        this.Sell2PriceValueLabel.ForeColor = this.themeHandler.GetQuoteForecolor(-1);
        this.Sell3PriceValueLabel.ForeColor = this.themeHandler.GetQuoteForecolor(-1);
        this.Sell4PriceValueLabel.ForeColor = this.themeHandler.GetQuoteForecolor(-1);
        this.Sell5PriceValueLabel.ForeColor = this.themeHandler.GetQuoteForecolor(-1);
    }

    public override void AttachEntityToFace(TradeStrand tradeStrand)
    {
        if (tradeStrand == null)
        {
            this.BiddingPriceValueLabel.Text = "-";
            this.AuctionPriceValueLabel.Text = "-";

            this.Buy1StrandValueLabel.Text = "-";
            this.Buy2StrandValueLabel.Text = "-";
            this.Buy3StrandValueLabel.Text = "-";
            this.Buy4StrandValueLabel.Text = "-";
            this.Buy5StrandValueLabel.Text = "-";

            this.Buy1PriceValueLabel.Text = "-";
            this.Buy2PriceValueLabel.Text = "-";
            this.Buy3PriceValueLabel.Text = "-";
            this.Buy4PriceValueLabel.Text = "-";
            this.Buy5PriceValueLabel.Text = "-";

            this.Sell1StrandValueLabel.Text = "-";
            this.Sell2StrandValueLabel.Text = "-";
            this.Sell3StrandValueLabel.Text = "-";
            this.Sell4StrandValueLabel.Text = "-";
            this.Sell5StrandValueLabel.Text = "-";

            this.Sell1PriceValueLabel.Text = "-";
            this.Sell2PriceValueLabel.Text = "-";
            this.Sell3PriceValueLabel.Text = "-";
            this.Sell4PriceValueLabel.Text = "-";
            this.Sell5PriceValueLabel.Text = "-";
        }
        else
        {
            this.BiddingPriceValueLabel.Text = tradeStrand.BiddingPrice.ToString("N4");
            this.AuctionPriceValueLabel.Text = tradeStrand.AuctionPrice.ToString("N4");

            this.Buy1StrandValueLabel.Text = tradeStrand.BuyStrand1.ToString("N0");
            this.Buy2StrandValueLabel.Text = tradeStrand.BuyStrand2.ToString("N0");
            this.Buy3StrandValueLabel.Text = tradeStrand.BuyStrand3.ToString("N0");
            this.Buy4StrandValueLabel.Text = tradeStrand.BuyStrand4.ToString("N0");
            this.Buy5StrandValueLabel.Text = tradeStrand.BuyStrand5.ToString("N0");

            this.Buy1PriceValueLabel.Text = tradeStrand.BuyPrice1.ToString("N2");
            this.Buy2PriceValueLabel.Text = tradeStrand.BuyPrice2.ToString("N2");
            this.Buy3PriceValueLabel.Text = tradeStrand.BuyPrice3.ToString("N2");
            this.Buy4PriceValueLabel.Text = tradeStrand.BuyPrice4.ToString("N2");
            this.Buy5PriceValueLabel.Text = tradeStrand.BuyPrice5.ToString("N2");

            this.Sell1StrandValueLabel.Text = tradeStrand.SellStrand1.ToString("N0");
            this.Sell2StrandValueLabel.Text = tradeStrand.SellStrand2.ToString("N0");
            this.Sell3StrandValueLabel.Text = tradeStrand.SellStrand3.ToString("N0");
            this.Sell4StrandValueLabel.Text = tradeStrand.SellStrand4.ToString("N0");
            this.Sell5StrandValueLabel.Text = tradeStrand.SellStrand5.ToString("N0");

            this.Sell1PriceValueLabel.Text = tradeStrand.SellPrice1.ToString("N2");
            this.Sell2PriceValueLabel.Text = tradeStrand.SellPrice2.ToString("N2");
            this.Sell3PriceValueLabel.Text = tradeStrand.SellPrice3.ToString("N2");
            this.Sell4PriceValueLabel.Text = tradeStrand.SellPrice4.ToString("N2");
            this.Sell5PriceValueLabel.Text = tradeStrand.SellPrice5.ToString("N2");
        }
    }
}
