using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using CG.Application.Common.Helpers;
using CG.Domain.Entities;
using NUnit.Framework;

namespace Application.UnitTests.Helpers
{
    public class ExcelFileTests
    {
        private const string FolderName = "PersonPhoneNumber/Excels/phoneNumbersTest.xlsx";
        private string _excelpath;

        [SetUp]
        public void Setup()
        {
            var baseDirectory = AppDomain.CurrentDomain.BaseDirectory;
            Assert.That(baseDirectory, Is.Not.Null); 
            _excelpath = Path.Combine(baseDirectory, FolderName);
            System.Text.Encoding.RegisterProvider(System.Text.CodePagesEncodingProvider.Instance);
        }

        [Test]
        public void MustCorrectlyReadExcelFile()
        {
            var personPhoneNumbers = ExcelFile.ReadExcelFile(_excelpath,
                x => new PersonPhoneNumber()
                {
                    Id = long.Parse(x.GetValue(0).ToString() ?? string.Empty),
                    Name = x.GetValue(1).ToString(),
                    Phone = x.GetValue(2).ToString()
                });

            Assert.IsInstanceOf<IEnumerable<PersonPhoneNumber>>(personPhoneNumbers);
            Assert.That(personPhoneNumbers.Count(),Is.EqualTo(4));
        }
    }
}
