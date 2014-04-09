using System;

namespace WPFCommandBinding
{
    public class OrderViewModel : ViewModelBase
    {
        private int _number;
        private string _description;
        private bool _isSelected;
        private OrderStatusViewModel _status;
        private DateTime _requestedDateTime;
        private bool _isAssigned;

        public int Number
        {
            get { return _number; }
            set
            {
                _number = value;
                NotifyProperty();
            }
        }

        public string Description
        {
            get { return _description; }
            set
            {
                _description = value;
                NotifyProperty();

            }
        }

        public bool IsSelected
        {
            get { return _isSelected; }
            set
            {
                _isSelected = value;
                NotifyProperty();
            }
        }

        public OrderStatusViewModel Status
        {
            get { return _status; }
            set
            {
                _status = value;
                NotifyProperty();
            }
        }

        public DateTime RequestedDateTime
        {
            get { return _requestedDateTime; }
            set
            {
                _requestedDateTime = value;
                NotifyProperty();
            }
        }

        public bool IsAssigned
        {
            get { return _isAssigned; }
            set
            {
                _isAssigned = value;
                NotifyProperty();
            }
        }

        public string Assigned
        {
            get { return IsAssigned ? "Yes" : "No"; }
        }
    }
}
