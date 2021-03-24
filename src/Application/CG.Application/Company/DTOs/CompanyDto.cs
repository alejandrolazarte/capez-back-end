using System;

namespace CG.Application.Company.DTOs
{
    public class CompanyDto
    {
        public long Id { get; set; }

        public string BusinessName { get; set; }

        public string Email { get; set; }

        public string  TaxId { get; set; }

        public string PhoneNumber { get; set; }

        public DateTime CreatedDateAtUtc { get; set; }
    }
}