using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Drawing;

namespace Notepad
{
    public partial class MainForm : Form
    {
        #region Начальная сборка
        /// <summary>
        /// Генерация начального текст бокса.
        /// </summary>
        private void FirstRichTextBox()
        {
            Panel fontDialogPanel = new();
            SetFontDialogPanel(fontDialogPanel);
            var contextMenu = new ContextMenuStrip();
            contextMenu.Renderer = new MyRenderer();
            var copyMenuItem = new ToolStripMenuItem("Копировать", null, копироватьToolStripMenuItem_Click, Keys.Control | Keys.C);
            var cutMenuItem = new ToolStripMenuItem("Вырезать", null, вырезатьToolStripMenuItem_Click, Keys.Control | Keys.X);
            var pasteMenuItem = new ToolStripMenuItem("Вставить", null, вставитьToolStripMenuItem_Click, Keys.Control | Keys.V);
            var selectAllMenuItem = new ToolStripMenuItem("Выбрать все", null, выделитьВсеToolStripMenuItem_Click, Keys.Control | Keys.A);
            contextMenu.Items.AddRange(new[] { copyMenuItem, cutMenuItem, pasteMenuItem, selectAllMenuItem });
            contextMenu.Opened += showFontContextMenu;
            var richText = new RichTextBox();
            richText.Dock = DockStyle.Fill;
            richText.AcceptsTab = true;
            richText.ScrollBars = RichTextBoxScrollBars.Both;
            richText.WordWrap = false;
            richText.Text = "";
            richText.ContextMenuStrip = contextMenu;
            editPages.Add(new(richText.Text));
            isSaved.Add(true);
            isOpenedFile.Add(null);
            richText.SelectionChanged += RichText_SelectionChanged;
            richText.TextChanged += richTextBox_TextChanged;
            richText.MouseClick += hideFontContextMenu;
            tabControl.TabPages[0].Controls.Add(fontDialogPanel);
            tabControl.TabPages[0].Controls.Add(richText);
        }

        /// <summary>
        /// Открытие ранее открытых файлов
        /// </summary>
        private void OpenPrevFiles()
        {
            System.Collections.Specialized.StringCollection openedFiles = Properties.Settings.Default.OpenedFilesPrev;
            if (openedFiles != null)
            {
                for (int i = 0; i < openedFiles.Count; i++)
                {
                    if (openedFiles[i] == null || openedFiles[i] == "" || !File.Exists(openedFiles[i]))
                        continue;
                    if (i == 0)
                    {
                        RichTextBox richText = (RichTextBox)tabControl.SelectedTab.Controls[1];
                        editPages[tabControl.SelectedIndex] = File.ReadAllText(openedFiles[i]);
                        isSaved[tabControl.SelectedIndex] = true;
                        isOpenedFile[tabControl.SelectedIndex] = openedFiles[i];
                        try
                        {
                            if (openedFiles[i].Split('\\')[^1].Split('.')[^1] == "rtf")
                                richText.LoadFile(openedFiles[i]);
                            else
                                richText.Text = File.ReadAllText(openedFiles[i]);
                        }
                        catch (Exception e)
                        {
                            MessageBox.Show(e.Message + openedFiles[i]);
                        }
                        tabControl.SelectedTab.Text = openedFiles[i].Split('\\')[^1];
                    }
                    else
                    {
                        CreateTab();
                        SetFormTheme();
                        editPages[tabControl.SelectedIndex] = File.ReadAllText(openedFiles[i]);
                        isSaved[tabControl.SelectedIndex] = true;
                        isOpenedFile[tabControl.SelectedIndex] = openedFiles[i];

                        RichTextBox richText = (RichTextBox)tabControl.SelectedTab.Controls[1];
                        tabControl.TabPages[i].BorderStyle = BorderStyle.None;
                        try
                        {
                            if (openedFiles[i].Split('\\')[^1].Split('.')[^1] == "rtf")
                                richText.LoadFile(openedFiles[i]);
                            else
                                richText.Text = File.ReadAllText(openedFiles[i]);
                        }
                        catch (Exception e)
                        {
                            MessageBox.Show(e.Message + openedFiles[i]);
                        }
                        tabControl.SelectedTab.Text = openedFiles[i].Split('\\')[^1];
                    }
                }
            }
        }
        #endregion

