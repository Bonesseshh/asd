using System;
using System.Collections.ObjectModel;
using System.Dynamic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
namespace YP2_home;

public class WaiterVM : ViewModelCafe
{
    private ObservableCollection<Order> collection_ord =
        new(Helper.db.Orders.Include(x => x.IdStatusNavigation).Where(x => x.IdStatus == 1));

    private ObservableCollection<Order> payOrd = new(Helper.db.Orders
        .Include(x => x.IdStatusNavigation).Where(x => x.IdStatus == 2)); 
    private Order sOrder;
    private ObservableCollection<Dish> dish = new(Helper.db.Dishes);
    private RelayCommand upd_stat;
    private RelayCommand norder;


    public RelayCommand Upd_Status
    {
        get
        {
            return upd_stat ??
                   (upd_stat = new RelayCommand((x) =>
                   {
                       var order_st = SOrder;
                       if (order_st == null)
                       {
                           return;
                       }

                       if (order_st != null)
                       {
                           order_st.IdStatus = 2;
                           Helper.db.SaveChanges();
                           Collection_ord = new ObservableCollection<Order>(Helper.db.Orders.Include(x => x.IdStatusNavigation)
                               .Where(x => x.IdStatus == 1));
                           PayOrd = new ObservableCollection<Order>(Helper.db.Orders.Include(x => x.IdStatusNavigation)
                               .Where(x => x.IdStatus == 2));
                           OnPropertyChanged();
                       }
                       
                   }));
        }
    }

    public RelayCommand NOrder
    {
        get
        {
            return norder ??
                   (norder = new RelayCommand((x) =>
                   {
                       new Window3().Show();
                       Helper.db.SaveChanges();
                       Collection_ord = new ObservableCollection<Order>(Helper.db.Orders.Include(x => x.IdStatusNavigation)
                           .Where(x => x.IdStatus == 1));
                       PayOrd = new ObservableCollection<Order>(Helper.db.Orders.Include(x => x.IdStatusNavigation)
                           .Where(x => x.IdStatus == 2));
                       OnPropertyChanged();
                   }));
        }
    }

    public ObservableCollection<Dish> Dish_l
    {
        get => dish;
        set
        {
            dish = value;
            OnPropertyChanged();
        }
    }
    public ObservableCollection<Order> PayOrd
    {
        get => payOrd;
        set
        {
            payOrd = value;
            OnPropertyChanged();
        }
    }
    public ObservableCollection<Order> Collection_ord
    {
        get => collection_ord;
        set
        {
            collection_ord = value;
            OnPropertyChanged();
        }
    }
    public Order SOrder
    {
        get => sOrder;
        set
        {
            sOrder = value;
            OnPropertyChanged();
        }
    }
}
