using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Text;
using System.Windows.Forms;
using VideoTooling.Entity;

namespace VideoTooling
{
    public partial class TextHelper : Form
    {
        private Project project;

        public TextHelper()
        {
            InitializeComponent();
        }

        public TextHelper(Project project)
        {
            InitializeComponent();
            this.project = project;
        }

        private void TextHelper_Load(object sender, EventArgs e)
        {
            try
            {
                richTextBox1.Text = File.ReadAllText(project.DescriptionPath);
                richTextBox2.Text = File.ReadAllText(project.TagsPath);
            }
            catch(Exception ex)
            {
                Util.Message(ex.Message);
            }
        }

        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {
            File.WriteAllText(project.DescriptionPath, richTextBox1.Text);
        }

        private void richTextBox2_TextChanged(object sender, EventArgs e)
        {
            File.WriteAllText(project.TagsPath, richTextBox2.Text);
        }
    }
}
