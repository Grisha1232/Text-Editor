using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Notepad
{
    static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            #region Обработка любой ошибки и вывод предложения продолжитьили завершить
        again:
            try
            {
                Application.SetHighDpiMode(HighDpiMode.SystemAware);
                Application.EnableVisualStyles();
                Application.Run(new MainForm());
            }
            catch (Exception e)
            {
                Application.Exit();
                DialogResult dialog = MessageBox.Show(e.Message+"\nХотите проидолжить или выйти. Нажмите \"ДА\" если хотите выйти", 
                                                      "Произошла ошибка", 
                                                      MessageBoxButtons.YesNo,
                                                      MessageBoxIcon.Warning);
                if (dialog == DialogResult.Yes)
                {
                    Application.Exit();
                }
                else
                {
                    Application.ExitThread();
                    goto again;
                }
            }
            #endregion
        }
    }
}