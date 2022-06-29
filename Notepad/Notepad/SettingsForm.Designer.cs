
namespace Notepad
{
    partial class SettingsForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.panel1 = new System.Windows.Forms.Panel();
            this.ApplyButton = new System.Windows.Forms.Button();
            this.CancelButton = new System.Windows.Forms.Button();
            this.panel2 = new System.Windows.Forms.Panel();
            this.AutosaveComboBox = new System.Windows.Forms.ComboBox();
            this.themeComboBox = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.ApplyButton);
            this.panel1.Controls.Add(this.CancelButton);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(0, 722);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1086, 68);
            this.panel1.TabIndex = 0;
            // 
            // ApplyButton
            // 
            this.ApplyButton.Location = new System.Drawing.Point(778, 6);
            this.ApplyButton.Name = "ApplyButton";
            this.ApplyButton.Size = new System.Drawing.Size(146, 50);
            this.ApplyButton.TabIndex = 1;
            this.ApplyButton.Text = "Применить";
            this.ApplyButton.UseVisualStyleBackColor = true;
            this.ApplyButton.Click += new System.EventHandler(this.ApplyButton_Click);
            // 
            // CancelButton
            // 
            this.CancelButton.Location = new System.Drawing.Point(930, 6);
            this.CancelButton.Name = "CancelButton";
            this.CancelButton.Size = new System.Drawing.Size(144, 50);
            this.CancelButton.TabIndex = 0;
            this.CancelButton.Text = "Отменить";
            this.CancelButton.UseVisualStyleBackColor = true;
            this.CancelButton.Click += new System.EventHandler(this.CancelButton_Click);
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.AutosaveComboBox);
            this.panel2.Controls.Add(this.themeComboBox);
            this.panel2.Controls.Add(this.label2);
            this.panel2.Controls.Add(this.label1);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1086, 722);
            this.panel2.TabIndex = 1;
            // 
            // AutosaveComboBox
            // 
            this.AutosaveComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.AutosaveComboBox.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.AutosaveComboBox.FormattingEnabled = true;
            this.AutosaveComboBox.Items.AddRange(new object[] {
            "Нет",
            "1 минута",
            "2 минуты",
            "3 минуты",
            "5 минут",
            "10 минут"});
            this.AutosaveComboBox.Location = new System.Drawing.Point(12, 233);
            this.AutosaveComboBox.Name = "AutosaveComboBox";
            this.AutosaveComboBox.Size = new System.Drawing.Size(313, 46);
            this.AutosaveComboBox.TabIndex = 3;
            // 
            // themeComboBox
            // 
            this.themeComboBox.BackColor = System.Drawing.SystemColors.Window;
            this.themeComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.themeComboBox.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.themeComboBox.ForeColor = System.Drawing.SystemColors.Desktop;
            this.themeComboBox.FormattingEnabled = true;
            this.themeComboBox.Items.AddRange(new object[] {
            "Светлая тема",
            "Темная тема"});
            this.themeComboBox.Location = new System.Drawing.Point(12, 74);
            this.themeComboBox.Name = "themeComboBox";
            this.themeComboBox.Size = new System.Drawing.Size(313, 46);
            this.themeComboBox.TabIndex = 2;
            this.themeComboBox.SelectedIndexChanged += new System.EventHandler(this.themeComboBox_SelectedIndexChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label2.Location = new System.Drawing.Point(12, 166);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(328, 38);
            this.label2.TabIndex = 1;
            this.label2.Text = "Частота автосохранения";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label1.Location = new System.Drawing.Point(12, 18);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(313, 38);
            this.label1.TabIndex = 0;
            this.label1.Text = "Цветовое оформление";
            // 
            // SettingsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 30F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1086, 790);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "SettingsForm";
            this.Text = "Настройки";
            this.TopMost = true;
            this.Load += new System.EventHandler(this.SettingsForm_Load);
            this.panel1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button ApplyButton;
        private System.Windows.Forms.Button CancelButton;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.ComboBox AutosaveComboBox;
        private System.Windows.Forms.ComboBox themeComboBox;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
    }
}