        #region Вспомогательные методы
        /// <summary>
        /// Вспомогательный метод для определения начального состояния формы.
        /// </summary>
        private void InitialСonfiguration()
        {
            AutoSaveTimer.Interval = intervalAutosave;
            AutoSaveTimer.Stop();
            tabControl.Padding = new Point(20, 4);
            tabControl.TabPages[0].Text = "Untitled";
            tabControl.TabPages[0].BorderStyle = BorderStyle.None;
            FirstRichTextBox();
            if (!child)
                OpenPrevFiles();
            SetFormTheme();
        }

        /// <summary>
        /// Вспомогательный метод задать цветовое оформление формы.
        /// </summary>
        private void SetFormTheme()
        {
            var texts = tabControl.Controls;
            this.ForeColor = themeLight ? Color.Black : Color.White;
            this.BackColor = themeLight ? Color.White : Color.FromArgb(45, 45, 45);
            panel1.BackColor = themeLight ? Color.White : Color.FromArgb(45, 45, 45);
            menuStrip1.BackColor = themeLight ? Color.White : Color.FromArgb(45, 45, 45);
            menuStrip1.ForeColor = themeLight ? Color.Black : Color.White;
            foreach (ToolStripMenuItem item in menuStrip1.Items)
            {
                item.BackColor = themeLight ? Color.White : Color.FromArgb(45, 45, 45);
                item.ForeColor = themeLight ? Color.Black : Color.White;
                foreach (var dropItem in item.DropDownItems)
                {
                    if (dropItem is ToolStripMenuItem drop)
                    {
                        drop.BackColor = themeLight ? Color.White : Color.FromArgb(45, 45, 45);
                        drop.ForeColor = themeLight ? Color.Black : Color.White;
                    }
                }
            }
            statusStrip1.BackColor = themeLight ? Color.White : Color.FromArgb(45, 45, 45);
            tabControl.SelectedTab.BackColor = themeLight ? Color.White : Color.FromArgb(45, 45, 45);
            tabControl.SelectedTab.ForeColor = themeLight ? Color.Black : Color.White;
            tabControl.TabPages[0].BackColor = themeLight ? Color.White : Color.Black;
            for (int i = 0; i < texts.Count - 1; i++)
            {
                foreach (ToolStripMenuItem item in texts[i].Controls[1].ContextMenuStrip.Items)
                {
                    item.BackColor = themeLight ? Color.White : Color.FromArgb(45, 45, 45);
                    item.ForeColor = themeLight ? Color.Black : Color.White;
                }
                texts[i].Controls[1].BackColor = themeLight ? Color.White : Color.FromArgb(30, 30, 30);
                texts[i].Controls[1].ForeColor = themeLight ? Color.Black : Color.White;
                texts[i].Controls[0].BackColor = themeLight ? Color.White : Color.FromArgb(45, 45, 45);
                texts[i].Controls[0].ForeColor = themeLight ? Color.Black : Color.White;
                texts[i].Controls[0].Controls[0].BackColor = themeLight ? Color.White : Color.Black;
                texts[i].Controls[0].Controls[1].BackColor = themeLight ? Color.White : Color.Black;
                texts[i].Controls[0].Controls[2].BackColor = themeLight ? Color.White : Color.Black;
                texts[i].Controls[0].Controls[3].BackColor = themeLight ? Color.White : Color.Black;
                texts[i].Controls[0].Controls[4].BackColor = themeLight ? Color.White : Color.Black;
                texts[i].Controls[0].Controls[5].BackColor = themeLight ? Color.White : Color.Black;
                texts[i].Controls[0].Controls[0].ForeColor = themeLight ? Color.Black : Color.White;
                texts[i].Controls[0].Controls[1].ForeColor = themeLight ? Color.Black : Color.White;
                texts[i].Controls[0].Controls[2].ForeColor = themeLight ? Color.Black : Color.White;
                texts[i].Controls[0].Controls[3].ForeColor = themeLight ? Color.Black : Color.White;
                texts[i].Controls[0].Controls[4].ForeColor = themeLight ? Color.Black : Color.White;
                texts[i].Controls[0].Controls[5].ForeColor = themeLight ? Color.Black : Color.White;
            }
        }

