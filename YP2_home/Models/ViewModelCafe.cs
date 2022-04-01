using System.ComponentModel;
using System.Runtime.CompilerServices;
namespace YP2_home;

public class ViewModelCafe : INotifyPropertyChanged
{
    public event PropertyChangedEventHandler PropertyChanged;
    public void OnPropertyChanged([CallerMemberName] string property = "")
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(property));
    }
}