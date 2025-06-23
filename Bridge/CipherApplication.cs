using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ThePlayfairCipher.Bridge.Abstractions;

namespace ThePlayfairCipher.Bridge
{
    public class CipherApplication
    {
        private readonly ICipherUIImpl ui;

        public CipherApplication(ICipherUIImpl ui)
        {
            this.ui = ui;
        }

        public void Run()
        {

        }

        public void Start() => ui.Start();
    }

}