        /// <summary>
        /// Вспомогательный метод обработки события перед закрытием формы.
        /// </summary>
        /// <param name="e"></param>
        private void BeforeClosingForm(FormClosingEventArgs e)
        {
            Properties.Settings.Default.ThemeLight = themeLight;
            Properties.Settings.Default.AutosaveInterval = intervalAutosave;
            var openedFiles = new System.Collections.Specialized.StringCollection();
            var pages = tabControl.TabPages;
            var saveDialog = new SaveFileDialog();
            saveDialog.Filter = "Текстовый файл *.txt|*.txt|Rich text file *.rtf|*.rtf|Все файлы|*.*";
            for (int i = 0; i < pages.Count - 1; i++)
            {
                if (isOpenedFile[i] != null)
                    openedFiles.Add(isOpenedFile[i]);
                var text = (RichTextBox)pages[i].Controls[1];
                if (!isSaved[i] && isOpenedFile[i] != null)
                {
                    DialogResult dialog = MessageBox.Show(
                       $"Есть не сохраненный файл: {isOpenedFile[i]}\n" +
                       $"Хотите сохранить перед закрытием?",
                       "Завершение программы",
                       MessageBoxButtons.YesNoCancel,
                       MessageBoxIcon.Warning
                       );
                    if (dialog == DialogResult.Cancel)
                    {
                        e.Cancel = true;
                        return;
                    }
                    if (dialog == DialogResult.Yes)
                    {
                        try
                        {
                            if (tabControl.SelectedTab.Text.TrimEnd('*').Split('.')[^1] == "rtf")
                                text.SaveFile(isOpenedFile[tabControl.SelectedIndex].TrimEnd('*'));
                            else
                                File.WriteAllText(isOpenedFile[tabControl.SelectedIndex], tabControl.SelectedTab.Controls[1].Text);
                        }
                        catch
                        {
                        }
                    }
                }
                else if (!isSaved[i] && isOpenedFile[i] == null)
                {
                    DialogResult dialog = MessageBox.Show(
                       $"Есть не сохраненная вкладка: {pages[i].Text}\n" +
                       $"Хотите сохранить перед закрытием?",
                       "Завершение программы",
                       MessageBoxButtons.YesNoCancel,
                       MessageBoxIcon.Warning
                       );
                    if (dialog == DialogResult.Cancel)
                    {
                        e.Cancel = true;
                        return;
                    }
                    if (dialog == DialogResult.Yes)
                    {
                        if (saveDialog.ShowDialog() == DialogResult.Cancel)
                            continue;
                        try
                        {
                            if (saveDialog.FileName.Split('\\')[^1].Split('.')[^1] == "rtf")
                                text.SaveFile(saveDialog.FileName);
                            else
                                File.WriteAllText(saveDialog.FileName, tabControl.SelectedTab.Controls[1].Text);
                        }
                        catch
                        {
                        }

                    }
                }
                Properties.Settings.Default.OpenedFilesPrev = openedFiles;
                Properties.Settings.Default.Save();
                e.Cancel = false;
            }
        }

        /// <summary>
        /// Генерация контекстного меню с изменением шрифта.
        /// </summary>
        /// <param name="fontDialogPanel"></param>
        private void SetFontDialogPanel(Panel fontDialogPanel)
        {
            ComboBox comboBoxFont = GetComboBoxFont();
            ComboBox comboBoxSize = GetComboBoxSize();
            Button boldButton = GetBoldButton();
            Button italicButton = GetItalicButton();
            Button underlineButton = GetUnderlineButton();
            Button crossButton = GetCrossButton();

            fontDialogPanel.Controls.AddRange(new[] { comboBoxFont, comboBoxSize });
            fontDialogPanel.Controls.AddRange(new[] { boldButton, italicButton, underlineButton, crossButton });
            fontDialogPanel.Size = new Size(390, 120);
            fontDialogPanel.Visible = false;
            fontDialogPanel.BorderStyle = BorderStyle.FixedSingle;
            fontDialogPanel.MouseHover += FontDialogPanel_MouseHover;
        }

