using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using WpfDynamicApp.ViewModel;

namespace WpfDynamicApp.ViewModel
{
    public delegate void LoadItemsDelegate();
    public class MainViewModel : DynamicViewModel
    {
        public ICommand LoadItemsCommand { get; }

        public MainViewModel()
        {
            LoadItemsCommand = new RelayCommand(_ => LoadItems());
        }

        private void LoadItems()
        {
            var items = new ObservableCollection<string> { "DynamicItem1", "DynamicItem2", "DynamicItem3" };
            SetDynamicProperty("ItemsSource", items);

            // Assume selecting the first item as default
            SetDynamicProperty("SelectedItem", items.FirstOrDefault());
        }

    }

}





