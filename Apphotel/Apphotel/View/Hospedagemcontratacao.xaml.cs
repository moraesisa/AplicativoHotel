﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Apphotel.Model;

namespace Apphotel.View
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Hospedagemcontratacao : ContentPage
    {

        App PropriedadesApp;

        public Hospedagemcontratacao()
        {
            InitializeComponent();

            NavigationPage.SetHasNavigationBar(this, false);

            PropriedadesApp = (App)Application.Current;

            pck_suites.ItemsSource = PropriedadesApp.Suites;



            dtpck_checkin.MinimumDate = DateTime.Now;
            dtpck_checkin.MaximumDate = DateTime.Now.AddMonths(6);

            dtpck_ckeckout.MinimumDate = DateTime.Now.AddDays(1);
            dtpck_ckeckout.MaximumDate = DateTime.Now.AddMonths(6).AddDays(1);
        }

        private void Button_Clicked(object sender, EventArgs e)
        {
            try
            {
                Navigation.PushAsync(new HospedagemCalculada()
                {
                    BindingContext = new Hospedagem()
                    {
                        QntAdultos = Convert.ToInt32(stp_adultos.Value),
                        QntCriancas = Convert.ToInt32(stp_criancas.Value),
                        Quarto = (Suite)pck_suites.SelectedItem,
                        DataCheckIn = dtpck_checkin.Date,
                        DataCheckOut = dtpck_ckeckout.Date
                    }
                });

            }
            catch (Exception ex)
            {
                DisplayAlert("Ops", ex.Message, "OK");
            }
        }

        private void dtpck_checkin_DateSelected(object sender, DateChangedEventArgs e)
        {
            DatePicker elemento = (DatePicker)sender;

            dtpck_ckeckout.MinimumDate = elemento.Date.AddDays(1);
            dtpck_ckeckout.MaximumDate = elemento.Date.AddMonths(6);
        }
    }
}