        /// <summary>
        /// Вспомогательный метод для создания вкладки.
        /// </summary>
        private void CreateTab()
        {
            TabPage tab = new();
            RichTextBox text = new();
            Panel fontDialogPanel = new();
            SetFontDialogPanel(fontDialogPanel);
            var contextMenu = new ContextMenuStrip();
            contextMenu.Renderer = new MyRenderer();
            var sep = new ToolStripSeparator();
            var copyMenuItem = new ToolStripMenuItem("Копировать", null, копироватьToolStripMenuItem_Click, Keys.Control | Keys.C);
            var cutMenuItem = new ToolStripMenuItem("Вырезать", null, вырезатьToolStripMenuItem_Click, Keys.Control | Keys.X);
            var pasteMenuItem = new ToolStripMenuItem("Вставить", null, вставитьToolStripMenuItem_Click, Keys.Control | Keys.V);
            var selectAllMenuItem = new ToolStripMenuItem("Выбрать все", null, выделитьВсеToolStripMenuItem_Click, Keys.Control | Keys.A);
            contextMenu.Items.AddRange(new[] { copyMenuItem, cutMenuItem, pasteMenuItem, selectAllMenuItem });
            contextMenu.Opened += showFontContextMenu;
            text.AcceptsTab = true;
            text.Dock = DockStyle.Fill;
            text.Text = $"";
            editPages.Add(new(""));
            isSaved.Add(true);
            isOpenedFile.Add(null);
            text.ScrollBars = RichTextBoxScrollBars.Both;
            text.WordWrap = false;
            text.ContextMenuStrip = contextMenu;
            text.SelectionChanged += RichText_SelectionChanged;
            text.TextChanged += richTextBox_TextChanged;
            text.MouseClick += hideFontContextMenu;
            tab.Controls.Add(fontDialogPanel);
            tab.Controls.Add(text);
            tab.Text = $"Untitled{tabControl.TabCount - 1}";
            this.tabControl.Controls.RemoveAt(tabControl.TabCount - 1);
            this.tabControl.Controls.Add(tab);
            this.tabControl.SelectedTab = this.tabControl.TabPages[^1];
            this.tabControl.Controls.Add(new TabPage("+"));
        }

        /// <summary>
        /// Вспомогательный метод обработки события закрытия вкладки.
        /// </summary>
        private void ClosingTab()
        {
            if (isSaved[tabControl.SelectedIndex])
            {
                TabPage tabPage = (TabPage)tabControl.TabPages[tabControl.SelectedIndex];
                isSaved.RemoveAt(tabControl.SelectedIndex);
                isOpenedFile.RemoveAt(tabControl.SelectedIndex);
                editPages.RemoveAt(tabControl.SelectedIndex);
                tabControl.TabPages.Remove(tabPage);
            }
            else
            {
                DialogResult result = MessageBox.Show("Эта вкладка не сохраненна, хотите ее сохранить перед закрытием?",
                                                      "Закрытие вкладки",
                                                      MessageBoxButtons.YesNoCancel,
                                                      MessageBoxIcon.Warning);
                if (result == DialogResult.Cancel)
                {
                    return;
                }
                if (result == DialogResult.Yes)
                {
                    var saveDialog = new SaveFileDialog();
                    saveDialog.Filter = "Текстовый файл *.txt|*.txt|Rich text file *.rtf|*.rtf";

                    if (saveDialog.ShowDialog() == DialogResult.Cancel)
                        return;
                    File.WriteAllText(saveDialog.FileName, tabControl.SelectedTab.Controls[1].Text);

                    TabPage tabPage = (TabPage)tabControl.TabPages[tabControl.SelectedIndex];
                    isSaved.RemoveAt(tabControl.SelectedIndex);
                    isOpenedFile.RemoveAt(tabControl.SelectedIndex);
                    editPages.RemoveAt(tabControl.SelectedIndex);
                    tabControl.TabPages.Remove(tabPage);
                }
                if (result == DialogResult.No)
                {
                    TabPage tabPage = (TabPage)tabControl.TabPages[tabControl.SelectedIndex];
                    isSaved.RemoveAt(tabControl.SelectedIndex);
                    isOpenedFile.RemoveAt(tabControl.SelectedIndex);
                    editPages.RemoveAt(tabControl.SelectedIndex);
                    tabControl.TabPages.Remove(tabPage);
                }
            }
        }
        #endregion

        #region Элементы fontDialogPanel
        /// <summary>
        /// Получение комбобокса со шрифтами.
        /// </summary>
        /// <returns></returns>
        private ComboBox GetComboBoxFont()
        {
            var comboBoxFont = new ComboBox();
            comboBoxFont.FlatStyle = FlatStyle.Flat;
            comboBoxFont.Size = new Size(250, 50);
            comboBoxFont.Location = new Point(10, 10);
            comboBoxFont.Items.AddRange(FontFamily.Families.Select(f => f.Name).ToArray());
            comboBoxFont.AutoCompleteMode = AutoCompleteMode.Suggest;
            comboBoxFont.AutoCompleteSource = AutoCompleteSource.ListItems;
            comboBoxFont.SelectedIndexChanged += ComboBoxFont_SelectedIndexChanged;
            comboBoxFont.KeyUp += ComboBox_KeyUp;
            return comboBoxFont;
        }

