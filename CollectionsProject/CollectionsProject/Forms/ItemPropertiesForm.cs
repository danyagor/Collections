using System;
using System.Data;
using System.Collections.Generic;
using System.Windows.Forms;
using CollectionsProject.CustomComponents;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;

namespace CollectionsProject.Forms
{
    public partial class ItemPropertiesForm : Form
    {
        MainForm mf;
        int typeId;
        string collectionName;
        string foreignTableName;
        int itemId;

        List<TextField> textFields;
        Field[] fields;

        Image[] images;
        string[] comments;

        // Конструктор для добавления предмета
        public ItemPropertiesForm(MainForm mf, int typeId, string collectionName, string foreignTableName = "")
        {
            InitializeComponent();

            this.mf = mf;
            this.typeId = typeId;
            this.collectionName = collectionName;
            this.foreignTableName = foreignTableName;

            images = new Image[4];
            comments = new string[4];
            textFields = new List<TextField>();
            if (foreignTableName == "")
                fields = CollectionTypes.GetCollection(typeId)[0].Fields;
            else
            {
                fields = CollectionTypes.GetCollection(typeId)[foreignTableName].Fields;
                tabControl.TabPages.RemoveAt(2);
            }

            AddTextFields();
            btnEditItem.Text = "Добавить предмет в коллекцию";
        }

        // Конструктор для изменения предмета
        public ItemPropertiesForm(MainForm mf, int typeId, string collectionName, int itemId, string foreignTableName = "")
        {
            InitializeComponent();

            this.mf = mf;
            this.typeId = typeId;
            this.collectionName = collectionName;
            this.itemId = itemId;
            this.foreignTableName = foreignTableName;

            images = new Image[4];
            comments = new string[4];
            textFields = new List<TextField>();
            if (foreignTableName == "")
                fields = CollectionTypes.GetCollection(typeId)[0].Fields;
            else
            {
                fields = CollectionTypes.GetCollection(typeId)[foreignTableName].Fields;
                tabControl.TabPages.RemoveAt(2); // Удаление вкладки фотографий
            }

            AddTextFields();
            InsertDataInTextFields();
            btnEditItem.Text = "Изменить данные о предмете";
        }

        // Создание текстовых полей
        private void AddTextFields()
        {
            foreach (Field field in fields)
            {
                string reqStr = "";
                if (field.RequiredField)
                    reqStr = "*";

                // Внешнее поле
                if (field.ForeignKey)
                {
                    // Получение во внешней таблице значений и вывод в текущий ComboBox
                    TextField tf = new TextField(field.ProgramName + reqStr, field.BaseName, true);
                    DataTable dt = new DataTable();
                    dt = mf.CurrentDatabase.GetDataFromForeignTable(typeId, collectionName, field.ForeignTable);
                    //dt.Rows.Add("-1", "Добавить новый элемент...");
                    tf.CB.DataSource = dt;
                    tf.CB.ValueMember = "id";
                    tf.CB.DisplayMember = "data";
                    tf.CB.DropDownStyle = ComboBoxStyle.DropDownList;
                    tf.CB.SelectedValueChanged += CB_SelectedValueChanged;
                    if (tf.CB.Items.Count != 0)
                        tf.CB.SelectedIndex = 0;

                    flowLayoutPanel.Controls.Add(tf);
                    textFields.Add(tf);
                }
                else // Обычное поле
                {
                    TextField tf = new TextField(field.ProgramName + reqStr, field.BaseName, false);
                    
                    flowLayoutPanel.Controls.Add(tf);
                    textFields.Add(tf);
                }
            }
        }

        private void CB_SelectedValueChanged(object sender, EventArgs e)
        {
            ComboBox cb = (ComboBox)sender;
            //if (cb.SelectedValue.ToString() == "-1")
            //{
            //    ItemPropertiesForm ifp = new ItemPropertiesForm(mf, typeId, collectionName, )
            //}
        }

