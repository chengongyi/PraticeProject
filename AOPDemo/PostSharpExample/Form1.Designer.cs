namespace PostSharpExample
{
    partial class Form1
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.BTN_SUBSCRIBE = new System.Windows.Forms.Button();
            this.TXB_NAME = new System.Windows.Forms.TextBox();
            this.TXB_ROOM = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(53, 27);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "房间号：";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(41, 87);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(65, 12);
            this.label2.TabIndex = 1;
            this.label2.Text = "您的姓名：";
            // 
            // BTN_SUBSCRIBE
            // 
            this.BTN_SUBSCRIBE.Location = new System.Drawing.Point(237, 147);
            this.BTN_SUBSCRIBE.Name = "BTN_SUBSCRIBE";
            this.BTN_SUBSCRIBE.Size = new System.Drawing.Size(75, 23);
            this.BTN_SUBSCRIBE.TabIndex = 2;
            this.BTN_SUBSCRIBE.Text = "预定";
            this.BTN_SUBSCRIBE.UseVisualStyleBackColor = true;
            this.BTN_SUBSCRIBE.Click += new System.EventHandler(this.BTN_SUBSCRIBE_Click);
            // 
            // TXB_NAME
            // 
            this.TXB_NAME.Location = new System.Drawing.Point(112, 84);
            this.TXB_NAME.Name = "TXB_NAME";
            this.TXB_NAME.Size = new System.Drawing.Size(200, 21);
            this.TXB_NAME.TabIndex = 3;
            // 
            // TXB_ROOM
            // 
            this.TXB_ROOM.Location = new System.Drawing.Point(112, 24);
            this.TXB_ROOM.Name = "TXB_ROOM";
            this.TXB_ROOM.Size = new System.Drawing.Size(200, 21);
            this.TXB_ROOM.TabIndex = 4;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(365, 190);
            this.Controls.Add(this.TXB_ROOM);
            this.Controls.Add(this.TXB_NAME);
            this.Controls.Add(this.BTN_SUBSCRIBE);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button BTN_SUBSCRIBE;
        private System.Windows.Forms.TextBox TXB_NAME;
        private System.Windows.Forms.TextBox TXB_ROOM;
    }
}

