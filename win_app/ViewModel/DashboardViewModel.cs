﻿using LiveCharts;
using LiveCharts.Wpf;
using Newtonsoft.Json;
using SOM.Model;
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

            ChatCollection = new ObservableCollection<ChatModel>();
            SendCommand = new RelayCommand(GetChatbotData);
        }

        public ICommand SendCommand { get; }

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

        private string[] _labels;
        public string[] Labels
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

        private void GetInterlockData()
        {
            
            SeriesCollection = new SeriesCollection
            {
                new ColumnSeries
                {
                    Title = "2015",
                    Values = new ChartValues<double> { 10, 50, 39, 50 }
                }
            };

            //adding series will update and animate the chart automatically
            SeriesCollection.Add(new ColumnSeries
            {
                Title = "2016",
                Values = new ChartValues<double> { 11, 56, 42 }
            });

            //also adding values updates and animates the chart automatically
            SeriesCollection[1].Values.Add(48d);

            Labels = new[] { "Maria", "Susan", "Charles", "Frida" };
            Formatter = value => value.ToString("N");
        }

        private async void GetChatbotData()
        {
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
                answerText = "현재 서버와 연결할 수 없습니다.";
            }
            ChatCollection.RemoveAt(ChatCollection.Count - 1);
            ChatCollection.Add(new ChatModel(questionText, answerText));
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged(string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
