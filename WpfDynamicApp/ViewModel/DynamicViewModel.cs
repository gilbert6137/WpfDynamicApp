using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Dynamic;
using System.Runtime.CompilerServices;

namespace WpfDynamicApp.ViewModel
{
    public class DynamicViewModel : DynamicObject, INotifyPropertyChanged
    {
        private readonly Dictionary<string, object> _dynamicProperties = new Dictionary<string, object>();

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public override bool TrySetMember(SetMemberBinder binder, object value)
        {
            _dynamicProperties[binder.Name] = value;
            OnPropertyChanged(binder.Name);
            return true;
        }

        public override bool TryGetMember(GetMemberBinder binder, out object result)
        {
            return _dynamicProperties.TryGetValue(binder.Name, out result);
        }

        public void SetDynamicProperty<T>(string propertyName, T value)
        {
            if (!_dynamicProperties.ContainsKey(propertyName))
            {
                _dynamicProperties[propertyName] = value;
                OnPropertyChanged(propertyName);
            }
            else
            {
                _dynamicProperties[propertyName] = value;
                OnPropertyChanged(propertyName);
            }
        }

        public T GetDynamicProperty<T>(string propertyName)
        {
            if (_dynamicProperties.TryGetValue(propertyName, out var value))
            {
                return (T)value;
            }
            return default(T);
        }
    }
}




