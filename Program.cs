using EspacioCadete;
using EspacioCadeteria;
using EspacioPedido;
internal class Program
{
    private static void Main(string[] args)
    {

        List<Cadete> listaCadetes = new List<Cadete>()
        {
            new Cadete(1, "Marcos", "Tomas guido 1410",  new List<Pedido>()), // Uso de listaP
            new Cadete(2, "juan", "San martin 429",  new List<Pedido>()), // Uso de listaP
            new Cadete(3, "Pepe", "Barrio alberdi sur",  new List<Pedido>()),
            new Cadete(4, "Patricio", "Av mate de luna 1258",  new List<Pedido>()),
            new Cadete(5, "Monserrat", "calle juan pablo II 1200",  new List<Pedido>()),
        };
        var variableCadeteria = new Cadeteria("JuLiAn CoRpOrEiShOn","3816522550",listaCadetes);
        int option;
        const int MaxOption = 5;
        const bool P_No_Entregado = false;
        string? observacionPedido,nombreCliente, direccionCliente,telCliente,refDireccionCliente;
        int numeroPedido, idCadete; 
        Pedido? pedidoNuevo = null;
        Console.Clear();
        do
        {
            Menu_Option(out option);
            switch (option)
            {
                case 1:
                    Console.WriteLine("Acerca del cliente\n");
                    Console.WriteLine("Nombe: ");
                    nombreCliente = Console.ReadLine();
                    Console.WriteLine("Direccion: ");
                    direccionCliente = Console.ReadLine();
                    Console.WriteLine("Referencia A la Direccion: ");
                    refDireccionCliente = Console.ReadLine();
                    Console.WriteLine("Telefono: ");
                    telCliente =  Console.ReadLine();
                    Console.WriteLine("\nAcerca del pedido\n");
                    Console.WriteLine("Numero Pedido: ");
                    int.TryParse(Console.ReadLine(), out numeroPedido);
                    Console.WriteLine("Obs pedido: ");
                    observacionPedido = Console.ReadLine();
                    pedidoNuevo = variableCadeteria.CrearPedido(numeroPedido,observacionPedido,P_No_Entregado,nombreCliente,direccionCliente,telCliente,refDireccionCliente);
                break;
                case 2:
                    Console.WriteLine("\nASIGNAR UN PEDIDO A UN CADETE\n");
                    Console.WriteLine("ingrese el identificador del cadete");
                    ValidarNumero(out idCadete);
                    if(pedidoNuevo != null)
                      if(variableCadeteria.AsignarPedido(pedidoNuevo, idCadete))Console.WriteLine("Pedido Asiganado");
                      else Console.WriteLine("Identificador invalido");
                    else Console.WriteLine("No hay pedidos para asignar");
                    break;
                case 3:
                    Console.WriteLine("\nCAMBIAR DE ESTADO PEDIDO\n");
                    Console.WriteLine("Ingrese el numero de pedido\n");
                    ValidarNumero(out numeroPedido);
                    
                    if(variableCadeteria.CambiarEstadoPedido(numeroPedido))Console.WriteLine("Estado del pedido Cambiado");
                    else Console.WriteLine("numero de pedido invalido");

                break;
                case 4:
                    Console.WriteLine("\nREASIGNAR PEDIDO A CADETE\n");
                    Console.WriteLine("Ingrese el numero de pedido\n");
                    ValidarNumero(out numeroPedido);
                    Console.WriteLine("Ingrese el numero ID del cadete\n");
                    ValidarNumero(out idCadete);
                    if(variableCadeteria.ReasignarPedido(idCadete,numeroPedido)) Console.WriteLine("Pedido Reasignado");
                    else Console.WriteLine("numero de pedido o identificado invalido");

                break;
            }
            
        } while (option != MaxOption);

        void Menu_Option(out int option)
        {
            bool flag;
            Console.WriteLine("\t1 ALTA PEDIDO");
            Console.WriteLine("\t2 ASIGNAR A CADETE");
            Console.WriteLine("\t3 CAMBIAR ESTADO PEDIDOS");
            Console.WriteLine("\t4 REASIGNAR PEDIDOS");
            Console.WriteLine("\t5 SALIR");
            
            do
            {
                flag = int.TryParse(Console.ReadLine(), out option);
            } while (flag != true);  
        }

        void ValidarNumero(out int numero)
        {
            string? ReadLine;
            do
            {
                ReadLine = Console.ReadLine();
            } while (int.TryParse(ReadLine, out numero)!= true);
        }

    }
}