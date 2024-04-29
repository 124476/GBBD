using GBBDMobile.Service;
using GBBDMobile.Models;

namespace GBBDMobile.Pages;

public partial class PageMain : ContentPage
{
	public PageMain()
	{
		InitializeComponent();
		DataDTPs.ItemsSource = NetManager.DTPs.ToList();
    }
}