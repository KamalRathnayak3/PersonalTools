using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace VideoTooling.Commands
{
    public class DefaultRenaming : ICommand<bool>
    {
        public bool Execute(Form1 form)
        {
            var allVideos = Directory.EnumerateFiles(Config.OBSOutput)
                .Where(file => file.EndsWith(".mkv"))
                .OrderBy(file => file)
                .ToList();

            int index = 1;
            foreach (var video in allVideos)
            {
                var newFileName = (index++).ToString("D2");
                File.Move(video, Config.OBSOutput.Combine($"{newFileName}.mkv"));
            }
            return true;
        }
    }
}
