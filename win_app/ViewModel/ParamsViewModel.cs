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

namespace SOM.ViewModel
{
    public class ParamsViewModel : INotifyPropertyChanged
    {
        private ObservableCollection<ParamsModel> _params;

        public ParamsViewModel()
        {
            SetParams();
        }

        public ObservableCollection<ParamsModel> Params
        {
            get { return _params; }
            set
            {
                _params = value;
                OnPropertyChanged(nameof(Params));
            }
        }

        private async void SetParams()
        {
            HttpResponseMessage response = await GetParams.GetParamsAsync();
            ObservableCollection<ParamsModel> content = new ObservableCollection<ParamsModel>();

            content = await response.Content.ReadAsAsync<ObservableCollection<ParamsModel>>();
            Params = new ObservableCollection<ParamsModel>(content);
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged(string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
