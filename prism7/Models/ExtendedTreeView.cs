using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace AclProcessor.Models
{
    /// <summary>
    /// A custome extended TreeView component for the purposes of enhanced binding support
    /// </summary>
    public class ExtendedTreeView : TreeView
    {
        /// <summary>
        /// Default constructor
        /// </summary>
        public ExtendedTreeView() : base()
        {
            this.SelectedItemChanged += new RoutedPropertyChangedEventHandler<object>(___ICH);
        }

        void ___ICH(object sender, RoutedPropertyChangedEventArgs<object> e)
        {
            if (SelectedItem != null)
            {
                var item = (XModule.Models.MenuItem)SelectedItem;
                SetValue(SelectedObject_Property, item);
                SetValue(SelectedItem_Property, item.Name);
                SetValue(SelectedItemParent_Property, item.Title);
            }

        }

        /// <summary>
        /// The Currently selected Item, that also sets the parent item
        /// </summary>
        public object SelectedItem_
        {
            get { return (object)GetValue(SelectedItem_Property); }
            set 
            { 
                SetValue(SelectedItem_Property, value);
                
            }
        }

        /// <summary>
        /// The selected Items parent node
        /// </summary>
        public object SelectedItemParent_ 
        {
            get { return (object)GetValue(SelectedItemParent_Property); }
            set 
            {
                SetValue(SelectedItemParent_Property, value);
            } 
        }

        /// <summary>
        /// The selected menu object
        /// </summary>
        public object SelectedObject_
        {
            get { return (object)GetValue(SelectedObject_Property); }
            set
            {
                SetValue(SelectedObject_Property, value);
            }
        }
        public static readonly DependencyProperty SelectedItem_Property = DependencyProperty.Register("SelectedItem_", typeof(object), typeof(ExtendedTreeView), new UIPropertyMetadata(null));
        public static readonly DependencyProperty SelectedItemParent_Property = DependencyProperty.Register("SelectedItemParent_", typeof(object), typeof(ExtendedTreeView), new UIPropertyMetadata(null));
        public static readonly DependencyProperty SelectedObject_Property = DependencyProperty.Register("SelectedObject_", typeof(object), typeof(ExtendedTreeView), new UIPropertyMetadata(null));
    }
}
