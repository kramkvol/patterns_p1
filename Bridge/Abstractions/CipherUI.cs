using CiphersWithPatterns;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ThePlayfairCipher.Bridge.Abstractions
{
    public class CipherUI
    {
        protected ICipherUIImpl impl;

        public CipherUI(ICipherUIImpl implementation)
        {
            impl = implementation;
        }

        public void Run()
        {
            impl.Start();

            string message = impl.GetInput("Enter the message");
            string key1 = impl.GetInput("Enter key1");
            string key2 = impl.GetInput("Enter key2 (optional)");

            impl.DisplayMessage("Processing...");
            impl.ShowResult($"Encrypted result for: {message}"); 
        }
    }
}

