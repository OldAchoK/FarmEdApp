using VaitsekhovskiiOS.classes;
using System.IO;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace VaitsekhovskiiOS
{
    public partial class Form1 : Form
    {
        private Farm cache = new Farm();
        private string userAnswer;
        private List<Animal> listBase = new List<Animal>();
        int rowIndex;
        public Form1()
        {
            InitializeComponent();
            userAnswer = string.Empty;
            rowIndex = -1;
        }
        
        private void Form1_Load(object sender, EventArgs e)
        {
            dataGridView1.Rows.Clear();
            delete.Rows.Clear();
            delete.ReadOnly = true;
            delete.AllowUserToOrderColumns = false;
            delete.AllowUserToAddRows = false;
            dataGridView1.ReadOnly = true;
            dataGridView1.AllowUserToOrderColumns = false;
            dataGridView1.AllowUserToAddRows = false;
            deleteAnimalToolStripMenuItem.Enabled = false;
            addNewAnimalToolStripMenuItem.Enabled = false;
            showTableToolStripMenuItem.Enabled = false;

            Start.Visible = true;
            addBox.Visible = false;
            deleteBox.Visible = false;
            Filter.Visible = false;
            textBox2.Enabled = false;
            textBox3.Enabled = false;
            comboBox3.Enabled = false;
            checkBox1.Enabled = false;
            button1.Enabled = false;
            label8.Text = String.Empty;

            dataGridView1.Columns.Add("Name", "Name");
            dataGridView1.Columns.Add("Weight", "Weight");
            dataGridView1.Columns.Add("Type", "Type");
            dataGridView1.AutoSizeColumnsMode= DataGridViewAutoSizeColumnsMode.Fill;
            delete.Columns.Add("Name", "Name");
            delete.Columns.Add("Weight", "Weight");
            delete.Columns.Add("Type", "Type");
            delete.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            foreach (DataGridViewColumn column in dataGridView1.Columns)
            {
                column.SortMode = DataGridViewColumnSortMode.NotSortable;
            }
            foreach (DataGridViewColumn column in delete.Columns)
            {
                column.SortMode = DataGridViewColumnSortMode.NotSortable;
            }
            delete.SelectionMode = DataGridViewSelectionMode.RowHeaderSelect;
            dataGridView1.SelectionMode = DataGridViewSelectionMode.RowHeaderSelect;
        }

        private void radioButton_CheckedChanged(object sender, EventArgs e)
        {
            if(sender!=null)
            {
                if ((sender as RadioButton).Name == radioButton1.Name)
                {
                    textBox2.Enabled = true;
                    textBox3.Enabled = true;
                    comboBox3.Enabled = false;
                    checkBox1.Enabled = false;
                    textBox2.Text = String.Empty;
                    textBox3.Text = String.Empty;
                    comboBox3.SelectedIndex = 0;
                    checkBox1.Checked = false;
                    button1.Enabled = false;
                }
                if ((sender as RadioButton).Name == radioButton2.Name)
                {
                    textBox2.Enabled = true;
                    textBox3.Enabled = true;
                    comboBox3.Enabled = true;
                    checkBox1.Enabled = false;
                    textBox2.Text = String.Empty;
                    textBox3.Text = String.Empty;
                    comboBox3.SelectedIndex = 0;
                    checkBox1.Checked = false;
                    button1.Enabled = false;
                }
                if ((sender as RadioButton).Name == radioButton3.Name)
                {
                    textBox2.Enabled = true;
                    textBox3.Enabled = true;
                    comboBox3.Enabled = true;
                    checkBox1.Enabled = true;
                    textBox2.Text = String.Empty;
                    textBox3.Text = String.Empty;
                    comboBox3.SelectedIndex = 0;
                    checkBox1.Checked = false;
                    button1.Enabled = false;
                }
            }
        }

        private void ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (sender != null)
            {
                if ((sender as ToolStripMenuItem).Name == loadDefaultToolStripMenuItem.Name)
                {
                    listBase.Clear();
                    dataGridView1.Rows.Clear();
                    delete.Rows.Clear();
                    dataGridView1.Refresh();
                    delete.Refresh();
                    userAnswer = "Default.txt";
                    listBase = cache.OpenFile(userAnswer);
                    cache.GridFiller(dataGridView1, listBase);
                    cache.GridFiller(delete, listBase);
                    MessageBox.Show("Sucessfull import", "File Content at path: " + userAnswer, MessageBoxButtons.OK);
                    deleteAnimalToolStripMenuItem.Enabled = true;
                    addNewAnimalToolStripMenuItem.Enabled = true;
                    showTableToolStripMenuItem.Enabled = true;
                    label8.Text = userAnswer;
                    comboBox1.SelectedIndex = 0;
                    comboBox2.SelectedIndex = 0;
                }
                if ((sender as ToolStripMenuItem).Name == openToolStripMenuItem.Name)
                {
                    listBase.Clear();
                    dataGridView1.Rows.Clear();
                    delete.Rows.Clear();
                    dataGridView1.Refresh();
                    delete.Refresh();

                    using (OpenFileDialog openFileDialog = new OpenFileDialog())
                    {
                        openFileDialog.InitialDirectory = "c:\\";
                        openFileDialog.Filter = "txt files (*.txt)|*.txt|All files (*.*)|*.*";
                        openFileDialog.FilterIndex = 2;
                        openFileDialog.RestoreDirectory = true;

                        if (openFileDialog.ShowDialog() == DialogResult.OK)
                        {
                            userAnswer = openFileDialog.FileName;
                            listBase = cache.OpenFile(userAnswer);
                            cache.GridFiller(dataGridView1, listBase);
                            cache.GridFiller(delete, listBase);
                            MessageBox.Show("Sucessfull import", "File Content at path: " + userAnswer, MessageBoxButtons.OK);
                        }
                    }

                    deleteAnimalToolStripMenuItem.Enabled = true;
                    addNewAnimalToolStripMenuItem.Enabled = true;
                    showTableToolStripMenuItem.Enabled = true;
                    label8.Text = userAnswer;
                    comboBox1.SelectedIndex = 0;
                    comboBox2.SelectedIndex = 0;
                }
                if ((sender as ToolStripMenuItem).Name == newToolStripMenuItem.Name)
                {
                    listBase.Clear();
                    dataGridView1.Rows.Clear();
                    delete.Rows.Clear();
                    dataGridView1.Refresh();
                    delete.Refresh();
                    deleteAnimalToolStripMenuItem.Enabled = true;
                    addNewAnimalToolStripMenuItem.Enabled = true;
                    showTableToolStripMenuItem.Enabled = true;
                    userAnswer = Microsoft.VisualBasic.Interaction.InputBox("Choose name for new file ", "Create as", "Animal.txt");
                    cache.CreateEvent += (s, args) =>
                    {
                        MessageBox.Show("File was created", "File " + userAnswer + " was sucessfully created", MessageBoxButtons.OK);
                    };
                    cache.CreateFile(userAnswer);
                    label8.Text = userAnswer;
                    comboBox1.SelectedIndex = 0;
                    comboBox2.SelectedIndex = 0;
                }
                //cut useless feature
                /*if ((sender as ToolStripMenuItem).Name == saveToolStripMenuItem.Name)
                {
                    cache.SaveEvent += (s, args) =>
                    {
                        MessageBox.Show("File was saved", "File was saved", MessageBoxButtons.OK);
                    };
                    cache.SaveFile(listBase);
                }*/
                if ((sender as ToolStripMenuItem).Name == addNewAnimalToolStripMenuItem.Name)
                {
                    Start.Visible = false;
                    addBox.Visible = true;
                    deleteBox.Visible = false;
                    Filter.Visible = false;
                    comboBox1.SelectedIndex = 0;
                    comboBox2.SelectedIndex = 0;
                }
                if ((sender as ToolStripMenuItem).Name == deleteAnimalToolStripMenuItem.Name)
                { 
                    delete.Rows.Clear();
                    delete.Refresh();
                    listBase = cache.OpenFile(userAnswer);
                    Start.Visible = false;
                    addBox.Visible = false;
                    deleteBox.Visible = true;
                    Filter.Visible = false;
                    cache.GridFiller(delete, listBase);
                    comboBox1.SelectedIndex = 0;
                    comboBox2.SelectedIndex = 0;
                }
                if ((sender as ToolStripMenuItem).Name == showTableToolStripMenuItem.Name)
                {
                    button2.Text = "Rise";
                    dataGridView1.Rows.Clear();
                    dataGridView1.Refresh();
                    listBase = cache.OpenFile(userAnswer);
                    Start.Visible = false;
                    addBox.Visible = false;
                    deleteBox.Visible = false;
                    Filter.Visible = true;
                    cache.GridFiller(dataGridView1, listBase);
                    comboBox1.SelectedIndex = 0;
                    comboBox2.SelectedIndex = 0;
                }
                if((sender as ToolStripMenuItem).Name == exitToolStripMenuItem.Name)
                {
                    DialogResult result = MessageBox.Show(
                    "Are you sure?",
                    "Exit",
                    MessageBoxButtons.YesNo);
                    if (result == DialogResult.Yes)
                    {
                        this.Close();
                    }
                }
                
            }
        }

        private void textBox_TextChanged(object sender, EventArgs e)
        {
            if(radioButton1.Checked)
            {
                button1.Enabled = false;
                if (textBox2.Text!=string.Empty&& textBox3.Text != string.Empty && double.TryParse(textBox3.Text, out double d) &&
           !(double.IsNaN(d) && !double.IsInfinity(d)))
                {
                    button1.Enabled = true;
                }
                else button1.Enabled = false;
            }
            if(radioButton2.Checked)
            {
                button1.Enabled = false;
                if (textBox2.Text != string.Empty && textBox3.Text != string.Empty && double.TryParse(textBox3.Text, out double d) &&
           !(double.IsNaN(d) && !double.IsInfinity(d)))
                {
                    button1.Enabled = true;
                }
                else button1.Enabled = false;
            }
            if(radioButton3.Checked)
            {
                button1.Enabled = false;
                if (textBox2.Text != string.Empty && textBox3.Text != string.Empty && double.TryParse(textBox3.Text, out double d) &&
           !(double.IsNaN(d) && !double.IsInfinity(d)))
                {
                    button1.Enabled = true;
                }
                else button1.Enabled = false;
            }
        }

        private void Filters_SelectedIndexChanged(object sender, EventArgs e)
        {
            List<Animal> temp = new List<Animal>();
            listBase = cache.OpenFile(userAnswer);
            switch (comboBox1.SelectedIndex)
            {
                case 0:
                    {
                        temp = listBase;
                        break;
                    }
                case 1:
                    {
                        foreach(var item in listBase.ToList())
                        {
                            if(item.Type=="Animal")
                            {
                                temp.Add(item);
                            }
                        }
                        break;
                    }
                case 2:
                    {
                        foreach (var item in listBase.ToList())
                        {
                            if (item.Type == "Mammal")
                            {
                                temp.Add(item);
                            }
                        }
                        break;
                    }
                case 3:
                    {
                        foreach (var item in listBase.ToList())
                        {
                            if (item.Type == "Artiodactyl")
                            {
                                temp.Add(item);
                            }
                        }
                        break;
                    }
                case 4:
                    {
                        foreach (var item in listBase.ToList())
                        {
                            if (item is Mammal wild && wild.Gender == "Female")
                            {
                                temp.Add(item);
                            }
                        }
                        break;
                    }
                case 5:
                    {
                        foreach (var item in listBase.ToList())
                        {
                            if (item is Mammal wild && wild.Gender == "Male")
                            {
                                temp.Add(item);
                            }
                        }
                        break;
                    }
                case 6:
                    {
                        foreach (var item in listBase.ToList())
                        {
                            if (item is Artiodactyl beast && beast.Horns)
                            {
                                temp.Add(item);
                            }
                        }
                        break;
                    }
                case 7:
                    {
                        foreach (var item in listBase.ToList())
                        {
                            if (item is Artiodactyl beast && beast.Horns== false || item.Type == "Animal" || item.Type == "Mammal")
                            {
                                temp.Add(item);
                            }
                        }
                        break;
                    }
            }
            listBase = temp;
            dataGridView1.Rows.Clear();
            dataGridView1.Refresh();
            cache.GridFiller(dataGridView1, temp);
        }
        private void Sort_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (button2.Text == "Rise")
            {
                listBase = cache.Sort(listBase, comboBox2.SelectedIndex, 0);
            }
            else
            {
                listBase = cache.Sort(listBase, comboBox2.SelectedIndex, 1);
            }
            dataGridView1.Rows.Clear();
            dataGridView1.Refresh();
            cache.GridFiller(dataGridView1, listBase);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if(radioButton1.Checked)
            {
                listBase.Add(new Animal(textBox2.Text, Convert.ToDouble(textBox3.Text)));
                cache.SaveFile(listBase);
            }
            if (radioButton2.Checked)
            {
                listBase.Add(new Mammal(textBox2.Text, Convert.ToDouble(textBox3.Text), comboBox3.Text));
                cache.SaveFile(listBase);
            }
            if (radioButton3.Checked)
            {
                listBase.Add(new Artiodactyl(textBox2.Text, Convert.ToDouble(textBox3.Text), comboBox3.Text, Convert.ToBoolean(checkBox1.Checked)));
                cache.SaveFile(listBase);
            }
        }

        private void deleteButton_Click(object sender, EventArgs e)
        {
            if (rowIndex != -1)
            {
                DialogResult result = MessageBox.Show("Are you sure?","Deleting object",MessageBoxButtons.YesNo);
                if(result==DialogResult.Yes)
                {
                    delete.Rows.RemoveAt(rowIndex);
                    cache.DeleteItem(rowIndex);
                    rowIndex = -1;
                }
            }
        }

        private void delete_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            rowIndex = e.RowIndex;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if(button2.Text=="Rise")
            {
                button2.Text = "Fall";
                listBase = cache.Sort(listBase, comboBox2.SelectedIndex, 0);
            }
            else
            {
                button2.Text = "Rise";
                listBase = cache.Sort(listBase, comboBox2.SelectedIndex, 1);
            }
            dataGridView1.Rows.Clear();
            dataGridView1.Refresh();
            cache.GridFiller(dataGridView1, listBase);
        }
    }
}