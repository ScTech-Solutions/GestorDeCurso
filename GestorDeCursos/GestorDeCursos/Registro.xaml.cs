using System;
using System.Collections.Generic;
using GestorDeCursos.Models;

using Xamarin.Forms;

namespace GestorDeCursos
{	
	public partial class Registro : ContentPage
	{	
		public Registro ()
		{
			InitializeComponent ();
		}

        private async void Btn_Registrar(System.Object sender, System.EventArgs e)
        {

            if (string.IsNullOrEmpty(txtEmailReg.Text))
            {
                await DisplayAlert("AVISO", "Debe escribir el correo en el campo", "OK");
                return;

            }

            if (string.IsNullOrEmpty(txtContraReg.Text))
            {
                await DisplayAlert("AVISO", "Debe escribir la contraseña en el campo", "OK");
                return;

            }

            if (string.IsNullOrEmpty(txtNombreReg.Text))
            {
                await DisplayAlert("AVISO", "Debe escribir su nombre en el campo", "OK");
                return;

            }

            if (string.IsNullOrEmpty(txtEdadReg.Text))
            {
				await DisplayAlert("AVISO", "Debe escribir la edad en el campo", "OK");
				return;

            }

            Users usr = new Users()
            {
                Email = txtEmailReg.Text,
                Emailpassword = txtContraReg.Text,
                NombreCompleto = txtNombreReg.Text,
                Edad = int.Parse(txtEdadReg.Text),
                FechaCreacion = DateTime.Now

            };

            await App.SQLiteDB.SaveUserModelAsync(usr);
			await DisplayAlert("AVISO", "El registro quedo guardado", "OK");

			txtEmailReg.Text = "";
			txtContraReg.Text = "";
			txtNombreReg.Text = "";
			txtEdadReg.Text = "";

			await Navigation.PushAsync(new Login());
        }
    }
}

