using CDG.Models;
using CDG.Service.Interfaces;
using CommonServiceLocator;
using DataAccess.Data.Interface;
using Models;
using SendGrid;
using SendGrid.Helpers.Mail;
using Service.Manage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CDG.Service.Manage
{
    public class EmailService : IEmailService
    {
        private string apiKey = string.Empty;
        Dictionary<string, string> emailMap;
        private IAuthManage _manage;
        private static Random random;
        private IPersonRepository _personRepostory;
        public EmailService(IAuthManage manage, IPersonRepository personRepository, string key)
        {
            apiKey = key;
            _manage = manage;
            _personRepostory = personRepository;
            emailMap = new Dictionary<string, string>();
        }
        public async Task SendCratedEmailAsync(EmailModel value)
        {
            if (!(await _personRepostory.CheckEmailAsync(value.To))) throw new Exception("Email does not exits");
            
            var client = new SendGridClient(apiKey);
            var from = new EmailAddress(value.From);
            var to = new EmailAddress(value.To);
            var subject = "A new account has been created";
            var body = "";
            var msg = MailHelper.CreateSingleEmail(
                from,
                to,
                subject,
                body,
                SetContent("Account created successfully", value.To, "", "We are glad to have you here")
                );
            var respone = await client.SendEmailAsync(msg);

            if (!respone.IsSuccessStatusCode) throw new Exception("Email Send Error");
        }
        public async Task SendAppointmentMadeEmailAsync(EmailModel value)
        {
            if (!(await _personRepostory.CheckEmailAsync(value.To))) throw new Exception("Email does not exits");
            var client = new SendGridClient(apiKey);
            var from = new EmailAddress(value.From);
            var to = new EmailAddress(value.To);
            var subject = "A new appointment has been created";
            var body = "";
            var msg = MailHelper.CreateSingleEmail(
                from,
                to,
                subject,
                body,
                SetContent(
                 "Appointment has been made succesfully", 
                 "",
                 "Please show up with your car at our garage on the scheduled date until 9AM or a day before",
                 "You will recive a email form us when your car is done")
                );
            var respone = await client.SendEmailAsync(msg);

            if (!respone.IsSuccessStatusCode) throw new Exception("Email Send Error");
        }
        public async Task SendAppointmentFinishedEmailAsync(EmailModel value)
        {
            if (!(await _personRepostory.CheckEmailAsync(value.To))) throw new Exception("Email does not exits");
            var client = new SendGridClient(apiKey);
            var from = new EmailAddress(value.From);
            var to = new EmailAddress(value.To);
            var subject = "Detailing done";
            var body = "";
            var msg = MailHelper.CreateSingleEmail(
                from,
                to,
                subject,
                body,
                SetContent(
                 "Your car has been detailed",
                 "",
                 "You can pick up your car any time from now, thanks for choosing us",
                 "We are glad to have you here")
                );
            var respone = await client.SendEmailAsync(msg);

            if (!respone.IsSuccessStatusCode) throw new Exception("Email Send Error");
        }
        public async Task SendForgotPasswordEmailAsync(EmailModel value)
        {
            if (!(await _personRepostory.CheckEmailAsync(value.To))) throw new Exception("Email does not exits");
            var key = RandomString(7);

            if (!emailMap.ContainsKey(key))
               emailMap.Add(key, value.To);
            

            var client = new SendGridClient(apiKey);
            var from = new EmailAddress(value.From);
            var to = new EmailAddress(value.To);
            var subject = "Reset password";
            var body = "";
            var msg = MailHelper.CreateSingleEmail(
                from,
                to,
                subject,
                body,
                SetContent(
                 "Login to your account with a unic code",
                 "",
                 "Use this code " + key + " to login",
                 "After you login, we recomand to change your password")
                );
            var respone = await client.SendEmailAsync(msg);

            if (!respone.IsSuccessStatusCode) throw new Exception("Email Send Error");
        }
        public async Task<dynamic> GetTokenForForgotPasswordAsync(string email, string key)
        {
            if (string.IsNullOrEmpty(key) || !emailMap.ContainsKey(key)) throw new Exception("Invalid code");

            var model = await _personRepostory.SearchUserEmailAsync(emailMap.GetValueOrDefault(key)) ?? throw new Exception("Email not found");

            if (model.Email != email) throw new Exception("Invalid code");

            emailMap.Remove(key);

            return await _manage.GenerateToken(
                new AuthModel() 
                { 
                  Password = model.Password,
                  UserName = model.UserName 
                });
        }
        private static string RandomString(int length)
        {
            random = new Random();
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
            return new string(Enumerable.Repeat(chars, length)
                .Select(s => s[random.Next(s.Length)]).ToArray());
        }
        private string SetContent(string titleMessage, string values, string info1, string info2)
        {
        var footer = "© 2022 Car Detailing Garage .";
        var style = "<style> #yiv6451144479 .yiv6451144479awl a { color: #FFFFFF; text-decoration: none; } #yiv6451144479 .yiv6451144479abml a { color: #000000; font-family: Roboto-Medium, Helvetica, Arial, sans-serif; font-weight: bold; text-decoration: none; } #yiv6451144479 .yiv6451144479adgl a { color: rgba(0, 0, 0, 0.87); text-decoration: none; } #yiv6451144479 .yiv6451144479afal a { color: #b0b0b0; text-decoration: none; } @media screen and (min-width:600px) { #yiv6451144479 .yiv6451144479v2sp { padding: 6px 30px 0px; } #yiv6451144479 .yiv6451144479v2rsp { padding: 0px 10px; } } @media screen and (min-width:600px) { #yiv6451144479 .yiv6451144479mdv2rw { padding: 40px 40px; } } </style>";
        return  @$"<div class='jb_0 X_6MGW N_6Fd5'> <div> <div id='yiv6451144479'> {style} <style class='darkreader darkreader--sync' media='screen'></style> <div> <table width='100%' height='100%' style='min-width:348px;' border='0' cellspacing='0' cellpadding='0' lang='en'> <tbody> <tr height='32' style='min-height:32px;'> <td></td> </tr> <tr align='center'> <td> <div> <div></div> </div> <table border='0' cellspacing='0' cellpadding='0' style='padding-bottom:20px;max-width:516px;min-width:220px;'> <tbody> <tr> <td width='8' style='width:8px;'></td> <td> <div style='border-style: solid; border-width: thin; border-color: rgb(218, 220, 224); border-radius: 8px; padding: 40px 20px; --darkreader-inline-border-top:#3a3e41; --darkreader-inline-border-right:#3a3e41; --darkreader-inline-border-bottom:#3a3e41; --darkreader-inline-border-left:#3a3e41;' align='center' class='yiv6451144479mdv2rw' data-darkreader-inline-border-top='' data-darkreader-inline-border-right='' data-darkreader-inline-border-bottom='' data-darkreader-inline-border-left=''> <div style='border-bottom: thin solid rgb(218, 220, 224); color: rgba(0, 0, 0, 0.87); line-height: 32px; padding-bottom: 24px; text-align: center; --darkreader-inline-border-bottom:#3a3e41; --darkreader-inline-color:rgba(232, 230, 227, 0.87);' data-darkreader-inline-border-bottom='' data-darkreader-inline-color=''> <div style='font-size:24px;'> {titleMessage} </div> <table align='center' style='margin-top:8px;'> <tbody> <tr style='line-height:normal;'> <td><a rel='nofollow noopener noreferrer' style='color: rgba(0, 0, 0, 0.87); font-size: 14px; line-height: 20px; --darkreader-inline-color:rgba(232, 230, 227, 0.87);' data-darkreader-inline-color=''>{values}</a> </td> </tr> </tbody> </table> </div> <div style='font-family: Roboto-Regular, Helvetica, Arial, sans-serif; font-size: 14px; color: rgba(0, 0, 0, 0.87); line-height: 20px; padding-top: 20px; text-align: center; --darkreader-inline-color:rgba(232, 230, 227, 0.87);' data-darkreader-inline-color=''> <h3>{info1}</h3> {info2} </div> </div> <div style='text-align:center;'> <div style='font-family: Roboto-Regular, Helvetica, Arial, sans-serif; color: rgba(0, 0, 0, 0.54); font-size: 11px; line-height: 18px; padding-top: 12px; text-align: center; --darkreader-inline-color:rgba(232, 230, 227, 0.54);' data-darkreader-inline-color=''> <div>You received this email to let you know about important changes to your Account and services.</div> <div style='direction:ltr;'>{footer}, </div> </div> </div> </td> <td width='8' style='width:8px;'></td> </tr> </tbody> </table> </td> </tr> <tr height='32' style='min-height:32px;'> <td></td> </tr> </tbody> </table> </div> </div> </div> </div>";
        }
}
}
