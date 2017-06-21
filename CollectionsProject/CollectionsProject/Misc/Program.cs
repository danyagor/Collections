using System;
using System.Windows.Forms;

namespace CollectionsProject
{
    static class Program
    {
        /// <summary>
        /// Главная точка входа для приложения.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            
            MainForm mf = new MainForm();

            // Удаление не существующих путей файлов
            XmlHelper.DeleteNotExistsLastFiles();

            // Открытие последнего открытого файла базы
            string fileToOpen = XmlHelper.GetLastActiveFile();
            if (fileToOpen != null)
                mf.OpenDatabaseByPath(fileToOpen);
            
            Application.Run(mf);
        }
    }
}
