using System.Windows.Input;
using Microsoft.Maui.Controls;

namespace ApiMaui;

public partial class MainPage : ContentPage
{
	RestService _restService;

	public MainPage()
	{
		InitializeComponent();
        _restService = new RestService();

        ICommand refreshCommand = new Command(() =>
        {
            refreshView.IsRefreshing = false;
        });
        refreshView.Command = refreshCommand;
    }

    async protected override void OnAppearing()
    {
        base.OnAppearing();

        List<Users> users = await _restService.GetUsersAsync(Constants.UsersEndpoint);
        collectionView.ItemsSource = users;
    }
}