        // Вставление данных о предмете
        private void InsertDataInTextFields()
        {
            if (itemId != 0)
            {
                DataRow itemData;
                if (foreignTableName == "")
                    itemData = mf.CurrentDatabase.GetItemFromCollection(typeId, itemId, collectionName);
                else
                    itemData = mf.CurrentDatabase.GetItemFromCollection(typeId, itemId, collectionName, foreignTableName);

                int textFieldsCounter = 0;
                for (int i = 0; i < itemData.ItemArray.Length; i++)
                {
                    if (itemData.Table.Columns[i].ColumnName != "id" &&
                        itemData.Table.Columns[i].ColumnName != "uploadDate" &&
                        itemData.Table.Columns[i].ColumnName != "changeDate" &&
                        itemData.Table.Columns[i].ColumnName != "note" &&
                        itemData.Table.Columns[i].ColumnName != "photo1" &&
                        itemData.Table.Columns[i].ColumnName != "photo2" &&
                        itemData.Table.Columns[i].ColumnName != "photo3" &&
                        itemData.Table.Columns[i].ColumnName != "photo4" &&
                        itemData.Table.Columns[i].ColumnName != "comment1" &&
                        itemData.Table.Columns[i].ColumnName != "comment2" &&
                        itemData.Table.Columns[i].ColumnName != "comment3" &&
                        itemData.Table.Columns[i].ColumnName != "comment4")
                    {
                        if (fields[textFieldsCounter].ForeignKey)
                            textFields[textFieldsCounter].CB.SelectedValue = itemData.ItemArray[i];
                        else
                            textFields[textFieldsCounter].Value = itemData.ItemArray[i].ToString();

                        textFieldsCounter++;
                    }
                }

                
                for (int i = 0; i < itemData.Table.Columns.Count; i++)
                {
                    // Описание
                    if (itemData.Table.Columns[i].ColumnName == "note")
                        tbNote.Text = itemData.ItemArray[i].ToString();

                    // Фотографии
                    if (itemData.Table.Columns[i].ColumnName == "photo1")
                        if (itemData.ItemArray[i].ToString() != "")
                            images[0] = ByteToImage((byte[])itemData.ItemArray[i]);
                    if (itemData.Table.Columns[i].ColumnName == "photo2")
                        if (itemData.ItemArray[i].ToString() != "")
                            images[1] = ByteToImage((byte[])itemData.ItemArray[i]);
                    if (itemData.Table.Columns[i].ColumnName == "photo3")
                        if (itemData.ItemArray[i].ToString() != "")
                            images[2] = ByteToImage((byte[])itemData.ItemArray[i]);
                    if (itemData.Table.Columns[i].ColumnName == "photo4")
                        if (itemData.ItemArray[i].ToString() != "")
                            images[3] = ByteToImage((byte[])itemData.ItemArray[i]);

                    // Комментарии
                    if (itemData.Table.Columns[i].ColumnName == "comment1")
                        comments[0] = itemData.ItemArray[i].ToString();
                    if (itemData.Table.Columns[i].ColumnName == "comment2")
                        comments[1] = itemData.ItemArray[i].ToString();
                    if (itemData.Table.Columns[i].ColumnName == "comment3")
                        comments[2] = itemData.ItemArray[i].ToString();
                    if (itemData.Table.Columns[i].ColumnName == "comment4")
                        comments[3] = itemData.ItemArray[i].ToString();
                }
            }
        }

        // Конвертирует массив байтов в картинку
        public Image ByteToImage(byte[] imageBytes)
        {
            if (imageBytes.Length == 0)
                return null;

            MemoryStream ms = new MemoryStream(imageBytes, 0, imageBytes.Length);
            ms.Write(imageBytes, 0, imageBytes.Length);
            Image image = new Bitmap(ms);
            return image;
        }

        private ItemImage[] GetItemImages()
        {
            List<ItemImage> itemImages = new List<ItemImage>();
            for (int i = 0; i < images.Length; i++)
            {
                //Image resizedImage = ResizeImage(images[i], 400, 400);
                if (images[i] != null)
                {
                    MemoryStream ms = new MemoryStream();
                    images[i].Save(ms, ImageFormat.Jpeg);
                    byte[] bytes = ms.ToArray();
                    itemImages.Add(new ItemImage(bytes, comments[i]));
                }
                else
                    itemImages.Add(new ItemImage(null, ""));
            }

            return itemImages.ToArray();
        }

        // Редактирование предмета
        private void btnEditItem_Click(object sender, EventArgs e)
        {
            string[] userText = new string[textFields.Count];

            // Проверка на введенность всех обязательных полей
            bool requiredCheck = true;
            for (int i = 0; i < fields.Length; i++)
            {
                if (fields[i].RequiredField && textFields[i].Value == "")
                {
                    requiredCheck = false;
                    break;
                }
            }

            if (requiredCheck)
            {
                for (int i = 0; i < fields.Length; i++)
                {
                    if (textFields[i].Identificated)
                    {
                        if (textFields[i].CB.Items.Count != 0)
                            userText[i] = textFields[i].CB.SelectedValue.ToString();
                    }
                    else
                        userText[i] = textFields[i].Value;
                }

                if (itemId == 0) // Добавление
                {
                    if (foreignTableName == "")
                        mf.CurrentDatabase.AddItem(typeId, userText, tbNote.Text, collectionName, "", GetItemImages());
                    else
                        mf.CurrentDatabase.AddItem(typeId, userText, tbNote.Text, collectionName, foreignTableName);
                }
                else // Обновление
                {
                    if (foreignTableName == "")
                        mf.CurrentDatabase.UpdateItem(typeId, itemId, userText, tbNote.Text, collectionName, "", GetItemImages());
                    else
                        mf.CurrentDatabase.UpdateItem(typeId, itemId, userText, tbNote.Text, collectionName, foreignTableName);
                }

                Close();
            }
            else
                MessageBox.Show("Введены не все обязательные поля");
        }

        private void lbPhotos_SelectedIndexChanged(object sender, EventArgs e)
        {
            pbPhoto.Image = images[lbPhotos.SelectedIndex];
            tbComment.Text = comments[lbPhotos.SelectedIndex];
        }

        private void btnAssign_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "Файлы изображений| *.jpg; *.jpeg; *.png";
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                images[lbPhotos.SelectedIndex] = Image.FromFile(ofd.FileName);
                pbPhoto.Image = images[lbPhotos.SelectedIndex];
            }
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            images[lbPhotos.SelectedIndex] = null;
            pbPhoto.Image = null;

            comments[lbPhotos.SelectedIndex] = "";
            tbComment.Text = "";
        }

        private void tbComment_Leave(object sender, EventArgs e)
        {
            comments[lbPhotos.SelectedIndex] = tbComment.Text;
        }

        private void tabControl_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (tabControl.SelectedTab.Text == "Фотографии")
                lbPhotos.SelectedIndex = 0;
        }
    }
}
