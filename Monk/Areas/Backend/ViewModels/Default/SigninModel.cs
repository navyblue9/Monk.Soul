using System;
using System.ComponentModel.DataAnnotations;

namespace Monk.Areas.Backend.ViewModels
{
    public class SigninModel
    {
        [Display(Name = "会员账号", Description = "账号由3-16位英文字母，数字或中文组成")]
        public string Account { get; set; }

        [Display(Name = "会员密码", Description = "密码由6-20位英文字母、数字或符号组成")]
        public string Password { get; set; }
    }
}