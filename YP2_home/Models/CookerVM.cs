using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Security.Cryptography.X509Certificates;
using System.Windows;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;

namespace YP2_home;

public class CookerVM : ViewModelBase 
{
    private ObservableCollection<Order> selOrder = new (Helper.db.Orders.Include(x => x.IdStatusNavigation).Where(x => x.IdStatus == 3 || x.IdStatus == 2));
    private RelayCommand _sort;
    private ObservableCollection<Order> orders = new(Helper.db.Orders.Include(x => x.IdStatusNavigation).Where(x => x.IdStatus == 4));
    private Order _selorder;
    public RelayCommand Sort => _sort ??
                   (_sort = new RelayCommand((x) =>
                   {
                       Order? order_st = SelectedOrder;
                       if (order_st == null)
                       {
                           MessageBox.Show("Выберите заказ!");
                           return;
                       }

                       if (order_st != null)
                       {
                           order_st.IdStatus = 4;
                           Helper.db.SaveChanges();
                           ColOrders = new ObservableCollection<Order>(Helper.db.Orders.Include(x => x.IdStatusNavigation)
                               .Where(x => x.IdStatus == 3));
                           NewOrders = new ObservableCollection<Order>(Helper.db.Orders.Include(x => x.IdStatusNavigation)
                               .Where(x => x.IdStatus == 4));
                           OnPropertyChanged();
                       }

                   }));
    public Order SelectedOrder
    {
        get => _selorder;
        set
        {
            _selorder = value;
            OnPropertyChanged();
        }
    }

    public ObservableCollection<Order> ColOrders
    {
        get => selOrder;
        set
        {
            selOrder = value;
            OnPropertyChanged();
        }
    }

    public ObservableCollection<Order> NewOrders
    {
        get => orders;
        set
        {
            orders = value;
            OnPropertyChanged();
        }
    }

}