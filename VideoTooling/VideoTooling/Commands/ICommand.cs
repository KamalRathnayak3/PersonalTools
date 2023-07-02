using System;
using System.Collections.Generic;
using System.Text;

namespace VideoTooling.Commands
{
    internal interface ICommand<T>
    {
        T Execute(Form1 form);
    }
}
