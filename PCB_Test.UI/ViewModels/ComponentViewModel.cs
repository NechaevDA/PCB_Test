using PCB_Test.Models;

namespace PCB_Test.UI.ViewModels
{
    public class ComponentViewModel
    {
        public Component Model
        {
            get; set;
        }

        public ComponentViewModel(Component model)
        {
            Model = model;
        }
    }
}