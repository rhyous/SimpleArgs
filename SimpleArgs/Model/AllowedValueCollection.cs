using System.Collections.Generic;
using System.Linq;

namespace SimpleArgs
{
    public class AllowedValueCollection : List<string>
    {
        public AllowedValueCollection()
        {
        }

        public AllowedValueCollection(int size)
            : base(size)
        {
        }

        public AllowedValueCollection(IEnumerable<string> collection)
            : base(collection)
        {
            if (collection != null && collection.Any())
                OnAllowedValueAdded();
        }

        new public void Add(string value)
        {
            base.Add(value);
            OnAllowedValueAdded(value);
        }

        public delegate void AllowedValueAddedEventHandler(object sender, AllowedValueAddedEventArgs e);

        public event AllowedValueAddedEventHandler AllowedValueAdded;

        protected void OnAllowedValueAdded(string value = null)
        {
            if (AllowedValueAdded != null)
                AllowedValueAdded(this, new AllowedValueAddedEventArgs(value));
        }
    }
}
