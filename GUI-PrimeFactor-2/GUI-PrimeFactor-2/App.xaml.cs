using GUI_PrimeFactor_2.MVVM.Model;
using GUI_PrimeFactor_2.MVVM.ViewModel;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using Unity;

namespace GUI_PrimeFactor_2
{
    /// <summary>
    ///     // Responsible for starting and running a new unity container, and then running the  view, with the viewModel as its content
    /// </summary>
    /// 

    public partial class App : Application
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);

            var container = new UnityContainer();

            // Register interfaces and classes for dependency injection
            container.RegisterType<IPrimeFactorAlgorithm, TrialDivisionAlgorithm>();
            container.RegisterType<PrimeFactorModel>();
            container.RegisterType<PrimeFactorViewModel>();

            // Resolve dependencies and create the view model
            var viewModel = container.Resolve<PrimeFactorViewModel>();

            // Set up the view and data context
            var view = new MVVM.View.PrimeFactorView
            {
                DataContext = viewModel
            };
            view.Show();
        }
    }
}
