using EMJI.Components.Classes;

namespace EMJI
{
    public partial class App : Application
    {
        public App()
        {
            Constants.thisUser = new User();
            InitializeComponent();

            MainPage = new MainPage();
        }
    }
}
