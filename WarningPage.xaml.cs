namespace ProyectoBiblioteca;

public partial class WarningPage : ContentPage
{
    public WarningPage()
    {
        InitializeComponent();
    }

    private async void OnCloseButtonClicked(object sender, EventArgs e)
    {
        await Navigation.PopModalAsync(); 
    }
}