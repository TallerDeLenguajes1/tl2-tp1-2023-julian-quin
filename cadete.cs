using EspacioPedido;

namespace EspacioCadete
{
    public class Cadete
    {
        private static int pedidoEntregado = 500;
        private int id;
        private string? nombre;
        private string? telefono;
        private string? direccion;
        private List<Pedido>listaPedidos; // agregacion

        public static int PedidoEntregado { get => pedidoEntregado; set => pedidoEntregado = value; }
        public int Id { get => id; set => id = value; }
        public string? Nombre { get => nombre; set => nombre = value; }
        public string? Direccion { get => direccion; set => direccion = value; }
        internal List<Pedido> ListaPedidos { get => listaPedidos; set => listaPedidos = value; }
        public string? Telefono { get => telefono; set => telefono = value; }

        public Cadete (int id, string nombreCadete, string direccionCadete,string TelCadete)
        {
            Id = id;
            Nombre = nombreCadete;
            Direccion = direccionCadete;
            Telefono = TelCadete;
            listaPedidos = new List<Pedido>();
        }
        public Cadete(){}

        public void AgregarUnPedido (Pedido nuevoPedido) //hace uso del crear pedido de cadeteria 
        {
            ListaPedidos.Add(nuevoPedido);
        }
        public void CambiarEstadoPedido(int numeroPedido)
        {
            foreach (var pedido in ListaPedidos)
            {
                if (pedido.Numero == numeroPedido)
                {
                    pedido.CambiarEstado();
                    break;
                }
                
            }
    
        }

        public void EliminarPedido(int numeroPedido)
        {
            foreach (var pedido in ListaPedidos)
             {
                if (pedido.Numero == numeroPedido)
                {
                    ListaPedidos.Remove(pedido);
                    break;
                }
                
             }
            
        }
        public double JornalACobrar()
        {
            double jornal=0;  
            foreach (var pedido in listaPedidos )
            {
                if(pedido.Estado==true) jornal += PedidoEntregado;
            }
            return jornal;
        }

    }
    
}