using EspacioCadete;
using EspacioPedido;
namespace EspacioCadeteria
{
    public class Cadeteria
    {
        private string? nombre;
        private string? telefonoCadeteria;
        private List<Cadete> listaCadete;
        private List<Pedido>listaPedidos; 

        public string? Nombre { get => nombre; set => nombre = value; }
        public string? TelefonoCadeteria { get => telefonoCadeteria; set => telefonoCadeteria = value; }
        internal List<Cadete> ListaCadete { get => listaCadete; set => listaCadete = value; }
        public List<Pedido> ListaPedidos { get => listaPedidos; set => listaPedidos = value; }

        public Cadeteria(string NombreCadeteria, string telCadeteria, List<Cadete> cadetesLista) 
        {
            ListaCadete = cadetesLista;
            Nombre = NombreCadeteria;
            telefonoCadeteria = telCadeteria;
            listaPedidos = new List<Pedido>(); //error sino instancio!!
        }

        public bool  CrearPedido(int numeroP, string observacionP, bool estadoP, string nombreC, string direccionC, string telC, string refDireccionC) 
        {
            var nuevoPedido = new Pedido(numeroP, observacionP, estadoP, nombreC, direccionC, telC, refDireccionC);
            if (nuevoPedido!=null)
            {
                ListaPedidos.Add(nuevoPedido);
                return true;   
            }
          
            return false;
        }
        public bool AsignarCadeteAPedido( int idCadete , int numeroP)
        {
            var CadeteEncontrado = EncontrarCadetePorId(idCadete);
            var PedidoEncontado = EncontrarPedido(numeroP);
            if (CadeteEncontrado!=null && PedidoEncontado!=null)
            {
                PedidoEncontado.AsignarCadete(CadeteEncontrado);
                return true;
            }
            return false;
        }
        public void EliminarPedido(int numeroP)
        {
            var PedidoEncontrado = EncontrarPedido(numeroP);
            if (PedidoEncontrado!=null)
            {
                ListaPedidos.Remove(PedidoEncontrado);
            }
        }
        public bool ReasignarCadeteApedido(int idCadete, int numeroP)
        {
            var CadeteEncontrado = EncontrarCadetePorId(idCadete);
            var PedidoEncontado = EncontrarPedido(numeroP);
            if (CadeteEncontrado != null && PedidoEncontado!=null)
            {
                PedidoEncontado.AsignarCadete(CadeteEncontrado);  
                return true;
            }
            return false;
        }
        public bool CambiarEstadoPedido(int numeroP)
        {
            var PedidoEncontrado= EncontrarPedido(numeroP);
            if(PedidoEncontrado!=null)
            {
                if (PedidoEncontrado.Cadete!=null)
                {
                    PedidoEncontrado.CambiarEstado();
                    return true;
                }

            }
            return false;
        }

        private Cadete? EncontrarCadetePorId(int idCadete)
        {
            foreach (var cadete in ListaCadete)
            {
                if (cadete.Id==idCadete)
                { 
                    return cadete; 
                } 
            }
            return null;
             
        }
        private Pedido? EncontrarPedido(int numeroP)
        {
            foreach (var pedido in ListaPedidos)
            {
                if (numeroP == pedido.Numero)
                {
                    return pedido;
                }
                
            }
            return null;

        }


    }

}