using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows.Input;

namespace WPFCommandBinding
{
    public class MainWindowViewModel : ViewModelBase
    {
        #region Constructor

        public MainWindowViewModel()
        {
            OrderList = GetOrderList();
            StatusTypeList = GetStatusTypeList();
            StatusTypeList.Insert(0, new OrderStatusViewModel { Id = -1, Name = "All" });
            SelectedStatus = StatusTypeList.FirstOrDefault();
            FilterOrders();
        }

        #endregion

        #region Commands

        public ICommand StatusChangeCommand
        {
            get { return new RelayCommand(x => FilterOrders()); }
        }

        public ICommand CancelCommand
        {
            get { return new RelayCommand(CancelOrder, CanCancelOrder); }
        }

        private bool CanCancelOrder(object seletedItem)
        {
            if (seletedItem != null)
            {
                return ((OrderViewModel) seletedItem).IsAssigned &&
                       ((OrderViewModel) seletedItem).Status.Name != "Cancel";
            }
            return false;
        }

        private void CancelOrder(object seletedItem)
        {
        }

        public ICommand AssignToMeCommand
        {
            get { return new RelayCommand(x => AssignToMe(), x=> CanAssignToMe()); }
        }

        private bool CanAssignToMe()
        {
            return FilterOrderList.Count(x => x.IsSelected) > 0;
        }

        private void AssignToMe()
        {
        }

        public ICommand WindowLoadedCommand
        {
            get { return new RelayCommand(x => WindowLoaded()); }
        }

        private void WindowLoaded()
        {
        }

        #endregion

        #region Properties

        public ObservableCollection<OrderViewModel> OrderList { get; set; }

        private ObservableCollection<OrderViewModel> _filterOrderList;
        public ObservableCollection<OrderViewModel> FilterOrderList
        {
            get { return _filterOrderList; }
            set
            {
                _filterOrderList = value;
                NotifyProperty();
            }
        }

        private ObservableCollection<OrderStatusViewModel> _statusTypeList;
        public ObservableCollection<OrderStatusViewModel> StatusTypeList
        {
            get { return _statusTypeList; }
            set
            {
                _statusTypeList = value;
                NotifyProperty();
            }
        }

        private OrderStatusViewModel _selectedStatus;
        public OrderStatusViewModel SelectedStatus
        {
            get { return _selectedStatus; }
            set
            {
                _selectedStatus = value;
                NotifyProperty();
            }
        }

        #endregion

        #region Private Methods

        private void FilterOrders()
        {
            FilterOrderList = new ObservableCollection<OrderViewModel>();
            if (SelectedStatus != null && SelectedStatus.Id == -1)
            {
                PopulateList(OrderList);
            }
            else
            {
                var filteredOrderList = OrderList.Where(x => x.Status.Id == SelectedStatus.Id);
                PopulateList(filteredOrderList);
            }
        }

        private void PopulateList(IEnumerable<OrderViewModel> filteredOrderList)
        {
            foreach (var order in filteredOrderList)
            {
                FilterOrderList.Add(order);
            }
        }

        private ObservableCollection<OrderStatusViewModel> GetStatusTypeList()
        {
            var statusTypeList = new ObservableCollection<OrderStatusViewModel>
                            {
                                new OrderStatusViewModel
                                    {
                                        Id = 1,
                                        Name = "Assigned"
                                    },
                                new OrderStatusViewModel
                                    {
                                        Id = 2,
                                        Name = "Unassigned"
                                    },
                               new OrderStatusViewModel
                                    {
                                        Id = 3,
                                        Name = "In progress"
                                    },
                              new OrderStatusViewModel
                                    {
                                        Id = 3,
                                        Name = "Cancel"
                                    }
                            };
            return statusTypeList;
        }

        private ObservableCollection<OrderViewModel> GetOrderList()
        {
            var orderList = new ObservableCollection<OrderViewModel>
            {
                new OrderViewModel
                    {
                        IsAssigned = false,
                        Description = "Test Order 101",
                        Number = 101,
                        RequestedDateTime = DateTime.Now.AddDays(-2),
                        Status = new OrderStatusViewModel{ Id = 2, Name = "Unassigned"}
                    },
                    new OrderViewModel
                    {
                        IsAssigned = true,
                        Description = "Test Order 127",
                        Number = 127,
                        RequestedDateTime = DateTime.Now.AddDays(-3),
                        Status = new OrderStatusViewModel{ Id = 1, Name = "Assigned"}
                    },
                    new OrderViewModel
                    {
                        IsAssigned = false,
                        Description = "Test Order 191",
                        Number = 191,
                        RequestedDateTime = DateTime.Now.AddDays(-2),
                        Status = new OrderStatusViewModel{ Id = 2, Name = "Unassigned"}
                    },
                    new OrderViewModel
                    {
                        IsAssigned = false,
                        Description = "Test Order 137",
                        Number = 137,
                        RequestedDateTime = DateTime.Now.AddDays(-2),
                        Status = new OrderStatusViewModel{ Id = 2, Name = "Unassigned"}
                    },
                    new OrderViewModel
                    {
                        IsAssigned = true,
                        Description = "Test Order 218",
                        Number = 218,
                        RequestedDateTime = DateTime.Now.AddDays(-1),
                        Status = new OrderStatusViewModel{ Id = 3, Name = "In progress"}
                    },
                    new OrderViewModel
                    {
                        IsAssigned = false,
                        Description = "Test Order 149",
                        Number = 149,
                        RequestedDateTime = DateTime.Now.AddDays(-2),
                        Status = new OrderStatusViewModel{ Id = 2, Name = "Unassigned"}
                    }
            };
            return orderList;
        }

        #endregion

    }
}
