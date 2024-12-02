using System.Runtime.CompilerServices;

namespace FloresExamenP2
{
    public partial class JFMainPage : ContentPage
    {

        public JFMainPage()
        {
            InitializeComponent();
        }

        private void OnConvertClicked(object sender, EventArgs e)
        {
            if (double.TryParse(InputCantidad.Text, out double cantidad) &&
                PickerOrigen.SelectedIndex != -1 &&
                PickerDestino.SelectedIndex != -1)
            {
                string unidadOrigen = PickerOrigen.SelectedItem.ToString();
                string unidadDestino = PickerOrigen.SelectedItem.ToString();

                double resultado = ConvertirLongitud(cantidad, unidadOrigen, unidadDestino);
                LabelResultado.Text = "Resultado: {resultado} {unidadDestino}";
            }
            else
            {
                DisplayAlert("No válido", "Llene todos los campos");
            }
        }

        private double ConvertirLongitud (double cantidad, string origen, string destino)
        {
            if (origen == destino) return cantidad;

            double metros = origen switch
            {
                "Metros" => cantidad,
                "Kilometros" => cantidad * 1000,
                "Millas" => cantidad * 1609.34
            };

            return destino switch
            {
                "Metros" => cantidad,
                "Kilometros" => cantidad * 1000,
                "Millas" => cantidad * 1609.34
            };

         }

        private void OnLimpiarClicked(object sender, EventArgs e)
        {
            InputCantidad.Text = string.Empty;
            PickerOrigen.SelectIndex = -1;
            PickerDestino.SelectIndex = -1;
            LabelResultado.Text = "Resultado: ";
        }

    }

}
