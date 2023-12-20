using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Windows.Forms;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;
using System.Runtime.Serialization;


namespace T02P02FileManager
{
    [Serializable]
    class Settings
    {
        public Font Font { get; set; }
        public Color ForeColor { get; set; }
        public string Login;
        public string Password;

        public Settings()
        { }

        public Settings(Form form)
        {
            Set(form);
        }

        private string Encrypt(string s)
        {
            char[] charArray;

            if (s != null)
                charArray = s.ToCharArray();
            else
                charArray = new char[0];

            Array.Reverse(charArray);
            return new string(charArray);
        }

        private string Decrypt(string s)
        {
            char[] charArray = s.ToCharArray();
            Array.Reverse(charArray);
            return new string(charArray);
        }

        [OnSerializing()]
        private void EncryptSettings(StreamingContext context)
        {
            Login = Encrypt(Login);
            Password = Encrypt(Password);
        }

        [OnDeserialized()]
        private void DecryptSettings(StreamingContext context)
        {
            Login = Decrypt(Login);
            Password = Decrypt(Password);
        }

        public void Apply(Form form)
        {
            form.Font = Font;
            form.ForeColor = ForeColor;
        }

        public void Set(Form form)
        {
            Font = form.Font;
            ForeColor = form.ForeColor;
        }

        public void Serialize(string path)
        {
            BinaryFormatter formatter = new BinaryFormatter();
            using (FileStream fs = new FileStream(path, FileMode.OpenOrCreate))
            {
                formatter.Serialize(fs, this);
            }
        }
    }
}