        /// <summary>
        /// Получение комбобокса с размерами шрифта.
        /// </summary>
        /// <returns></returns>
        private ComboBox GetComboBoxSize()
        {
            var comboBoxSize = new ComboBox();
            comboBoxSize.FlatStyle = FlatStyle.Flat;
            comboBoxSize.Size = new Size(100, 50);
            comboBoxSize.Location = new Point(270, 10);
            comboBoxSize.Items.AddRange(Enumerable.Range(9, 100).Select(n => n.ToString()).ToArray());
            comboBoxSize.SelectedIndexChanged += ComboBoxSize_SelectedIndexChanged;
            comboBoxSize.KeyUp += ComboBox_KeyUp;
            return comboBoxSize;
        }

        /// <summary>
        /// Получение кнопки жирного шрифта.
        /// </summary>
        /// <returns>Кнопку с соответсвующими событиями.</returns>
        private Button GetBoldButton()
        {
            var tip = new ToolTip();
            var boldButton = new Button();
            tip.SetToolTip(boldButton, "Жирный");
            boldButton.Text = "Ж";
            boldButton.Font = new Font("Arial", 15, FontStyle.Bold);
            boldButton.Size = new Size(50, 50);
            boldButton.Location = new Point(10, 60);
            boldButton.BackColor = Color.White;
            boldButton.FlatStyle = FlatStyle.Flat;
            boldButton.FlatAppearance.BorderSize = 0;
            boldButton.Click += BoldButton_Click;
            return boldButton;
        }

        /// <summary>
        /// Получение кнопки курсива.
        /// </summary>
        /// <returns>Кнопку с соответсвующими событиями.</returns>
        private Button GetItalicButton()
        {
            var tip = new ToolTip();
            var italicButton = new Button();
            tip.SetToolTip(italicButton, "Курсив");
            italicButton.Text = "К";
            italicButton.Font = new Font("Arial", 15, FontStyle.Italic);
            italicButton.Size = new Size(50, 50);
            italicButton.Location = new Point(65, 60);
            italicButton.BackColor = Color.White;
            italicButton.FlatStyle = FlatStyle.Flat;
            italicButton.FlatAppearance.BorderSize = 0;
            italicButton.Click += ItalicButton_Click;
            return italicButton;
        }

        /// <summary>
        /// Получение кнопки подчеркивания.
        /// </summary>
        /// <returns>Кнопку с соответсвующими событиями.</returns>
        private Button GetUnderlineButton()
        {
            var tip = new ToolTip(); 
            var underlineButton = new Button();
            tip.SetToolTip(underlineButton, "Подчеркнуть");
            underlineButton.Text = "П";
            underlineButton.Font = new Font("Arial", 15, FontStyle.Underline);
            underlineButton.Size = new Size(50, 50);
            underlineButton.Location = new Point(120, 60);
            underlineButton.BackColor = Color.White;
            underlineButton.FlatStyle = FlatStyle.Flat;
            underlineButton.FlatAppearance.BorderSize = 0;
            underlineButton.Click += UnderlineButton_Click;
            return underlineButton;
        }

        /// <summary>
        /// Получение кнопки зачеркивания.
        /// </summary>
        /// <returns>Кнопку с соответсвующими событиями.</returns>
        private Button GetCrossButton()
        {
            var tip = new ToolTip();
            var crossButton = new Button();
            tip.SetToolTip(crossButton, "Зачеркнуть");
            crossButton.Text = "З";
            crossButton.Font = new Font("Arial", 15, FontStyle.Strikeout);
            crossButton.Size = new Size(50, 50);
            crossButton.Location = new Point(175, 60);
            crossButton.BackColor = Color.White;
            crossButton.FlatStyle = FlatStyle.Flat;
            crossButton.FlatAppearance.BorderSize = 0;
            crossButton.Click += CrossButton_Click;
            return crossButton;
        }
        #endregion

