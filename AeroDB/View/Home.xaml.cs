using AeroDB.ViewModel;

namespace AeroDB.View;

public partial class Home : ContentPage
{
	public Home(HomeViewModel viewModel)
	{
		InitializeComponent();
		BindingContext = viewModel;
	}
}