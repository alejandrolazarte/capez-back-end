using CG.Application.Services.Interfaces;
using CG.Domain.Entities;
using CG.Domain.Repository;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using CG.Application.Common.Helpers;

namespace CG.Application.Services
{
    public class MigratePersonPhoneNumberService : IMigratePersonPhoneNumberService
    {
        private readonly IRepository<PersonPhoneNumber> _personPhoneNumberRepository;
        private const string FolderName = "PersonPhoneNumber/Excels";

        public MigratePersonPhoneNumberService(IRepository<PersonPhoneNumber> personPhoneNumberRepository)
        {
            _personPhoneNumberRepository = personPhoneNumberRepository;
        }

        public async Task Migrate()
        {
            var baseDirectory = AppDomain.CurrentDomain.BaseDirectory;
            var path = Path.Combine(baseDirectory, FolderName);
            var filePahts = Directory.GetFiles(path);
            var phoneNumbers = new List<PersonPhoneNumber>();
            System.Text.Encoding.RegisterProvider(System.Text.CodePagesEncodingProvider.Instance);
            foreach (var filepath in filePahts)
            {
                var personPhoneNumbers = ExcelFile.ReadExcelFile(filepath, reader => new PersonPhoneNumber()
                {
                    Phone = reader.GetValue(1).ToString(),
                    Name = reader.GetValue(2).ToString()
                }, 1);

                personPhoneNumbers = personPhoneNumbers.ToHashSet()
                    .Where(x => !string.IsNullOrEmpty(x.Phone) && x.Phone != "0");

                phoneNumbers.AddRange(personPhoneNumbers);
            }

            await _personPhoneNumberRepository.AddRange(phoneNumbers);
        }
    }
}
