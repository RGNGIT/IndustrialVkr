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
        public App(string username, string role)
        {
            InitializeComponent();
            UpdateDirectoryGrid();
            UpdateDataGrid();
            UpdateAttachmentGrid();
            FillCombo();

            labelUsername.Text = username;
            labelRole.Text = role;

            if (role == "Сотрудник")
              tabControl1.TabPages.RemoveAt(3);

            if (role == "Руководитель") 
            {
                buttonAddDictionary.Enabled = false;
                buttonAddData.Enabled = false;
            }
        }

        private void FillCombo() 
        {
            using (DatabaseConnection connection = new DatabaseConnection())
            {
                switch (tabControlData.SelectedIndex)
                {
                    case 0:
                        comboBoxEqDirectoryType.Items.Clear();
                        dataGridViewTemp.DataSource = connection.SelectScript("SELECT id, name FROM equipment_type;");
                        for (int i = 0; i < dataGridViewTemp.Rows.Count - 1; i++) 
                        {
                            comboBoxEqDirectoryType.Items.Add($"{dataGridViewTemp.Rows[i].Cells[0].Value} {dataGridViewTemp.Rows[i].Cells[1].Value}");
                        }
                        break;
                    case 1:
                        comboBoxEmpRolePhys.Items.Clear();
                        dataGridViewTemp.DataSource = connection.SelectScript("SELECT id, lastName, name, middleName FROM phys;");
                        for (int i = 0; i < dataGridViewTemp.Rows.Count - 1; i++)
                        {
                            comboBoxEmpRolePhys.Items.Add($"{dataGridViewTemp.Rows[i].Cells[0].Value} {dataGridViewTemp.Rows[i].Cells[1].Value} {dataGridViewTemp.Rows[i].Cells[2].Value} {dataGridViewTemp.Rows[i].Cells[3].Value}");
                        }

                        comboBoxEmpRoleJobTitle.Items.Clear();
                        dataGridViewTemp.DataSource = connection.SelectScript("SELECT id, name FROM job_title;");
                        for (int i = 0; i < dataGridViewTemp.Rows.Count - 1; i++)
                        {
                            comboBoxEmpRoleJobTitle.Items.Add($"{dataGridViewTemp.Rows[i].Cells[0].Value} {dataGridViewTemp.Rows[i].Cells[1].Value}");
                        }

                        comboBoxEmpRoleZone.Items.Clear();
                        dataGridViewTemp.DataSource = connection.SelectScript("SELECT id, name FROM zone;");
                        for (int i = 0; i < dataGridViewTemp.Rows.Count - 1; i++)
                        {
                            comboBoxEmpRoleZone.Items.Add($"{dataGridViewTemp.Rows[i].Cells[0].Value} {dataGridViewTemp.Rows[i].Cells[1].Value}");
                        }
                        break;
                    case 2:
                        comboBoxEquipmentDirectory.Items.Clear();
                        dataGridViewTemp.DataSource = connection.SelectScript("SELECT id, name FROM equipment_dictionary;");
                        for (int i = 0; i < dataGridViewTemp.Rows.Count - 1; i++)
                        {
                            comboBoxEquipmentDirectory.Items.Add($"{dataGridViewTemp.Rows[i].Cells[0].Value} {dataGridViewTemp.Rows[i].Cells[1].Value}");
                        }

                        comboBoxEquipmentModel.Items.Clear();
                        dataGridViewTemp.DataSource = connection.SelectScript("SELECT id, name FROM equipment_model;");
                        for (int i = 0; i < dataGridViewTemp.Rows.Count - 1; i++)
                        {
                            comboBoxEquipmentModel.Items.Add($"{dataGridViewTemp.Rows[i].Cells[0].Value} {dataGridViewTemp.Rows[i].Cells[1].Value}");
                        }
                        break;
                    case 3:
                        comboBoxRejectionReason.Items.Clear();
                        dataGridViewTemp.DataSource = connection.SelectScript("SELECT id, name FROM rejection_reason;");
                        for (int i = 0; i < dataGridViewTemp.Rows.Count - 1; i++)
                        {
                            comboBoxRejectionReason.Items.Add($"{dataGridViewTemp.Rows[i].Cells[0].Value} {dataGridViewTemp.Rows[i].Cells[1].Value}");
                        }

                        comboBoxRejectionDirectory.Items.Clear();
                        dataGridViewTemp.DataSource = connection.SelectScript("SELECT id, name FROM equipment_dictionary;");
                        for (int i = 0; i < dataGridViewTemp.Rows.Count - 1; i++)
                        {
                            comboBoxRejectionDirectory.Items.Add($"{dataGridViewTemp.Rows[i].Cells[0].Value} {dataGridViewTemp.Rows[i].Cells[1].Value}");
                        }

                        comboBoxRejectionEquipment.Items.Clear();
                        dataGridViewTemp.DataSource = connection.SelectScript("SELECT id, number FROM equipment;");
                        for (int i = 0; i < dataGridViewTemp.Rows.Count - 1; i++)
                        {
                            comboBoxRejectionEquipment.Items.Add($"{dataGridViewTemp.Rows[i].Cells[0].Value} {dataGridViewTemp.Rows[i].Cells[1].Value}");
                        }

                        comboBoxRejectionAttachment.Items.Clear();
                        dataGridViewTemp.DataSource = connection.SelectScript("SELECT a.id, a.dateOfAttachment, b.number FROM equipment_attach a, equipment b WHERE a.equipment_id = b.id;");
                        for (int i = 0; i < dataGridViewTemp.Rows.Count - 1; i++)
                        {
                            comboBoxRejectionAttachment.Items.Add($"{dataGridViewTemp.Rows[i].Cells[0].Value} {dataGridViewTemp.Rows[i].Cells[1].Value} {dataGridViewTemp.Rows[i].Cells[2].Value}");
                        }
                        break;
                }
            }
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

        private void UpdateDataGrid() 
        {
            using (DatabaseConnection connection = new DatabaseConnection()) 
            {
                switch (tabControlData.SelectedIndex) 
                {
                    case 0:
                        dataGridViewMainData.DataSource = connection.SelectScript("SELECT a.id as Ключ, a.name as Имя, a.shortName as 'Краткое имя', b.name as 'Тип оборудования' FROM equipment_dictionary a, equipment_type b WHERE a.equipment_type_id = b.id;");
                        break;
                    case 1:
                        dataGridViewMainData.DataSource = connection.SelectScript("SELECT a.id as Ключ, a.openDate as 'Дата открытия', a.closeDate as 'Дата закрытия', CONCAT(b.lastName, ' ', b.name, ' ', b.middleName) as 'ФИО', c.name as Должность, d.name as Участок FROM employee_role a, phys b, job_title c, zone as d WHERE a.phys_id = b.id AND a.job_title_id = c.id AND a.zone_id = d.id;");
                        break;
                    case 2:
                        dataGridViewMainData.DataSource = connection.SelectScript("SELECT a.id as Ключ, a.number as 'Номер', b.name as 'Справочник оборудования', c.name as 'Модель оборудования' FROM equipment a, equipment_dictionary b, equipment_model c WHERE a.equipment_dictionary_id = b.id AND a.equipment_model_id = c.id;");
                        break;
                    case 3:
                        dataGridViewMainData.DataSource = connection.SelectScript("SELECT a.id as Ключ, c.name as 'Наименование', b.number as 'Номер', a.dateOfRejection as 'Дата отказа', a.dateOfResume as 'Дата возобновления' FROM equipment_rejection a, equipment b, equipment_dictionary c WHERE a.equipment_id = b.id AND a.equipment_dictionary_id = c.id;");
                        break;
                }
            }
        }

        private void UpdateAttachmentGrid()
        {
            using (DatabaseConnection connection = new DatabaseConnection())
                dataGridViewAttachment.DataSource = connection.SelectScript("SELECT a.id as 'Ключ', a.dateOfAttachment as 'Дата прикрепления', a.dateOfDettachment as 'Дата открепления', f.number as 'Номер оборудования', d.name as Должность, c.name as Участок FROM equipment_attach a, employee_role b, zone c, job_title d, equipment f WHERE a.employee_role_id = b.id AND a.zone_id = c.id AND b.job_title_id = d.id AND a.equipment_id = f.id;");
        }

        private void tabControlDirectories_SelectedIndexChanged(object sender, EventArgs e)
        {
            UpdateDirectoryGrid();
            FillCombo();
        }

        private void buttonAddDictionary_Click(object sender, EventArgs e)
        {
            using (DatabaseConnection connection = new DatabaseConnection())
            {
                switch (tabControlDirectories.SelectedIndex)
                {
                    case 0:
                        connection.AddJobTitle(textBoxJobTitleName.Text, textBoxJobTitleShortName.Text);
                        break;
                    case 1:
                        connection.AddPhys(textBoxPhysName.Text, textBoxPhysLastName.Text, textBoxPhysMiddleName.Text);
                        break;
                    case 2:
                        connection.AddRejectionReason(textBoxRejectionReasonName.Text, textBoxRejectionReasonShortName.Text);
                        break;
                    case 3:
                        connection.AddEquipmentType(textBoxEqTypeName.Text, textBoxEqTypeShortName.Text);
                        break;
                    case 4:
                        connection.AddEquipmentModel(textBoxEqModelName.Text, textBoxEqModelShortName.Text);
                        break;
                    case 5:
                        connection.AddZone(textBoxZoneName.Text, textBoxZoneShortName.Text);
                        break;
                }
            }

            UpdateDirectoryGrid();
        }

        private void buttonAddData_Click(object sender, EventArgs e)
        {
            using (DatabaseConnection connection = new DatabaseConnection()) 
            {
                switch (tabControlData.SelectedIndex) 
                {
                    case 0:
                        connection.AddEquipmentDictionary(textBoxEqDirectoryName.Text, textBoxEqDirectoryShortName.Text, int.Parse(comboBoxEqDirectoryType.Text.Split(' ')[0]));
                        break;
                    case 1:
                        connection.AddEmployeeRole(dateTimePickerEmployeeRoleOpenDate.Value.ToString("yyyy-MM-dd"), dateTimePickerEmployeeRoleCloseDate.Value.ToString("yyyy-MM-dd"), int.Parse(comboBoxEmpRolePhys.Text.Split(' ')[0]), int.Parse(comboBoxEmpRoleJobTitle.Text.Split(' ')[0]), int.Parse(comboBoxEmpRoleZone.Text.Split(' ')[0]));
                        break;
                    case 2:
                        connection.AddEquipment(textBoxEquipmentNumber.Text, int.Parse(comboBoxEquipmentDirectory.Text.Split(' ')[0]), int.Parse(comboBoxEquipmentModel.Text.Split(' ')[0]));
                        break;
                    case 3:
                        connection.AddRejection(dateTimePickerRejectionDate.Value.ToString("yyyy-MM-dd"), dateTimePickerRejectionResumeDate.Value.ToString("yyyy-MM-dd"), int.Parse(comboBoxRejectionReason.Text.Split(' ')[0]), int.Parse(comboBoxRejectionDirectory.Text.Split(' ')[0]), int.Parse(comboBoxRejectionEquipment.Text.Split(' ')[0]), int.Parse(comboBoxRejectionAttachment.Text.Split(' ')[0]));
                        break;
                }
            }

            UpdateDataGrid();
        }

        private void tabControlData_SelectedIndexChanged(object sender, EventArgs e)
        {
            UpdateDataGrid();
            FillCombo();
        }

        private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {
            using (DatabaseConnection connection = new DatabaseConnection()) 
            {
                switch (tabControl1.SelectedIndex) 
                {
                    case 2:
                        comboBoxAttachmentZone.Items.Clear();
                        dataGridViewTemp.DataSource = connection.SelectScript("SELECT id, name FROM zone;");
                        for (int i = 0; i < dataGridViewTemp.Rows.Count - 1; i++)
                        {
                            comboBoxAttachmentZone.Items.Add($"{dataGridViewTemp.Rows[i].Cells[0].Value} {dataGridViewTemp.Rows[i].Cells[1].Value}");
                        }

                        comboBoxAttachmentRole.Items.Clear();
                        dataGridViewTemp.DataSource = connection.SelectScript("SELECT a.id, b.lastName, b.name, b.middleName, c.name as l FROM employee_role a, phys b, job_title c WHERE a.phys_id = b.id AND a.job_title_id = c.id;");
                        for (int i = 0; i < dataGridViewTemp.Rows.Count - 1; i++)
                        {
                            comboBoxAttachmentRole.Items.Add($"{dataGridViewTemp.Rows[i].Cells[0].Value} {dataGridViewTemp.Rows[i].Cells[1].Value} {dataGridViewTemp.Rows[i].Cells[2].Value} {dataGridViewTemp.Rows[i].Cells[3].Value} {dataGridViewTemp.Rows[i].Cells[4].Value}");
                        }

                        comboBoxAttachmentEquipment.Items.Clear();
                        dataGridViewTemp.DataSource = connection.SelectScript("SELECT a.id, a.number, b.name FROM equipment a, equipment_model b WHERE a.equipment_model_id = b.id;");
                        for (int i = 0; i < dataGridViewTemp.Rows.Count - 1; i++)
                        {
                            comboBoxAttachmentEquipment.Items.Add($"{dataGridViewTemp.Rows[i].Cells[0].Value} {dataGridViewTemp.Rows[i].Cells[1].Value} {dataGridViewTemp.Rows[i].Cells[2].Value}");
                        }

                        UpdateAttachmentGrid();
                        break;
                    case 3:
                        comboBoxAnalyzisZone.Items.Clear();
                        dataGridViewTemp.DataSource = connection.SelectScript("SELECT id, name FROM zone;");
                        for (int i = 0; i < dataGridViewTemp.Rows.Count - 1; i++)
                        {
                            comboBoxAnalyzisZone.Items.Add($"{dataGridViewTemp.Rows[i].Cells[0].Value} {dataGridViewTemp.Rows[i].Cells[1].Value}");
                        }
                        break;
                }
            }
        }

        private void buttonAttach_Click(object sender, EventArgs e)
        {
            using (DatabaseConnection connection = new DatabaseConnection())
                connection.AddAttachment(dateTimePickerAttachmentDateOfAttach.Value.ToString("yyyy-MM-dd"), "NULL", int.Parse(comboBoxAttachmentZone.Text.Split(' ')[0]), int.Parse(comboBoxAttachmentRole.Text.Split(' ')[0]), int.Parse(comboBoxAttachmentEquipment.Text.Split(' ')[0]));

            UpdateAttachmentGrid();
        }

        private void buttonAnalyzisShow_Click(object sender, EventArgs e)
        {
            using (DatabaseConnection connection = new DatabaseConnection())
                dataGridViewAnalyzis.DataSource = connection.SelectScript($"SELECT eq.number as 'Номер', ed.name as 'Название', em.name as 'Модель', COUNT(er.id) AS 'Количество отказов', SUM(DATEDIFF(er.dateOfResume, er.dateOfRejection)) AS 'Количество простоя' FROM equipment eq, equipment_dictionary ed, equipment_model em, equipment_rejection er, equipment_attach ea WHERE ea.equipment_id = eq.id AND ea.zone_id = {comboBoxAnalyzisZone.Text.Split(' ')[0]} AND ea.dateOfDettachment IS NULL AND er.equipment_id = eq.id AND eq.equipment_model_id = em.id AND eq.equipment_dictionary_id = ed.id AND (er.dateOfRejection BETWEEN '{dateTimePickerAnalyzisFrom.Value.ToString("yyyy-MM-dd")}' AND '{dateTimePickerAnalyzisTo.Value.ToString("yyyy-MM-dd")}') GROUP BY eq.number, ed.name, em.name;");
        }

        private List<Equipment> FormList() 
        {
            List<Equipment> equipmentList = new List<Equipment>();
            for (int i = 0; i < dataGridViewAnalyzis.Rows.Count - 1; i++)
            {
                equipmentList.Add(new Equipment() { FailureCount = int.Parse(dataGridViewAnalyzis.Rows[i].Cells[3].Value.ToString()), DowntimeDays = int.Parse(dataGridViewAnalyzis.Rows[i].Cells[4].Value.ToString()) });
            }

            return equipmentList;
        }

        private void buttonAnalyze_Click(object sender, EventArgs e)
        {
            dataGridViewAnalyzisResult.Rows.Clear();

            List<Equipment> equipmentList = FormList();
            AdditiveCriterionAnalyzis analyzis = new AdditiveCriterionAnalyzis();

            equipmentList = analyzis.Calculate(equipmentList);
            for (int i = 0; i < dataGridViewAnalyzis.Rows.Count - 1; i++) 
            {
                dataGridViewAnalyzisResult.Rows.Add(
                    dataGridViewAnalyzis.Rows[i].Cells[0].Value, 
                    dataGridViewAnalyzis.Rows[i].Cells[1].Value,
                    dataGridViewAnalyzis.Rows[i].Cells[2].Value,
                    dataGridViewAnalyzis.Rows[i].Cells[3].Value,
                    dataGridViewAnalyzis.Rows[i].Cells[4].Value,
                    equipmentList[i].AdditiveCriterion
                    );
            }
        }

        private void buttonAttachmentDetach_Click(object sender, EventArgs e)
        {
            using (DatabaseConnection connection = new DatabaseConnection())
                connection.DetachAttachment(int.Parse(dataGridViewAttachment.SelectedRows[0].Cells[0].Value.ToString()), dateTimePickerAttachmentDetach.Value.ToString("yyyy-MM-dd"));

            UpdateAttachmentGrid();
        }
    }
}
