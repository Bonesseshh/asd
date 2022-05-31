using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Net.Mime;
using System.Windows;
using Microsoft.EntityFrameworkCore;
namespace YP2_home;

public class Authentication : ViewModelBase
{
    private string login;
    private string password;
    private RelayCommand auth;

    public RelayCommand Auth
    {
        get
        {
            return auth ??
                   (auth = new RelayCommand((x) =>
                   {

                       var selUs = Helper.db.Users.FirstOrDefault(x => x.LoginUs == Login && x.PasswordUs == Password);

                       if (selUs == null)
                       {
                           return;
                       }

                       else if (selUs.IdRole == 1)
                       {
                           new Window1().Show();                         
                       }

                       else if (selUs.IdRole == 2)
                       {
                           new Window2().Show();                        
                       }
                       
                   }));
        }
    }
    public string Login
    {
        get => login;
        set
        {
            login = value;
        }
    }
    public string Password
    {
        get => password;
        set
        {
            password = value;
        }
    }

}