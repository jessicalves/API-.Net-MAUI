using System.Collections;
using System.Collections.Generic;
using System.Windows.Input;
using Microsoft.Maui;
using Microsoft.Maui.Controls;

namespace ApiMaui;

public partial class UserPosts : ContentPage
{
    RestService _restService;
    private int UserID;

    public UserPosts(int UserID)
    {
        InitializeComponent();
        this.UserID = UserID;
        _restService = new RestService();
    }

    async protected override void OnAppearing()
    {
        base.OnAppearing();

        string url = "https://jsonplaceholder.typicode.com/users/" + UserID.ToString() + "/posts";
        List<Posts> posts = await _restService.GetPostsAsync(url);
        collectionView.ItemsSource = posts;
    }
}
