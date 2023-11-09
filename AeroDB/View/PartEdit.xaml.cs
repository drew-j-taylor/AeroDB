using AeroDB.ViewModel;

namespace AeroDB.View;

public partial class PartEdit : ContentView
{
	public PartEdit(PartViewModel viewModel)
    {
        InitializeComponent();
        BindingContext = viewModel;
    }
}