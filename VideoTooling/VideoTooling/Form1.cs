using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using VideoTooling.Commands;
using VideoTooling.Entity;

namespace VideoTooling
{
    public partial class Form1 : Form
    {
        Project Project { get; set; }
        List<Project> Projects { get; set;}
        public Form1()
        {
            InitializeComponent();
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            textBox1.Focus();
            _loadProjects();

            var props = Config.GetProps();
            navigateToList.Items.AddRange(props.ToArray());
        }

        private void _loadProjects()
        {
            ICommand<List<Project>> loadProjects = new LoadProjects();
            Projects = loadProjects.Execute(this);
            listBox1.SelectedIndex = 0;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            ICommand<Project> command = new CreateProject();
            Project = command.Execute(this);
            _loadProjects();
        }

        private void listBox1_DoubleClick(object sender, EventArgs e)
        {
            var project = (Project)listBox1.SelectedItem;
            Process.Start("explorer.exe", project.ProjectArtifacts);
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            var project = (Project)listBox1.SelectedItem;
            Project = project;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            var project = (Project)listBox1.SelectedItem;
            Process.Start(Config.App_PPT, project.PPTX);
        }

        private void button5_Click(object sender, EventArgs e)
        {
            var project = (Project)listBox1.SelectedItem;
            Process.Start(Config.App_VSCode, project.MKTSource);
        }

        private void button7_Click(object sender, EventArgs e)
        {
            Process.Start("explorer.exe", Config.OBSOutput);
        }

        private void button6_Click(object sender, EventArgs e)
        {
            var script = Config.OBSOutput.Combine("sample.ps1");
            Process.Start("powershell", script);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Process.Start(Config.App_Audacity, Config.OBSOutput.Combine("audio.mp3"));
        }

        private void button8_Click(object sender, EventArgs e)
        {
            ICommand<bool> defaultRenaming = new DefaultRenaming();
            var result = defaultRenaming.Execute(this);
        }

        private void button9_Click(object sender, EventArgs e)
        {
            TextHelper textHelper = new TextHelper(Project);
            textHelper.Show();
        }

        private void navigateToList_SelectedIndexChanged(object sender, EventArgs e)
        {
            Process.Start("explorer.exe", ((ConfigItem)navigateToList.SelectedItem).Value);
        }
    }
}
