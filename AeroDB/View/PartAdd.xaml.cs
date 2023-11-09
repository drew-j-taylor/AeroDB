using AeroDB.ViewModel;

namespace AeroDB.View;

public partial class PartAdd : ContentView
{
	public PartAdd(PartViewModel viewModel)
    {
        InitializeComponent();
        BindingContext = viewModel;
    }
}