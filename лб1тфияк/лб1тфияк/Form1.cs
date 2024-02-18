using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Diagnostics;
namespace лб1тфияк
{
    public partial class Form1 : Form
    {
        private int fileCounter = 1;
        private string openedFilePath;
        public Form1()
        {
            InitializeComponent();
        }



       

        private void создатьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string folderPath = @"C:\Users\Ольга\source\repos\лб1тфияк\лб1тфияк\bin\Debug\netcoreapp3.1";
            try
            {
                string fileName = $"File{fileCounter}.txt";
                string filePath = Path.Combine(folderPath, fileName);
                // Создание файла
                File.WriteAllText(filePath, $"Содержимое файла {fileCounter}");
                MessageBox.Show($"Файл {fileName} успешно создан.", "Успех", MessageBoxButtons.OK, MessageBoxIcon.Information);

                fileCounter++;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Произошла ошибка: {ex.Message}", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private bool CheckForChanges()
        {
            if (richTextBox1.Modified)
            {
                DialogResult result = MessageBox.Show("Хотите сохранить изменения?", "Предупреждение", MessageBoxButtons.YesNoCancel);
                if (result == DialogResult.Yes)
                {
                    SaveChanges();
                }
                else if (result == DialogResult.Cancel)
                {
                    return false;
                }
            }
            return true;
        }

        private void открытьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!CheckForChanges())
            {
                return;
            }
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.Filter = "Текстовые файлы (*.txt)|*.txt|Все файлы (*.*)|*.*";

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    string filePath = openFileDialog.FileName;

                    try
                    {
                        // Считываем содержимое файла
                        string fileContent = File.ReadAllText(filePath);

                        // Устанавливаем текст в RichTextBox
                        richTextBox1.Text = fileContent;
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Ошибка при открытии файла: {ex.Message}", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

               
        private void сохранитьToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }


        private void сохранитьКакToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(openedFilePath))
            {
                // Если файл не был открыт ранее, используйте диалог сохранения
                using (SaveFileDialog saveFileDialog = new SaveFileDialog())
                {
                    saveFileDialog.Filter = "Текстовые файлы (*.txt)|*.txt|Все файлы (*.*)|*.*";

                    if (saveFileDialog.ShowDialog() == DialogResult.OK)
                    {
                        openedFilePath = saveFileDialog.FileName;
                    }
                    else
                    {
                        return; // Пользователь отменил сохранение
                    }
                }
            }

            try
            {
                // Сохраняем содержимое RichTextBox в тот же файл
                File.WriteAllText(openedFilePath, richTextBox1.Text);
                MessageBox.Show("Файл успешно сохранен", "Успех", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при сохранении файла: {ex.Message}", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            richTextBox1.Modified = false;
        }

        private void выделитьВсеToolStripMenuItem_Click(object sender, EventArgs e)
        {
            richTextBox1.SelectAll();
        }

        private void удалитьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (richTextBox1.SelectionLength > 0)
            {
                richTextBox1.SelectedText = "";
            }
        }

