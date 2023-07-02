using System;
using System.Collections.Generic;
using System.Text;

namespace VideoTooling.Entity
{
    public class Project
    {
        public string ProjectArtifacts {get; set;}
        public string OBSOutput { get; set; }
        public string MKTSource { get; set; }
        public string PSD { get; set; }
        public string PPTX { get; set; }
        public string Name { get; set; }
        public string NameWithoutId { get; set; }
        public string DescriptionPath { get; set; }
        public string TagsPath { get; set; }

        public override string ToString()
        {
            return Name.ToString();
        }

    }
}
