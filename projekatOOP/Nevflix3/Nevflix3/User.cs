using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nevflix3
{
    public class User
    {
        private string username;
        private string sifra;
        private List<Film> mojiFilmovi = new List<Film>();


        public User(string username, string sifra)
        {
            this.Username = username;
            this.Sifra = sifra;
        }

        public string Username { get => username; set => username = value; }
        public string Sifra { get => sifra; set => sifra = value; }

        public void AddMojiFilmovi (Film f)
        {
            if (f == null)
                throw new Exception("Film koji pokusavate da dodate je null");
            mojiFilmovi.Add(f);
        }
    }
}
