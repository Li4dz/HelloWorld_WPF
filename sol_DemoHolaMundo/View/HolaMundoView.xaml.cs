using sol_DemoHolaMundo.View.Interface;
using sol_DemoHolaMundo.ViewModel;
using sol_DemoHolaMundo.ViewModel.Interface;
using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace sol_DemoHolaMundo.View
{
    [Export(typeof(IHolaMundoView))]
    [PartCreationPolicy(CreationPolicy.NonShared)]
    public partial class HolaMundoView : UserControl
    {
        HolaMundoViewModel oHolaMundoViewModel;
        public HolaMundoView()
        {
            InitializeComponent();
            oHolaMundoViewModel = new HolaMundoViewModel();
            this.DataContext = oHolaMundoViewModel;
        }


        [Import]
        IHolaMundoViewModel ViewModel
        {
            set { this.DataContext = value; }
        }
    }
}