        private void копироватьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (richTextBox1.SelectionLength > 0)
            {
                Clipboard.SetText(richTextBox1.SelectedText);
            }
        }

        private void вставитьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (Clipboard.ContainsText())
            {
                richTextBox1.SelectedText = Clipboard.GetText();
            }
        }

        private void вырезатьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (richTextBox1.SelectionLength > 0)
            {
                Clipboard.SetText(richTextBox1.SelectedText);
                richTextBox1.SelectedText = "";
            }
        }

        private void отменитьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (richTextBox1.CanUndo)
            {
                richTextBox1.Undo();
            }
        }

        private void повторитьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (richTextBox1.CanRedo)
            {
                richTextBox1.Redo();
            }
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            string folderPath = @"C:\Users\Ольга\source\repos\лб1тфияк\лб1тфияк\bin\Debug\netcoreapp3.1";
            try
            {
                string fileName = $"File{fileCounter}.txt";
                string filePath = Path.Combine(folderPath, fileName);
                // Создание файла
                File.WriteAllText(filePath, $"Содержимое файла {fileCounter}");
                MessageBox.Show($"Файл {fileName} успешно создан.", "Успех", MessageBoxButtons.OK, MessageBoxIcon.Information);

                fileCounter++;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Произошла ошибка: {ex.Message}", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            if (!CheckForChanges())
            {
                return;
            }
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.Filter = "Текстовые файлы (*.txt)|*.txt|Все файлы (*.*)|*.*";

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    openedFilePath = openFileDialog.FileName;

                    try
                    {
                        // Считываем содержимое файла
                        string fileContent = File.ReadAllText(openedFilePath);

                        // Устанавливаем текст в RichTextBox
                        richTextBox1.Text = fileContent;
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Ошибка при открытии файла: {ex.Message}", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        private void toolStripButton3_Click(object sender, EventArgs e)
        {
            try
            {
                if (!string.IsNullOrEmpty(openedFilePath))
                {
                    // Сохраняем содержимое RichTextBox в тот же файл
                    File.WriteAllText(openedFilePath, richTextBox1.Text);
                    MessageBox.Show("Файл успешно сохранен", "Успех", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    // Если openedFilePath не установлена, используйте диалог сохранения
                    SaveFileDialog saveFileDialog = new SaveFileDialog();
                    saveFileDialog.Filter = "Текстовые файлы (*.txt)|*.txt|Все файлы (*.*)|*.*";

                    if (saveFileDialog.ShowDialog() == DialogResult.OK)
                    {
                        openedFilePath = saveFileDialog.FileName;
                        // Сохраняем содержимое RichTextBox в новый файл
                        File.WriteAllText(openedFilePath, richTextBox1.Text);
                        MessageBox.Show("Файл успешно сохранен", "Успех", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при сохранении файла: {ex.Message}", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            richTextBox1.Modified = false;
        }

        private void toolStripButton4_Click(object sender, EventArgs e)
        {
            if (richTextBox1.CanUndo)
            {
                richTextBox1.Undo();
            }
        }

        private void toolStripButton5_Click(object sender, EventArgs e)
        {

            if (richTextBox1.CanRedo)
            {
                richTextBox1.Redo();
            }
        }

        private void toolStripButton11_Click(object sender, EventArgs e)
        {

            if (richTextBox1.SelectionLength > 0)
            {
                Clipboard.SetText(richTextBox1.SelectedText);
            }
        }

        private void toolStripButton6_Click(object sender, EventArgs e)
        {
            if (richTextBox1.SelectionLength > 0)
            {
                Clipboard.SetText(richTextBox1.SelectedText);
                richTextBox1.SelectedText = "";
            }
        }

        private void toolStripButton7_Click(object sender, EventArgs e)
        {
            if (Clipboard.ContainsText())
            {
                richTextBox1.SelectedText = Clipboard.GetText();
            }
        }
        private bool IsRichTextBoxModified()
        {
            return richTextBox1.Modified;
        }

        private void PromptToSaveChanges()
        {
            if (IsRichTextBoxModified())
            {
                DialogResult result = MessageBox.Show("Сохранить изменения?", "Предупреждение", MessageBoxButtons.YesNoCancel);

                if (result == DialogResult.Yes)
                {
                    SaveChanges();
                    Close();
                }
                else if (result == DialogResult.Cancel)
                {
                    return;
                }
                else if (result == DialogResult.No)
                {
                    Close();
                }
            }
        }

        private void SaveChanges()
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "Текстовые файлы|*.txt|Все файлы|*.*";

            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                richTextBox1.SaveFile(saveFileDialog.FileName, RichTextBoxStreamType.PlainText);
                richTextBox1.Modified = false;
            }
        }
        private void выходToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (IsRichTextBoxModified())
            {
                PromptToSaveChanges();
            }
            else
            {
                Close();
            }
        }

        private void richTextBox2_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }
        private void Information()
        {
            MessageBox.Show("Для создания файла в меню нажать ФАЙЛ -> СОЗДАТЬ\n" +
                "Для открытия файла в меню нажать ФАЙЛ -> ОТКРЫТЬ (если вы не сохранили файл, при нажатии на открытие другого файла, будет уведомление о возможности сохранения)\n " +
                "Для сохранения файла нажать в меню ФАЙЛ -> СОХРАНИТЬ КАК и выбрать папку куда сохранить\n" +
                "Для выхода из программы нажать в меню ФАЙЛ -> ВЫХОД (если вы не сохранили файл, при нажатии на выход, будет уведомление о возможности сохранения)\n" +
                "Для отмены действия нажмите в меню ПРАВКА -> ОТМЕНИТЬ\n" +
                "Для повторения действия нажмите в меню ПРАВКА -> ПОВТОРИТЬ\n" +
                "Для того, чтобы вырезать фрагмент нажмите в меню ПРАВКА -> ВЫРЕЗАТЬ\n" +
                "Для того, чтобы копировать фрагмент нажмите в меню ПРАВКА -> КОПИРОВАТЬ\n" +
                "Для того, чтобы удалить фрагмент нажмите в меню ПРАВКА -> УДАЛИТЬ\n" +
                "Для того, чтобы выделить весь текст нажмите в меню ПРАВКА -> ВЫДЕЛИТЬ ВСЕ\n" +
                "Для вызова справки (руководства пользователя) нажмите в меню СПРАВКА -> ВЫЗОВ СПРАВКИ\n" +
                "Для вызова информации о программе нажмите СПРАВКА -> О ПРОГРАММЕ\n" +
                "Панель инструментов содержит кнопки вызова часто используемых пунктов меню\n");
        }
        private void вызовСправкиToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Information();
            //Process.Start(@"C:\Users\Ольга\source\repos\лб1тфияк\лб1тфияк\bin\Debug\netcoreapp3.1\y.html");
       
        }

        private void toolStripButton9_Click(object sender, EventArgs e)
        {
            Information();
        }
        private void About_program()
        {
            MessageBox.Show("Программа разаработана Моревой Ольгой в 2024 году\n" +
                "По всем вопросам обращаться по телефону 89612243308\n" +
                "Все права защищены нот копи плиз\n");
        }

        private void оПрограммеToolStripMenuItem_Click(object sender, EventArgs e)
        {
            About_program();
        }

        private void toolStripButton10_Click(object sender, EventArgs e)
        {
            About_program();
        }
    }
}
    