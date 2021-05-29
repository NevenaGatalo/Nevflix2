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
using System.Text.RegularExpressions;
using System.Collections;
using System.Runtime.Serialization.Formatters.Binary;
using System.Runtime.Serialization;

namespace Nevflix3
{
    public partial class forma : Form
    {
        private List<Film> filmovi = new List<Film>();

        public static string prosledi;

        public User trenuranUser;

        public forma()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            
            UcitajFilmoveUListu();
            UcitajFilmoveNaFormu(filmovi);
            PoslednjeGledanoDeserialzuj();
            UcitajComboBox();

        }

        /// <summary>
        /// ucitava filmove iz fajla u listu filmovi
        /// </summary>
        private void UcitajFilmoveUListu()
        {
            StreamReader sr = null;
            try
            {
                Regex izraz = new Regex(@"[0-9]+\|[a-z A-Z]+\|[0-9]{4}\|[a-z A-Z]+\|[0-9]+\|[1-5]{1}\.[0-9]{1}\|[a-z A-Z]+\|[a-z A-Z\s ,]+\|.+");
                sr = new StreamReader("Filmovi.txt");
                string linija;
                while ((linija = sr.ReadLine()) != null)
                {
                    //ako se linija ne slaze sa regularnim izrazom preskoci je
                    if (!izraz.IsMatch(linija))
                    {
                        MessageBox.Show("nije dobar format");
                        continue;
                    }

                    string[] objekat = linija.Split('|');
                    int id = Convert.ToInt32(objekat[0]);
                    int godina = Convert.ToInt32(objekat[2]);
                    int vreme = Convert.ToInt32(objekat[4]);
                    double rating = Convert.ToDouble(objekat[5]);
                    Zanr zanr = (Zanr)Enum.Parse(typeof(Zanr), objekat[6]);

                    Film film = new Film(id, objekat[1], godina, objekat[3], vreme, rating, zanr, objekat[7], objekat[9], objekat[8]);
                    filmovi.Add(film);
                }
            }
            catch
            {
                throw new Exception("Fajl ne postoji");
            }
            finally
            {
                if (sr != null)
                    sr.Close();

            }
        }

        private void UcitajFilmoveNaFormu(List<Film> lista)
        {
            IzbrisiBoxove();
            IzbrisiButtoneGledaj();
            int XKoordinata = 12;
            int YKoordinata = 196;
            int brojac = 0;
            foreach (var film in lista)
            {
                if(brojac == 4)
                {
                    brojac = 0;
                    XKoordinata = 12;
                    YKoordinata += 100;
                }

                PictureBox p = new PictureBox();
                p.Location = new Point(XKoordinata, YKoordinata);
                p.Name = film.Id.ToString();
                p.Anchor = AnchorStyles.None;
                p.BackColor = Color.Red;
                p.Load(film.UrlSlike);
                p.SizeMode = PictureBoxSizeMode.StretchImage;
                Controls.Add(p);
                p.Click += this.PictureBox_Click;

                Button b = new Button();
                b.Location = new Point(XKoordinata, YKoordinata + 55);
                b.Anchor = AnchorStyles.None;
                b.Text = "Gledaj";
                b.Name = film.Id.ToString();
                b.AccessibleName = film.Url;
                Controls.Add(b);
                b.Click += this.GledajButton_Click;

                XKoordinata += 115;
                brojac += 1;
                //ako je x koordinata veca ili jednaka sa x + width od forme --> povecaj y i resetuj x

            }
        }

        private void IzbrisiBoxove()
        {
            var PBs = this.Controls.OfType<PictureBox>().ToList();
            foreach (Control pb in PBs)
                if (pb.Name != "Nevflix")
                    this.Controls.Remove(pb);
        }

        private void IzbrisiButtoneGledaj()
        {
            var BTs = this.Controls.OfType<Button>().ToList();
            foreach (var button in BTs)
            {
                if (button.Name != "btnRefresh")
                    this.Controls.Remove(button);
            }
        }

