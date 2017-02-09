using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace JobAnalyzer
{
    public class AnalyzeKey
    {
        public AnalyzeKey()
        {
            key = new List<string>();
        }
        List<string> key { get; set; }
    }


    public class VacancyCollection
    {
        public VacancyCollection()
        {
            VacancyList = new List<Items>();
            DicKey = new Dictionary<int, List<string>>();
            aKey = new AnalyzeKey();
        }

        public AnalyzeKey aKey { get; set; }

        public Dictionary<int, List<string>> DicKey { get; set; }

        public static string BaseName { get; } = "VacancyList.xml";


        public List<Items> VacancyList { get; set; }
        public void Add(Items vac) => VacancyList.Add(vac);
        public void Remove(Items vac) => VacancyList.Remove(vac);
        public void ClearVacancyList() => VacancyList.Clear();

        


        #region Сериализация

        public void Save()                  // Сохранение
        {
            XmlSerializeHelper.SerializeAndSave(BaseName, this);
        }

        public static VacancyCollection Load()    // Загрузка
        {
            VacancyCollection result;
            try
            {
                result = BaseName.LoadAndDeserialize<VacancyCollection>();
            }
            catch (Exception ex)
            {
                throw new Exception("Ошибка на этапе загрузки файла базы. \n" + ex.Message);
            }
            return result;
        }

        #endregion
    }
}
