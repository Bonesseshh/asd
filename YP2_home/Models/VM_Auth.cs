using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Net.Mime;
using System.Windows;
using Microsoft.EntityFrameworkCore;
namespace YP2_home;

public class VM_Auth : ViewModelCafe
{
    private ObservableCollection<User> selUsers;
    private string login;
    private string password;
    private RelayCommand auth;

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

                       if (selUs.IdRole == 1)
                       {
                           new Window1().Show();
                           Helper.id_user = 1;
                       }

                       else if (selUs.IdRole == 2)
                       {
                           new Window2().Show();
                           Helper.id_user = 2;
                       }
                       //else
                       //{
                       //    MessageBox.Show("Неправильно введен логин или пароль");
                       //}
                   }));
        }
    }

}