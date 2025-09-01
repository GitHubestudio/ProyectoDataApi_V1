namespace AnalisisDeDatosApi.Models
{
    public class DatoDeVenta
    {
        public int Id { get; set; }
        public string Producto { get; set; }
        public string Marca { get; set; }
        public double Precio { get; set; }
        public int Cantidad { get; set; }
        public DateTime Fecha { get; set; }
    }
}
