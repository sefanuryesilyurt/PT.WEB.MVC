using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PT.Entity.ViewModel
{

    public class ProfilePasswordViewModel
    {
        public ProfileViewModel ProfileModel { get; set; } = new ProfileViewModel();
        public PasswordViewModel PasswordModel { get; set; } = new PasswordViewModel();
    }

    public class ProfileViewModel
    {
        public string Id { get; set; }

        [Required]
        [Display(Name = "Ad")]
        [StringLength(25)]
        public string Name { get; set; }

        [Required]
        [Display(Name = "Soyad")]
        public string Surname { get; set; }


        [Required]
        [Display(Name = "Kulanıcı Adı")]
        public string UserName { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }


    }


    public class PasswordViewModel
    {

        [StringLength(100, MinimumLength = 5, ErrorMessage = "Şİfreniz en az 5 karakter olmalı")]
        [Display(Name = "Eski şifre")]
        [DataType(DataType.Password)]
        public string OldPassword { get; set; }

        [StringLength(100, MinimumLength = 5, ErrorMessage = "Şİfreniz en az 5 karakter olmalı")]
        [Display(Name = "Yeni şifre")]
        [DataType(DataType.Password)]
        public string NewPassword { get; set; }


        [DataType(DataType.Password)]
        [Display(Name = "şifre tekrar")]
        [Compare("NewPassword", ErrorMessage = "Şifreler uyuşmuyor")]
        [StringLength(100, MinimumLength = 5, ErrorMessage = "Şİfreniz en az 5 karakter olmalı")]

        public string NewPasswordConfirm { get; set; }
    }



}

