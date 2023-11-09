using AeroDB.ViewModel;

namespace AeroDB.View;

public partial class Part : ContentPage
{
	public Part(PartViewModel viewModel)
	{
		InitializeComponent();
		BindingContext = viewModel;
        PartViewContainer.Content = new PartInfo(new PartViewModel(new Service.PartService()));
    }

    void OnPartInfo(object sender, EventArgs e)
	{
		PartViewContainer.Content = new PartInfo(new PartViewModel(new Service.PartService()));
	}

    void OnPartEdit(object sender, EventArgs e)
    {
        PartViewContainer.Content = new PartEdit(new PartViewModel(new Service.PartService()));
    }

    void OnPartAdd(object sender, EventArgs e)
    {
        PartViewContainer.Content = new PartAdd(new PartViewModel(new Service.PartService()));
    }
}