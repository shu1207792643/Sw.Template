using GalaSoft.MvvmLight.Command;
using Sw.Template.Common.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace Sw.Template.Web
{
    public class CusTreeView:TreeView
    {
        public RelayCommand<TreeNode> Command
        {
            get { return (RelayCommand<TreeNode>)GetValue(CommandProperty); }
            set { SetValue(CommandProperty, value); }
        }
        public static readonly DependencyProperty CommandProperty =
            DependencyProperty.Register("Command", typeof(RelayCommand<TreeNode>), typeof(CusTreeView), new PropertyMetadata(null));


        protected override void OnSelectedItemChanged(RoutedPropertyChangedEventArgs<object> e)
        {
            base.OnSelectedItemChanged(e);
            if (e.NewValue is TreeNode item)
            {
                Command?.Execute(item);
            }
        }
    }
}
