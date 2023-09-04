using EspacioCadete;
using EspacioCadeteria;
using EspacioHelperCsv;
internal class Program
{
    private static void Main(string[] args)
    {
        List<Cadete> listaCadetes = HerramientasCsv.ObtenerListaCadetes("DatosCadetes.csv");
        string []DatosCad = HerramientasCsv.ObtenerDatosCadeteria("DatosCadeteria.csv");
        var variableCadeteria = new Cadeteria(DatosCad[0],DatosCad[1],listaCadetes);
        int option;
        const int MaxOption = 5;
        const bool P_No_Entregado = false;
        string? observacionPedido,nombreCliente, direccionCliente,telCliente,refDireccionCliente;
        int numeroPedido, idCadete; 
        Console.Clear();
        Console.WriteLine("\t"+variableCadeteria.Nombre+"\n");
        do
        {
            Menu_Option(out option);
            switch (option)
            {
                case 1:
                    Console.WriteLine("\nALTA PEDIDO\n");
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
                    ValidarNumero(out numeroPedido);
                    Console.WriteLine("Obs pedido: ");
                    observacionPedido = Console.ReadLine();
                    if(variableCadeteria.CrearPedido(numeroPedido,observacionPedido,P_No_Entregado,nombreCliente,direccionCliente,telCliente,refDireccionCliente))Console.WriteLine("Pedido creado correctamente\n");
                    else Console.WriteLine("Error al crear el pedido\n");
                break;
                case 2:
                    Console.WriteLine("\nASIGNAR CADETE A UN PEDIDO\n");
                    Console.WriteLine("Ingrese el numero de pedido\n");
                    ValidarNumero(out numeroPedido);
                    Console.WriteLine("Ingrese el numero ID del cadete\n");
                    ValidarNumero(out idCadete);
                    if(variableCadeteria.AsignarCadeteAPedido(idCadete,numeroPedido)) Console.WriteLine("Asignacion Exitosa\n");
                    else Console.WriteLine("Error: cadete o pedido no encontrado\n");
                    
                break;
                case 3:
                    Console.WriteLine("\nCAMBIAR DE ESTADO UN PEDIDO\n");
                    Console.WriteLine("Ingrese el numero de pedido\n");
                    ValidarNumero(out numeroPedido);
                    if(variableCadeteria.CambiarEstadoPedido(numeroPedido))Console.WriteLine("Estado del pedido Cambiado\n");
                    else Console.WriteLine("numero de pedido invalido\n");
                break;
                case 4:
                    Console.WriteLine("\nREASIGNAR CADETE A UN PEDIDO\n");
                    Console.WriteLine("Ingrese el numero de pedido\n");
                    ValidarNumero(out numeroPedido);
                    Console.WriteLine("Ingrese el numero ID del cadete\n");
                    ValidarNumero(out idCadete);
                    if(variableCadeteria.ReasignarCadeteApedido(idCadete,numeroPedido)) Console.WriteLine("Nuevo cadete reasignado al pedido\n");
                    else Console.WriteLine("numero de pedido o identificador invalido\n");

                break;

            }
            
        } while (option != MaxOption);

        void Menu_Option(out int option)
        {
            bool flag;
            Console.WriteLine("\t1 ALTA PEDIDO");
            Console.WriteLine("\t2 ASIGNAR CADETE A UN PEDIDO");
            Console.WriteLine("\t3 CAMBIAR ESTADO PEDIDOS");
            Console.WriteLine("\t4 REASIGNAR CADETE A UN PEDIDO");
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