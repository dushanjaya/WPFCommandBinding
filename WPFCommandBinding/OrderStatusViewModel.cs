namespace WPFCommandBinding
{
    public class OrderStatusViewModel : ViewModelBase
    {
        private int _id;
        private string _name;

        public int Id
        {
            get { return _id; }
            set
            {
                _id = value;
                NotifyProperty();
            }
        }

        public string Name
        {
            get { return _name; }
            set
            {
                _name = value;
                NotifyProperty();
            }
        }
    }
}
