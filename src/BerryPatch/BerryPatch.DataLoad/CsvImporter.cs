using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Xml;
using System.Xml.Schema;
using BerryPatch.Security;
using LumenWorks.Framework.IO.Csv;
using System.Text;
using System.IO;

namespace BerryPatch.DataLoad
{
    public class CsvImporter
    {
        private string _csvFilePath;
        private IUserRepository _repository;
        private CsvReader _reader;

        public delegate void RecordsImported(object sender, RecordsImportedEventArgs args);
        public event RecordsImported OnRecordsImported;

        public static readonly string SchemValidationMessageFormat = "Xml validation failed against schema: '{0}', Message: {1}, Severity: {2}";
        public CsvImporter(string csvFilePath, string schemaFilePath, IUserRepository repository)
        {
            _csvFilePath = csvFilePath;
            _repository = repository;
            _reader = new CsvReader(File.OpenText(csvFilePath), true);
            ValidateAgainstSchema(_reader, schemaFilePath);
        }

        /// <summary>
        /// Validates the csv file against the schema.
        /// </summary>
        /// <param name="csvReader">The reader.</param>
        /// <param name="schemaFilePath">The path to the xml schema to process</param>
        private void ValidateAgainstSchema(CsvReader csvReader, string schemaFilePath)
        {
            DataSet ds = CreateDataSetFromCsv(csvReader);
                        
            //Load the schema            
            XmlReaderSettings setting = new XmlReaderSettings();
            setting.CheckCharacters = true; 
            setting.CloseInput = true;
            setting.ValidationFlags |= XmlSchemaValidationFlags.ReportValidationWarnings;
            setting.ValidationType = ValidationType.Schema;

            setting.Schemas.Add(null, schemaFilePath);
            setting.ValidationEventHandler += delegate(object sender, ValidationEventArgs args)
                                                  {
                                                      throw new XmlSchemaValidationException(string.Format(SchemValidationMessageFormat, schemaFilePath, args.Message, args.Severity));                
                                                  };
            StringBuilder xmlData = new StringBuilder();
            using (StringWriter writer = new StringWriter(xmlData))
            {                               
                ds.WriteXml(writer);
            }            

            using (StringReader reader = new StringReader(xmlData.ToString()))
            using (XmlReader schemaReader = XmlReader.Create(reader, setting))
            {
                while (schemaReader.Read()) { }
            }
        }
        
        /// <summary>
        /// Creates the data set from CSV.
        /// </summary>
        /// <param name="reader">The reader.</param>
        /// <returns></returns>
        private DataSet CreateDataSetFromCsv(CsvReader reader)
        {
            string[] headers = reader.GetFieldHeaders();
            DataSet ds = new DataSet("CSVImport");
            ds.Tables.Add("ImportData");

            DataColumn[] columns = new DataColumn[headers.Count()];            
            for (int i=0; i < headers.Length; i++)
            {
                ds.Tables[0].Columns.Add(new DataColumn(headers[i]));                
            }

            while (reader.ReadNextRecord())
            {
                object[] columnData = new object[headers.Length];
                for (int i = 0; i < headers.Length; i++)
                    columnData[i] = reader[headers[i]];

                ds.Tables[0].Rows.Add(columnData);
            }
            return ds;
        }

        public List<string> GetHeaderElements()
        {
            return _reader.GetFieldHeaders().ToList();
        }

        /// <summary>
        /// Imports the data using the repository passed in.
        /// </summary>
        /// <returns></returns>
        public int ImportData()
        {
            throw new NotImplementedException();
        }
    }    

    public class RecordsImportedEventArgs
    {
        private readonly int _importedRowCount;
        public RecordsImportedEventArgs(int importedRowCount)
        {
            _importedRowCount = importedRowCount;
        }

        public int ImportRowCount
        {
            get { return _importedRowCount; }
        }

        public IEnumerable FieldsUpdated
        {
            get { throw new NotImplementedException(); }
        }

        public int UpdateCount
        {
            get { throw new NotImplementedException(); }
        }
    }
}