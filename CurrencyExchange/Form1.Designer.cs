namespace CurrencyExchange
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            textBox1 = new TextBox();
            label1 = new Label();
            label2 = new Label();
            textBox2 = new TextBox();
            groupBox1 = new GroupBox();
            GbpToPlnRadio = new RadioButton();
            UsdToPlnRadio = new RadioButton();
            EurToPlnRadio = new RadioButton();
            groupBox1.SuspendLayout();
            SuspendLayout();
            // 
            // textBox1
            // 
            textBox1.Location = new Point(229, 232);
            textBox1.Margin = new Padding(4, 5, 4, 5);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(180, 31);
            textBox1.TabIndex = 0;
            textBox1.Text = "0";
            textBox1.TextAlign = HorizontalAlignment.Right;
            textBox1.TextChanged += textBox1_TextChanged;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(229, 202);
            label1.Margin = new Padding(4, 0, 4, 0);
            label1.Name = "label1";
            label1.Size = new Size(188, 25);
            label1.TabIndex = 1;
            label1.Text = "Kwota w obcej walucie";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(521, 202);
            label2.Margin = new Padding(4, 0, 4, 0);
            label2.Name = "label2";
            label2.Size = new Size(96, 25);
            label2.TabIndex = 3;
            label2.Text = "Kwota PLN";
            // 
            // textBox2
            // 
            textBox2.Location = new Point(521, 232);
            textBox2.Margin = new Padding(4, 5, 4, 5);
            textBox2.Name = "textBox2";
            textBox2.ReadOnly = true;
            textBox2.Size = new Size(180, 31);
            textBox2.TabIndex = 2;
            textBox2.Text = "0";
            textBox2.TextAlign = HorizontalAlignment.Right;
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(GbpToPlnRadio);
            groupBox1.Controls.Add(UsdToPlnRadio);
            groupBox1.Controls.Add(EurToPlnRadio);
            groupBox1.Location = new Point(314, 13);
            groupBox1.Margin = new Padding(4, 5, 4, 5);
            groupBox1.Name = "groupBox1";
            groupBox1.Padding = new Padding(4, 5, 4, 5);
            groupBox1.Size = new Size(286, 167);
            groupBox1.TabIndex = 4;
            groupBox1.TabStop = false;
            groupBox1.Text = "Wybór waluty";
            // 
            // GbpToPlnRadio
            // 
            GbpToPlnRadio.AutoSize = true;
            GbpToPlnRadio.Location = new Point(9, 120);
            GbpToPlnRadio.Margin = new Padding(4, 5, 4, 5);
            GbpToPlnRadio.Name = "GbpToPlnRadio";
            GbpToPlnRadio.Size = new Size(129, 29);
            GbpToPlnRadio.TabIndex = 2;
            GbpToPlnRadio.Text = "GBP -> PLN";
            GbpToPlnRadio.UseVisualStyleBackColor = true;
            GbpToPlnRadio.CheckedChanged += textBox1_TextChanged;
            // 
            // UsdToPlnRadio
            // 
            UsdToPlnRadio.AutoSize = true;
            UsdToPlnRadio.Location = new Point(9, 78);
            UsdToPlnRadio.Margin = new Padding(4, 5, 4, 5);
            UsdToPlnRadio.Name = "UsdToPlnRadio";
            UsdToPlnRadio.Size = new Size(132, 29);
            UsdToPlnRadio.TabIndex = 1;
            UsdToPlnRadio.Text = "USD -> PLN";
            UsdToPlnRadio.UseVisualStyleBackColor = true;
            UsdToPlnRadio.CheckedChanged += textBox1_TextChanged;
            // 
            // EurToPlnRadio
            // 
            EurToPlnRadio.AutoSize = true;
            EurToPlnRadio.Checked = true;
            EurToPlnRadio.Location = new Point(9, 37);
            EurToPlnRadio.Margin = new Padding(4, 5, 4, 5);
            EurToPlnRadio.Name = "EurToPlnRadio";
            EurToPlnRadio.Size = new Size(129, 29);
            EurToPlnRadio.TabIndex = 0;
            EurToPlnRadio.TabStop = true;
            EurToPlnRadio.Text = "EUR -> PLN";
            EurToPlnRadio.UseVisualStyleBackColor = true;
            EurToPlnRadio.CheckedChanged += textBox1_TextChanged;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(883, 393);
            Controls.Add(groupBox1);
            Controls.Add(label2);
            Controls.Add(textBox2);
            Controls.Add(label1);
            Controls.Add(textBox1);
            Margin = new Padding(4, 5, 4, 5);
            Name = "Form1";
            Text = "Form1";
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox textBox1;
        private Label label1;
        private Label label2;
        private TextBox textBox2;
        private GroupBox groupBox1;
        private RadioButton GbpToPlnRadio;
        private RadioButton UsdToPlnRadio;
        private RadioButton EurToPlnRadio;
    }
}
