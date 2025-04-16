using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OccupationalTherapist_Core.VMs
{
    public class AppointmentCreateVM
    {

        [Required]
        public bool IsForSelf { get; set; } = true;

        [Required(ErrorMessage = "Ad zorunludur.")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "Soyad zorunludur.")]
        public string LastName { get; set; }

        [Required(ErrorMessage = "Doğum tarihi zorunludur.")]
        [DataType(DataType.Date)]
        public DateTime DateOfBirth { get; set; }

        [Required(ErrorMessage = "Telefon numarası zorunludur.")]
        [Phone]
        [Display(Name = "Cep telefonu")]
        public string PhoneNumber { get; set; }

        [Required(ErrorMessage = "Email zorunludur.")]
        [EmailAddress]
        public string Email { get; set; }

        [Required(ErrorMessage = "Email doğrulama zorunludur.")]
        [EmailAddress]
        [Compare("Email", ErrorMessage = "Email adresleri eşleşmiyor.")]
        [Display(Name = "Eposta adresini doğrulayın")]
        public string ConfirmEmail { get; set; }

        [Display(Name = "Doktor/uzman için ek bilgi")]
        public string ExtraNote { get; set; }

        [Required(ErrorMessage = "Rıza vermeniz gerekmektedir.")]
        [Display(Name = "Veri işleme izni")]
        public bool AcceptDataProcessing { get; set; }

        [Display(Name = "Ticari iletiler")]
        public bool AcceptCommercialMessages { get; set; }

        [Required(ErrorMessage = "Şartları kabul etmelisiniz.")]
        public bool AcceptTerms { get; set; }
        [Required(ErrorMessage = "Randevu tarihi zorunludur.")]
        [DataType(DataType.Date)]
        public DateTime AppointmentDate { get; set; }
    }

}
