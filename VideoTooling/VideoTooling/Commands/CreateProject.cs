using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using VideoTooling.Entity;

namespace VideoTooling.Commands
{
    internal class CreateProject : ICommand<Project>
    {
        int currentDirId = -1;
        string currentDirectory = "";
        Project ICommand<Project>.Execute(Form1 form)
        {
            Project re = new Project();
            var projectName = form.textBox1.Text.Trim().Replace(" ", "-").ToLower();

            // new folder
            currentDirId = Directory.EnumerateDirectories(Config.ProjectArtifacts).ToList().Count() + 5;
            currentDirectory = $"{currentDirId}-{projectName}";
            re.ProjectArtifacts = Config.ProjectArtifacts.Combine(currentDirectory);
            Directory.CreateDirectory(re.ProjectArtifacts);

            // copy presentation
            var templatePath = Config.OneDrive.Combine(@"YouTube\Powerpoint\MKT_Template.pptx");
            re.PPTX = Config.ProjectArtifacts.Combine(currentDirectory).Combine($"presentation-{projectName}.pptx");
            File.Copy(templatePath, re.PPTX);

            // create source folder
            re.MKTSource = Config.MKTSource.Combine(currentDirectory);
            Directory.CreateDirectory(re.MKTSource);
            File.Create(Config.MKTSource.Combine(currentDirectory).Combine("readme.md"));

            // create description and tag files
            re.DescriptionPath = re.ProjectArtifacts.Combine("description.txt");
            re.TagsPath = re.ProjectArtifacts.Combine("tags.txt");
            File.WriteAllText(re.DescriptionPath, Config.Template_Description);
            File.WriteAllText(re.TagsPath, "");

            return re;
        }
    }
}
