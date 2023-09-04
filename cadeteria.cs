using EspacioCadete;
using EspacioPedido;
namespace EspacioCadeteria
{
    public class Cadeteria
    {
        private string? nombre;
        private string? telefonoCadeteria;
        private List<Cadete> listaCadete; //dijo que es conveniente inicializar en el constructor (min 28)

        public string? Nombre { get => nombre; set => nombre = value; }
        public string? TelefonoCadeteria { get => telefonoCadeteria; set => telefonoCadeteria = value; }
        internal List<Cadete> ListaCadete { get => listaCadete; set => listaCadete = value; }

        public Cadeteria(string NombreCadeteria, string telCadeteria, List<Cadete> cadetesLista) //constructor
        {
            ListaCadete = cadetesLista;
            Nombre = NombreCadeteria;
            telefonoCadeteria = telCadeteria;
        }

        public bool  CrearPedido(int numeroP, string observacionP, bool estadoP, string nombreC, string direccionC, string telC, string refDireccionC, int idCadete) //recibo los datos del pedido, mas los datos del cliente
        {
            var nuevoPedido = new Pedido(numeroP, observacionP, estadoP, nombreC, direccionC, telC, refDireccionC);
            var CadeteEncontrado = EncontrarCadetePorId(idCadete);
            if (CadeteEncontrado!=null)
            {
                CadeteEncontrado.AgregarUnPedido(nuevoPedido);
                return true;
            }
            return false;
        }
        public bool ReasignarPedido(int idCadete, int numeroP)
        {
            var CadeteEncontradoA = EncontrarCadetePorPedido(numeroP);// busco el cadete que ya tiene el pedido
            var CadeteEncontradoR = EncontrarCadetePorId(idCadete);// busco el cadete al que se va a reasignar el pedido

            if (CadeteEncontradoA!=null && CadeteEncontradoR!=null)
            {
                foreach (var pedido in CadeteEncontradoA.ListaPedidos)
                {
                    if (pedido.Numero == numeroP)
                    {
                        CadeteEncontradoR.AgregarUnPedido(pedido);
                        CadeteEncontradoA.EliminarPedido(numeroP);
                        return true;
                    }
                    
                }
            }
            return false;
        }
        public bool CambiarEstadoPedido(int numeroP)
        {
            var Cadete = EncontrarCadetePorPedido(numeroP);
            if (Cadete != null)
            {
                foreach (var pedido in Cadete.ListaPedidos)
                {
                    if (pedido.Numero == numeroP)
                    {
                        Cadete.CambiarEstadoPedido(numeroP);
                        return true;
                    }
                }
                return false;

            }
            else return false;

        }

        private Cadete? EncontrarCadetePorPedido(int numeroP) // buscar el cadete directamente 
        {
            foreach (var cadete in ListaCadete)
            {
                foreach (var pedido in cadete.ListaPedidos)
                {
                    if (pedido.Numero == numeroP)
                    {
                        return cadete;
                    }
                }

            }
            return null;

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


    }

}