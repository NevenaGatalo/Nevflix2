using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace Nevflix3
{
    class BinarniFajl
    {
        public void Serializuj(object objekat, FileStream file)
        {
            try
            {
                if (objekat == null)
                    throw new Exception("Objekat je null");
                BinaryFormatter bf = new BinaryFormatter();
                bf.Serialize(file, objekat);
                return;
            }
            catch
            {
                throw new Exception("Fajl ne postoji!");
            }
            finally
            {
                file.Close();
            }
        }

        public bool Deserialize(FileStream file, out Film o)
        {
            try
            {
                o = null;
                if (file.Length == 0)
                {
                    return false;
                }
                BinaryFormatter bf = new BinaryFormatter();
                o = (Film)bf.Deserialize(file);
                if (o == null)
                    throw new Exception("Fajl nije dobro napisan");
                return true;
            }
            catch
            {
                throw new Exception("Fajl ne postoji!");
            }
            finally
            {
                file.Close();
            }
        }
    }
}
