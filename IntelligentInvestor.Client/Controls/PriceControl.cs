namespace IntelligentInvestor.Client.Controls;

public class PriceControl : Label
{
    private Color staticForecolor = Color.Black;
    private Color riseForeColor = Color.Crimson;
    private Color fallForeColor = Color.LimeGreen;
    private byte accuracy = 4;
    private string priceFormat = "N4";
    private decimal? lastPrice;
    private decimal? basePrice;
    private decimal? price;

    public PriceControl()
    {
        this.AutoEllipsis = true;
        this.Dock = DockStyle.Fill;
        this.Font = new Font("Microsoft YaHei UI", 20F, FontStyle.Bold);
        this.ImageAlign = ContentAlignment.MiddleLeft;
        this.Margin = new Padding(0);
        this.Text = "-";
        this.TextAlign = ContentAlignment.MiddleCenter;

        this.ImageList = new ImageList();
        this.ImageList.Images.Add(IntelligentInvestorResource.StaticStatus);
        this.ImageList.Images.Add(IntelligentInvestorResource.UpArrow);
        this.ImageList.Images.Add(IntelligentInvestorResource.DownArrow);
        this.ImageIndex = 0;
    }

    public Color StaticForecolor
    {
        get => this.staticForecolor;
        set
        {
            if (this.staticForecolor != value)
            {
                this.staticForecolor = value;
                this.RefreshPrice();
            }
        }
    }

    public Color RiseForeColor
    {
        get => this.riseForeColor;
        set
        {
            if (this.riseForeColor != value)
            {
                this.riseForeColor = value;
                this.RefreshPrice();
            }
        }
    }

    public Color FallForeColor
    {
        get => this.fallForeColor;
        set
        {
            if (this.fallForeColor != value)
            {
                this.fallForeColor = value;
                this.RefreshPrice();
            }
        }
    }

    public byte Accuracy
    {
        get => this.accuracy;
        set
        {
            value = Math.Max((byte)0, value);

            if (this.accuracy != value)
            {
                this.accuracy = value;
                this.priceFormat = $"N{value}";
                this.RefreshPrice();
            }
        }
    }

    public decimal? BasePrice
    {
        get => this.basePrice;
        set
        {
            if (this.basePrice != value)
            {
                this.basePrice = value;
                this.RefreshPrice();
            }
        }
    }

    public decimal? Price
    {
        get => this.price;
        set
        {
            this.lastPrice = this.price;
            this.price = value;
            this.RefreshPrice();
        }
    }

    public void ClearPrice()
    {
        this.lastPrice = null;
        this.price = decimal.Zero;

        this.RefreshPrice();
    }

    public void RefreshPrice()
    {
        if (this.Price.HasValue)
        {
            this.Text = this.Price.Value.ToString(this.priceFormat);
            this.ForeColor = this.Price > this.BasePrice ? this.RiseForeColor : this.Price < this.BasePrice ? this.FallForeColor : this.StaticForecolor;
            this.ImageIndex = this.lastPrice.HasValue ? this.Price > this.lastPrice ? 1 : this.Price < this.lastPrice ? 2 : 0 : 0;
        }
        else
        {
            this.Text = "-";
            this.ForeColor = this.StaticForecolor;
            this.ImageIndex = 0;
        }
    }
}
