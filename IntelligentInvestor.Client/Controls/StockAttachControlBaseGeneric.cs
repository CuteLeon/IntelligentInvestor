using System.ComponentModel;
using IntelligentInvestor.Client.Extensions;
using IntelligentInvestor.Domain.Comparers;
using IntelligentInvestor.Domain.Stocks;

namespace IntelligentInvestor.Client.Controls
{
    public class StockAttachControlBaseGeneric<TAttachEntity> : UserControl, IStockAttachControlBaseGeneric<TAttachEntity>
        where TAttachEntity : StockBase
    {
        public StockAttachControlBaseGeneric() : base()
        {
        }

        protected readonly StockBaseComparer<Stock> StockComparer = new StockBaseComparer<Stock>();

        private Color labelForecolor;

        [Browsable(true)]
        public virtual Color LabelForecolor
        {
            get => this.labelForecolor;
            set
            {
                this.labelForecolor = value;

                this.InvokeIfRequired<ValueType, Action<Color>>(this.SetLabelForecolor, value);
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

                this.InvokeIfRequired<ValueType, Action<Color>>(this.SetValueForecolor, value);
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

                    this.InvokeIfRequired<ValueType, Action<Stock>>(this.StockToFace, value);
                }
            }
        }

        private TAttachEntity attachEntity;

        [Browsable(false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual TAttachEntity AttachEntity
        {
            get => this.attachEntity;
            set
            {
                this.attachEntity = value;

                this.InvokeIfRequired<ValueType, Action<TAttachEntity>>(this.AttachEntityToFace, value);
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

        public virtual void AttachEntityToFace(TAttachEntity entity)
        {
        }
    }
}