        #region Открытие и сохранение фалов
        /// <summary>
        /// Вспомогательный метод для открытия файла.
        /// </summary>
        private void OpenFile()
        {
            if (isOpenedFile[tabControl.SelectedIndex] != null || !isSaved[tabControl.SelectedIndex])
            {
                CreateTab();
                SetFormTheme();
            }
            OpenFileDialog dialog = new() { InitialDirectory = Directory.GetCurrentDirectory() };
            var text = (RichTextBox)tabControl.SelectedTab.Controls[1];
            dialog.Filter = "Текстовый файл *.txt|*.txt|Rich text file *.rtf|*.rtf|Все файлы|*.*";
            if (dialog.ShowDialog() == DialogResult.Cancel)
                return;
            editPages[tabControl.SelectedIndex] = File.ReadAllText(dialog.FileName);
            try
            {
                if (dialog.FileName.Split('\\')[^1].Split('.')[^1] == "rtf")
                    text.LoadFile(dialog.FileName);
                else
                    text.Text = File.ReadAllText(dialog.FileName);
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
            text.Select(text.Text.Length, 0);
            tabControl.SelectedTab.Text = dialog.FileName.Split('\\')[^1];
            isSaved[tabControl.SelectedIndex] = true;
            isOpenedFile[tabControl.SelectedIndex] = dialog.FileName;
        }

        /// <summary>
        /// Вспомогательный метод для сохранения файла.
        /// </summary>
        private void SaveFile()
        {
            SaveFileDialog dialog = new() { InitialDirectory = Directory.GetCurrentDirectory() };
            dialog.Filter = "Текстовый файл *.txt|*.txt|Rich text file *.rtf|*.rtf|Все файлы|*.*";
            var text = (RichTextBox)tabControl.SelectedTab.Controls[1];

            if (isOpenedFile[tabControl.SelectedIndex] != null && !isSaved[tabControl.SelectedIndex])
            {
                if (tabControl.SelectedTab.Text.TrimEnd('*').Split('.')[^1] == "rtf")
                {
                    text.SaveFile(isOpenedFile[tabControl.SelectedIndex].TrimEnd('*'));
                }
                else
                {
                    File.WriteAllText(isOpenedFile[tabControl.SelectedIndex], tabControl.SelectedTab.Controls[1].Text);
                }
                isSaved[tabControl.SelectedIndex] = true;
                tabControl.SelectedTab.Text = tabControl.SelectedTab.Text.TrimEnd('*');
                editPages[tabControl.SelectedIndex] = new(tabControl.SelectedTab.Controls[1].Text);
            }
            if ((isOpenedFile[tabControl.SelectedIndex] == null && !isSaved[tabControl.SelectedIndex]))
            {
                if (dialog.ShowDialog() == DialogResult.Cancel)
                    return;

                if (dialog.FileName.Split('\\')[^1].Split('.')[^1] == "rtf")
                    text.SaveFile(dialog.FileName);
                else
                    File.WriteAllText(dialog.FileName, tabControl.SelectedTab.Controls[1].Text);

                isOpenedFile[tabControl.SelectedIndex] = dialog.FileName;
                isSaved[tabControl.SelectedIndex] = true;
                tabControl.SelectedTab.Text = dialog.FileName.Split('\\')[^1];
                editPages[tabControl.SelectedIndex] = new(tabControl.SelectedTab.Controls[1].Text);
            }
        }

        /// <summary>
        /// Вспомогательный метод для сохранения Файла.
        /// </summary>
        private void SaveAsFile()
        {
            SaveFileDialog dialog = new() { InitialDirectory = Directory.GetCurrentDirectory() };
            dialog.Filter = "Текстовый файл *.txt|*.txt|Rich text file *.rtf|*.rtf|Все файлы|*.*";
            var text = (RichTextBox)tabControl.SelectedTab.Controls[1];
            if (dialog.ShowDialog() == DialogResult.Cancel)
                return;

            if (dialog.FileName.Split('\\')[^1].Split('.')[^1] == "rtf")
                text.SaveFile(dialog.FileName);
            else
                File.WriteAllText(dialog.FileName, tabControl.SelectedTab.Controls[1].Text);

            if (isOpenedFile[tabControl.SelectedIndex] != null)
            {
                CreateTab();
                SetFormTheme();
                text = (RichTextBox)tabControl.SelectedTab.Controls[1];
                if (dialog.FileName.Split('\\')[^1].Split('.')[^1] == "rtf")
                    text.LoadFile(dialog.FileName);
                else
                    text.Text = File.ReadAllText(dialog.FileName);
            }
            isOpenedFile[tabControl.SelectedIndex] = dialog.FileName;
            isSaved[tabControl.SelectedIndex] = true;
            tabControl.SelectedTab.Text = dialog.FileName.Split('\\')[^1];
            editPages[tabControl.SelectedIndex] = new(tabControl.SelectedTab.Controls[1].Text);
        }
        #endregion
    }
}
