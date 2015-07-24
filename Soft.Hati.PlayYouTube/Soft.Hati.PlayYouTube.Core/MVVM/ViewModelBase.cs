using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq.Expressions;

namespace Soft.Hati.PlayYouTube.Core.MVVM
{
    public abstract class ViewModelBase : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        protected void SetValue<T>(ref T field, T value, Expression<Func<T>> property)
        {
            SetValue(ref field, value, ((MemberExpression)property.Body).Member.Name);
        }

        private void SetValue<T>(ref T field, T value, string property = null)
        {
            if (EqualityComparer<T>.Default.Equals(field, value))
                return;

            field = value;
            RaisePropertyChanged(property);
        }

        protected void RaisePropertyChanged<T>(Expression<Func<T>> propertyExpression)
        {
            RaisePropertyChanged(((MemberExpression)propertyExpression.Body).Member.Name);
        }

        private void RaisePropertyChanged(string propertyName)
        {
            var handler = PropertyChanged;
            if (handler != null)
                handler(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}