using Gma.CodeCloud.Base;
using Gma.CodeCloud.Base.FileIO;
using Gma.CodeCloud.Base.Geometry;
using Gma.CodeCloud.Base.TextAnalyses.Blacklist;
using Gma.CodeCloud.Base.TextAnalyses.Processing;
using Gma.CodeCloud.Base.TextAnalyses.Stemmers;
using Gma.CodeCloud.Controls;
using LiteDB;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Configuration;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace JobAnalyzer
{
    public partial class MainForm : Form
    {
        #region Cloud Tags
        private readonly CloudControl m_CloudControl = new CloudControl();
        private decimal m_TotalWordCount;
        private CancellationTokenSource m_CancelSource;
        private long m_LastTicks;
        private int m_ProgressValue;
        #endregion

        Handler getVacancy;
        VacancyCollection _vacancyCollection;
        Areas ars;
        string DBstorage;

        /// <summary>Словарь для построения запроса</summary>
        Dictionary<string, List<string>> DicQuery { get; set; }

        public MainForm()
        {
            InitializeComponent();

            #region Инициализация облачных тэгов
            m_CloudControl.Dock = DockStyle.Fill;
            splitContainer1.Panel1.Controls.Add(m_CloudControl);
            m_CloudControl.MouseClick += CloudControlClick;
            m_CloudControl.MouseMove += CloudControlMouseMove;
            m_CloudControl.Paint += CloudControlPaint;

            toolStripComboBoxLayout.Items.AddRange(GetAvailableLayouts());
            toolStripComboBoxLayout.SelectedItem = LayoutType.Spiral;

            toolStripComboBoxFont.Items.AddRange(GetNamesWitRegularStyle());

            toolStripComboBoxMinFontSize.SelectedItem = "8";
            toolStripComboBoxMaxFontSize.SelectedItem = "72";
            toolStripComboBoxFont.SelectedItem = "Tahoma";
            //toolStripComboBoxLanguage.SelectedItem = "c#";
            toolStripComboBoxLanguage.SelectedItem = "Any *.txt";
            #endregion


            DBstorage = @"LiteData.db";

            getVacancy = new Handler();

            _vacancyCollection = new VacancyCollection();
            ars = new Areas();
            DicQuery = new Dictionary<string, List<string>>();

            for (int i = 1; i < 31; i++)
            {
                cbPeriod.Items.Add(i);
            }

            //Debug.Listeners.Add(new TextWriterTraceListener(Console.Out));
            //Debug.AutoFlush = true;
            Debug.Indent();
            Debug.WriteLine("Entering Main");
            Console.WriteLine("Hello World.");
            Debug.WriteLine("Exiting Main");
            Debug.Unindent();

            System.Diagnostics.Trace.WriteLine("Trace - Hello World!");
            System.Diagnostics.Debug.WriteLine("Debug - Hello World!");

            tbQuery.Text = LoadAppConfig();
        }

        private string LoadAppConfig()
        {
            return Properties.Settings.Default.LastRequest;
        }

        private void SaveAppConfig(string query)
        {
            //string Query = tbQuery.Text;

            // 100% рабочий вариант
            //Properties.Settings.Default.LastRequest = Query;
            //Properties.Settings.Default.Save();
            //Properties.Settings.Default.Upgrade();
            //MessageBox.Show("Saved Settings: " + Query);
            //Application.Restart();

            Properties.Settings.Default.LastRequest = query;
            Properties.Settings.Default.Save();
            ConfigurationManager.RefreshSection("appSettings");
            ConfigurationManager.RefreshSection("userSettings");

            //// Open App.Config of executable
            //System.Configuration.Configuration config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
            //// Add an Application Setting.
            //config.AppSettings.Settings.Remove("LastDateFeesChecked");
            //config.AppSettings.Settings.Add("LastDateFeesChecked", DateTime.Now.ToShortDateString());
            //// Save the configuration file.
            //config.Save(ConfigurationSaveMode.Modified);
            //// Force a reload of a changed section.
            //ConfigurationManager.RefreshSection("appSettings");
        }

        private void SaveOldRequest(string query)
        {
            // Open App.Config of executable
            System.Configuration.Configuration config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
            // Add an Application Setting.
            config.AppSettings.Settings.Add(DateTime.Now.Ticks.ToString(), query);
            // Save the configuration file.
            config.Save(ConfigurationSaveMode.Modified);
            // Force a reload of a changed section.
            ConfigurationManager.RefreshSection("appSettings");
        }

        private void ReloadView()
        {
            Console.WriteLine("ReloadView");

            System.Configuration.Configuration config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
            NameValueCollection sAll = ConfigurationManager.AppSettings;

            foreach (string s in sAll.AllKeys)
            {
                DateTime myDate = new DateTime(Convert.ToInt64(s));
                String test = myDate.ToString("dd MMMM yyyy");

                //Console.WriteLine("Key: " + s + " Value: " + sAll.Get(s));
                Console.WriteLine("Key: " + myDate.ToString() + " Value: " + sAll.Get(s));
            }


            //DateTime myDate = new DateTime(numberOfTicks);
            //String test = myDate.ToString("MMMM dd, yyyy");

            //DateTime dt = new DateTime(633896886277130000);
            //dt.ToString() ==> "9/27/2009 10:50:27 PM"
        }


        private void btnLoad_Click(object sender, EventArgs e)
        {
            RefreshTable();
        }

        private void Form_Load(object sender, EventArgs e)
        {
            if (File.Exists(VacancyCollection.BaseName))     // Если база создана, то выполняем
            {
                _vacancyCollection = VacancyCollection.Load();

                if (_vacancyCollection.VacancyList.Count > 0) RefreshTable();
            }
            LoadCountry();
        }

        private void RefreshTable()    // Обновление таблицы путем фильтрации элементов по полю Path
        {
            List<Items> filtered = _vacancyCollection.VacancyList;

            dgvTable.DataSource = null;
            dgvTable.DataSource = filtered;
        }


        #region Analyze

        private void btnAddKeyforAnalyze_Click(object sender, EventArgs e)
        {
            lbKeys.Items.Add(tbKey.Text);
        }

        private void lbKeys_DoubleClick(object sender, EventArgs e)
        {
            lbKeys.Items.Remove(lbKeys.SelectedItem);
        }

        #endregion



        // Получить список стран
        private void btnRefreshCountry_Click(object sender, EventArgs e)
        {
            btnRefreshCountry.Enabled = false;
            LoadCountry();
            btnRefreshCountry.Enabled = true;
        }

        private void LoadCountry()
        {
            try
            {
                cbCountry.Items.Clear();
                List<Area> ListArea = getVacancy.GetCountry();
                ListArea.Sort(Area.CompareByName);
                cbCountry.Items.AddRange(ListArea.ToArray());

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        // Получить периоды
        private void btnRefreshPeriod_Click(object sender, EventArgs e)
        {
            btnRefreshPeriod.Enabled = false;
            getJobPlan();
            btnRefreshPeriod.Enabled = true;
        }

        private void getJobPlan()
        {
            cbGrafik.Items.Clear();
            cbGrafik.Items.AddRange(getVacancy.GetGrafik().schedule);    // []Schedule
        }

        private void cbGrafik_SelectedIndexChanged(object sender, EventArgs e)
        {
            Schedule _period = new Schedule();
            if (cbGrafik.SelectedItem is Schedule)
            {
                _period = (Schedule)cbGrafik.SelectedItem;
            }

            string key = "grafik";
            string par = "&schedule=" + _period.id;
            SetRequestParam(key, par);
        }


        private void cbPeriod_SelectedIndexChanged(object sender, EventArgs e)
        {
            string key = "period";
            string par = "&search_period=" + cbPeriod.SelectedItem.ToString();
            SetRequestParam(key, par);
        }

        private void cbSpecs_SelectedIndexChanged(object sender, EventArgs e)
        {
            Specs _spec = new Specs();
            if (cbSpecs.SelectedItem is Specs)
            {
                _spec = (Specs)cbSpecs.SelectedItem;
            }

            string key = "specs";
            string par = "&specialization=" + _spec.id;
            SetRequestParam(key, par);
        }

        /// <summary>Корректировка словаря параметров запросов</summary>
        /// <param name="key">ключ</param>
        /// <param name="par">URL значение</param>
        private void SetRequestParam(string key, string par)
        {
            if (!DicQuery.ContainsKey(key)) // проверяем создан ли ключ
            {
                DicQuery.Add(key, new List<string>());
                DicQuery[key].Add(par);
                return;
            }
            else
            {
                DicQuery[key].Clear();
                DicQuery[key].Add(par);
            }
        }



        #region Постройка дерева
        void TreeViewDeveloper(Areas _areas)
        {
            TreeNode treeNode = new TreeNode(_areas.name);
            AddChildren(treeNode, _areas.areas);
            treeView1.Nodes.Add(treeNode);
        }

        void AddChildren(TreeNode treeNode, List<Areas> _areas) // Рекурсивное построение дерева
        {
            _areas.Sort(Areas.CompareByName);   // Сортировка дерева
            foreach (var item in _areas)
            {
                TreeNode newNode = new TreeNode(item.name);
                treeNode.Nodes.Add(newNode);
                if (item.areas != null && item.areas.Count > 0)
                {
                    AddChildren(newNode, item.areas);
                }
            }
        }
        #endregion

        private void cbCountry_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Получить список регионов
            Area _country = new Area();
            if (cbCountry.SelectedItem is Area)
            {
                _country = (Area)cbCountry.SelectedItem;
            }

            foreach (TreeNode countryNode in treeView1.Nodes)  // исключаем дублирование элементов
            {
                if (countryNode.Text == _country.name)
                    return;
            }

            ars = getVacancy.GetRegions(_country.id.ToString());
            treeView1.Nodes.Clear();
            TreeViewDeveloper(ars);
        }

        private void treeView1_NodeMouseClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            SelectRegion(e.Node.Text);
        }

        // Выбор региона
        private void SelectRegion(string nodeName)
        {
            try
            {
                Areas _regionA = Areas.Find(ars, nodeName);

                if (_regionA != null)
                {
                    string region = "&area=" + _regionA.id;

                    if (!DicQuery.ContainsKey("country"))// проверяем создан ли ключ
                    {
                        DicQuery.Add("country", new List<string>());
                        DicQuery["country"].Add(region);
                        return;
                    }
                    else
                    {
                        if (_regionA.parent_id == null)     // если нет родителя (parent_id), значит это страна
                        {
                            //if (!DicQuery["country"].Contains(region))  // если &area=113 не существует, то добавить
                            //{
                            //    deleteParent(region);
                            //    deleteChild(region);
                            //    DicQuery["country"].Add(region);
                            //    return;
                            //}
                            //else
                            //{   // даже если он есть удаляем все лишнее
                            //    deleteParent(region);
                            //    deleteChild(region);
                            //    DicQuery["country"].Add(region);// проверка чтобы удаленный объект возвращался на место
                            //    return;
                            //}

                            deleteParent(region);
                            deleteChild(region);
                            DicQuery["country"].Add(region);
                            return;

                        }       // есть родитель, запуск поиска
                        else
                        {
                            deleteParent(region);
                            deleteChild(region);
                            if (!DicQuery["country"].Contains(region))
                            {
                                DicQuery["country"].Add(region);
                            }
                        }
                    }
                }
            }
            catch (Exception ex) { MessageBox.Show("Выполняется метод: SelectRegion. \n\nОшибка:\n" + ex.Message); }
        }

        //удаление предков на основе parent_id (идем снизу вверх)
        void deleteParent(string node)
        {
            try
            {
                Areas objectID = Areas.FindbyID(ars, node.Substring(node.LastIndexOf('=') + 1));

                if (objectID != null)
                {
                    if (objectID.parent_id != null)
                    {
                        string parent = "&area=" + objectID.parent_id;

                        if (DicQuery["country"].Contains(parent))
                            DicQuery["country"].Remove(parent);

                        deleteParent(parent);
                    }
                }
            }
            catch (Exception ex) { MessageBox.Show("Выполняется метод: checkArea3. /nОшибка:/n" + ex.Message); }
        }

        //удаление детей на основе parent_id (идем сверху вниз)
        void deleteChild(string node)
        {
            string nodeID = node.Substring(node.LastIndexOf('=') + 1);   // 113

            List<string> ss = new List<string>();

            DicQuery["country"].ForEach(x => ss.Add(x));


            // for (int i = 0; i < DicQuery["country"].Count; i++)
            for (int i = 0; i < ss.Count(); i++)
            {
                string count = ss[i];
                string count_number = count.Substring(count.LastIndexOf('=') + 1);   // 113

                List<string> listParent = new List<string>();

                Areas _id_obj = Areas.FindbyID(ars, count_number);
                if (_id_obj != null)    //если есть объект
                {
                    checkparent(_id_obj.id, ref listParent);
                }

                foreach (var pr in listParent)
                {
                    if (pr == nodeID)
                    {
                        DicQuery["country"].Remove(count);
                        break;
                    }
                }
            }
        }

        void checkparent(string id, ref List<string> parent)
        {
            Areas _id_obj = Areas.FindbyID(ars, id);
            if (_id_obj != null)    //если есть объект
            {
                if (_id_obj.parent_id != null)
                {
                    parent.Add(_id_obj.id);
                    checkparent(_id_obj.parent_id, ref parent);
                }
                else
                {   // если родителей нет, значит корневой элемент, добавляем и выходим
                    parent.Add(_id_obj.id);
                }
            }
        }


        private string getQueryText()
        {
            return tbQuery.Text;
        }

        private void setQueryText(string query)
        {
            tbQuery.Text = query;
        }

        // проверка строки запроса
        private void btnCheckTextQuery_Click(object sender, EventArgs e)
        {
            string query = "?text=" + System.Uri.EscapeDataString(tbTextForQuery.Text);  // преобразовываем строку в формат URL

            if (DicQuery != null && DicQuery.Keys.Count > 0)
            {
                foreach (var _key in DicQuery.Keys)
                {
                    if (DicQuery[_key].Count > 0)
                    {
                        foreach (var _listElement in DicQuery[_key])
                        {
                            query += _listElement;
                        }
                    }
                }
            }
            setQueryText(query);
            SaveAppConfig(getQueryText());

            SaveOldRequest(getQueryText());

            ReloadView();
        }



        private void btnQuery_Click(object sender, EventArgs e)
        {
            string Query = tbQuery.Text;
            List<Class.Item> VacItems = getVacancy.FindAllVacancies(Query);
            List<string> ListURL = new List<string>();
            foreach (var item in VacItems)
            {
                ListURL.Add(item.url);
            }

            var listVacs = getcontentVacancy(ListURL);

            //SaveContentVacancyToFiles(listVacs);

            SaveToDB(listVacs);

            Debug.WriteLine("Request completed successfully!");
        }

        private List<Class.Vacancy.RootObject> getcontentVacancy(List<string> ListURL)
        {
            List<Class.Vacancy.RootObject> listVacs = new List<Class.Vacancy.RootObject>();

            foreach (var _url in ListURL)
            {
                listVacs.Add(getVacancy.GetVacContent(_url));
                //break;
            }
            return listVacs;
        }

        private void SaveToDB(List<Class.Vacancy.RootObject> listVacs)
        {
            listVacs = listVacs.GroupBy(x => x.id).Select(x => x.First()).ToList();

            foreach (Class.Vacancy.RootObject _obj in listVacs)
            {
                // Open database (or create if not exits)
                using (var db = new LiteDatabase(DBstorage))
                {
                    var vacancies = db.GetCollection<Class.Vacancy.RootObject>("Vacancies");
                    if (!vacancies.Exists(x => x.id.Contains(_obj.id)))
                    {
                        vacancies.Insert(_obj);
                    }
                }
            }
        }


        private void SaveContentVacancyToFiles(List<Class.Vacancy.RootObject> listVacs)
        {
            foreach (Class.Vacancy.RootObject _obj in listVacs)
            {
                SaveRootObject(_obj);
            }
        }

        /// <summary>Сохранение описания вакансий в файл</summary>
        /// <param name="_obj">Vacancy object</param>
        private void SaveRootObject(Class.Vacancy.RootObject _obj)
        {
            string fileName = _obj.id + ".txt";

            if (File.Exists(fileName))
            {
                File.Delete(fileName);
            }

            using (System.IO.StreamWriter file = new System.IO.StreamWriter(fileName, true))
            {
                string desc = _obj.description;

                desc = ClearUnsuppporteSymbol(desc);

                file.WriteLine(desc);
            }
        }

        /// <summary>Очистка текста о спец.чимвлов и кирилицы</summary>
        private string ClearUnsuppporteSymbol(string desc)
        {
            desc = StripHTML(desc);
            //Debug.WriteLine(desc);

            desc = TrimNonAscii(desc);
            //Debug.WriteLine(desc);

            //desc = RemoveCyrillic(desc);
            //Debug.WriteLine(desc);

            desc = RemovePunctuationCharacters(desc);
            //Debug.WriteLine(desc);

            desc = RemoveOneSymbol(desc);
            //Debug.WriteLine(desc);

            desc = RemoveDuplicateSpace(desc);
            //Debug.WriteLine(desc);
            return desc;
        }

        public static string StripHTML(string htmlString)
        {
            string pattern = @"<(.|\n)*?>";
            return Regex.Replace(htmlString, pattern, string.Empty);
        }

        private string TrimNonAscii(string value)
        {
            string pattern = "[^ -~]+";
            Regex reg_exp = new Regex(pattern);
            return reg_exp.Replace(value, "");
        }

        private string RemoveCyrillic(string value)
        {
            return Regex.Replace(value, "[^a-zA-Z0-9% ._]", string.Empty);
        }

        private string RemovePunctuationCharacters(string value)
        {
            return Regex.Replace(value, @"\p{P}", " ");
        }

        private string RemoveDuplicateSpace(string tempo)
        {
            RegexOptions options = RegexOptions.None;
            Regex regex = new Regex("[ ]{2,}", options);
            tempo = regex.Replace(tempo, " ");
            return tempo;
        }

        private string RemoveOneSymbol(string input)
        {
            Regex re = new Regex(@"\b\w{1}\b");
            var result = re.Replace(input, "");
            return result;
        }



        // сброс
        private void btnReset_Click(object sender, EventArgs e)
        {
            DicQuery.Clear();
            tbTextForQuery.Text = "";
            tbQuery.Text = "";
        }


        private void btnVac_Click(object sender, EventArgs e)
        {
            //string vac = "19291539";
            //getVacancy.GetVacancy(vac);
        }

        private void btnAnalyze_Click(object sender, EventArgs e)
        {

            //  _vacancyCollection.DicKey
        }

        private void btnCheckSpecs_Click(object sender, EventArgs e)
        {
            btnCheckSpecs.Enabled = false;
            getSpecs();
            btnCheckSpecs.Enabled = true;
        }

        private void getSpecs()
        {
            cbSpecs.Items.Clear();
            List<Specs> ListSpecs = getVacancy.GetSpecs();
            ListSpecs.Sort(Specs.CompareByName);
            cbSpecs.Items.AddRange(ListSpecs.ToArray());
        }



        #region Cloud Handler

        private static object[] GetAvailableLayouts()
        {
            return Enum.GetValues(typeof(LayoutType)).Cast<object>().ToArray();
        }

        private static object[] GetNamesWitRegularStyle()
        {
            return FontFamily.Families
                .Where(fontFamily => fontFamily.IsStyleAvailable(FontStyle.Regular))
                .Select(fontFamily => fontFamily.Name)
                .Cast<object>()
                .ToArray();
        }

        private string GetItemCaption(LayoutItem itemUderMouse)
        {
            if (m_TotalWordCount == 0 || itemUderMouse == null)
            {
                return null;
            }

            return string.Format(
                "\n\r{0} - occurances\n\r{1}% - of total words\n\r-------------------------------------\n\r{2}",
                itemUderMouse.Word.Occurrences,
                Math.Round(itemUderMouse.Word.Occurrences * 100 / m_TotalWordCount, 2),
                itemUderMouse.Word.GetCaption());
        }

        private void CloudControlClick(object sender, MouseEventArgs e)
        {
            if (e.Button != MouseButtons.Left)
            {
                if (e.Button == MouseButtons.Right)
                {
                    contextMenu.Show(this, e.Location);
                }
                return;
            }

            LayoutItem itemUderMouse = m_CloudControl.ItemUnderMouse;
            if (itemUderMouse == null)
            {
                return;
            }

            MessageBox.Show(
                GetItemCaption(itemUderMouse),
               string.Format("Statistics for word [{0}]", itemUderMouse.Word.Text),
               MessageBoxButtons.OK,
               MessageBoxIcon.Information);
        }

        private void ToolStripButtonGoClick(object sender, EventArgs e)
        {
            IsRunning = true;

            //string path = FolderTree.SelectedPath;
            string path = System.IO.Path.GetDirectoryName(Assembly.GetEntryAssembly().Location);
            Language formatFiles = ByLanguageFactory.GetLanguageFromString(toolStripComboBoxLanguage.Text);

            FileIterator fileIterator = ByLanguageFactory.GetFileIterator(formatFiles);
            IBlacklist blacklist = ByLanguageFactory.GetBlacklist(formatFiles);
            IWordStemmer stemmer = ByLanguageFactory.GetStemmer(formatFiles);

            SetCaptionText("Estimating ...");

            string[] files = fileIterator
                .GetFiles(path)
                .ToArray();

            ToolStripProgressBar.Maximum = files.Length;

            m_CloudControl.WeightedWords = new List<IWord>();

            //Note do not dispose m_CancelSource it will be disposed by task 
            //TODO need to find correct way to work with CancelationToken
            //http://stackoverflow.com/questions/6960520/when-to-dispose-cancellationtokensource
            m_CancelSource = new CancellationTokenSource();
            Task.Factory
                .StartNew(
                    () => GetWordsParallely(files, formatFiles, blacklist, stemmer), m_CancelSource.Token)
                .ContinueWith(
                    ApplyResults);
        }

        private void CloudControlPaint(object sender, PaintEventArgs e)
        {
            SetCaptionText(string.Format("Showing {0} words of {1}", m_CloudControl.ItemsCount, m_TotalWordCount));
        }

        private void CloudControlMouseMove(object sender, MouseEventArgs e)
        {
            LayoutItem itemUderMouse = m_CloudControl.ItemUnderMouse;
            if (itemUderMouse == null)
            {
                toolTip.SetToolTip(m_CloudControl, null);
                return;
            }

            toolTip.SetToolTip(
                m_CloudControl,
                GetItemCaption(itemUderMouse));

            toolTip.ToolTipTitle = string.Format("Statistics for word [{0}]", itemUderMouse.Word.Text);
        }

        /// <summary>Поиск и выборка слова с учетом фильтра</summary>
        /// <param name="files"></param>
        /// <param name="language"></param>
        /// <param name="blacklist"></param>
        /// <param name="stemmer"></param>
        /// <returns></returns>
        private List<IWord> GetWordsParallely(IEnumerable<string> files, Language language, IBlacklist blacklist, IWordStemmer stemmer)
        {
            return files
                .AsParallel()
                //.WithDegreeOfParallelism(0x8)
                .WithCancellation(m_CancelSource.Token)
                .WithCallback(DoProgress)
                .SelectMany(file => ByLanguageFactory.GetWordExtractor(language, file))
                .Filter(blacklist)
                .CountOccurences()
                .GroupByStem(stemmer)
                .SortByOccurences()
                .AsEnumerable()
                .Cast<IWord>()
                .ToList();
        }

        /// ////////////////////////////////////////////////////////////////////////////////////////////
        /// 

        private void CreateDiagram(string[] files)
        {
            FileIterator fileIterator = ByLanguageFactory.GetFileIterator(ByLanguageFactory.GetLanguageFromString(toolStripComboBoxLanguage.Text));
            IBlacklist blacklist = ByLanguageFactory.GetBlacklist(Language.AnyTxt);
            //IWordStemmer stemmer = ByLanguageFactory.GetStemmer(Language.AnyTxt);
            IWordStemmer stemmer = new LowerCaseStemmer();

            //{ Gma.CodeCloud.Base.TextAnalyses.Stemmers.LowerCaseStemmer}

            SetCaptionText("Estimating ...");

            ToolStripProgressBar.Maximum = files.Length;

            m_CloudControl.WeightedWords = new List<IWord>();

            //Note do not dispose m_CancelSource it will be disposed by task 
            //TODO need to find correct way to work with CancelationToken
            //http://stackoverflow.com/questions/6960520/when-to-dispose-cancellationtokensource
            m_CancelSource = new CancellationTokenSource();
            Task.Factory
                .StartNew(
                    () => GetWordsParallelyLiteDB(files, blacklist, stemmer), m_CancelSource.Token)
                .ContinueWith(
                    ApplyResults);
        }

        /// <summary>Модификация для работы с базой</summary>
        /// <param name="files"></param>
        /// <param name="blacklist"></param>
        /// <param name="stemmer"></param>
        /// <returns></returns>
        private List<IWord> GetWordsParallelyLiteDB(IEnumerable<string> files, IBlacklist blacklist, IWordStemmer stemmer)
        {
            return files
                .AsParallel()
                .WithCallback(DoProgress)
                .SelectMany(file => ByLanguageFactory.GetWordExtractor(file))
                .Filter(blacklist)
                .CountOccurences()
                .GroupByStem(stemmer)
                .SortByOccurences()
                .AsEnumerable()
                .Cast<IWord>()
                .ToList();
        }

        /// <summary>Передача тэгов на панель отрисовки</summary>
        /// <param name="task"></param>
        private void ApplyResults(Task<List<IWord>> task)
        {
            Invoke(
                new Action(
                    () =>
                    {
                        if (task.IsCanceled)
                        {
                            SetCaptionThreadsafe("Canceled");
                            m_CloudControl.WeightedWords = new List<IWord>();
                        }
                        else
                        {
                            if (task.IsFaulted && task.Exception != null)
                            {
                                throw task.Exception;
                            }

                            SetCaptionThreadsafe("Finished");
                            //var a = task.Result;
                            //m_CloudControl.WeightedWords = a;
                            m_CloudControl.WeightedWords = task.Result;
                        }

                        m_TotalWordCount = m_CloudControl.WeightedWords.Sum(word => word.Occurrences);
                        IsRunning = false;
                    }));
        }

        private void DoProgress(string fileName)
        {
            m_ProgressValue++;
            if (DateTime.UtcNow.Ticks - m_LastTicks < TimeSpan.TicksPerSecond / 30) //30 frames per second
            {
                return;
            }
            SetCaptionThreadsafe(ShortenFileName(fileName, 60));
            m_LastTicks = DateTime.UtcNow.Ticks;
        }

        public void SetCaptionThreadsafe(string fileName)
        {
            Action<string> setCaption = SetCaptionText;
            Invoke(setCaption, fileName);
        }

        public void SetCaptionText(string text)
        {
            ToolStripProgressBar.Value = m_ProgressValue;
            Text = string.Concat("Source Code Word Colud Generator :: " + text);
        }

        private void ToolStripButtonCancelClick(object sender, EventArgs e)
        {
            if (m_CancelSource != null)
            {
                m_CancelSource.Cancel(true);
            }
        }

        private bool IsRunning
        {
            set
            {
                ToolStripButtonCancel.Enabled = value;
                ToolStripButtonGo.Enabled = !value;
                if (!value)
                {
                    ToolStripProgressBar.Value = 0;
                    m_ProgressValue = 0;
                }
                Application.DoEvents();
            }
        }

        private void ToolStripButtonEditBlacklistClick(object sender, EventArgs e)
        {
            Language language = ByLanguageFactory.GetLanguageFromString(toolStripComboBoxLanguage.Text);
            string fileName = ByLanguageFactory.GetBlacklistFileName(language);
            Process.Start("notepad.exe", fileName);
        }

        private void ToolStripComboBoxFontSelectedIndexChanged(object sender, EventArgs e)
        {
            m_CloudControl.Font = new Font(toolStripComboBoxFont.Text, 12, FontStyle.Regular);
            if (int.TryParse(toolStripComboBoxMinFontSize.Text, out int value))
            {
                m_CloudControl.MinFontSize = value;
            }

            if (int.TryParse(toolStripComboBoxMaxFontSize.Text, out value))
            {
                m_CloudControl.MaxFontSize = value;
            }

            m_CloudControl.LayoutType = (LayoutType)toolStripComboBoxLayout.SelectedItem;
        }

        private static string ShortenFileName(string fullFileName, int maxLength)
        {
            if (fullFileName.Length <= maxLength)
            {
                return fullFileName;
            }

            int partLength = maxLength / 2 - 2;

            return string.Concat(
                fullFileName.Remove(partLength),
                "...",
                fullFileName.Substring(fullFileName.Length - partLength));
        }


        private void HideMenuItemClick(object sender, EventArgs e)
        {
            IWord word = GetWordUnderMouse();
            RemoveFromControl(word);
        }

        private void HideAndBlackListMenuItemClick(object sender, EventArgs e)
        {
            IWord word = GetWordUnderMouse();
            RemoveFromControl(word);
            AddToBlacklist(word.Text);
        }

        private void RemoveFromControl(IWord word)
        {
            m_CloudControl.WeightedWords.Remove(word);
            m_CloudControl.BuildLayout();
            m_CloudControl.Invalidate();
        }

        private void AddToBlacklist(string term)
        {
            Language language = ByLanguageFactory.GetLanguageFromString(toolStripComboBoxLanguage.Text);
            string fileName = ByLanguageFactory.GetBlacklistFileName(language);
            using (StreamWriter writer = new StreamWriter(fileName, true, Encoding.UTF8))
            {
                writer.WriteLine();
                writer.Write(term);
            }
        }

        private IWord GetWordUnderMouse()
        {
            LayoutItem itemUderMouse = m_CloudControl.ItemUnderMouse;
            return itemUderMouse == null
                ? new Word(string.Empty, 0)
                : itemUderMouse.Word;
        }

        private void ToolStripButtonSaveClick(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog
            {
                Filter = @"PNG (*.png)|*.png|Bitmap (*.bmp)|*.bmp",
                //saveFileDialog.FileName = Path.GetFileName(FolderTree.SelectedPath);
                FileName = "Cloud_image",
                DefaultExt = "png"
            };

            if (saveFileDialog.ShowDialog() != DialogResult.OK)
            {
                return;
            }

            using (Bitmap bitmap = new Bitmap(m_CloudControl.Size.Width, m_CloudControl.Size.Height))
            {
                m_CloudControl.DrawToBitmap(bitmap, new Rectangle(new Point(0, 0), bitmap.Size));
                bitmap.Save(
                    saveFileDialog.FileName,
                    saveFileDialog.FileName.EndsWith("png")
                        ? ImageFormat.Png
                        : ImageFormat.Bmp);
            }
        }


        #endregion


        private void btnInit_Click(object sender, EventArgs e)
        {
            getJobPlan();
            getSpecs();
        }

        private void tbQuery_DoubleClick(object sender, EventArgs e)
        {
            tbQuery.ReadOnly = false;
        }

        private void btnCheckDB_Click(object sender, EventArgs e)
        {
            using (var db = new LiteDatabase(DBstorage))
            {
                LiteCollection<Class.Vacancy.RootObject> vacancies = db.GetCollection<Class.Vacancy.RootObject>("Vacancies");
                IEnumerable<Class.Vacancy.RootObject> result = vacancies.FindAll();

                foreach (Class.Vacancy.RootObject _obj in result)
                {
                    SaveRootObject(_obj);
                }
            }
        }



        private void btnDBtoDiagram_Click(object sender, EventArgs e)
        {
            List<string> TEst = new List<string>();

            using (var db = new LiteDatabase(DBstorage))
            {
                LiteCollection<Class.Vacancy.RootObject> vacancies = db.GetCollection<Class.Vacancy.RootObject>("Vacancies");
                IEnumerable<Class.Vacancy.RootObject> result = vacancies.FindAll();

                foreach (Class.Vacancy.RootObject _obj in result)
                {
                    string desc = _obj.description;

                    desc = ClearUnsuppporteSymbol(desc);

                    TEst.Add(desc);
                }
            }

            string[] files = TEst.ToArray();

            CreateDiagram(files);

            DisplayPresetData();
        }

        private List<Class.Vacancy.RootObject> GetAll()
        {
            var list = new List<Class.Vacancy.RootObject>();
            using (var db = new LiteDatabase(DBstorage))
            {
                var col = db.GetCollection<Class.Vacancy.RootObject>("Vacancies");
                foreach (Class.Vacancy.RootObject _id in col.FindAll())
                {
                    list.Add(_id);
                }
            }
            return list;
        }

        public void DisplayPresetData()
        {
            dgvTable.DataSource = GetAll();
        }

        private void tbQuery_Enter(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)13)
            {
                tbQuery.ReadOnly = true;
                SaveAppConfig(getQueryText());
            }
        }
    }
}