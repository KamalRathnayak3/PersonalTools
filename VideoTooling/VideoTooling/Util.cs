using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;

namespace VideoTooling
{
    public static class Util
    {
        public static void Message(object text)
        {
            MessageBox.Show(text.ToString(), "Video Tooling");
        }
    }
}
