
using Notepad.TabControl.CustomSeporatorMenuStrip;

namespace Notepad
{
    partial class MainForm
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
            this.components = new System.ComponentModel.Container();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.файлToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.newtabtoolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.открытьToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.новоеОкноToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.сохранитьToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.сохранитьКакToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new Notepad.TabControl.CustomSeporatorMenuStrip.CustomMenuSeporator();
            this.вызодToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.правкаToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.отменитьToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.вернутьToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator2 = new Notepad.TabControl.CustomSeporatorMenuStrip.CustomMenuSeporator();
            this.вырезатьToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.копироватьToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.вставитьToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator3 = new Notepad.TabControl.CustomSeporatorMenuStrip.CustomMenuSeporator();
            this.выделитьВсеToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.времяИДатаToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.форматToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.шрифтToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.переносСтрокиToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.настройкиToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.справкаToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.NumberOfRowsLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.NumberOfColumnLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.wordsCountLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.lengthCountLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripTextBox1 = new System.Windows.Forms.ToolStripTextBox();
            this.toolStripMenuItem2 = new System.Windows.Forms.ToolStripMenuItem();
            this.AutoSaveTimer = new System.Windows.Forms.Timer(this.components);
            this.panel1 = new System.Windows.Forms.Panel();
            this.tabControl = new System.Windows.Forms.CustomTabControl();
            this.tabPage = new System.Windows.Forms.TabPage();
            this.addPage = new System.Windows.Forms.TabPage();
            this.СохранитьВсеtoolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.tabControl.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.menuStrip1.GripMargin = new System.Windows.Forms.Padding(2);
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(28, 28);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.файлToolStripMenuItem,
            this.правкаToolStripMenuItem,
            this.форматToolStripMenuItem,
            this.настройкиToolStripMenuItem,
            this.справкаToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(3, 3);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1524, 38);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // файлToolStripMenuItem
            // 
            this.файлToolStripMenuItem.BackColor = System.Drawing.SystemColors.Control;
            this.файлToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.newtabtoolStripMenuItem,
            this.открытьToolStripMenuItem,
            this.новоеОкноToolStripMenuItem,
            this.сохранитьToolStripMenuItem,
            this.сохранитьКакToolStripMenuItem,
            this.СохранитьВсеtoolStripMenuItem,
            this.toolStripSeparator1,
            this.вызодToolStripMenuItem});
            this.файлToolStripMenuItem.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.файлToolStripMenuItem.Name = "файлToolStripMenuItem";
            this.файлToolStripMenuItem.Size = new System.Drawing.Size(80, 34);
            this.файлToolStripMenuItem.Text = "Файл";
            // 
            // newtabtoolStripMenuItem
            // 
            this.newtabtoolStripMenuItem.Name = "newtabtoolStripMenuItem";
            this.newtabtoolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.T)));
            this.newtabtoolStripMenuItem.Size = new System.Drawing.Size(422, 40);
            this.newtabtoolStripMenuItem.Text = "Новая вкладка";
            this.newtabtoolStripMenuItem.Click += new System.EventHandler(this.newTabtoolStripMenuItem_Click);
            // 
            // открытьToolStripMenuItem
            // 
            this.открытьToolStripMenuItem.Name = "открытьToolStripMenuItem";
            this.открытьToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.O)));
            this.открытьToolStripMenuItem.Size = new System.Drawing.Size(422, 40);
            this.открытьToolStripMenuItem.Text = "Открыть...";
            this.открытьToolStripMenuItem.Click += new System.EventHandler(this.открытьToolStripMenuItem_Click);
            // 
            // новоеОкноToolStripMenuItem
            // 
            this.новоеОкноToolStripMenuItem.Name = "новоеОкноToolStripMenuItem";
            this.новоеОкноToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.N)));
            this.новоеОкноToolStripMenuItem.Size = new System.Drawing.Size(422, 40);
            this.новоеОкноToolStripMenuItem.Text = "Новое окно";
            this.новоеОкноToolStripMenuItem.Click += new System.EventHandler(this.новоеОкноToolStripMenuItem_Click);
            // 
            // сохранитьToolStripMenuItem
            // 
            this.сохранитьToolStripMenuItem.Name = "сохранитьToolStripMenuItem";
            this.сохранитьToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.S)));
            this.сохранитьToolStripMenuItem.Size = new System.Drawing.Size(422, 40);
            this.сохранитьToolStripMenuItem.Text = "Сохранить";
            this.сохранитьToolStripMenuItem.Click += new System.EventHandler(this.сохранитьToolStripMenuItem_Click);
            // 
            // сохранитьКакToolStripMenuItem
            // 
            this.сохранитьКакToolStripMenuItem.Name = "сохранитьКакToolStripMenuItem";
            this.сохранитьКакToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)(((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Shift) 
            | System.Windows.Forms.Keys.S)));
            this.сохранитьКакToolStripMenuItem.Size = new System.Drawing.Size(422, 40);
            this.сохранитьКакToolStripMenuItem.Text = "Сохранить как...";
            this.сохранитьКакToolStripMenuItem.Click += new System.EventHandler(this.сохранитьКакToolStripMenuItem_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.BackColor = System.Drawing.SystemColors.ControlText;
            this.toolStripSeparator1.ForeColor = System.Drawing.SystemColors.ActiveCaption;
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(419, 6);
            // 
            // вызодToolStripMenuItem
            // 
            this.вызодToolStripMenuItem.Name = "вызодToolStripMenuItem";
            this.вызодToolStripMenuItem.Size = new System.Drawing.Size(422, 40);
            this.вызодToolStripMenuItem.Text = "Выход";
            this.вызодToolStripMenuItem.Click += new System.EventHandler(this.вызодToolStripMenuItem_Click);
            // 
            // правкаToolStripMenuItem
            // 
            this.правкаToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.отменитьToolStripMenuItem,
            this.вернутьToolStripMenuItem,
            this.toolStripSeparator2,
            this.вырезатьToolStripMenuItem,
            this.копироватьToolStripMenuItem,
            this.вставитьToolStripMenuItem,
            this.toolStripSeparator3,
            this.выделитьВсеToolStripMenuItem,
            this.времяИДатаToolStripMenuItem});
            this.правкаToolStripMenuItem.Name = "правкаToolStripMenuItem";
            this.правкаToolStripMenuItem.Size = new System.Drawing.Size(101, 34);
            this.правкаToolStripMenuItem.Text = "Правка";
            // 
            // отменитьToolStripMenuItem
            // 
            this.отменитьToolStripMenuItem.Name = "отменитьToolStripMenuItem";
            this.отменитьToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Z)));
            this.отменитьToolStripMenuItem.Size = new System.Drawing.Size(346, 40);
            this.отменитьToolStripMenuItem.Text = "Отменить";
            this.отменитьToolStripMenuItem.Click += new System.EventHandler(this.отменитьToolStripMenuItem_Click);
            // 
            // вернутьToolStripMenuItem
            // 
            this.вернутьToolStripMenuItem.Name = "вернутьToolStripMenuItem";
            this.вернутьToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)(((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Shift) 
            | System.Windows.Forms.Keys.Z)));
            this.вернутьToolStripMenuItem.Size = new System.Drawing.Size(346, 40);
            this.вернутьToolStripMenuItem.Text = "Вернуть";
            this.вернутьToolStripMenuItem.Click += new System.EventHandler(this.вернутьToolStripMenuItem_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(343, 6);
            // 
            // вырезатьToolStripMenuItem
            // 
            this.вырезатьToolStripMenuItem.Name = "вырезатьToolStripMenuItem";
            this.вырезатьToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.X)));
            this.вырезатьToolStripMenuItem.Size = new System.Drawing.Size(346, 40);
            this.вырезатьToolStripMenuItem.Text = "Вырезать";
            this.вырезатьToolStripMenuItem.Click += new System.EventHandler(this.вырезатьToolStripMenuItem_Click);
            // 
            // копироватьToolStripMenuItem
            // 
            this.копироватьToolStripMenuItem.Name = "копироватьToolStripMenuItem";
            this.копироватьToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.C)));
            this.копироватьToolStripMenuItem.Size = new System.Drawing.Size(346, 40);
            this.копироватьToolStripMenuItem.Text = "Копировать";
            this.копироватьToolStripMenuItem.Click += new System.EventHandler(this.копироватьToolStripMenuItem_Click);
            // 
            // вставитьToolStripMenuItem
            // 
            this.вставитьToolStripMenuItem.Name = "вставитьToolStripMenuItem";
            this.вставитьToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.V)));
            this.вставитьToolStripMenuItem.Size = new System.Drawing.Size(346, 40);
            this.вставитьToolStripMenuItem.Text = "Вставить";
            this.вставитьToolStripMenuItem.Click += new System.EventHandler(this.вставитьToolStripMenuItem_Click);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(343, 6);
            // 
            // выделитьВсеToolStripMenuItem
            // 
            this.выделитьВсеToolStripMenuItem.Name = "выделитьВсеToolStripMenuItem";
            this.выделитьВсеToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.A)));
            this.выделитьВсеToolStripMenuItem.Size = new System.Drawing.Size(346, 40);
            this.выделитьВсеToolStripMenuItem.Text = "Выделить все";
            this.выделитьВсеToolStripMenuItem.Click += new System.EventHandler(this.выделитьВсеToolStripMenuItem_Click);
            // 
            // времяИДатаToolStripMenuItem
            // 
            this.времяИДатаToolStripMenuItem.Name = "времяИДатаToolStripMenuItem";
            this.времяИДатаToolStripMenuItem.ShortcutKeys = System.Windows.Forms.Keys.F5;
            this.времяИДатаToolStripMenuItem.Size = new System.Drawing.Size(346, 40);
            this.времяИДатаToolStripMenuItem.Text = "Время и дата";
            this.времяИДатаToolStripMenuItem.Click += new System.EventHandler(this.времяИДатаToolStripMenuItem_Click);
            // 
            // форматToolStripMenuItem
            // 
            this.форматToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.шрифтToolStripMenuItem,
            this.переносСтрокиToolStripMenuItem});
            this.форматToolStripMenuItem.Name = "форматToolStripMenuItem";
            this.форматToolStripMenuItem.Size = new System.Drawing.Size(105, 34);
            this.форматToolStripMenuItem.Text = "Формат";
            this.форматToolStripMenuItem.Click += new System.EventHandler(this.форматToolStripMenuItem_Click);
            // 
            // шрифтToolStripMenuItem
            // 
            this.шрифтToolStripMenuItem.Name = "шрифтToolStripMenuItem";
            this.шрифтToolStripMenuItem.Size = new System.Drawing.Size(285, 40);
            this.шрифтToolStripMenuItem.Text = "Шрифт...";
            this.шрифтToolStripMenuItem.Click += new System.EventHandler(this.шрифтToolStripMenuItem_Click);
            // 
            // переносСтрокиToolStripMenuItem
            // 
            this.переносСтрокиToolStripMenuItem.Name = "переносСтрокиToolStripMenuItem";
            this.переносСтрокиToolStripMenuItem.Size = new System.Drawing.Size(285, 40);
            this.переносСтрокиToolStripMenuItem.Text = "Перенос строки";
            this.переносСтрокиToolStripMenuItem.Click += new System.EventHandler(this.переносСтрокиToolStripMenuItem_Click);
            // 
            // настройкиToolStripMenuItem
            // 
            this.настройкиToolStripMenuItem.Name = "настройкиToolStripMenuItem";
            this.настройкиToolStripMenuItem.Size = new System.Drawing.Size(134, 34);
            this.настройкиToolStripMenuItem.Text = "Настройки";
            this.настройкиToolStripMenuItem.Click += new System.EventHandler(this.настройкиToolStripMenuItem_Click);
            // 
            // справкаToolStripMenuItem
            // 
            this.справкаToolStripMenuItem.Name = "справкаToolStripMenuItem";
            this.справкаToolStripMenuItem.Size = new System.Drawing.Size(111, 34);
            this.справкаToolStripMenuItem.Text = "Справка";
            this.справкаToolStripMenuItem.Click += new System.EventHandler(this.справкаToolStripMenuItem_Click);
            // 
            // statusStrip1
            // 
            this.statusStrip1.ImageScalingSize = new System.Drawing.Size(28, 28);
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel1,
            this.NumberOfRowsLabel,
            this.NumberOfColumnLabel,
            this.wordsCountLabel,
            this.lengthCountLabel});
            this.statusStrip1.Location = new System.Drawing.Point(3, 900);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(1524, 39);
            this.statusStrip1.TabIndex = 1;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // toolStripStatusLabel1
            // 
            this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            this.toolStripStatusLabel1.Size = new System.Drawing.Size(1173, 30);
            this.toolStripStatusLabel1.Spring = true;
            // 
            // NumberOfRowsLabel
            // 
            this.NumberOfRowsLabel.Name = "NumberOfRowsLabel";
            this.NumberOfRowsLabel.Size = new System.Drawing.Size(63, 30);
            this.NumberOfRowsLabel.Text = "Row: ";
            this.NumberOfRowsLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // NumberOfColumnLabel
            // 
            this.NumberOfColumnLabel.Name = "NumberOfColumnLabel";
            this.NumberOfColumnLabel.Size = new System.Drawing.Size(96, 30);
            this.NumberOfColumnLabel.Text = "Column: ";
            this.NumberOfColumnLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // wordsCountLabel
            // 
            this.wordsCountLabel.Name = "wordsCountLabel";
            this.wordsCountLabel.Size = new System.Drawing.Size(83, 30);
            this.wordsCountLabel.Text = "Words: ";
            this.wordsCountLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lengthCountLabel
            // 
            this.lengthCountLabel.Name = "lengthCountLabel";
            this.lengthCountLabel.Size = new System.Drawing.Size(94, 30);
            this.lengthCountLabel.Text = "Symbols:";
            this.lengthCountLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // toolStripTextBox1
            // 
            this.toolStripTextBox1.Margin = new System.Windows.Forms.Padding(1, 0, 1, 0);
            this.toolStripTextBox1.Name = "toolStripTextBox1";
            this.toolStripTextBox1.Size = new System.Drawing.Size(100, 35);
            // 
            // toolStripMenuItem2
            // 
            this.toolStripMenuItem2.Name = "toolStripMenuItem2";
            this.toolStripMenuItem2.Size = new System.Drawing.Size(270, 36);
            this.toolStripMenuItem2.Text = "toolStripMenuItem2";
            // 
            // AutoSaveTimer
            // 
            this.AutoSaveTimer.Interval = 60000;
            this.AutoSaveTimer.Tick += new System.EventHandler(this.AutoSaveTimer_Tick);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.White;
            this.panel1.Controls.Add(this.tabControl);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(3, 41);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1524, 859);
            this.panel1.TabIndex = 2;
            // 
            // tabControl
            // 
            this.tabControl.Controls.Add(this.tabPage);
            this.tabControl.Controls.Add(this.addPage);
            this.tabControl.DisplayStyle = System.Windows.Forms.TabStyle.IE8;
            // 
            // 
            // 
            this.tabControl.DisplayStyleProvider.BorderColor = System.Drawing.SystemColors.ControlDark;
            this.tabControl.DisplayStyleProvider.BorderColorHot = System.Drawing.SystemColors.ControlDark;
            this.tabControl.DisplayStyleProvider.BorderColorSelected = System.Drawing.Color.FromArgb(((int)(((byte)(127)))), ((int)(((byte)(157)))), ((int)(((byte)(185)))));
            this.tabControl.DisplayStyleProvider.CloserColor = System.Drawing.Color.DarkGray;
            this.tabControl.DisplayStyleProvider.CloserColorActive = System.Drawing.Color.Red;
            this.tabControl.DisplayStyleProvider.FocusTrack = false;
            this.tabControl.DisplayStyleProvider.HotTrack = true;
            this.tabControl.DisplayStyleProvider.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.tabControl.DisplayStyleProvider.Opacity = 1F;
            this.tabControl.DisplayStyleProvider.Overlap = 0;
            this.tabControl.DisplayStyleProvider.Padding = new System.Drawing.Point(6, 5);
            this.tabControl.DisplayStyleProvider.Radius = 3;
            this.tabControl.DisplayStyleProvider.ShowTabCloser = true;
            this.tabControl.DisplayStyleProvider.TextColor = System.Drawing.SystemColors.ControlText;
            this.tabControl.DisplayStyleProvider.TextColorDisabled = System.Drawing.SystemColors.ControlDark;
            this.tabControl.DisplayStyleProvider.TextColorSelected = System.Drawing.SystemColors.ControlText;
            this.tabControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl.DrawMode = System.Windows.Forms.TabDrawMode.OwnerDrawFixed;
            this.tabControl.HotTrack = true;
            this.tabControl.Location = new System.Drawing.Point(0, 0);
            this.tabControl.Name = "tabControl";
            this.tabControl.SelectedIndex = 0;
            this.tabControl.Size = new System.Drawing.Size(1524, 859);
            this.tabControl.SizeMode = System.Windows.Forms.TabSizeMode.FillToRight;
            this.tabControl.TabIndex = 0;
            this.tabControl.TabClosing += new System.EventHandler<System.Windows.Forms.TabControlCancelEventArgs>(this.tabControl_TabClosing);
            this.tabControl.MouseClick += new System.Windows.Forms.MouseEventHandler(this.tabControl_MouseClick);
            // 
            // tabPage
            // 
            this.tabPage.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.tabPage.ForeColor = System.Drawing.Color.Black;
            this.tabPage.Location = new System.Drawing.Point(4, 44);
            this.tabPage.Name = "tabPage";
            this.tabPage.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage.Size = new System.Drawing.Size(1516, 811);
            this.tabPage.TabIndex = 0;
            this.tabPage.Text = "tabPage1";
            this.tabPage.UseVisualStyleBackColor = true;
            // 
            // addPage
            // 
            this.addPage.Location = new System.Drawing.Point(4, 44);
            this.addPage.Name = "addPage";
            this.addPage.Padding = new System.Windows.Forms.Padding(3);
            this.addPage.Size = new System.Drawing.Size(1516, 811);
            this.addPage.TabIndex = 1;
            this.addPage.Text = "+";
            this.addPage.UseVisualStyleBackColor = true;
            // 
            // СохранитьВсеtoolStripMenuItem
            // 
            this.СохранитьВсеtoolStripMenuItem.Name = "СохранитьВсеtoolStripMenuItem";
            this.СохранитьВсеtoolStripMenuItem.Size = new System.Drawing.Size(422, 40);
            this.СохранитьВсеtoolStripMenuItem.Text = "Сохранить все";
            this.СохранитьВсеtoolStripMenuItem.Click += new System.EventHandler(this.AutoSaveTimer_Tick);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 30F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1530, 942);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "MainForm";
            this.Padding = new System.Windows.Forms.Padding(3);
            this.Text = "Notepad+";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainForm_FormClosing);
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.tabControl.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem файлToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem правкаToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem форматToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem настройкиToolStripMenuItem;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
        private System.Windows.Forms.ToolStripStatusLabel NumberOfRowsLabel;
        private System.Windows.Forms.ToolStripStatusLabel NumberOfColumnLabel;
        private System.Windows.Forms.ToolStripStatusLabel wordsCountLabel;
        private System.Windows.Forms.ToolStripMenuItem открытьToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem новоеОкноToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem сохранитьToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem сохранитьКакToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem вызодToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem отменитьToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem вернутьToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem вырезатьToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem копироватьToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem вставитьToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem выделитьВсеToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem времяИДатаToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem newtabtoolStripMenuItem;
        private System.Windows.Forms.ToolStripTextBox toolStripTextBox1;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem2;
        private System.Windows.Forms.ToolStripMenuItem шрифтToolStripMenuItem;
        private System.Windows.Forms.Timer AutoSaveTimer;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.CustomTabControl tabControl;
        private System.Windows.Forms.TabPage tabPage;
        private System.Windows.Forms.TabPage addPage;
        private System.Windows.Forms.ToolStripStatusLabel lengthCountLabel;
        private System.Windows.Forms.ToolStripMenuItem переносСтрокиToolStripMenuItem;
        private CustomMenuSeporator toolStripSeparator1;
        private CustomMenuSeporator toolStripSeparator2;
        private CustomMenuSeporator toolStripSeparator3;
        private System.Windows.Forms.ToolStripMenuItem справкаToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem СохранитьВсеtoolStripMenuItem;
    }
}

