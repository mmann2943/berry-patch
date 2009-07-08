using System;
using System.Collections.Generic;

namespace BerryPatch.Web
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

        public SessionAttribute(List<string> itemsInSession, Expiration expiration)
            : this(itemsInSession)
        {
            _itemsInSession = itemsInSession;
            _expiration = expiration;
        }

        public SessionAttribute(List<string> itemsInSession)
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