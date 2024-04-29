using GBBDMobile.Models;
using GBBDMobile.Service;

namespace GBBDMobile.Pages;

public partial class PageNewDTP : ContentPage
{
    List<User> users = new List<User>();
    List<Car> cars = new List<Car>();
	public PageNewDTP()
	{
		InitializeComponent();
		ComboClass.ItemsSource = new string[] { "Легкое", "Сложное", "Критическое" };

        DataUsers.ItemsSource = NetManager.Users.ToList();
        //ComboUsers.ItemsSource = NetManager.Users.ToList();
        //ComboCars.ItemsSource = NetManager.Cars.ToList();
    }

    private void ComboUsers_SelectedIndexChanged(object sender, EventArgs e)
    {
        User user = ComboUsers.SelectedItem as User;
        if (user != null)
        {
            users.Add(user);
        }
    }

    private void ComboCars_SelectedIndexChanged(object sender, EventArgs e)
    {
        Car car = ComboCars.SelectedItem as Car;
        if (car != null)
        {
            cars.Add(car);
        }
    }
}