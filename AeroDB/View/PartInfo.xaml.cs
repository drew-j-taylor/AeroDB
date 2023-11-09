using AeroDB.ViewModel;

namespace AeroDB.View;

public partial class PartInfo : ContentView
{
	public PartInfo(PartViewModel viewModel)
	{
		InitializeComponent();
        BindingContext = viewModel;
    }
}
