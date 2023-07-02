using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using VideoTooling.Entity;

namespace VideoTooling.Commands
{
    internal class LoadProjects : ICommand<List<Project>>
    {
        public List<Project> Execute(Form1 form)
        {
            var artifacts = Directory.EnumerateDirectories(Config.ProjectArtifacts)
                                     .Where(x => char.IsDigit(new FileInfo(x).Name[0]))
                                     .Select(x => new FileInfo(x))
                                     .OrderByDescending(x => x.CreationTime)
                                     .Select(x => x.FullName)
                                     .ToList();

            var projects = new List<Project>();

            form.listBox1.Items.Clear();
            foreach (var artifact in artifacts)
            {
                var project = new Project
                {
                    ProjectArtifacts = artifact,
                    PSD = "??",
                    MKTSource = Config.MKTSource.Combine(new FileInfo(artifact).Name),
                    Name = new FileInfo(artifact).Name,
                    NameWithoutId = string.Join("-", new FileInfo(artifact).Name.Split("-").Skip(1).ToList()),
                    DescriptionPath = artifact.Combine("description.txt"),
                    TagsPath = artifact.Combine("tags.txt")
                };
                project.PPTX = artifact.Combine($"presentation-{project.NameWithoutId}.pptx");
                projects.Add(project);
                form.listBox1.Items.Add(project);
            }

            return projects.ToList();
        }
    }
}
