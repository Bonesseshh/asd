using System.Collections.ObjectModel;
namespace YP2_home;

public class ViewModelUser : ViewModelCafe
{
    private User _user;
    private ObservableCollection<Role> _role;
    private ObservableCollection<Dish> _dish;
    private ObservableCollection<Status> _status;
    public User User
    {
        get => _user;
        set
        {
            _user = value;
            OnPropertyChanged();
        }
    }
    public ObservableCollection<Role> Role
    {
        get => _role;
        set
        {
            _role = value;
            OnPropertyChanged();
        }
    }
    public ObservableCollection<Dish> Dish
    {
        get => _dish;
        set
        {
            _dish = value;
            OnPropertyChanged();
        }
    }

    

}