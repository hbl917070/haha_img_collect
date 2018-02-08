namespace 哈哈姆特_圖片整理工具 {
    partial class Form1 {
        /// <summary>
        /// 設計工具所需的變數。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清除任何使用中的資源。
        /// </summary>
        /// <param name="disposing">如果應該處置 Managed 資源則為 true，否則為 false。</param>
        protected override void Dispose(bool disposing) {
            if (disposing && (components != null)) {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form 設計工具產生的程式碼

        /// <summary>
        /// 此為設計工具支援所需的方法 - 請勿使用程式碼編輯器修改
        /// 這個方法的內容。
        /// </summary>
        private void InitializeComponent() {
            this.but_開始 = new System.Windows.Forms.Button();
            this.richTextBox1 = new System.Windows.Forms.RichTextBox();
            this.but_載入網頁 = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.button1 = new System.Windows.Forms.Button();
            this.but_回收記憶體 = new System.Windows.Forms.Button();
            this.richTextBox_刪除圖片 = new System.Windows.Forms.RichTextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.but_顯示或隱藏 = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // but_開始
            // 
            this.but_開始.Location = new System.Drawing.Point(106, 12);
            this.but_開始.Name = "but_開始";
            this.but_開始.Size = new System.Drawing.Size(87, 23);
            this.but_開始.TabIndex = 0;
            this.but_開始.Text = "開始";
            this.but_開始.UseVisualStyleBackColor = true;
            this.but_開始.Click += new System.EventHandler(this.but_開始_Click);
            // 
            // richTextBox1
            // 
            this.richTextBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.richTextBox1.Location = new System.Drawing.Point(582, 56);
            this.richTextBox1.Name = "richTextBox1";
            this.richTextBox1.Size = new System.Drawing.Size(131, 82);
            this.richTextBox1.TabIndex = 2;
            this.richTextBox1.Text = "";
            // 
            // but_載入網頁
            // 
            this.but_載入網頁.Location = new System.Drawing.Point(12, 12);
            this.but_載入網頁.Name = "but_載入網頁";
            this.but_載入網頁.Size = new System.Drawing.Size(87, 23);
            this.but_載入網頁.TabIndex = 3;
            this.but_載入網頁.Text = "載入網頁";
            this.but_載入網頁.UseVisualStyleBackColor = true;
            this.but_載入網頁.Click += new System.EventHandler(this.but_載入網頁_Click);
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.Location = new System.Drawing.Point(12, 41);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(564, 355);
            this.panel1.TabIndex = 4;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(197, 12);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(87, 23);
            this.button1.TabIndex = 5;
            this.button1.Text = "立即執行js";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // but_回收記憶體
            // 
            this.but_回收記憶體.Location = new System.Drawing.Point(396, 12);
            this.but_回收記憶體.Name = "but_回收記憶體";
            this.but_回收記憶體.Size = new System.Drawing.Size(87, 23);
            this.but_回收記憶體.TabIndex = 6;
            this.but_回收記憶體.Text = "回收記憶體";
            this.but_回收記憶體.UseVisualStyleBackColor = true;
            this.but_回收記憶體.Click += new System.EventHandler(this.but_回收記憶體_Click);
            // 
            // richTextBox_刪除圖片
            // 
            this.richTextBox_刪除圖片.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.richTextBox_刪除圖片.Location = new System.Drawing.Point(582, 174);
            this.richTextBox_刪除圖片.Name = "richTextBox_刪除圖片";
            this.richTextBox_刪除圖片.Size = new System.Drawing.Size(131, 222);
            this.richTextBox_刪除圖片.TabIndex = 7;
            this.richTextBox_刪除圖片.Text = "";
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(580, 159);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 12);
            this.label1.TabIndex = 8;
            this.label1.Text = "刪除圖片";
            // 
            // but_顯示或隱藏
            // 
            this.but_顯示或隱藏.Location = new System.Drawing.Point(489, 12);
            this.but_顯示或隱藏.Name = "but_顯示或隱藏";
            this.but_顯示或隱藏.Size = new System.Drawing.Size(87, 23);
            this.but_顯示或隱藏.TabIndex = 9;
            this.but_顯示或隱藏.Text = "顯示或隱藏";
            this.but_顯示或隱藏.UseVisualStyleBackColor = true;
            this.but_顯示或隱藏.Click += new System.EventHandler(this.but_顯示或隱藏_Click);
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(582, 41);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(29, 12);
            this.label2.TabIndex = 10;
            this.label2.Text = "日誌";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(725, 408);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.but_顯示或隱藏);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.richTextBox_刪除圖片);
            this.Controls.Add(this.but_回收記憶體);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.but_載入網頁);
            this.Controls.Add(this.richTextBox1);
            this.Controls.Add(this.but_開始);
            this.Name = "Form1";
            this.Text = "哈哈姆特-圖片整理工具";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button but_開始;
        private System.Windows.Forms.RichTextBox richTextBox1;
        private System.Windows.Forms.Button but_載入網頁;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button but_回收記憶體;
        private System.Windows.Forms.RichTextBox richTextBox_刪除圖片;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button but_顯示或隱藏;
        private System.Windows.Forms.Label label2;
    }
}

