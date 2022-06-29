using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Notepad
{
    public partial class SettingsForm : Form
    {
        #region Конструктор
        public SettingsForm()
        {
            InitializeComponent();
        }
        #endregion

        #region Обработка событий
        /// <summary>
        /// Обработчик события загрузки формы.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SettingsForm_Load(object sender, EventArgs e)
        {
            themeComboBox.SelectedItem = MainForm.themeLight ? themeComboBox.Items[0] : themeComboBox.Items[1];
            AutosaveComboBox.SelectedItem = AutosaveComboBox.Items[GetNumberItem(MainForm.intervalAutosave)];
        }

        /// <summary>
        /// Обработчик события кнопки отмены.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CancelButton_Click(object sender, EventArgs e)
        {
            Close();
        }

        /// <summary>
        /// Обработчик события применения изменений.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ApplyButton_Click(object sender, EventArgs e)
        {
            MainForm.themeLight = this.ForeColor == Color.Black;
            MainForm.intervalAutosave = GetInterval(AutosaveComboBox.SelectedItem.ToString());
            Close();
        }

        /// <summary>
        /// Отобразить изменения темы на вспомогательной форме.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void themeComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            var themeComboBox = (ComboBox)sender;
            if (themeComboBox.SelectedItem.ToString() == "Темная тема")
            {
                themeComboBox.BackColor = Color.FromArgb(45, 45, 45);
                themeComboBox.ForeColor = Color.White;
                this.ForeColor = Color.White;
                this.BackColor = Color.FromArgb(30, 30, 30);
                ApplyButton.BackColor = Color.FromArgb(45, 45, 45);
                CancelButton.BackColor = Color.FromArgb(45, 45, 45);
            }
            else
            {
                themeComboBox.BackColor = Color.White;
                themeComboBox.ForeColor = Color.Black;
                this.ForeColor = Color.Black;
                this.BackColor = Color.White;
                ApplyButton.BackColor = Color.White;
                CancelButton.BackColor = Color.White;
            }
        }
        #endregion

        #region Вспомогательные методы
        /// <summary>
        /// Вспомогательный метод получение интервала срабатывания автосохранения в миллисекундах.
        /// </summary>
        /// <param name="selectedItem"></param>
        /// <returns></returns>
        private int GetInterval(string selectedItem)
        {
            return selectedItem switch
            {
                "Нет" => 1,
                "1 минута" => 60000,
                "2 минуты" => 120000,
                "3 минуты" => 180000,
                "5 минут" => 300000,
                "10 минут" => 600000,
                _ => 1
            };
        }

        /// <summary>
        /// Вспомогательный метод получения номера элемента в ComboBox.
        /// </summary>
        /// <param name="interval"></param>
        /// <returns></returns>
        private int GetNumberItem(int interval)
        {
            return interval switch
            {
                1 => 0,
                60000 => 1,
                120000 => 2,
                180000 => 3,
                300000 => 4,
                600000 => 5,
                _ => 0
            };
        }
        #endregion
    }
}
