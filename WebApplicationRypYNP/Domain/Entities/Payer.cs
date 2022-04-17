using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplicationRypYNP.Domain.Entities
{
    public class Payer
    {

        public Guid Id { get; set; }

        [Required]
        [Display(Name = "Уникальный номер плательщика")]
        public string VUNP { get; set; }


        [Required]
        [Display(Name = "Полное наименование плательщика")]
        public string VNAIMP { get; set; }

        [Required]
        [Display(Name = "Краткое наименование плательщика")]
        public string VNAIMK { get; set; }

        [Required]
        [Display(Name = "Дата постановки на учет")]
        public DateTime DREG { get; set; }

        [Required]
        [Display(Name = "Код инспекции МНС")]
        public string NMNS { get; set; }

        [Required]
        [Display(Name = "наименование инспекции МНС")]
        public string VMNS { get; set; }

        [Required]
        [Display(Name = "Код состояния плательщика")]
        public string CKODSOST { get; set; }

        [Required]
        [Display(Name = "Наименование плательщика")]
        public string VKODS { get; set; }



        [Display(Name = "Дата изменения состояния плательщика")]
        public DateTime DLIKV { get; set; }

        [Display(Name = "Основание изменения состояния плательщика")]
        public string VLIKV { get; set; }



        [Display(Name = "email")]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        [DataType(DataType.Time)]
        public DateTime DateAdded { get; set; }


    }
}
