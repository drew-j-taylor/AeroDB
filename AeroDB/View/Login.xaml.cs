using AeroDB.ViewModel;

namespace AeroDB.View;

public partial class Login : ContentPage
{
	public Login(LoginViewModel viewModel)
	{
		InitializeComponent();
		BindingContext = viewModel;
	}
}