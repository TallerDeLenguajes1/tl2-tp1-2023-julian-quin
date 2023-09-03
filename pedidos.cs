using EspacioCliente;
namespace EspacioPedido
{
    class Pedido
    {
        private int numero;
        private string? observacion;
        private Cliente cliente; //composicion 
        private bool estado;
        
        public bool Estado { get => estado; set => estado = value; }
        public int Numero { get => numero; set => numero = value; }
        public string? Observacion { get => observacion; set => observacion = value; }
        internal Cliente Cliente { get => cliente; set => cliente = value; }
        public Pedido (int numero, string observacion, bool estado, string nombreCliente, string direccionCliente, string telCliente, string refDireccionCliente)
        {
            Numero = numero;
            Observacion = observacion;
            Estado = estado;
            Cliente = new Cliente(nombreCliente,direccionCliente,telCliente,refDireccionCliente);
        }
        public Pedido (){}

        public string VerDireccionCliente()
        {
            return Cliente.Direccion;
        }
        public Cliente VerDatosCliente()
        {
            return Cliente;
        }
        public void CambiarEstado ()
        {
            Estado = true;
        }
    }
}