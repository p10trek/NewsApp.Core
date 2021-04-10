using MvvmCross;
using MvvmCross.ViewModels;
using NewsApp.Core.Interfaces;


namespace NewsApp.Core
{
    public class App : MvxApplication
    {
        public override void Initialize()
        {
            Mvx.IoCProvider.RegisterType<IServices, Services>();
            RegisterAppStart<MainViewModel>();
        }
    }
}
