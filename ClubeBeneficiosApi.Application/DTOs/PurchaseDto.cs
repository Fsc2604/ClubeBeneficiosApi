using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClubeBeneficiosApi.Application.DTOs
{
    public class PurchaseDto
    {
        public int Id { get; set; }

        public int ClientId { get; set; }      
        public int ProductId { get; set; }
        public string ClientName { get; set; }
        public string Description { get; set; }
        public string? ProductName { get; set; }
        public decimal? Price { get; set; }
    }
}
