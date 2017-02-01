using System;
using System.IO;
using System.Windows.Forms;
using System.Xml.Serialization;

namespace JobAnalyzer
{
    public static class XmlSerializeHelper
    {
        public static bool SerializeAndSave(string filename, object objectToSerialize)
        {
            XmlSerializer serializer = new XmlSerializer(objectToSerialize.GetType());
            try
            {
                using (FileStream stream = new FileStream(Path.Combine(Path.GetDirectoryName(Application.ExecutablePath), filename), FileMode.Create))
                    serializer.Serialize(stream, objectToSerialize);
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
                return false;
            }
            return true;
        }   

        public static T LoadAndDeserialize<T>(this string filename)
        {
            if (!File.Exists(filename))
                throw new Exception("File not exist");

            if ((new FileInfo(filename).Length) < 200)
                throw new Exception("Некорректный файл XML");

            XmlSerializer serializer = new XmlSerializer(typeof(T));

            try
            {
                using (FileStream stream = new FileStream(Path.Combine(Path.GetDirectoryName(Application.ExecutablePath), filename), FileMode.Open))
                    return (T)serializer.Deserialize(stream);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message + "\nПричина: " + ex.InnerException.Message);
            }
        }
    }
}
