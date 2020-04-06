﻿using System;
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
        public IList<AgeCategory> allCategs;
        public IList<Competition> allComps;
        public IList<ParticipantDTO> allParts;
        public IList<Competition> allAvailableComps;

        public Form1(ContestController s)
        {
            this.Controller = s;
            InitializeComponent();
            Populate();
            MyInit();
            Controller.udateEvent += ExecuteUpdate;
        }
        private void MyInit()
        {
            participantsTable.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            filterRadio.Checked = true;

            IdCol.DataPropertyName = "Id";
            NameCol.DataPropertyName = "Name";
            AgeCol.DataPropertyName = "Age";
            NoCompCol.DataPropertyName = "NoComp";

        }

        private void Populate()
        {
            catVarstaList.Items.Clear();
            this.allCategs = this.Controller.GetAgeCategories();
            catVarstaList.Items.AddRange(this.allCategs.ToArray());
        }


        private void Form1_Load(object sender, EventArgs e)
        {


        }
        private void handleSelectionAgeCategs(object sender, ItemCheckEventArgs e)
        {
            if (e.NewValue == CheckState.Checked && catVarstaList.CheckedItems.Count > 0)
            {
                catVarstaList.ItemCheck -= handleSelectionAgeCategs;
                catVarstaList.SetItemChecked(catVarstaList.CheckedIndices[0], false);
                catVarstaList.ItemCheck += handleSelectionAgeCategs;
            }
            if (e.NewValue == CheckState.Checked)
            {

                var ageCateg = (AgeCategory)catVarstaList.Items[e.Index];
                allComps = this.Controller.GetCompetitions(ageCateg);
                competitionsList.Items.Clear();
                competitionsList.Items.AddRange(allComps.ToArray());
            }
            participantsTable.DataSource = null;
        }

        private void handleSelectionCompetitions(object sender, ItemCheckEventArgs e)
        {

            if (e.NewValue == CheckState.Checked && competitionsList.CheckedItems.Count > 0)
            {
                competitionsList.ItemCheck -= handleSelectionCompetitions;
                competitionsList.SetItemChecked(competitionsList.CheckedIndices[0], false);
                competitionsList.ItemCheck += handleSelectionCompetitions;
            }

            if (e.NewValue == CheckState.Checked)
            {
                var comp = (Competition)competitionsList.Items[e.Index];
                allParts = this.Controller.GetParticipantDTOs(comp);
                participantsTable.DataSource = allParts;

               

            }

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

            if (allRadio.Checked == true)
            {
                catVarstaList.Items.Clear();
                competitionsList.Items.Clear();
                allParts = Controller.GetParticipantDTOs(null);
                participantsTable.DataSource = allParts;

            }
            else
            {
                this.Populate();
                participantsTable.DataSource = null;
            }

        }

        private void handleParticipantsSelection(object sender, EventArgs e)
        {
            if (participantsTable.SelectedRows.Count > 0)
            {
                var part = (ParticipantDTO)participantsTable.SelectedRows[0].DataBoundItem;
                NameBox.Text = part.Name;
                AgeBox.Text = part.Age.ToString();
                if (part.NoComp == 0)
                {
                    comp1.Text = "";
                    comp2.Text = "";
                    return;
                }
                if (part.NoComp == 1)
                {
                    comp1.Text = part.Competition1.Name;
                    comp2.Text = "";
                    return;
                }
                if (part.NoComp == 2)
                {
                    comp1.Text = part.Competition1.Name;
                    comp2.Text = part.Competition2.Name;
                    return;
                }
            }
        }

        private void handleDeleteParticipant(object sender, EventArgs e)
        {
            if (participantsTable.SelectedRows.Count == 1)
            {
                ParticipantDTO p = (ParticipantDTO)participantsTable.SelectedRows[0].DataBoundItem;
                try
                {
                    this.Controller.DeleteParticipant(p);
                    participantsTable.ClearSelection();
                    NameBox.Text = p.Name;
                    AgeBox.Text = p.Age.ToString();
                    if (p.Competition1 != null)
                        comp1.Text = p.Competition1.Name;
                    if (p.Competition2 != null)
                        comp2.Text = p.Competition2.Name;
                    MessageBox.Show("Participant was deleted", "INFO");
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "something went wrong...");
                }
            }
        }

        private void handleAddParticipant(object sender, EventArgs e)
        {
            String name = NameBox.Text;
            int age = Int32.Parse(AgeBox.Text);
            var comps = compList2.CheckedItems;
            IList<Competition> competitions = new List<Competition>();
            foreach (var comp in comps)
            {
                competitions.Add((Competition)comp);
            }
            try
            {
                this.Controller.AddParticipant(name, age, competitions);
                participantsTable.ClearSelection();
                NameBox.Clear();
                AgeBox.Clear();
                comp1.Clear();
                comp2.Clear();
                allAvailableComps.Clear();
                MessageBox.Show("Participant Added");
            }catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        public void ExecuteUpdate(object sender, ContestEventArgs eventArgs)
        {
            if (eventArgs.eventType == ContestEvent.ParticipantRemoved)
            {
                ParticipantDTO part = (ParticipantDTO)eventArgs.Data;
                if (allParts.Contains(part))
                {
                    allParts.Remove(part);
                    participantsTable.Invoke(new UpdateParticipantiCallback(this.UpdateTabel),allParts);
                }
            }
            if (eventArgs.eventType == ContestEvent.ParticipantAdded)
            {
                ParticipantDTO part = (ParticipantDTO)eventArgs.Data;
                if (!allParts.Contains(part))
                {
                    allParts.Add(part);
                    participantsTable.Invoke(new UpdateParticipantiCallback(this.UpdateTabel), allParts);
                }
            }
        }
        public void UpdateTabel(IList<ParticipantDTO> newOne)
        {
            participantsTable.DataSource = null;
            participantsTable.DataSource = newOne;
        }

        public delegate void UpdateParticipantiCallback(IList<ParticipantDTO> list);

        private void handleGetCompetitions2(object sender, EventArgs e)
        {
            try
            {
                int age = Int32.Parse(AgeBox.Text);
                AgeCategory ageCateg = this.allCategs.First(x => x.Apartine(age));
                if (ageCateg!=null)
                    this.allAvailableComps = this.Controller.GetCompetitions(ageCateg);
                compList2.Items.Clear();
                compList2.Items.AddRange(allAvailableComps.ToArray());
            }
            catch (Exception ex)
            {
                MessageBox.Show("Age must be a number between 6 and 15");
                compList2.Items.Clear();
            }
        }
    }
}
