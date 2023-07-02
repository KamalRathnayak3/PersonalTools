using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;

namespace VideoTooling
{
    internal static class Config
    {
        public static string ProjectArtifacts = @"D:\YouTube";
        public static string OneDrive = @"C:\Users\kamal\OneDrive";
        public static string OBSOutput = @"D:\YouTube\ScreenRecs";
        public static string MKTSource = @"D:\Coding\MKT";
        public static string App_VSCode = @"C:\Users\kamal\AppData\Local\Programs\Microsoft VS Code\Code.exe";
        public static string App_PPT = @"C:\Program Files (x86)\Microsoft Office\Office14\POWERPNT.EXE";
        public static string App_Audacity = @"C:\Program Files\Audacity\Audacity.exe";

        public static string Template_Description = "Today, We are going to learn about \n\n\n00:00 Intro\n:\n:\n:\n\n\nMeet Kamal Today\nKamal Rathnayake\n" + DateTime.Now.Year + " ©";

        public static string Combine(this string str, string relativePath)
        {
            return Path.Combine(str, relativePath);
        }

        public static List<ConfigItem> GetProps()
        {
            FieldInfo[] fields = (typeof(Config)).GetFields(BindingFlags.Static | BindingFlags.Public);

            var val = fields[0].GetValue(null).ToString();

            var props = fields.ToList()
                              .Where(x => !x.Name.Contains("Template_Description"))
                              .Select(x => new ConfigItem
                              {
                                  Key = x.Name,
                                  Value = x.GetValue(null).ToString()
                              })
                              .ToList();
            return props;
        }
    }

    public class ConfigItem
    {
        public string Key { get; set; }
        public string Value { get; set; }
        public override string ToString()
        {
            return Key;
        }
    }
}
