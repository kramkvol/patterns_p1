using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ThePlayfairCipher.Bridge.Abstractions
{
    public interface ICipherUIImpl
    {
        void DisplayMessage(string message);
        string GetInput(string prompt);
        void ShowResult(string result);
        void Start();
    }
}

