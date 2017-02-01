using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace JobAnalyzer
{
    public class VacancyCollection
    {
        public VacancyCollection()
        {
            VacancyList = new List<Items>();
        }

        public void Clear()
        {
            try
            {
                ClearVacancyList();
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
        }

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
