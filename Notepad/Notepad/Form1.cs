using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Runtime.InteropServices;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace Notepad
{
    public partial class MainForm : Form
    {
        #region Объявление полей
        private Point _imageLocation = new Point(35, 4);
        private Point imageHitArea = new Point(35, 4);
        private readonly List<string> editPages;
        private readonly List<bool> isSaved;
        private readonly List<string> isOpenedFile;
        private int openedWindowsCount;
        private bool child = false;
        internal static bool themeLight;
        internal static int intervalAutosave;
        #endregion

        #region Конструкторы
        /// <summary>
        /// Конструктор начальной формы без параметров.
        /// </summary>
        public MainForm()
        {
            InitializeComponent();
            openedWindowsCount = 1;
            themeLight = Properties.Settings.Default.ThemeLight;
            intervalAutosave = Properties.Settings.Default.AutosaveInterval;
            menuStrip1.Renderer = new MyRenderer();
            editPages = new();
            isSaved = new();
            isOpenedFile = new();
        }

        /// <summary>
        /// Конструкт дочерних форм.
        /// </summary>
        /// <param name="child">Является ли форма дочерней.</param>
        /// <param name="openedWindowsCount">Кол-во уже открытых окон.</param>
        public MainForm(bool child, int openedWindowsCount)
        {
            InitializeComponent();
            this.child = child;
            this.openedWindowsCount = openedWindowsCount;
            themeLight = Properties.Settings.Default.ThemeLight;
            intervalAutosave = Properties.Settings.Default.AutosaveInterval;
            menuStrip1.Renderer = new MyRenderer();
            editPages = new();
            isSaved = new();
            isOpenedFile = new();
        }
        #endregion

        #region Отработка открытия и закрытия формы.
        /// <summary>
        /// Обработка события при загрузки формы.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MainForm_Load(object sender, EventArgs e)
        {
            InitialСonfiguration();
        }

        /// <summary>
        /// Обработка события при закрывании формы.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            openedWindowsCount--;
            BeforeClosingForm(e);
        }
        #endregion

        #region Отработка событий tabControl.
        /// <summary>
        /// Обработка события нажатия на вкладку. Закрытие/Добавление.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tabControl_MouseClick(object sender, MouseEventArgs e)
        {
            CustomTabControl tabControl = (CustomTabControl)sender;
            Point p = e.Location;
            int _tabWidth = this.tabControl.GetTabRect(tabControl.SelectedIndex).Width - (imageHitArea.X);
            Rectangle r = this.tabControl.GetTabRect(tabControl.SelectedIndex);
            r.Offset(_tabWidth, imageHitArea.Y);
            r.Width = 20;
            r.Height = 20;
            if (this.tabControl.SelectedIndex == this.tabControl.TabCount - 1)
            {
                CreateTab();
                SetFormTheme();
            }
            else
            {
                if (r.Contains(p))
                {
                    ClosingTab();
                }
            }
            if (this.tabControl.TabCount == 1)
            {
                Close();
            }
        }


        /// <summary>
        /// Обработка события закрытия вкладки.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tabControl_TabClosing(object sender, TabControlCancelEventArgs e)
        {
            if (tabControl.SelectedIndex == tabControl.TabCount - 1)
            {
                e.Cancel = true;
                tabControl.SelectedTab = tabControl.TabPages[^2];
                return;
            }
            ClosingTab();
            if (tabControl.TabCount == 1)
            {
                Close();
            }
        }
        #endregion

        #region Отработка событий richTextBox
        /// <summary>
        /// Обработка события изменения текста.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void richTextBox_TextChanged(object sender, EventArgs e)
        {
            var text = (RichTextBox)sender;
            if (editPages[tabControl.SelectedIndex].ToString() != text.Text
                && isSaved[tabControl.SelectedIndex])
            {
                tabControl.SelectedTab.Text += "*";
                isSaved[tabControl.SelectedIndex] = false;
            }
            else if (editPages[tabControl.SelectedIndex].ToString() == text.Text)
            {
                tabControl.SelectedTab.Text = tabControl.SelectedTab.Text.TrimEnd('*');
                isSaved[tabControl.SelectedIndex] = true;
            }
            string[] sep = { " ", "\n" };
            wordsCountLabel.Text = "Words: " + (text.Text.Split(sep, StringSplitOptions.RemoveEmptyEntries).Length);
            lengthCountLabel.Text = "Symbols: " + text.TextLength;
        }

        /// <summary>
        /// Обработка события изменения положения каретки.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void RichText_SelectionChanged(object sender, EventArgs e)
        {
            var text = (RichTextBox)sender;
            NumberOfRowsLabel.Text = "Row: " + (text.GetLineFromCharIndex(text.SelectionStart) + 1);
            NumberOfColumnLabel.Text = "Column: " +
                (text.SelectionStart - text.GetFirstCharIndexFromLine(text.GetLineFromCharIndex(text.SelectionStart)) + 1);
        }
        #endregion

        #region Обработка событий contextMenu и fontDialogMenu
        /// <summary>
        /// Обработка события появления контекстного меню.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void showFontContextMenu(object sender, EventArgs e)
        {
            var panel = (Panel)tabControl.SelectedTab.Controls[0];
            var fontBox = (ComboBox)panel.Controls[1];
            var sizeBox = (ComboBox)panel.Controls[1];
            var text = (RichTextBox)tabControl.SelectedTab.Controls[1];
            var menuStrip = (ContextMenuStrip)sender;
            fontBox.SelectedIndexChanged -= ComboBoxFont_SelectedIndexChanged;
            sizeBox.SelectedIndexChanged -= ComboBoxSize_SelectedIndexChanged;
            if (text.SelectionLength > 0)
            {
                try
                {
                    panel.Controls[0].Text = text.SelectionFont.FontFamily.Name;
                }
                catch
                {
                    panel.Controls[0].Text = "";
                }
                try
                {

                    panel.Controls[1].Text = text.SelectionFont.Size.ToString();
                }
                catch
                {
                    panel.Controls[1].Text = "";
                }
            }
            else
            {
                panel.Controls[0].Text = text.Font.FontFamily.Name;
                panel.Controls[1].Text = text.Font.Size.ToString();
            }
            fontBox.SelectedIndexChanged += ComboBoxFont_SelectedIndexChanged;
            sizeBox.SelectedIndexChanged += ComboBoxSize_SelectedIndexChanged;
            menuStrip.Location = new Point(Cursor.Position.X, Cursor.Position.Y + 160);
            panel.Location = new Point(Cursor.Position.X - this.Location.X - 15, Cursor.Position.Y - this.Location.Y - 120);
            panel.Visible = true;
        }

        /// <summary>
        /// Обработка события скрытия контекстного меню.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void hideFontContextMenu(object sender, EventArgs e)
        {
            var panel = (Panel)tabControl.SelectedTab.Controls[0];
            panel.Visible = false;
        }

        /// <summary>
        /// Обработка события нахождения мыши на элементе fontDialogPanel
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FontDialogPanel_MouseHover(object sender, EventArgs e)
        {
            var panel = (Panel)tabControl.SelectedTab.Controls[0];
            panel.Visible = true;
        }
        #endregion

        #region Обработка событий меню.
        /// <summary>
        /// Обработка события нажатия/Применения горячих клавиш на открытие файла.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void открытьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFile();
            if (intervalAutosave != 1 && !AutoSaveTimer.Enabled)
            {
                AutoSaveTimer.Interval = intervalAutosave;
                AutoSaveTimer.Start();
            }
        }

        /// <summary>
        /// Обработка события нажатие на "Новое окно"/Горячих клавиш.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void новоеОкноToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var newWindow = new MainForm(true, openedWindowsCount + 1);
            if (openedWindowsCount <= 5)
            {
                newWindow.Show();
                openedWindowsCount++;
            }
        }

        /// <summary>
        /// Обработка события нажатие на "Сохранить"/Горячих клавищ.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void сохранитьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveFile();
        }

        /// <summary>
        /// Обработка события нажатие на "Сохранить как..."/Горячих клавиш.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void сохранитьКакToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveAsFile();
        }

        /// <summary>
        /// Обработка события нажатие на "Выход".
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void вызодToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Close();
        }

        /// <summary>
        /// Обработка события нажатия на "Отменить"/Горячих клавиш.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void отменитьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            RichTextBox text = (RichTextBox)tabControl.SelectedTab.Controls[1];
            if (text.CanUndo)
            {
                text.Undo();
            }
        }

        /// <summary>
        /// Обработка события нажатия на "Вернуть"/Горячих клавиш.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void вернутьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            RichTextBox text = (RichTextBox)tabControl.SelectedTab.Controls[1];
            if (text.CanRedo)
                text.Redo();
        }

        /// <summary>
        /// Обработка события нажатие на "Вырезать"/Горячих клавиш.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void вырезатьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            tabControl.SelectedTab.Controls[0].Visible = false;
            RichTextBox text = (RichTextBox)tabControl.SelectedTab.Controls[1];
            if (text.SelectionLength > 0)
                text.Cut();
        }

        /// <summary>
        /// Обработка события нажатие на "Копировать"/Горячих клавиш.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void копироватьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            tabControl.SelectedTab.Controls[0].Visible = false;
            RichTextBox text = (RichTextBox)tabControl.SelectedTab.Controls[1];
            if (text.SelectionLength > 0)
                text.Copy();
        }

        /// <summary>
        /// Обработка события нажатие на "Вставить"/Горячих клавиш.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void вставитьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            tabControl.SelectedTab.Controls[0].Visible = false;
            RichTextBox text = (RichTextBox)tabControl.SelectedTab.Controls[1];
            if (Clipboard.GetDataObject().GetDataPresent(DataFormats.Text))
            {
                text.Paste();
            }
        }

        /// <summary>
        /// Обработка события нажатие на "Выделить все"/Горячих клавиш.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void выделитьВсеToolStripMenuItem_Click(object sender, EventArgs e)
        {
            tabControl.SelectedTab.Controls[0].Visible = false;
            RichTextBox text = (RichTextBox)tabControl.SelectedTab.Controls[1];
            if (text.TextLength > 0)
                text.SelectAll();
        }

        /// <summary>
        /// Обработка события нажатие на "Время и дата"/Горячих клавиш.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void времяИДатаToolStripMenuItem_Click(object sender, EventArgs e)
        {
            RichTextBox text = (RichTextBox)tabControl.SelectedTab.Controls[1];
            text.SelectedText = DateTime.Now.ToString();
        }

        /// <summary>
        /// Обработка события нажатия на элемент меню "Настройки". Открытие формы с настройками.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void настройкиToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SettingsForm dialog = new SettingsForm();
            var texts = tabControl.Controls;
            dialog.ShowDialog();
            SetFormTheme();
            if (intervalAutosave != 1)
            {
                AutoSaveTimer.Interval = intervalAutosave;
                AutoSaveTimer.Start();
            }
        }

        /// <summary>
        /// Обработка события нажатие на "Шрифт...".
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void шрифтToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var text = (RichTextBox)tabControl.SelectedTab.Controls[1];
            FontDialog dialog = new();
            dialog.ShowDialog();
            text.Select(text.TextLength, 0);
            text.SelectionFont = dialog.Font;

        }

        /// <summary>
        /// Обработка события добавления вкладки через Меню/Горячие клавишы.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void newTabtoolStripMenuItem_Click(object sender, EventArgs e)
        {
            CreateTab();
            SetFormTheme();
        }

        /// <summary>
        /// Обработка события нажатие на "Перенос строки".
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void переносСтрокиToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var text = (RichTextBox)tabControl.SelectedTab.Controls[1];
            var toolItem = (ToolStripMenuItem)sender;
            toolItem.Checked = !toolItem.Checked;
            text.WordWrap = !text.WordWrap;
        }

        /// <summary>
        /// Обработка события нажатия на "Формат".
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void форматToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var text = (RichTextBox)tabControl.SelectedTab.Controls[1];
            var send = (ToolStripMenuItem)sender;
            var toolItem = (ToolStripMenuItem)send.DropDownItems[1];
            toolItem.Checked = text.WordWrap;
        }

        /// <summary>
        /// Обработка события открытие справки.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void справкаToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var aboutWindow = new About();
            aboutWindow.ShowDialog();
        }

        /// <summary>
        /// Обработка события автосохранения открытых документов.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void AutoSaveTimer_Tick(object sender, EventArgs e)
        {
            for (int i = 0; i < isOpenedFile.Count; i++)
            {
                RichTextBox text = (RichTextBox)tabControl.TabPages[i].Controls[1];
                if (isOpenedFile[i] != null)
                {
                    if (tabControl.TabPages[i].Text.TrimEnd('*').Split('.')[^1] == "rtf")
                    {
                        text.SaveFile(isOpenedFile[i]);
                        tabControl.TabPages[i].Text = tabControl.TabPages[i].Text.TrimEnd('*');
                        isSaved[i] = true;
                        editPages[i] = text.Text;
                    }
                    else
                    {
                        File.WriteAllText(isOpenedFile[i], text.Text);
                        tabControl.TabPages[i].Text = tabControl.TabPages[i].Text.TrimEnd('*');
                        isSaved[i] = true;
                        editPages[i] = text.Text;
                    }
                }
            }
        }
        #endregion

        #region Изменение шрифта.
        /// <summary>
        /// Обработка события нажатия на кнопку зачеркивания.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CrossButton_Click(object sender, EventArgs e)
        {
            var text = (RichTextBox)tabControl.SelectedTab.Controls[1];
            try
            {
                if (text.SelectionLength > 0)
                {
                    if (!text.SelectionFont.Strikeout)
                        text.SelectionFont = new Font(text.SelectionFont.FontFamily, text.SelectionFont.Size, text.SelectionFont.Style | FontStyle.Strikeout);
                    else
                        text.SelectionFont = new Font(text.SelectionFont.FontFamily, text.SelectionFont.Size, text.SelectionFont.Style & ~FontStyle.Strikeout);
                }
                else
                {
                    text.Select(text.SelectionStart, 0);
                    text.SelectionFont = new Font(text.Font.FontFamily, text.Font.Size, text.SelectionFont.Style | FontStyle.Strikeout);
                }
            }
            catch
            {
                text.SelectionFont = new Font("Times New Roman", 11f, FontStyle.Regular | FontStyle.Strikeout);
            }
        }

        /// <summary>
        /// Обработка события нажати на кнопку подчеркивания.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void UnderlineButton_Click(object sender, EventArgs e)
        {
            var text = (RichTextBox)tabControl.SelectedTab.Controls[1];
            try
            {
                if (text.SelectionLength > 0)
                {
                    if (!text.SelectionFont.Underline)
                        text.SelectionFont = new Font(text.SelectionFont.FontFamily, text.SelectionFont.Size, text.SelectionFont.Style | FontStyle.Underline);
                    else
                        text.SelectionFont = new Font(text.SelectionFont.FontFamily, text.SelectionFont.Size, text.SelectionFont.Style & ~FontStyle.Underline);
                }
                else
                {
                    text.Select(text.SelectionStart, 0);
                    text.SelectionFont = new Font(text.Font.FontFamily, text.Font.Size, text.SelectionFont.Style | FontStyle.Underline);
                }
            }
            catch
            {
                text.SelectionFont = new Font("Times New Roman", 11f, FontStyle.Regular | FontStyle.Underline);
            }
        }

        /// <summary>
        /// Обработка события нажатия на кнопку выделения курсивом.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ItalicButton_Click(object sender, EventArgs e)
        {
            var text = (RichTextBox)tabControl.SelectedTab.Controls[1];
            try
            {
                if (text.SelectionLength > 0)
                {
                    if (!text.SelectionFont.Italic)
                        text.SelectionFont = new Font(text.SelectionFont.FontFamily, text.SelectionFont.Size, text.SelectionFont.Style | FontStyle.Italic);
                    else
                        text.SelectionFont = new Font(text.SelectionFont.FontFamily, text.SelectionFont.Size, text.SelectionFont.Style & ~FontStyle.Italic);
                }
                else
                {
                    text.Select(text.SelectionStart, 0);
                    text.SelectionFont = new Font(text.Font.FontFamily, text.Font.Size, text.SelectionFont.Style | FontStyle.Italic);
                }
            }
            catch
            {
                text.SelectionFont = new Font("Times New Roman", 11f, FontStyle.Regular | FontStyle.Italic);
            }
        }

        /// <summary>
        /// Обработка события нажатия на кнопку выделения жирным.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BoldButton_Click(object sender, EventArgs e)
        {
            var text = (RichTextBox)tabControl.SelectedTab.Controls[1];
            try
            {
                if (text.SelectionLength > 0)
                {
                    if (!text.SelectionFont.Bold)
                        text.SelectionFont = new Font(text.SelectionFont.FontFamily, text.SelectionFont.Size, text.SelectionFont.Style | FontStyle.Bold);
                    else
                        text.SelectionFont = new Font(text.SelectionFont.FontFamily, text.SelectionFont.Size, text.SelectionFont.Style & ~FontStyle.Bold);
                }
                else
                {
                    text.Select(text.SelectionStart, 0);
                    text.SelectionFont = new Font(text.Font.FontFamily, text.Font.Size, text.SelectionFont.Style | FontStyle.Bold);
                }
            }
            catch
            {
                text.SelectionFont = new Font("Times New Roman", 11f, FontStyle.Regular | FontStyle.Bold);
            }
        }

        /// <summary>
        /// Обработка события нажатия ENTER
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ComboBox_KeyUp(object sender, KeyEventArgs e)
        {
            
            if (e.KeyCode == Keys.Enter)
            {
                var text = (RichTextBox)tabControl.SelectedTab.Controls[1];
                var comboBoxFont = (ComboBox)tabControl.SelectedTab.Controls[0].Controls[0];
                var comboBoxSize = (ComboBox)tabControl.SelectedTab.Controls[0].Controls[1];
                if (!float.TryParse(comboBoxSize.Text.ToString(), out float size))
                {
                    return;
                }
                string fontFamily;
                if (comboBoxFont.SelectedItem == null)
                {
                    return;
                }
                fontFamily = comboBoxFont.Text;
                if (text.SelectionLength > 0)
                {
                    try
                    {
                        text.SelectionFont = new Font(fontFamily, size, text.SelectionFont.Style);
                    }
                    catch
                    {
                        text.SelectionFont = new Font(fontFamily, size);
                    }
                }
                else if (fontFamily != "" && size != 0)
                {
                    text.Select(text.SelectionStart, 0);
                    try
                    {
                        text.SelectionFont = new Font(fontFamily, size, text.SelectionFont.Style);
                    }
                    catch
                    {
                        text.SelectionFont = new Font("Times New Roman", 11f, FontStyle.Regular);
                    }
                }
            }

        }

        /// <summary>
        /// Обработка события изменения шрифта выделенного текста.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ComboBoxSize_SelectedIndexChanged(object sender, EventArgs e)
        {
            var text = (RichTextBox)tabControl.SelectedTab.Controls[1];
            var comboBox = (ComboBox)sender;
            if (text.SelectionLength > 0)
            {
                try
                {
                    text.SelectionFont = new Font(text.SelectionFont.FontFamily, float.Parse(comboBox.SelectedItem.ToString()), text.SelectionFont.Style);
                }
                catch
                {
                    text.SelectionFont = new Font("Times New Roman", float.Parse(comboBox.SelectedItem.ToString()));
                }
            }
            else
            {
                text.Select(text.SelectionStart, 0);
                try
                {
                    text.SelectionFont = new Font(text.SelectionFont.FontFamily, float.Parse(comboBox.SelectedItem.ToString()), text.SelectionFont.Style);
                }
                catch
                {
                    text.SelectionFont = new Font("Times New Roman", 11f, FontStyle.Regular);
                }
            }
        }

        /// <summary>
        /// Обработка события изменения размера шрифта.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ComboBoxFont_SelectedIndexChanged(object sender, EventArgs e)
        {
            var text = (RichTextBox)tabControl.SelectedTab.Controls[1];
            var comboBox = (ComboBox)sender;
            if (text.SelectionLength > 0)
            {
                try
                {
                    text.SelectionFont = new Font(comboBox.SelectedItem.ToString(), text.SelectionFont.Size, text.SelectionFont.Style);
                }
                catch
                {
                    text.SelectionFont = new Font(comboBox.SelectedItem.ToString(), 11f);
                }
            }
            else
            {
                text.Select(text.SelectionStart, 0);
                try
                {
                    text.SelectionFont = new Font(text.SelectionFont.FontFamily, float.Parse(comboBox.SelectedItem.ToString()), text.SelectionFont.Style);
                }
                catch
                {
                    text.SelectionFont = new Font("Times New Roman", 11f, FontStyle.Regular);
                }
            }
        }

        #endregion
    }
}