        private bool PretraziFilmove(string nazivFilma, out List<Film> movie)
        {
            List<Film> f = new List<Film>();
            foreach (var film in filmovi)
            {
                if (film.Naziv == nazivFilma)
                {
                    f.Add(film);
                }
            }
            if (f.Count == 0)
            {
                movie = null;
                return false;
            }
            movie = f;
            return true;
        }

        /// <summary>
        /// pretrazuje filmove po zanru koji je prosledjen stavlja ih u listu
        /// </summary>
        /// <param name="zanr"></param>
        /// <returns></returns>
        private bool PretraziFilmovePoZanru(Zanr zanr, out List<Film> lista)
        {
            List<Film> f = new List<Film>();
            foreach (var film in filmovi)
            {
                if (film.Zanr == zanr)
                    f.Add(film);
            }
            if (f.Count == 0)
            {
                lista = null;
                return false;
            }
            lista = f;
            return true;

        }
        private void UcitajComboBox()
        {
            foreach (var zanr in Enum.GetValues(typeof(Zanr)))
            {
                cbZanrovi.Items.Add(zanr);
            }
        }

        private void PictureBox_Click(object sender, EventArgs e)
        {
            PictureBox box = (PictureBox)sender;
            int ime = Convert.ToInt32(box.Name);
            MessageBox.Show(filmovi[ime - 1].ToString(), filmovi[ime - 1].Naziv);
        }

        private void GledajButton_Click(object sender, EventArgs e)
        {
            Button b = (Button)sender;
            prosledi = b.AccessibleName;
            Video v = new Video();
            v.ShowDialog();

            PoslednjeGledanoSerializuj(b);
        }

        private void PoslednjeGledanoSerializuj(Button b)
        {
            Film f = null;
            foreach (var item in filmovi)
            {
                if (b.Name == item.Id.ToString())
                {
                    f = item;
                    break;
                }
            }
            //pozovi serijalizaciju
            FileStream fs = new FileStream("PoslednjeGledano.txt", FileMode.OpenOrCreate);
            BinarniFajl bf = new BinarniFajl();
            bf.Serializuj(f, fs);
        }

        private void PoslednjeGledanoDeserialzuj()
        {
            Film a = new Film();
            FileStream fs = new FileStream("PoslednjeGledano.txt", FileMode.OpenOrCreate);
            BinarniFajl bf = new BinarniFajl();
            if (bf.Deserialize(fs, out a))
            {
                PictureBox pb = new PictureBox();
                pnlPoslednjiFilm.Controls.Add(pb);
                pb.Name = a.Id.ToString();
                pb.Location = new Point(70, 60);
                pb.Load(a.UrlSlike);
                pb.SizeMode = PictureBoxSizeMode.StretchImage;
                pb.Click += this.PictureBox_Click;

                Button b = new Button();
                pnlPoslednjiFilm.Controls.Add(b);
                b.Location = new Point(80, 120);
                b.Text = "Gledaj";
                b.Name = a.Id.ToString();
                b.AccessibleName = a.Url;
                b.Click += this.GledajButton_Click;
                return;
            }
            return;
        }

        private void tbSearch_KeyDown(object sender, KeyEventArgs e)
        {
            List<Film> f = new List<Film>();

            if (e.KeyData == Keys.Enter)
            {
                if (PretraziFilmove(tbSearch.Text, out f))
                    UcitajFilmoveNaFormu(f);
                else MessageBox.Show("Nemamo taj film");
            }
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            tbSearch.Text = "";
            UcitajFilmoveNaFormu(filmovi);
        }

        private void cbZanrovi_SelectedIndexChanged(object sender, EventArgs e)
        {
            List<Film> lista = new List<Film>();

            string selektovaniZanr = cbZanrovi.SelectedItem.ToString();
            Zanr z = (Zanr)Enum.Parse(typeof(Zanr), selektovaniZanr);
            if (PretraziFilmovePoZanru(z, out lista))
                UcitajFilmoveNaFormu(lista);
            else
                MessageBox.Show("nemamo film tog zanra");
        }
    }
}
