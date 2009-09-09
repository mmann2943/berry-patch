using System;
using System.Collections.Generic;
using BerryPatch.Repository;
using BerryPatch.Repository.Security;
using Rhino.Mocks;

namespace TestHelper
{
    public class MockVisitorRepository: IRepository<Visitor>
    {
        public List<Visitor> Find(Func<Visitor, bool> query)
        {
            return new List<Visitor>() {MockRepository.GenerateStub<Visitor>()};
        }
    }
}