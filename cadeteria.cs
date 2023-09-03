using EspacioCadete;
using EspacioPedido;
namespace EspacioCadeteria
{
    class Cadeteria
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

        public Pedido CrearPedido(int numeroP, string observacionP, bool estadoP, string nombreC, string direccionC, string telC, string refDireccionC) //recibo los datos del pedido, mas los datos del cliente
        {
            var nuevoPedido = new Pedido(numeroP, observacionP, estadoP, nombreC, direccionC, telC, refDireccionC);
            return nuevoPedido;
        }
        public bool AsignarPedido(Pedido pedido, int idCadete)
        {
            foreach (var cadete in ListaCadete)
            {
                if (cadete.Id == idCadete)
                {
                    cadete.AgregarUnPedido(pedido);
                    return true;
                }
            }
            return false;

        }
        public void EliminarPedido(int numeroP)
        {
            var CadeteEncontrado = EncontrarCadetePorPedido(numeroP);
            if (CadeteEncontrado != null)
            {
                CadeteEncontrado.EliminarPedido(numeroP);
            }

        }
        public bool ReasignarPedido(int idCadete, int numeroP)
        {
            var Reasignar = new Pedido();
            bool[] retorno = new bool[]{false,false};
            var CadeteEncontrado = EncontrarCadetePorPedido(numeroP);
            if (CadeteEncontrado != null)
            {
                foreach (var pedido in CadeteEncontrado.ListaPedidos)// busco el pedido del cadete, apartir del numero de pedido
                {
                    if (numeroP == pedido.Numero)
                    {
                        Reasignar = pedido;
                        CadeteEncontrado.EliminarPedido(numeroP);
                        retorno[0]=true;
                        break;
                    }

                }
                foreach (var cadete in ListaCadete) //busco al cadete por id
                {
                    if (cadete.Id == idCadete)
                    {
                        cadete.AgregarUnPedido(Reasignar);
                        retorno[1]=true;
                        break;
                    }
                }
                if((retorno[1] && retorno[0])==true) return true;
                
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


    }

}