using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;
using Test_Wa.Data.Domain;

namespace Test_Wa.Data.Dto
{
    public class CreateOccupation
    {
        public int EmploiId { get; set; }

        public int PersonneId { get; set; }

        public DateTime DateDebut { get; set; }

        public DateTime? DateFin { get; set; }
    }
}
