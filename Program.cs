using EspacioCadete;
using EspacioCadeteria;
using EspacioHelperCsv;
using EspacioInforme;
internal class Program
{
    private static void Main(string[] args)
    {
        const string CsvDcadeteria =  "DatosCadeteria.csv";
        const string CsvDcadetes =  "DatosCadetes.csv";
        List<Cadete> listaCadetes = HerramientasCsv.ObtenerListaCadetes(CsvDcadetes);
        string []DatosCad = HerramientasCsv.ObtenerDatosCadeteria(CsvDcadeteria);
        var variableCadeteria = new Cadeteria(DatosCad[0],DatosCad[1],listaCadetes);
        int option;
        const int MaxOption = 4;
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
                    Console.WriteLine("Indique el id del cadete para asignar el pedido");
                    ValidarNumero(out idCadete);
                    if(variableCadeteria.CrearPedido(numeroPedido,observacionPedido,P_No_Entregado,nombreCliente,direccionCliente,telCliente,refDireccionCliente,idCadete))Console.WriteLine("Pedido creado y asignado correctamente");
                    else Console.WriteLine("Error: id no encontrado");
                break;
                case 2:

                    Console.WriteLine("\nCAMBIAR DE ESTADO UN PEDIDO\n");
                    Console.WriteLine("Ingrese el numero de pedido\n");
                    ValidarNumero(out numeroPedido);
                    if(variableCadeteria.CambiarEstadoPedido(numeroPedido))Console.WriteLine("Estado del pedido Cambiado");
                    else Console.WriteLine("numero de pedido invalido");
                break;
                case 3:
                    Console.WriteLine("\nREASIGNAR PEDIDO A OTRO CADETE\n");
                    Console.WriteLine("Ingrese el numero de pedido\n");
                    ValidarNumero(out numeroPedido);
                    Console.WriteLine("Ingrese el numero ID del cadete\n");
                    ValidarNumero(out idCadete);
                    if(variableCadeteria.ReasignarPedido(idCadete,numeroPedido)) Console.WriteLine("Pedido Reasignado");
                    else Console.WriteLine("Error: numero de pedido, identificador invalido o pedido ya entregado");

                break;

            }
            
        } while (option != MaxOption);
        var SolicitudDeinforme = new Informe(variableCadeteria);
        SolicitudDeinforme.MostrarInforme();

        void Menu_Option(out int option)
        {
            bool flag;
            Console.WriteLine("\t1 ALTA PEDIDO");
            Console.WriteLine("\t2 CAMBIAR ESTADO PEDIDOS");
            Console.WriteLine("\t3 REASIGNAR PEDIDOS");
            Console.WriteLine("\t4 SALIR");
            
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