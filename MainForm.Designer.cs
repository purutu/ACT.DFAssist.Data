namespace ACT.DFAssist.Data
{
	partial class MainForm
	{
		/// <summary>
		/// 필수 디자이너 변수입니다.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		/// 사용 중인 모든 리소스를 정리합니다.
		/// </summary>
		/// <param name="disposing">관리되는 리소스를 삭제해야 하면 true이고, 그렇지 않으면 false입니다.</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing && (components != null))
			{
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		#region Windows Form 디자이너에서 생성한 코드

		/// <summary>
		/// 디자이너 지원에 필요한 메서드입니다. 
		/// 이 메서드의 내용을 코드 편집기로 수정하지 마세요.
		/// </summary>
		private void InitializeComponent()
		{
			this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
			this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
			this.txtResult = new System.Windows.Forms.TextBox();
			this.btnReadGameData = new System.Windows.Forms.Button();
			this.btnSave = new System.Windows.Forms.Button();
			this.btmOpenDb = new System.Windows.Forms.Button();
			this.lstLang = new System.Windows.Forms.ListBox();
			this.prgWorking = new System.Windows.Forms.ProgressBar();
			this.tableLayoutPanel3 = new System.Windows.Forms.TableLayoutPanel();
			this.btnQueryInstance = new System.Windows.Forms.Button();
			this.btnTest = new System.Windows.Forms.Button();
			this.btnQueryRoulette = new System.Windows.Forms.Button();
			this.btnQueryArea = new System.Windows.Forms.Button();
			this.btnQueryFate = new System.Windows.Forms.Button();
			this.dgvQuery = new System.Windows.Forms.DataGridView();
			this.tableLayoutPanel1.SuspendLayout();
			this.tableLayoutPanel2.SuspendLayout();
			this.tableLayoutPanel3.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.dgvQuery)).BeginInit();
			this.SuspendLayout();
			// 
			// tableLayoutPanel1
			// 
			this.tableLayoutPanel1.ColumnCount = 1;
			this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
			this.tableLayoutPanel1.Controls.Add(this.tableLayoutPanel2, 0, 0);
			this.tableLayoutPanel1.Controls.Add(this.prgWorking, 0, 1);
			this.tableLayoutPanel1.Controls.Add(this.tableLayoutPanel3, 0, 2);
			this.tableLayoutPanel1.Controls.Add(this.dgvQuery, 0, 3);
			this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
			this.tableLayoutPanel1.Name = "tableLayoutPanel1";
			this.tableLayoutPanel1.RowCount = 4;
			this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 90F));
			this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
			this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 50F));
			this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
			this.tableLayoutPanel1.Size = new System.Drawing.Size(787, 591);
			this.tableLayoutPanel1.TabIndex = 1;
			// 
			// tableLayoutPanel2
			// 
			this.tableLayoutPanel2.ColumnCount = 8;
			this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
			this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
			this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
			this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
			this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
			this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 80F));
			this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
			this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
			this.tableLayoutPanel2.Controls.Add(this.txtResult, 6, 0);
			this.tableLayoutPanel2.Controls.Add(this.btnReadGameData, 3, 0);
			this.tableLayoutPanel2.Controls.Add(this.btnSave, 2, 0);
			this.tableLayoutPanel2.Controls.Add(this.btmOpenDb, 0, 0);
			this.tableLayoutPanel2.Controls.Add(this.lstLang, 5, 0);
			this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
			this.tableLayoutPanel2.Location = new System.Drawing.Point(3, 3);
			this.tableLayoutPanel2.Name = "tableLayoutPanel2";
			this.tableLayoutPanel2.RowCount = 1;
			this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
			this.tableLayoutPanel2.Size = new System.Drawing.Size(781, 84);
			this.tableLayoutPanel2.TabIndex = 1;
			// 
			// txtResult
			// 
			this.txtResult.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.txtResult.BackColor = System.Drawing.Color.AntiqueWhite;
			this.txtResult.Location = new System.Drawing.Point(438, 3);
			this.txtResult.Multiline = true;
			this.txtResult.Name = "txtResult";
			this.txtResult.ReadOnly = true;
			this.txtResult.Size = new System.Drawing.Size(213, 78);
			this.txtResult.TabIndex = 4;
			// 
			// btnReadGameData
			// 
			this.btnReadGameData.Location = new System.Drawing.Point(228, 3);
			this.btnReadGameData.Name = "btnReadGameData";
			this.btnReadGameData.Size = new System.Drawing.Size(104, 78);
			this.btnReadGameData.TabIndex = 3;
			this.btnReadGameData.Text = "데이터\r\n가져오기";
			this.btnReadGameData.UseVisualStyleBackColor = true;
			this.btnReadGameData.Click += new System.EventHandler(this.btnReadGameData_Click);
			// 
			// btnSave
			// 
			this.btnSave.Location = new System.Drawing.Point(127, 3);
			this.btnSave.Name = "btnSave";
			this.btnSave.Size = new System.Drawing.Size(95, 78);
			this.btnSave.TabIndex = 1;
			this.btnSave.Text = "내보내기";
			this.btnSave.UseVisualStyleBackColor = true;
			this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
			// 
			// btmOpenDb
			// 
			this.btmOpenDb.Enabled = false;
			this.btmOpenDb.Location = new System.Drawing.Point(3, 3);
			this.btmOpenDb.Name = "btmOpenDb";
			this.btmOpenDb.Size = new System.Drawing.Size(98, 78);
			this.btmOpenDb.TabIndex = 5;
			this.btmOpenDb.Text = "열기\r\n(자동으로 만듦)\r\n";
			this.btmOpenDb.UseVisualStyleBackColor = true;
			// 
			// lstLang
			// 
			this.lstLang.Dock = System.Windows.Forms.DockStyle.Top;
			this.lstLang.FormattingEnabled = true;
			this.lstLang.Items.AddRange(new object[] {
            "en",
            "ja",
            "ko",
            "fr",
            "de"});
			this.lstLang.Location = new System.Drawing.Point(358, 3);
			this.lstLang.Name = "lstLang";
			this.lstLang.Size = new System.Drawing.Size(74, 69);
			this.lstLang.TabIndex = 6;
			// 
			// prgWorking
			// 
			this.prgWorking.Dock = System.Windows.Forms.DockStyle.Fill;
			this.prgWorking.Location = new System.Drawing.Point(3, 93);
			this.prgWorking.Name = "prgWorking";
			this.prgWorking.Size = new System.Drawing.Size(781, 24);
			this.prgWorking.TabIndex = 2;
			// 
			// tableLayoutPanel3
			// 
			this.tableLayoutPanel3.ColumnCount = 5;
			this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 80F));
			this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 80F));
			this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 80F));
			this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 80F));
			this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
			this.tableLayoutPanel3.Controls.Add(this.btnQueryInstance, 0, 0);
			this.tableLayoutPanel3.Controls.Add(this.btnTest, 4, 0);
			this.tableLayoutPanel3.Controls.Add(this.btnQueryRoulette, 1, 0);
			this.tableLayoutPanel3.Controls.Add(this.btnQueryArea, 2, 0);
			this.tableLayoutPanel3.Controls.Add(this.btnQueryFate, 3, 0);
			this.tableLayoutPanel3.Dock = System.Windows.Forms.DockStyle.Fill;
			this.tableLayoutPanel3.Location = new System.Drawing.Point(3, 123);
			this.tableLayoutPanel3.Name = "tableLayoutPanel3";
			this.tableLayoutPanel3.RowCount = 1;
			this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
			this.tableLayoutPanel3.Size = new System.Drawing.Size(781, 44);
			this.tableLayoutPanel3.TabIndex = 3;
			// 
			// btnQueryInstance
			// 
			this.btnQueryInstance.Dock = System.Windows.Forms.DockStyle.Fill;
			this.btnQueryInstance.Location = new System.Drawing.Point(3, 3);
			this.btnQueryInstance.Name = "btnQueryInstance";
			this.btnQueryInstance.Size = new System.Drawing.Size(74, 38);
			this.btnQueryInstance.TabIndex = 0;
			this.btnQueryInstance.Text = "Instance";
			this.btnQueryInstance.UseVisualStyleBackColor = true;
			this.btnQueryInstance.Click += new System.EventHandler(this.btnQueryInstance_Click);
			// 
			// btnTest
			// 
			this.btnTest.Location = new System.Drawing.Point(323, 3);
			this.btnTest.Name = "btnTest";
			this.btnTest.Size = new System.Drawing.Size(63, 38);
			this.btnTest.TabIndex = 2;
			this.btnTest.Text = "이거슨 테스트!";
			this.btnTest.UseVisualStyleBackColor = true;
			this.btnTest.Click += new System.EventHandler(this.btnTest_Click);
			// 
			// btnQueryRoulette
			// 
			this.btnQueryRoulette.Dock = System.Windows.Forms.DockStyle.Fill;
			this.btnQueryRoulette.Location = new System.Drawing.Point(83, 3);
			this.btnQueryRoulette.Name = "btnQueryRoulette";
			this.btnQueryRoulette.Size = new System.Drawing.Size(74, 38);
			this.btnQueryRoulette.TabIndex = 1;
			this.btnQueryRoulette.Text = "Roulette";
			this.btnQueryRoulette.UseVisualStyleBackColor = true;
			this.btnQueryRoulette.Click += new System.EventHandler(this.btnQueryRoulette_Click);
			// 
			// btnQueryArea
			// 
			this.btnQueryArea.Dock = System.Windows.Forms.DockStyle.Fill;
			this.btnQueryArea.Location = new System.Drawing.Point(163, 3);
			this.btnQueryArea.Name = "btnQueryArea";
			this.btnQueryArea.Size = new System.Drawing.Size(74, 38);
			this.btnQueryArea.TabIndex = 2;
			this.btnQueryArea.Text = "Area";
			this.btnQueryArea.UseVisualStyleBackColor = true;
			this.btnQueryArea.Click += new System.EventHandler(this.btnQueryArea_Click);
			// 
			// btnQueryFate
			// 
			this.btnQueryFate.Dock = System.Windows.Forms.DockStyle.Fill;
			this.btnQueryFate.Location = new System.Drawing.Point(243, 3);
			this.btnQueryFate.Name = "btnQueryFate";
			this.btnQueryFate.Size = new System.Drawing.Size(74, 38);
			this.btnQueryFate.TabIndex = 3;
			this.btnQueryFate.Text = "FATE";
			this.btnQueryFate.UseVisualStyleBackColor = true;
			this.btnQueryFate.Click += new System.EventHandler(this.btnQueryFate_Click);
			// 
			// dgvQuery
			// 
			this.dgvQuery.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.dgvQuery.Dock = System.Windows.Forms.DockStyle.Fill;
			this.dgvQuery.Location = new System.Drawing.Point(3, 173);
			this.dgvQuery.Name = "dgvQuery";
			this.dgvQuery.Size = new System.Drawing.Size(781, 415);
			this.dgvQuery.TabIndex = 4;
			// 
			// MainForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(787, 591);
			this.Controls.Add(this.tableLayoutPanel1);
			this.Name = "MainForm";
			this.Text = "ACT.DFAssist.Data 조사";
			this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainForm_FormClosing);
			this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.MainForm_FormClosed);
			this.tableLayoutPanel1.ResumeLayout(false);
			this.tableLayoutPanel2.ResumeLayout(false);
			this.tableLayoutPanel2.PerformLayout();
			this.tableLayoutPanel3.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.dgvQuery)).EndInit();
			this.ResumeLayout(false);

		}

		#endregion
		private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
		private System.Windows.Forms.Button btnSave;
		private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
		private System.Windows.Forms.Button btnTest;
		private System.Windows.Forms.ProgressBar prgWorking;
		private System.Windows.Forms.Button btnReadGameData;
		private System.Windows.Forms.TextBox txtResult;
		private System.Windows.Forms.TableLayoutPanel tableLayoutPanel3;
		private System.Windows.Forms.Button btnQueryInstance;
		private System.Windows.Forms.Button btnQueryRoulette;
		private System.Windows.Forms.Button btnQueryArea;
		private System.Windows.Forms.Button btnQueryFate;
		private System.Windows.Forms.DataGridView dgvQuery;
		private System.Windows.Forms.Button btmOpenDb;
		private System.Windows.Forms.ListBox lstLang;
	}
}

