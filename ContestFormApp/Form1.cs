using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows.Forms;
using ContestFormApp.Services;
using ContestModel.Domain;
using ContestServices.Services;
namespace ContestFormApp
{
    public partial class Form1 : Form
    {
        public ContestController Controller { get; set; }

        public Form1(ContestController s)
        {
            this.Controller = s;
            InitializeComponent();
            Populate();
            MyInit();
        }
        private void MyInit()
        {
            participantsTable.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            filterRadio.Checked = true;

           
        }

        private void Populate()
        {
            /*
            catVarstaList.Items.Clear();
            foreach (var cat in Service.GetAgeCategories())
                catVarstaList.Items.Add(cat);
                */
        }


        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void handleSelection(object sender, ItemCheckEventArgs e)
        {
            /*
            if (e.NewValue == CheckState.Checked && catVarstaList.CheckedItems.Count > 0)
            {
                catVarstaList.ItemCheck -= handleSelection;
                catVarstaList.SetItemChecked(catVarstaList.CheckedIndices[0], false);
                catVarstaList.ItemCheck += handleSelection;

                var cat = (AgeCategory)catVarstaList.Items[e.Index];
                competitionsList.Items.Clear();
                foreach (var el in Service.GetCompetitionsForAgeCategory(cat))
                    competitionsList.Items.Add(el);
            }
            else if (e.NewValue == CheckState.Checked)
            {
                var cat = (AgeCategory)catVarstaList.Items[e.Index];
                competitionsList.Items.Clear();
                foreach (var el in Service.GetCompetitionsForAgeCategory(cat))
                    competitionsList.Items.Add(el);
            }
            */
        }

        private void handleSelectionCompetitions(object sender, ItemCheckEventArgs e)
        {
            /*
            if (e.NewValue == CheckState.Checked && competitionsList.CheckedItems.Count > 0)
            {
                competitionsList.ItemCheck -= handleSelectionCompetitions;
                competitionsList.SetItemChecked(competitionsList.CheckedIndices[0], false);
                competitionsList.ItemCheck += handleSelectionCompetitions;

                var comp = (Competition)competitionsList.Items[e.Index];
                participantsTable.DataSource = Service.GetParticipantsForCompetition(comp);
            }
            else if (e.NewValue == CheckState.Checked)
            {
                var comp = (Competition)competitionsList.Items[e.Index];
                participantsTable.DataSource = Service.GetParticipantsForCompetition(comp);
                IdCol.DataPropertyName = "Id";
                NameCol.DataPropertyName = "Name";
                AgeCol.DataPropertyName = "Age";
                NoCompCol.DataPropertyName = "NoComp";

            }
            */
        }

        private void handleFilter(object sender, EventArgs e)
        {
            /*
            IList<Participant> my;
            if (filterRadio.Checked == true)
                my = Service.GetParticipantsForCompetition((Competition)competitionsList.CheckedItems[0]);
            else
                my = Service.getAllParticipants();
            var filtered = my.Where(x => x.Name.ToUpper().Contains(filter.Text.ToUpper())).ToList();
            participantsTable.DataSource = filtered;
        */
        }

        private void handleRadioButtons(object sender, EventArgs e)
        {
         /*
            if (allRadio.Checked == true)
            {
                catVarstaList.Items.Clear();
                competitionsList.Items.Clear();
                participantsTable.DataSource = Service.getAllParticipants();
            }
            else
            {
                this.Populate();
            }
            */
        }

        private void handleParticipantsSelection(object sender, EventArgs e)
        {
            /*
            if (participantsTable.SelectedRows.Count > 0)
            {
                var part = (Participant)participantsTable.SelectedRows[0].DataBoundItem;
                var comps = Service.GetCompetitionsForParticipant(part);
                if (comps.Count == 0)
                {
                    comp1.Text = "";
                    comp2.Text = "";
                    return;
                }
                if (comps.Count == 1)
                {
                    comp1.Text = comps[0].Name;
                    comp2.Text = "";
                    return;
                }
                if (comps.Count == 2)
                {
                    comp1.Text = comps[0].Name;
                    comp2.Text = comps[1].Name;
                    return;
                }
            }
            */
        }

        private void handleDeleteParticipant(object sender, EventArgs e)
        {
            /*
            if (participantsTable.SelectedRows.Count == 1)
            {
                Participant p = (Participant)participantsTable.SelectedRows[0].DataBoundItem;
                try
                {
                    Service.DeleteParticpant(p);
                    MessageBox.Show("Participant was deleted", "INFO");
                    this.handleRadioButtons(this, new EventArgs());
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "something went wrong...");
                }
            }
            */
        }
    }
}
