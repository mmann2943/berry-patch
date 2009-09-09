using BerryPatch.Visitor;

namespace BerryPatch.Repository
{
    public partial class Visitor: SiteVisitor
    {
        public bool IsLoggedIn
        {
            get { throw new System.NotImplementedException(); }
        }
    }
}