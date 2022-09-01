using System;
using System.Collections.Generic;
using System.Globalization;
using System.Threading;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

using Apphotel.View;
using Apphotel.Model;

namespace Apphotel
{
    public partial class App : Application
    {

        public List<Suite> Suites = new List<Suite>()
        {
            new Suite()
            {
                Descricao = "Super Luxo",
                Valordadiariaadulto = 95.5,
                Valordadiariacrianca = 45.5
            },

            new Suite()
            {
                Descricao = "Luxo",
                Valordadiariaadulto = 80,
                Valordadiariacrianca = 40
            },

            new Suite()
            {
                Descricao = "Pobre Premium (classe média)",
                Valordadiariaadulto = 70.5,
                Valordadiariacrianca = 35.5
            }
        };


        public App()
        {
            InitializeComponent();

            Thread.CurrentThread.CurrentCulture = new CultureInfo("pt-BR");

            MainPage = new NavigationPage(new View.Hospedagemcontratacao());
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
