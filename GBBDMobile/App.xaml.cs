using GBBDMobile.Service;

namespace GBBDMobile
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            MainPage = new AppShell();
            NetManager.DataInit(Path.Combine(FileSystem.Current.AppDataDirectory, "copyDTP.json"), NetManager.DTPPath);
            NetManager.DataInit(Path.Combine(FileSystem.Current.AppDataDirectory, "copyUser.json"), NetManager.UserPath);
            NetManager.DataInit(Path.Combine(FileSystem.Current.AppDataDirectory, "copyCar.json"), NetManager.CarPath);
            NetManager.DataInit(Path.Combine(FileSystem.Current.AppDataDirectory, "copyUsersOfDTP.json"), NetManager.UsersOfDTPPath);
            NetManager.DataInit(Path.Combine(FileSystem.Current.AppDataDirectory, "copyCarsOfDTP.json"), NetManager.CarsOfDTPPath);
        }
    }
}
