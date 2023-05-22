﻿using LiveCharts;
using LiveCharts.Wpf;
using Newtonsoft.Json;
using SOM.Model;
using SOM.Properties;
using SOM.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using System.Windows.Media;

namespace SOM.ViewModel
{
    public class DashboardViewModel : INotifyPropertyChanged
    {
        public DashboardViewModel() 
        {
            GetEquipmentsData();
            GetParamsData();
            GetRecipeData();
            GetInterlockData();
            setLanguage();

            Settings.Default.PropertyChanged += Default_Settings_PropertyChanged;

            ChatCollection = new ObservableCollection<ChatModel>();
            SendCommand = new RelayCommand(GetChatbotData);
            EnterPressedCommand = new RelayCommand(GetChatbotData);
        }

        public ICommand SendCommand { get; private set; }
        public ICommand EnterPressedCommand { get; private set; }

        private string _title;
        public string Title
        {
            get { return _title; }
            set
            {
                _title = value;
                OnPropertyChanged(nameof(Title));
            }
        }

        private string _equipmentName;
        public string EquipmentName
        {
            get { return _equipmentName; }
            set
            {
                _equipmentName = value;
                OnPropertyChanged(nameof(EquipmentName));
            }
        }

        private int _equipmentCount;
        public int EquipmentCount
        {
            get { return _equipmentCount; }
            set
            {
                _equipmentCount = value;
                OnPropertyChanged(nameof(EquipmentCount));
            }
        }

        private string _paramsName;
        public string ParamsName
        {
            get { return _paramsName; }
            set
            {
                _paramsName = value;
                OnPropertyChanged(nameof(ParamsName));
            }
        }

        private int _paramsCount;
        public int ParamsCount
        {
            get { return _paramsCount; }
            set
            {
                _paramsCount = value;
                OnPropertyChanged(nameof(ParamsCount));
            }
        }

        private string _recipeName;
        public string RecipeName
        {
            get { return _recipeName; }
            set
            {
                _recipeName = value;
                OnPropertyChanged(nameof(RecipeName));
            }
        }

        private int _recipeCount;
        public int RecipeCount
        {
            get { return _recipeCount; }
            set
            {
                _recipeCount = value;
                OnPropertyChanged(nameof(RecipeCount));
            }
        }

        private string _recentInterlockTitle;
        public string RecentInterlockTitle
        {
            get { return _recentInterlockTitle; }
            set
            {
                _recentInterlockTitle = value;
                OnPropertyChanged(nameof(RecentInterlockTitle));
            }
        }

        private string _smartSearchTitle;
        public string SmartSearchTitle
        {
            get { return _smartSearchTitle; }
            set
            {
                _smartSearchTitle = value;
                OnPropertyChanged(nameof(SmartSearchTitle));
            }
        }

        private string _smartSearchExplain;
        public string SmartSearchExplain
        {
            get { return _smartSearchExplain; }
            set
            {
                _smartSearchExplain = value;
                OnPropertyChanged(nameof(SmartSearchExplain));
            }
        }

        private string _sendText;
        public string SendText
        {
            get { return _sendText; }
            set
            {
                _sendText = value;
                OnPropertyChanged(nameof(SendText));
            }
        }

        private string _sendTextHint;
        public string SendTextHint
        {
            get { return _sendTextHint; }
            set
            {
                _sendTextHint = value;
                OnPropertyChanged(nameof(SendTextHint));
            }
        }

        private ObservableCollection<ChatModel> _chatCollection;
        public ObservableCollection<ChatModel> ChatCollection
        {
            get { return _chatCollection; }
            set
            {
                _chatCollection = value;
                OnPropertyChanged(nameof(ChatCollection));
            }
        }

        private SeriesCollection _seriesCollection;
        public SeriesCollection SeriesCollection
        {
            get { return _seriesCollection; }
            set
            {
                _seriesCollection = value;
                OnPropertyChanged(nameof(SeriesCollection));
            }
        }

        private List<string> _labels;
        public List<string> Labels
        {
            get { return _labels; }
            set
            {
                _labels = value;
                OnPropertyChanged(nameof(Labels));
            }
        }

        private Func<double, string> _formatter;
        public Func<double, string> Formatter
        {
            get { return _formatter; }
            set
            {
                _formatter = value;
                OnPropertyChanged(nameof(Formatter));
            }
        }

        private void Default_Settings_PropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            setLanguage();
        }

        private async void GetEquipmentsData()
        {
            HttpResponseMessage response = await GetEquipment.GetEquipmentAsync();
            ObservableCollection<EquipmentsModel> content = new ObservableCollection<EquipmentsModel>();

            if (response != null)
            {
                string str_content = await response.Content.ReadAsStringAsync();
                content = JsonConvert.DeserializeObject<ObservableCollection<EquipmentsModel>>(str_content);
                EquipmentCount = content.Count;
            }
            else
            {
                EquipmentCount = 0;
            }
        }

