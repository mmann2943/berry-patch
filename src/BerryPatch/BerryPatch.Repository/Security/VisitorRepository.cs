using System;
using System.Collections.Generic;
using System.Linq;

namespace BerryPatch.Repository.Security
{
    public class VisitorRepository: IRepository<Visitor>
    {
        private readonly DatabaseConfig dbConfig;
        public VisitorRepository(IConfig config)
        {
            this.dbConfig = new DatabaseConfig(config);
        }
        public List<Visitor> Find(Func<Visitor, bool> visitorQuery)
        {            
            
            using(var context = new VisitorDataContext(dbConfig.ConnectString))
            {
                return context.Visitors.Where(visitorQuery).ToList();               
            }            
        }
    }

    internal class DatabaseConfig
    {
        private readonly IConfig config;
        public DatabaseConfig(IConfig config)
        {
            this.config = config;
            config.ReadAppSetting(ConfigValue.DatabaseConnectionString);
        }

        public string ConnectString { get; private set;}
    }

    public interface IConfig
    {
        string ReadAppSetting(string appSetting);
    }

    public struct ConfigValue
    {
        public const string DatabaseConnectionString = "blah";
    }
}