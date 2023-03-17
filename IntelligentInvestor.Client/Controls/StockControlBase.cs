using System.ComponentModel;
using IntelligentInvestor.Client.Extensions;
using IntelligentInvestor.Domain.Comparers;
using IntelligentInvestor.Domain.Stocks;

namespace IntelligentInvestor.Client.Controls;

public class StockControlBase : UserControl
{
    public StockControlBase() : base()
    {
    }

    protected readonly StockBaseComparer<Stock> StockComparer = new();

    private Color labelForecolor;

    [Browsable(true)]
    public virtual Color LabelForecolor
    {
        get => this.labelForecolor;
        set
        {
            this.labelForecolor = value;

            _ = this.InvokeIfRequired<ValueType, Action<Color>>(this.SetLabelForecolor, value);
        }
    }

    private Color valueForecolor;

    [Browsable(true)]
    public virtual Color ValueForecolor
    {
        get => this.valueForecolor;
        set
        {
            this.valueForecolor = value;

            _ = this.InvokeIfRequired<ValueType, Action<Color>>(this.SetValueForecolor, value);
        }
    }

    private Stock stock;

    [Browsable(false)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public virtual Stock Stock
    {
        get => this.stock;
        set
        {
            if (!this.StockComparer.Equals(this.stock, value))
            {
                this.stock = value;

                _ = this.InvokeIfRequired<ValueType, Action<Stock>>(this.StockToFace, value);
            }
        }
    }

    public virtual void SetLabelForecolor(Color obj)
    {
    }

    public virtual void SetValueForecolor(Color obj)
    {
    }

    public virtual void StockToFace(Stock obj)
    {
    }

    public virtual void EntityToFace(StockBase? entity)
    {
    }
}
