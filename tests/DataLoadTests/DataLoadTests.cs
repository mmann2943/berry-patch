using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Xml.Schema;
using BerryPatch.DataLoad;
using BerryPatch.Security;
using MbUnit.Framework;
using Rhino.Mocks;

namespace DataLoadTests
{
    [TestFixture]
    public class DataLoadTests
    {
        private MockRepository _mock;
        private IUserRepository _repository;
        private string _pathToCsv;
        private string _pathToBadCsv;
        private DirectoryInfo _testDir;
        private string _schemaFilePath;
        private CsvImporter _importer;


        [FixtureSetUp]
        public void Setup()
        {
            _testDir = new DirectoryInfo(@"..\..\TestData");
            _pathToCsv = Path.Combine(_testDir.FullName, "ImportCustomers.csv");
            _pathToBadCsv = Path.Combine(_testDir.FullName, "BadCustomerImport.csv");
            _schemaFilePath = Path.Combine(_testDir.FullName, "ImportSchema.xsd");
        }

        [SetUp]
        public void TestSetup()
        {
            _mock = new MockRepository();
            _repository = _mock.CreateMock<IUserRepository>();
            _importer = new CsvImporter(_pathToCsv, _schemaFilePath, _repository);
        }

        [Test]
        public void verify_can_get_the_header_elements_from_the_csv()
        {
            string[] headerElements = new string[] { "First Name", "Last Name", "Mailing Address", "City", "State", "Zip", "Email"};
            
            CsvImporter importer = new CsvImporter(_pathToCsv, _schemaFilePath, _repository);
            List<string> csvHeaders = importer.GetHeaderElements();
            Assert.AreEqual(7, csvHeaders.Count); //There are 7 header elements
            Random rdm = new Random((int)DateTime.Now.Ticks);
            int idx = rdm.Next(headerElements.Length -1);

            Assert.AreEqual(headerElements[idx], csvHeaders[idx]); 
        }

        [Test]
        public void verify_file_will_fail_if_column_names_do_not_map_to_the_schema()
        {
            bool exceptionRaised = false;
            try
            {
                CsvImporter importer = new CsvImporter(_pathToBadCsv, _schemaFilePath, _repository);   
            } catch (XmlSchemaValidationException ex)
            {
                exceptionRaised = true;
                const string exception = "The element 'ImportData' has invalid child element 'DoDa'. List of possible elements expected: 'Email'.";
                string expectedMessage = string.Format(CsvImporter.SchemValidationMessageFormat, _schemaFilePath, exception,
                              XmlSeverityType.Error);
                Assert.AreEqual(expectedMessage, ex.Message);
            }
            Assert.IsTrue(exceptionRaised);
        }

        [Test]
        public void verify_can_create_a_row_in_the_database_for_a_new_record()
        {
            
            bool eventRaised = false;
            int recordsImported = 0;
            _importer.OnRecordsImported += delegate(object sender, RecordsImportedEventArgs args)
            {
                Assert.AreEqual(recordsImported, args.ImportRowCount);
                eventRaised = true;
            };

            recordsImported = _importer.ImportData();
            Assert.IsTrue(eventRaised);
        }

        [Test]
        public void verify_will_not_create_a_new_row_in_the_database_for_an_existing_record()
        {
            CsvImporter importer = new CsvImporter(_pathToCsv, _schemaFilePath, _repository);
            bool eventRaised = false;

            importer.ImportData();
            importer.OnRecordsImported += delegate(object sender, RecordsImportedEventArgs args)
            {
                Assert.AreEqual(0, args.ImportRowCount);
                eventRaised = true;
            };

            // Import data a second time with the same rows
            importer.ImportData();
            Assert.IsTrue(eventRaised);
        }

        [Test]
        public void verify_can_update_a_field_successfully_on_update()
        {
            CsvImporter importer = new CsvImporter(_pathToCsv, _schemaFilePath, _repository);
            bool eventRaised = false;

            importer.ImportData();
            importer.OnRecordsImported += delegate(object sender, RecordsImportedEventArgs args)
            {
                Assert.AreEqual(0, args.ImportRowCount);
                Assert.AreEqual(1, args.UpdateCount);
                foreach (DictionaryEntry updateField in args.FieldsUpdated)
                {
                    Assert.AreEqual("Address", updateField.Key);
                    Assert.AreEqual("2660 Loopridge Drive", updateField.Value);
                }
                eventRaised = true;
            };

            // Import data a second time with the same rows
            importer.ImportData();
            Assert.IsTrue(eventRaised);
        }
    }
}