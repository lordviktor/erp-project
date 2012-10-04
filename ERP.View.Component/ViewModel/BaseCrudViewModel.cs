#region Using

using System.Collections.Generic;
using System.Linq;
using System.Windows.Input;
using ERP.Business.Interfaces.Base;
using ERP.Domain.BasicEntity;

#endregion

namespace ERP.View.Component.ViewModel
{
    public class BaseCrudViewModel<T> where T : BaseEntity
    {
        private IList<T> _EntityList;
        private T _CurrentItem;

        public IBaseCrudLogic<T> Model { get; set; }

        public IList<T> EntityList
        {
            get { return _EntityList; }
            set { _EntityList = value; }
        }

        public T CurrentItem
        {
            get { return _CurrentItem; }
            set { _CurrentItem = value; }
        }

        public BaseCrudViewModel(IBaseCrudLogic<T> model)
        {
            Model = model;
            Initialize();
        }

        public void Initialize()
        {
            //this.ListCommand = new RelayCommand(List);
            //this.SaveCommand = new RelayCommand(Save);
            //this.DeleteCommand = new RelayCommand(Delete);
        }

        public void Loaded()
        {
            List();
        }

        public void List()
        {
            _EntityList = Model.FetchAll().ToList();
        }

        public void Save()
        {
            Model.Save(CurrentItem);
        }

        public void Delete()
        {
            Model.Delete(CurrentItem);
        }

        public ICommand SaveCommand { get; set; }

        public ICommand DeleteCommand { get; set; }

        public ICommand ListCommand { get; set; }
    }
}