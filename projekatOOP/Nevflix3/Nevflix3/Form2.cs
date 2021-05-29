using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Threading;

namespace Nevflix3
{
    public partial class Logovanje : Form
    {
        Thread th;
        private Dictionary<string, User> Users = new Dictionary<string, User>();
        public Logovanje()
        {
            InitializeComponent();
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            //DeserializeUDictionary();
            UcitajUDictionary();
        }

        private void btnSignUp_Click(object sender, EventArgs e)
        {
            SignUp();
        }

        private void SignUp()
        {
            Provera();
            if (Users.ContainsKey(tbUsername.Text))
                throw new Exception("Ovaj nalog vec postoji");
            else
            {
                StreamWriter sw = null;
                try
                {
                    sw = new StreamWriter("Users.txt", true);
                    string text = "\n" + tbUsername.Text + "|" + tbPassword.Text;
                    sw.Write(text);
                    User u = new User(tbUsername.Text, tbPassword.Text);
                    Users.Add(u.Username, u);
                }
                catch
                {
                    throw new Exception("Fajl ne postoji");
                }
                finally
                {
                    if (sw != null)
                        sw.Close();
                }

                /*FileStream fs = new FileStream("Users.txt", FileMode.Append);
                BinarniFajl bf = new BinarniFajl();
                bf.Serialize(u, fs);*/

                th = new Thread(OtvoriFormu);
                th.SetApartmentState(ApartmentState.STA);
                th.Start();
                this.Close();
            }
        }

        private void btnLogIn_Click(object sender, EventArgs e)
        {
            Login();
        }
        private void OtvoriFormu()
        {
            Application.Run(new forma());
        }
        private void Login()
        {
            Provera();
            if (!Users.ContainsKey(tbUsername.Text))
                throw new Exception("Ovaj nalog ne postoji!");
            else
            {
                th = new Thread(OtvoriFormu);
                th.SetApartmentState(ApartmentState.STA);
                th.Start();
                this.Close();
            }
        }
        /*private void DeserializeUDictionary()
        {
            FileStream fs = new FileStream("Users.txt", FileMode.OpenOrCreate);
            BinarniFajl bf = new BinarniFajl();
            User a = bf.Deserialize(fs);
            Users.Add(a.Username, a);
        }*/
        private void UcitajUDictionary()
        {
            StreamReader sr = null;
            try
            {
                sr = new StreamReader("Users.txt");
                string linija;
                while ((linija = sr.ReadLine()) != null)
                {
                    string[] objekat = linija.Split('|');
                    User u = new User(objekat[0], objekat[1]);
                    Users.Add(u.Username, u);

                    //stavlja listu filmova iz fajla u listu filmova korisnika
                    //string[] lista = objekat[3].Split(',');
                    //foreach (var item in lista)
                    //{
                    //    u.AddMojiFilmovi(item);
                    //}
                }
            }
            catch
            {
                throw new Exception("Fajl Users ne postoji");
            }
            finally
            {
                if (sr != null)
                {
                    sr.Close();
                }
            }

        }

        private void Provera()
        {
            if (tbUsername.Text == "" || tbPassword.Text == "")
                throw new Exception("Morate uneti i username i sifru!");
        }
    }
}