        private async void GetParamsData()
        {
            HttpResponseMessage response = await GetParams.GetParamsAsync();
            ObservableCollection<ParamsModel> content = new ObservableCollection<ParamsModel>();

            if (response != null)
            {
                string str_content = await response.Content.ReadAsStringAsync();
                content = JsonConvert.DeserializeObject<ObservableCollection<ParamsModel>>(str_content);
                ParamsCount = content.Count;
            }
            else
            {
                ParamsCount = 0;
            }
        }

        private async void GetRecipeData()
        {
            HttpResponseMessage response = await GetRecipe.GetRecipeAsync();
            ObservableCollection<RecipeModel> content = new ObservableCollection<RecipeModel>();

            if (response != null)
            {
                string str_content = await response.Content.ReadAsStringAsync();
                content = JsonConvert.DeserializeObject<ObservableCollection<RecipeModel>>(str_content);
                RecipeCount = content.Count;
            }
            else
            {
                RecipeCount = 0;
            }
        }

        private async void GetInterlockData()
        {
            ChartValues<int> values = new ChartValues<int>();
            List<string> ChartLabels = new List<string>();

            string startDate = DateTime.Now.AddMonths(-1).ToString("yyyy-MM-dd HH:mm");
            string endDate = DateTime.Now.ToString("yyyy-MM-dd HH:mm");

            HttpResponseMessage response_getInterlock = await GetInterlockLog.GetInterlockLogAsync(start_date: startDate, end_date: endDate);

            if (response_getInterlock != null && response_getInterlock.IsSuccessStatusCode)
            {

                string str_content = await response_getInterlock.Content.ReadAsStringAsync();
                ObservableCollection<InterlockLogModel> content = JsonConvert.DeserializeObject<ObservableCollection<InterlockLogModel>>(str_content);

                Dictionary<DateTime, int> itemCounts = new Dictionary<DateTime, int>();

                foreach (InterlockLogModel item in content)
                {
                    DateTime createdAt = item.created_at.Date; // 날짜 부분만 사용

                    if (itemCounts.ContainsKey(createdAt))
                    {
                        itemCounts[createdAt]++;
                    }
                    else
                    {
                        itemCounts.Add(createdAt, 1);
                    }
                }

                // 결과 출력
                foreach (KeyValuePair<DateTime, int> count in itemCounts)
                {
                    values.Add(count.Value);
                    ChartLabels.Add(count.Key.ToString("yyyy-MM-dd"));
                }
            }
            else
            {
                return;
            }


            SeriesCollection = new SeriesCollection
            {
                new ColumnSeries
                {
                    Title = "Interlock",
                    Values = values,
                    Fill = (SolidColorBrush)new BrushConverter().ConvertFrom("#d84a49")
        }
            };

            Labels = ChartLabels;
            //Formatter = value => value.ToString("N");
        }

        private async void GetChatbotData()
        {
            if (SendText == null) return;

            string questionText = SendText;
            SendText = string.Empty;
            string answerText = "작성 중...";

            ChatCollection.Add(new ChatModel(questionText, answerText));

            HttpResponseMessage response_chatbot = await GetChatbot.GetChatbotAsync(questionText);

            if (response_chatbot.IsSuccessStatusCode)
            {
                string str_content = await response_chatbot.Content.ReadAsStringAsync();
                ChatbotModel content = JsonConvert.DeserializeObject<ChatbotModel>(str_content);
                answerText = content.answer;
            }
            else
            {
                answerText = "해당 질문에 대해 답변을 찾기 어렵습니다.";
            }

            ChatCollection.RemoveAt(ChatCollection.Count - 1);
            ChatCollection.Add(new ChatModel(questionText, answerText));
        }

        private void setLanguage()
        {
            if (Settings.Default.Language == "Kor")
            {
                Title = "대쉬보드";
                EquipmentName = "등록된 설비";
                ParamsName = "등록된 항목";
                RecipeName = "등록된 레시피";
                RecentInterlockTitle = "최근 1개월간 인터락 발생현황";
                SmartSearchTitle = "스마트 서치";
                SmartSearchExplain = "원하는 데이터를 빠르게 검색해보세요.\n예시) 현재 사용 중인 설비 알려줘";
                SendTextHint = "찾고자 하는 데이터를 검색";
            }
            else if (Settings.Default.Language == "Eng")
            {
                Title = "DashBoard";
                EquipmentName = "Equipments";
                ParamsName = "Params";
                RecipeName = "Recipes";
                RecentInterlockTitle = "Interlock for the last 1 month";
                SmartSearchTitle = "Smart Search";
                SmartSearchExplain = "Search for the data you want quickly.\nex) Tell me about the equipments currently in use at the factory";
                SendTextHint = "Search for the data you want to find";
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged(string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
