using AeroDB.ViewModel;

namespace AeroDB.View;

public partial class AssyView : ContentPage
{
	public AssyView(AssyViewModel viewModel)
    {
        InitializeComponent();
        BindingContext = viewModel;
        //AssyViewContainer.Content = new AssyInfo(new AssyViewModel(new Service.PartService()));
    }
}