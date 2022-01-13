namespace IntelligentInvestor.Client.DockForms
{
    partial class QuotaRepositoryDocumentForm
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            this.QuotaRepositoryToolStrip = new System.Windows.Forms.ToolStrip();
            this.StockInfoToolLabel = new System.Windows.Forms.ToolStripLabel();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.StartTimeToolLabel = new System.Windows.Forms.ToolStripLabel();
            this.EndTimeToolLabel = new System.Windows.Forms.ToolStripLabel();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.QueryToolButton = new System.Windows.Forms.ToolStripButton();
            this.QuotaRepositoryGridView = new System.Windows.Forms.DataGridView();
            this.codeDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.marketDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.openingPriceTodayDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.closingPriceYesterdayDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.QuotaFrequencyComboBox = new System.Windows.Forms.ToolStripComboBox();
            this.currentPriceDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dayHighPriceDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dayLowPriceDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.biddingPriceDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.auctionPriceDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.countDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.amountDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.buyStrand1DataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.buyPrice1DataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.buyStrand2DataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.buyPrice2DataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.buyStrand3DataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.buyPrice3DataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.buyStrand4DataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.buyPrice4DataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.buyStrand5DataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.buyPrice5DataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.sellStrand1DataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.sellPrice1DataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.sellStrand2DataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.sellPrice2DataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.sellStrand3DataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.sellPrice3DataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.sellStrand4DataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.sellPrice4DataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.sellStrand5DataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.sellPrice5DataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.updateTimeDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.QuotaRepositoryBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.QuotaStartDatePicker = new System.Windows.Forms.DateTimePicker();
            this.QuotaEndDatePicker = new System.Windows.Forms.DateTimePicker();
            this.QuotaRepositoryToolStrip.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.QuotaRepositoryGridView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.QuotaRepositoryBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // QuotaRepositoryToolStrip
            // 
            this.QuotaRepositoryToolStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.StockInfoToolLabel,
            this.toolStripSeparator1,
            this.QuotaFrequencyComboBox,
            this.StartTimeToolLabel,
            this.EndTimeToolLabel,
            this.toolStripSeparator2,
            this.QueryToolButton});
            this.QuotaRepositoryToolStrip.Location = new System.Drawing.Point(0, 0);
            this.QuotaRepositoryToolStrip.Name = "QuotaRepositoryToolStrip";
            this.QuotaRepositoryToolStrip.Size = new System.Drawing.Size(562, 25);
            this.QuotaRepositoryToolStrip.TabIndex = 0;
            this.QuotaRepositoryToolStrip.Text = "toolStrip1";
            // 
            // StockInfoToolLabel
            // 
            this.StockInfoToolLabel.Font = new System.Drawing.Font("Microsoft YaHei UI", 10.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.StockInfoToolLabel.Name = "StockInfoToolLabel";
            this.StockInfoToolLabel.Size = new System.Drawing.Size(0, 22);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 25);
            // 
            // StartTimeToolLabel
            // 
            this.StartTimeToolLabel.Name = "StartTimeToolLabel";
            this.StartTimeToolLabel.Size = new System.Drawing.Size(32, 22);
            this.StartTimeToolLabel.Text = "Start";
            // 
            // EndTimeToolLabel
            // 
            this.EndTimeToolLabel.Name = "EndTimeToolLabel";
            this.EndTimeToolLabel.Size = new System.Drawing.Size(32, 22);
            this.EndTimeToolLabel.Text = "End";
            // 
            // QuotaFrequencyComboBox
            // 
            this.QuotaFrequencyComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.QuotaFrequencyComboBox.Name = "QuotaFrequencyComboBox";
            this.QuotaFrequencyComboBox.Size = new System.Drawing.Size(121, 25);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 25);
            // 
            // QueryToolButton
            // 
            this.QueryToolButton.Image = global::IntelligentInvestor.Client.IntelligentInvestorResource.Search;
            this.QueryToolButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.QueryToolButton.Name = "QueryToolButton";
            this.QueryToolButton.Size = new System.Drawing.Size(52, 22);
            this.QueryToolButton.Text = "Query";
            this.QueryToolButton.Click += new System.EventHandler(this.QueryToolButton_Click);
            // 
            // QuotaRepositoryGridView
            // 
            this.QuotaRepositoryGridView.AllowUserToAddRows = false;
            this.QuotaRepositoryGridView.AllowUserToDeleteRows = false;
            this.QuotaRepositoryGridView.AllowUserToOrderColumns = true;
            this.QuotaRepositoryGridView.AllowUserToResizeRows = false;
            this.QuotaRepositoryGridView.AutoGenerateColumns = false;
            this.QuotaRepositoryGridView.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.QuotaRepositoryGridView.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.QuotaRepositoryGridView.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.None;
            this.QuotaRepositoryGridView.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this.QuotaRepositoryGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.QuotaRepositoryGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.codeDataGridViewTextBoxColumn,
            this.marketDataGridViewTextBoxColumn,
            this.currentPriceDataGridViewTextBoxColumn,
            this.updateTimeDataGridViewTextBoxColumn,
            this.openingPriceTodayDataGridViewTextBoxColumn,
            this.closingPriceYesterdayDataGridViewTextBoxColumn,
            this.dayHighPriceDataGridViewTextBoxColumn,
            this.dayLowPriceDataGridViewTextBoxColumn,
            this.biddingPriceDataGridViewTextBoxColumn,
            this.auctionPriceDataGridViewTextBoxColumn,
            this.countDataGridViewTextBoxColumn,
            this.amountDataGridViewTextBoxColumn,
            this.buyStrand1DataGridViewTextBoxColumn,
            this.buyPrice1DataGridViewTextBoxColumn,
            this.buyStrand2DataGridViewTextBoxColumn,
            this.buyPrice2DataGridViewTextBoxColumn,
            this.buyStrand3DataGridViewTextBoxColumn,
            this.buyPrice3DataGridViewTextBoxColumn,
            this.buyStrand4DataGridViewTextBoxColumn,
            this.buyPrice4DataGridViewTextBoxColumn,
            this.buyStrand5DataGridViewTextBoxColumn,
            this.buyPrice5DataGridViewTextBoxColumn,
            this.sellStrand1DataGridViewTextBoxColumn,
            this.sellPrice1DataGridViewTextBoxColumn,
            this.sellStrand2DataGridViewTextBoxColumn,
            this.sellPrice2DataGridViewTextBoxColumn,
            this.sellStrand3DataGridViewTextBoxColumn,
            this.sellPrice3DataGridViewTextBoxColumn,
            this.sellStrand4DataGridViewTextBoxColumn,
            this.sellPrice4DataGridViewTextBoxColumn,
            this.sellStrand5DataGridViewTextBoxColumn,
            this.sellPrice5DataGridViewTextBoxColumn});
            this.QuotaRepositoryGridView.DataSource = this.QuotaRepositoryBindingSource;
            this.QuotaRepositoryGridView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.QuotaRepositoryGridView.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.QuotaRepositoryGridView.Location = new System.Drawing.Point(0, 25);
            this.QuotaRepositoryGridView.Name = "QuotaRepositoryGridView";
            this.QuotaRepositoryGridView.ReadOnly = true;
            this.QuotaRepositoryGridView.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this.QuotaRepositoryGridView.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.QuotaRepositoryGridView.RowTemplate.Height = 23;
            this.QuotaRepositoryGridView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.QuotaRepositoryGridView.Size = new System.Drawing.Size(562, 377);
            this.QuotaRepositoryGridView.TabIndex = 1;
            // 
            // codeDataGridViewTextBoxColumn
            // 
            this.codeDataGridViewTextBoxColumn.DataPropertyName = nameof(IntelligentInvestor.Domain.Stocks.StockBase.StockCode);
            this.codeDataGridViewTextBoxColumn.Frozen = true;
            this.codeDataGridViewTextBoxColumn.HeaderText = "Code";
            this.codeDataGridViewTextBoxColumn.Name = "codeDataGridViewTextBoxColumn";
            this.codeDataGridViewTextBoxColumn.ReadOnly = true;
            this.codeDataGridViewTextBoxColumn.Width = 51;
            // 
            // marketDataGridViewTextBoxColumn
            // 
            this.marketDataGridViewTextBoxColumn.DataPropertyName = nameof(IntelligentInvestor.Domain.Stocks.StockBase.StockMarket);
            this.marketDataGridViewTextBoxColumn.Frozen = true;
            this.marketDataGridViewTextBoxColumn.HeaderText = "Market";
            this.marketDataGridViewTextBoxColumn.Name = "marketDataGridViewTextBoxColumn";
            this.marketDataGridViewTextBoxColumn.ReadOnly = true;
            this.marketDataGridViewTextBoxColumn.Width = 51;
            // 
            // currentPriceDataGridViewTextBoxColumn
            // 
            this.currentPriceDataGridViewTextBoxColumn.DataPropertyName = nameof(IntelligentInvestor.Domain.Quotas.Quota.CurrentPrice);
            this.currentPriceDataGridViewTextBoxColumn.Frozen = true;
            this.currentPriceDataGridViewTextBoxColumn.HeaderText = "Current Price";
            this.currentPriceDataGridViewTextBoxColumn.Name = "currentPriceDataGridViewTextBoxColumn";
            this.currentPriceDataGridViewTextBoxColumn.ReadOnly = true;
            this.currentPriceDataGridViewTextBoxColumn.Width = 72;
            // 
            // updateTimeDataGridViewTextBoxColumn
            // 
            this.updateTimeDataGridViewTextBoxColumn.DataPropertyName = nameof(IntelligentInvestor.Domain.Quotas.QuotaBase.QuotaTime);
            dataGridViewCellStyle1.Format = "yyyy-MM-dd HH:mm:ss";
            this.updateTimeDataGridViewTextBoxColumn.Frozen = true;
            this.updateTimeDataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle1;
            this.updateTimeDataGridViewTextBoxColumn.HeaderText = "Quota Time";
            this.updateTimeDataGridViewTextBoxColumn.Name = "updateTimeDataGridViewTextBoxColumn";
            this.updateTimeDataGridViewTextBoxColumn.ReadOnly = true;
            this.updateTimeDataGridViewTextBoxColumn.Width = 61;
            // 
            // openingPriceTodayDataGridViewTextBoxColumn
            // 
            this.openingPriceTodayDataGridViewTextBoxColumn.DataPropertyName = nameof(IntelligentInvestor.Domain.Quotas.Quota.OpenningPrice);
            this.openingPriceTodayDataGridViewTextBoxColumn.HeaderText = "Open Price";
            this.openingPriceTodayDataGridViewTextBoxColumn.Name = "openingPriceTodayDataGridViewTextBoxColumn";
            this.openingPriceTodayDataGridViewTextBoxColumn.ReadOnly = true;
            this.openingPriceTodayDataGridViewTextBoxColumn.Width = 88;
            // 
            // closingPriceYesterdayDataGridViewTextBoxColumn
            // 
            this.closingPriceYesterdayDataGridViewTextBoxColumn.DataPropertyName = nameof(IntelligentInvestor.Domain.Quotas.Quota.ClosingPriceYesterday);
            this.closingPriceYesterdayDataGridViewTextBoxColumn.HeaderText = "Close Price Yst";
            this.closingPriceYesterdayDataGridViewTextBoxColumn.Name = "closingPriceYesterdayDataGridViewTextBoxColumn";
            this.closingPriceYesterdayDataGridViewTextBoxColumn.ReadOnly = true;
            this.closingPriceYesterdayDataGridViewTextBoxColumn.Width = 88;
            // 
            // dayHighPriceDataGridViewTextBoxColumn
            // 
            this.dayHighPriceDataGridViewTextBoxColumn.DataPropertyName = nameof(IntelligentInvestor.Domain.Quotas.Quota.HighestPrice);
            this.dayHighPriceDataGridViewTextBoxColumn.HeaderText = "Highest Price";
            this.dayHighPriceDataGridViewTextBoxColumn.Name = "dayHighPriceDataGridViewTextBoxColumn";
            this.dayHighPriceDataGridViewTextBoxColumn.ReadOnly = true;
            this.dayHighPriceDataGridViewTextBoxColumn.Width = 88;
            // 
            // dayLowPriceDataGridViewTextBoxColumn
            // 
            this.dayLowPriceDataGridViewTextBoxColumn.DataPropertyName = nameof(IntelligentInvestor.Domain.Quotas.Quota.LowestPrice);
            this.dayLowPriceDataGridViewTextBoxColumn.HeaderText = "Lowest Price";
            this.dayLowPriceDataGridViewTextBoxColumn.Name = "dayLowPriceDataGridViewTextBoxColumn";
            this.dayLowPriceDataGridViewTextBoxColumn.ReadOnly = true;
            this.dayLowPriceDataGridViewTextBoxColumn.Width = 88;
            // 
            // biddingPriceDataGridViewTextBoxColumn
            // 
            this.biddingPriceDataGridViewTextBoxColumn.DataPropertyName = nameof(IntelligentInvestor.Domain.Trades.TradeStrand.BiddingPrice);
            this.biddingPriceDataGridViewTextBoxColumn.HeaderText = "Bidding Price";
            this.biddingPriceDataGridViewTextBoxColumn.Name = "biddingPriceDataGridViewTextBoxColumn";
            this.biddingPriceDataGridViewTextBoxColumn.ReadOnly = true;
            this.biddingPriceDataGridViewTextBoxColumn.Width = 67;
            // 
            // auctionPriceDataGridViewTextBoxColumn
            // 
            this.auctionPriceDataGridViewTextBoxColumn.DataPropertyName = nameof(IntelligentInvestor.Domain.Trades.TradeStrand.AuctionPrice);
            this.auctionPriceDataGridViewTextBoxColumn.HeaderText = "Auction Price";
            this.auctionPriceDataGridViewTextBoxColumn.Name = "auctionPriceDataGridViewTextBoxColumn";
            this.auctionPriceDataGridViewTextBoxColumn.ReadOnly = true;
            this.auctionPriceDataGridViewTextBoxColumn.Width = 67;
            // 
            // countDataGridViewTextBoxColumn
            // 
            this.countDataGridViewTextBoxColumn.DataPropertyName = nameof(IntelligentInvestor.Domain.Quotas.Quota.Volume);
            this.countDataGridViewTextBoxColumn.HeaderText = "Volume";
            this.countDataGridViewTextBoxColumn.Name = "countDataGridViewTextBoxColumn";
            this.countDataGridViewTextBoxColumn.ReadOnly = true;
            this.countDataGridViewTextBoxColumn.Width = 72;
            // 
            // amountDataGridViewTextBoxColumn
            // 
            this.amountDataGridViewTextBoxColumn.DataPropertyName = nameof(IntelligentInvestor.Domain.Quotas.Quota.Amount);
            this.amountDataGridViewTextBoxColumn.HeaderText = "Amount";
            this.amountDataGridViewTextBoxColumn.Name = "amountDataGridViewTextBoxColumn";
            this.amountDataGridViewTextBoxColumn.ReadOnly = true;
            this.amountDataGridViewTextBoxColumn.Width = 72;
            // 
            // buyStrand1DataGridViewTextBoxColumn
            // 
            this.buyStrand1DataGridViewTextBoxColumn.DataPropertyName = "BuyStrand1";
            this.buyStrand1DataGridViewTextBoxColumn.HeaderText = "Buy Strand 1";
            this.buyStrand1DataGridViewTextBoxColumn.Name = "buyStrand1DataGridViewTextBoxColumn";
            this.buyStrand1DataGridViewTextBoxColumn.ReadOnly = true;
            this.buyStrand1DataGridViewTextBoxColumn.Width = 67;
            // 
            // buyPrice1DataGridViewTextBoxColumn
            // 
            this.buyPrice1DataGridViewTextBoxColumn.DataPropertyName = "BuyPrice1";
            this.buyPrice1DataGridViewTextBoxColumn.HeaderText = "Buy Price 1";
            this.buyPrice1DataGridViewTextBoxColumn.Name = "buyPrice1DataGridViewTextBoxColumn";
            this.buyPrice1DataGridViewTextBoxColumn.ReadOnly = true;
            this.buyPrice1DataGridViewTextBoxColumn.Width = 67;
            // 
            // buyStrand2DataGridViewTextBoxColumn
            // 
            this.buyStrand2DataGridViewTextBoxColumn.DataPropertyName = "BuyStrand2";
            this.buyStrand2DataGridViewTextBoxColumn.HeaderText = "Buy Strand 2";
            this.buyStrand2DataGridViewTextBoxColumn.Name = "buyStrand2DataGridViewTextBoxColumn";
            this.buyStrand2DataGridViewTextBoxColumn.ReadOnly = true;
            this.buyStrand2DataGridViewTextBoxColumn.Width = 67;
            // 
            // buyPrice2DataGridViewTextBoxColumn
            // 
            this.buyPrice2DataGridViewTextBoxColumn.DataPropertyName = "BuyPrice2";
            this.buyPrice2DataGridViewTextBoxColumn.HeaderText = "Buy Price 2";
            this.buyPrice2DataGridViewTextBoxColumn.Name = "buyPrice2DataGridViewTextBoxColumn";
            this.buyPrice2DataGridViewTextBoxColumn.ReadOnly = true;
            this.buyPrice2DataGridViewTextBoxColumn.Width = 67;
            // 
            // buyStrand3DataGridViewTextBoxColumn
            // 
            this.buyStrand3DataGridViewTextBoxColumn.DataPropertyName = "BuyStrand3";
            this.buyStrand3DataGridViewTextBoxColumn.HeaderText = "Buy Strand 3";
            this.buyStrand3DataGridViewTextBoxColumn.Name = "buyStrand3DataGridViewTextBoxColumn";
            this.buyStrand3DataGridViewTextBoxColumn.ReadOnly = true;
            this.buyStrand3DataGridViewTextBoxColumn.Width = 67;
            // 
            // buyPrice3DataGridViewTextBoxColumn
            // 
            this.buyPrice3DataGridViewTextBoxColumn.DataPropertyName = "BuyPrice3";
            this.buyPrice3DataGridViewTextBoxColumn.HeaderText = "Buy Price 3";
            this.buyPrice3DataGridViewTextBoxColumn.Name = "buyPrice3DataGridViewTextBoxColumn";
            this.buyPrice3DataGridViewTextBoxColumn.ReadOnly = true;
            this.buyPrice3DataGridViewTextBoxColumn.Width = 67;
            // 
            // buyStrand4DataGridViewTextBoxColumn
            // 
            this.buyStrand4DataGridViewTextBoxColumn.DataPropertyName = "BuyStrand4";
            this.buyStrand4DataGridViewTextBoxColumn.HeaderText = "Buy Strand 4";
            this.buyStrand4DataGridViewTextBoxColumn.Name = "buyStrand4DataGridViewTextBoxColumn";
            this.buyStrand4DataGridViewTextBoxColumn.ReadOnly = true;
            this.buyStrand4DataGridViewTextBoxColumn.Width = 67;
            // 
            // buyPrice4DataGridViewTextBoxColumn
            // 
            this.buyPrice4DataGridViewTextBoxColumn.DataPropertyName = "BuyPrice4";
            this.buyPrice4DataGridViewTextBoxColumn.HeaderText = "Buy Price 4";
            this.buyPrice4DataGridViewTextBoxColumn.Name = "buyPrice4DataGridViewTextBoxColumn";
            this.buyPrice4DataGridViewTextBoxColumn.ReadOnly = true;
            this.buyPrice4DataGridViewTextBoxColumn.Width = 67;
            // 
            // buyStrand5DataGridViewTextBoxColumn
            // 
            this.buyStrand5DataGridViewTextBoxColumn.DataPropertyName = "BuyStrand5";
            this.buyStrand5DataGridViewTextBoxColumn.HeaderText = "Buy Strand 5";
            this.buyStrand5DataGridViewTextBoxColumn.Name = "buyStrand5DataGridViewTextBoxColumn";
            this.buyStrand5DataGridViewTextBoxColumn.ReadOnly = true;
            this.buyStrand5DataGridViewTextBoxColumn.Width = 67;
            // 
            // buyPrice5DataGridViewTextBoxColumn
            // 
            this.buyPrice5DataGridViewTextBoxColumn.DataPropertyName = "BuyPrice5";
            this.buyPrice5DataGridViewTextBoxColumn.HeaderText = "Buy Price 5";
            this.buyPrice5DataGridViewTextBoxColumn.Name = "buyPrice5DataGridViewTextBoxColumn";
            this.buyPrice5DataGridViewTextBoxColumn.ReadOnly = true;
            this.buyPrice5DataGridViewTextBoxColumn.Width = 67;
            // 
            // sellStrand1DataGridViewTextBoxColumn
            // 
            this.sellStrand1DataGridViewTextBoxColumn.DataPropertyName = "SellStrand1";
            this.sellStrand1DataGridViewTextBoxColumn.HeaderText = "Sell Strand 1";
            this.sellStrand1DataGridViewTextBoxColumn.Name = "sellStrand1DataGridViewTextBoxColumn";
            this.sellStrand1DataGridViewTextBoxColumn.ReadOnly = true;
            this.sellStrand1DataGridViewTextBoxColumn.Width = 67;
            // 
            // sellPrice1DataGridViewTextBoxColumn
            // 
            this.sellPrice1DataGridViewTextBoxColumn.DataPropertyName = "SellPrice1";
            this.sellPrice1DataGridViewTextBoxColumn.HeaderText = "Sell Price 1";
            this.sellPrice1DataGridViewTextBoxColumn.Name = "sellPrice1DataGridViewTextBoxColumn";
            this.sellPrice1DataGridViewTextBoxColumn.ReadOnly = true;
            this.sellPrice1DataGridViewTextBoxColumn.Width = 67;
            // 
            // sellStrand2DataGridViewTextBoxColumn
            // 
            this.sellStrand2DataGridViewTextBoxColumn.DataPropertyName = "SellStrand2";
            this.sellStrand2DataGridViewTextBoxColumn.HeaderText = "Sell Strand 2";
            this.sellStrand2DataGridViewTextBoxColumn.Name = "sellStrand2DataGridViewTextBoxColumn";
            this.sellStrand2DataGridViewTextBoxColumn.ReadOnly = true;
            this.sellStrand2DataGridViewTextBoxColumn.Width = 67;
            // 
            // sellPrice2DataGridViewTextBoxColumn
            // 
            this.sellPrice2DataGridViewTextBoxColumn.DataPropertyName = "SellPrice2";
            this.sellPrice2DataGridViewTextBoxColumn.HeaderText = "Sell Price 2";
            this.sellPrice2DataGridViewTextBoxColumn.Name = "sellPrice2DataGridViewTextBoxColumn";
            this.sellPrice2DataGridViewTextBoxColumn.ReadOnly = true;
            this.sellPrice2DataGridViewTextBoxColumn.Width = 67;
            // 
            // sellStrand3DataGridViewTextBoxColumn
            // 
            this.sellStrand3DataGridViewTextBoxColumn.DataPropertyName = "SellStrand3";
            this.sellStrand3DataGridViewTextBoxColumn.HeaderText = "Sell Strand 3";
            this.sellStrand3DataGridViewTextBoxColumn.Name = "sellStrand3DataGridViewTextBoxColumn";
            this.sellStrand3DataGridViewTextBoxColumn.ReadOnly = true;
            this.sellStrand3DataGridViewTextBoxColumn.Width = 67;
            // 
            // sellPrice3DataGridViewTextBoxColumn
            // 
            this.sellPrice3DataGridViewTextBoxColumn.DataPropertyName = "SellPrice3";
            this.sellPrice3DataGridViewTextBoxColumn.HeaderText = "Sell Price 3";
            this.sellPrice3DataGridViewTextBoxColumn.Name = "sellPrice3DataGridViewTextBoxColumn";
            this.sellPrice3DataGridViewTextBoxColumn.ReadOnly = true;
            this.sellPrice3DataGridViewTextBoxColumn.Width = 67;
            // 
            // sellStrand4DataGridViewTextBoxColumn
            // 
            this.sellStrand4DataGridViewTextBoxColumn.DataPropertyName = "SellStrand4";
            this.sellStrand4DataGridViewTextBoxColumn.HeaderText = "Sell Strand 4";
            this.sellStrand4DataGridViewTextBoxColumn.Name = "sellStrand4DataGridViewTextBoxColumn";
            this.sellStrand4DataGridViewTextBoxColumn.ReadOnly = true;
            this.sellStrand4DataGridViewTextBoxColumn.Width = 67;
            // 
            // sellPrice4DataGridViewTextBoxColumn
            // 
            this.sellPrice4DataGridViewTextBoxColumn.DataPropertyName = "SellPrice4";
            this.sellPrice4DataGridViewTextBoxColumn.HeaderText = "Sell Price 4";
            this.sellPrice4DataGridViewTextBoxColumn.Name = "sellPrice4DataGridViewTextBoxColumn";
            this.sellPrice4DataGridViewTextBoxColumn.ReadOnly = true;
            this.sellPrice4DataGridViewTextBoxColumn.Width = 67;
            // 
            // sellStrand5DataGridViewTextBoxColumn
            // 
            this.sellStrand5DataGridViewTextBoxColumn.DataPropertyName = "SellStrand5";
            this.sellStrand5DataGridViewTextBoxColumn.HeaderText = "Sell Strand 5";
            this.sellStrand5DataGridViewTextBoxColumn.Name = "sellStrand5DataGridViewTextBoxColumn";
            this.sellStrand5DataGridViewTextBoxColumn.ReadOnly = true;
            this.sellStrand5DataGridViewTextBoxColumn.Width = 67;
            // 
            // sellPrice5DataGridViewTextBoxColumn
            // 
            this.sellPrice5DataGridViewTextBoxColumn.DataPropertyName = "SellPrice5";
            this.sellPrice5DataGridViewTextBoxColumn.HeaderText = "Sell Price 5";
            this.sellPrice5DataGridViewTextBoxColumn.Name = "sellPrice5DataGridViewTextBoxColumn";
            this.sellPrice5DataGridViewTextBoxColumn.ReadOnly = true;
            this.sellPrice5DataGridViewTextBoxColumn.Width = 67;
            // 
            // QuotaRepositoryBindingSource
            // 
            this.QuotaRepositoryBindingSource.DataSource = typeof(IntelligentInvestor.Domain.Quotas.Quota);
            // 
            // QuotaStartDatePicker
            // 
            this.QuotaStartDatePicker.CalendarFont = new System.Drawing.Font("Microsoft YaHei UI", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.QuotaStartDatePicker.Font = new System.Drawing.Font("Microsoft YaHei UI", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.QuotaStartDatePicker.Location = new System.Drawing.Point(94, 166);
            this.QuotaStartDatePicker.Margin = new System.Windows.Forms.Padding(0);
            this.QuotaStartDatePicker.Name = "QuotaStartDatePicker";
            this.QuotaStartDatePicker.ShowCheckBox = true;
            this.QuotaStartDatePicker.Size = new System.Drawing.Size(173, 26);
            this.QuotaStartDatePicker.TabIndex = 2;
            // 
            // QuotaEndDatePicker
            // 
            this.QuotaEndDatePicker.CalendarFont = new System.Drawing.Font("Microsoft YaHei UI", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.QuotaEndDatePicker.Font = new System.Drawing.Font("Microsoft YaHei UI", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.QuotaEndDatePicker.Location = new System.Drawing.Point(281, 166);
            this.QuotaEndDatePicker.Margin = new System.Windows.Forms.Padding(0);
            this.QuotaEndDatePicker.Name = "QuotaEndDatePicker";
            this.QuotaEndDatePicker.ShowCheckBox = true;
            this.QuotaEndDatePicker.Size = new System.Drawing.Size(173, 26);
            this.QuotaEndDatePicker.TabIndex = 3;
            // 
            // QuotaRepositoryDockForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(562, 402);
            this.Controls.Add(this.QuotaEndDatePicker);
            this.Controls.Add(this.QuotaStartDatePicker);
            this.Controls.Add(this.QuotaRepositoryGridView);
            this.Controls.Add(this.QuotaRepositoryToolStrip);
            this.Name = "QuotaRepositoryDockForm";
            this.TabText = "Quota Repository";
            this.Text = "Quota Repository";
            this.Load += new System.EventHandler(this.QuotaRepositoryDockForm_Load);
            this.Shown += new System.EventHandler(this.QuotaRepositoryDockForm_Shown);
            this.QuotaRepositoryToolStrip.ResumeLayout(false);
            this.QuotaRepositoryToolStrip.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.QuotaRepositoryGridView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.QuotaRepositoryBindingSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        private System.Windows.Forms.ToolStrip QuotaRepositoryToolStrip;
        private System.Windows.Forms.DataGridView QuotaRepositoryGridView;
        private System.Windows.Forms.BindingSource QuotaRepositoryBindingSource;
        private System.Windows.Forms.DateTimePicker QuotaStartDatePicker;
        private System.Windows.Forms.DateTimePicker QuotaEndDatePicker;
        private System.Windows.Forms.ToolStripLabel StockInfoToolLabel;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripLabel StartTimeToolLabel;
        private System.Windows.Forms.ToolStripLabel EndTimeToolLabel;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripButton QueryToolButton;
        private System.Windows.Forms.DataGridViewTextBoxColumn codeDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn marketDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn openingPriceTodayDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn closingPriceYesterdayDataGridViewTextBoxColumn;
        private System.Windows.Forms.ToolStripComboBox QuotaFrequencyComboBox;
        private System.Windows.Forms.DataGridViewTextBoxColumn currentPriceDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn dayHighPriceDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn dayLowPriceDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn biddingPriceDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn auctionPriceDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn countDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn amountDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn buyStrand1DataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn buyPrice1DataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn buyStrand2DataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn buyPrice2DataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn buyStrand3DataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn buyPrice3DataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn buyStrand4DataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn buyPrice4DataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn buyStrand5DataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn buyPrice5DataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn sellStrand1DataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn sellPrice1DataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn sellStrand2DataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn sellPrice2DataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn sellStrand3DataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn sellPrice3DataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn sellStrand4DataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn sellPrice4DataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn sellStrand5DataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn sellPrice5DataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn updateTimeDataGridViewTextBoxColumn;
    }
}