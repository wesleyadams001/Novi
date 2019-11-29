using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XModule.Tools;

namespace XModule.Models
{
    public class MenuItem : BindableBase
    {
        public MenuItem(string ApiName, string MethodName)
        {
            this.Title = ApiName;
            this.Name = MethodName;
            this.Items = new ObservableCollection<MenuItem>();
            this.ParameterList = new ObservableCollection<Pair<string, object>>();

        }

        /// <summary>
        /// The Title or Api name
        /// </summary>
        public string Title { get; set; }

        /// <summary>
        /// The Name or Method name
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// The observable collection of nested MenuItems
        /// </summary>
        public ObservableCollection<MenuItem> Items { get; set; }

        /// <summary>
        /// Backing field of parameter list
        /// </summary>
        private ObservableCollection<Pair<string, object>> list;

        /// <summary>
        /// The list of parameters that belong to a method with their associated types
        /// </summary>
        public ObservableCollection<Pair<string, object>> ParameterList
        {
            get { return list; }
            set { SetProperty(ref list, value); }
        }
    }
}
