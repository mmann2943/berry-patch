using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NuclearFamily.Web
{
    public enum Expiration
    {
        Instance=0,
        None,
    }
    public class SessionAttribute:Attribute
    {
        private List<string> _itemsInSession;
        private Expiration _expiration = Expiration.Instance;        

        public SessionAttribute(object[] itemsInSession, Expiration expiration) : this(itemsInSession)
        {
            _itemsInSession = itemsInSession;
            _expiration = expiration;
        }

        public SessionAttribute(object[] itemsInSession)
        {
            _itemsInSession = itemsInSession;
        }

        public Expiration Expiration
        {
            get { return _expiration; }
            set { _expiration = value; }
        }
    }
}
