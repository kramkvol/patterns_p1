using System;

namespace CiphersWithPatterns
{
    public class CipherController
    {
        private readonly MainForm view;
        private readonly ILogger logger = ConsoleLogger.Instance;

        public CipherController(MainForm view)
        {
            this.view = view;
        }

        public void Encrypt()
        {
            ExecuteCipher(true);
        }

        public void Decrypt()
        {
            ExecuteCipher(false);
        }

        private void ExecuteCipher(bool encrypt)
        {
            string type = view.CipherType;
            string abc = "abcdefghijklmnopqrstuvwxyz";
            int rows = 5, cols = 5;

            try
            {
                var cipher = CipherFactoryMethod.Create(type, abc, rows, cols, view.Message, view.Key1, view.Key2);
                view.ShowResult(CipherDebugger.PrintInf(cipher));
            }
            catch (Exception ex)
            {
                view.Log($"[Error] {ex.Message}");
            }
        }
    }
}