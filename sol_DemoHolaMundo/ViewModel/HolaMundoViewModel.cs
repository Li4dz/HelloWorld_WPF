using Microsoft.Practices.Prism.Commands;
using Microsoft.Practices.Prism.Mvvm;
using sol_DemoHolaMundo.Model;
using sol_DemoHolaMundo.ViewModel.Interface;
using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace sol_DemoHolaMundo.ViewModel
{
    [Export(typeof(IHolaMundoViewModel))]
    [PartCreationPolicy(CreationPolicy.NonShared)]
    public class HolaMundoViewModel : BindableBase, IHolaMundoViewModel
    {
        [ImportingConstructor]
        public HolaMundoViewModel()
        {

        }


        #region Entidades

        private string _Nombre;

        public string Nombre
        {
            get { return _Nombre; }
            set { _Nombre = value; OnPropertyChanged(() => Nombre); }
        }

        private string _Contenido;

        public string Contenido
        {
            get { return _Contenido; }
            set { _Contenido = value; OnPropertyChanged(() => Contenido); }
        }

        private ListaPersona _ListaPersona;

        public ListaPersona ListaPersona
        {
            get { return _ListaPersona; }
            set { _ListaPersona = value; OnPropertyChanged(() => ListaPersona); }
        }


        #endregion


        #region Commads


        public ICommand CommandMostrarNombre
        {
            get { return new DelegateCommand(MostrarNombreCommand); }
        }

        public ICommand CommandCargarPersona
        {
            get { return new DelegateCommand(CargarPersonaCommand); }
        }

        #endregion

        #region Métodos

        private void MostrarNombreCommand()
        {
            Contenido = Nombre;
        }

        private void CargarPersonaCommand()
        {
            ListaPersona = new ListaPersona();
            ListaPersona = CargarListaPersona();
            //base de datos
            //repositorios
        }


        private ListaPersona CargarListaPersona()
        {
            ListaPersona oListaPersona = new ListaPersona();

            for (int i = 0; i < 5; i++)
            {
                oListaPersona.Add(new Persona { IdPersona = i, Nombre = $"Persona N° {i}" });
            }

            return oListaPersona;
        }

        #endregion
    }
}
