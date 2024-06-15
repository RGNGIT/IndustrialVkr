using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace IndustrialVkr
{
    public partial class App : Form
    {
        public App()
        {
            InitializeComponent();
            UpdateDirectoryGrid();
        }

        private void UpdateDirectoryGrid() 
        {
            using (DatabaseConnection connection = new DatabaseConnection())
            {
                switch (tabControlDirectories.SelectedIndex)
                {
                    case 0:
                        dataGridViewDirectories.DataSource = connection.SelectScript("SELECT id as Ключ, name as Имя, shortName as 'Краткое имя' FROM job_title;");
                        break;
                    case 1:
                        dataGridViewDirectories.DataSource = connection.SelectScript("SELECT id as Ключ, name as Имя, lastName as 'Фамилия', middleName as 'Отчество' FROM phys;");
                        break;
                    case 2:
                        dataGridViewDirectories.DataSource = connection.SelectScript("SELECT id as Ключ, name as Имя, shortName as 'Краткое имя' FROM rejection_reason;");
                        break;
                    case 3:
                        dataGridViewDirectories.DataSource = connection.SelectScript("SELECT id as Ключ, name as Имя, shortName as 'Краткое имя' FROM equipment_type;");
                        break;
                    case 4:
                        dataGridViewDirectories.DataSource = connection.SelectScript("SELECT id as Ключ, name as Имя, shortName as 'Краткое имя' FROM equipment_model;");
                        break;
                    case 5:
                        dataGridViewDirectories.DataSource = connection.SelectScript("SELECT id as Ключ, name as Имя, shortName as 'Краткое имя' FROM zone;");
                        break;
                }
            }
        }

        private void tabControlDirectories_SelectedIndexChanged(object sender, EventArgs e)
        {
            UpdateDirectoryGrid();
        }
    }
}
