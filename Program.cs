using EspacioCadeteria;
using EspacioInforme;
using EspacioPedido;
using EspacioAcceso;
internal class Program
{
    private static void Main(string[] args)
    {
        Cadeteria cadeteria;
        string ArchivoCadetes;
        string ArchivoCadeteria;

        int option; // para los do wile
        int eleccion; // para las elecciones de menu
        bool NewEstado; //para etados de pedidos
        const int MaxOptionMenu = 5;
        string observacionPedido, nombreCliente, direccionCliente, telCliente, refDireccionCliente;
        int numeroPedido, idCadete;
        string ReadLine; // para recibir cualquier escrito de ReadLine()
        AccesoADatos Access;
        Console.Clear();
        do
        {
            Console.WriteLine("\tIMPORTACION DE DATOS\n");
            Console.WriteLine("\t(1) Via Csv");
            Console.WriteLine("\t(2) Via Json");
            ReadLine = Console.ReadLine();
            int.TryParse(ReadLine, out option);

        } while (option != 2 && option != 1);

        if (option == 1) 
        {
            Access = new AccesoADatos_Csv();
            ArchivoCadetes="DatosCadetes.csv";
            ArchivoCadeteria="DatosCadeteria.csv";
        } else {
            Access = new AccesoADatos_Json();
            ArchivoCadetes="DatosCadetes.json";
            ArchivoCadeteria="DatosCadeteria.json";
        }

        if (Access.PathExist(ArchivoCadetes) && Access.PathExist(ArchivoCadeteria))
        {
            ////////////new Cadeteria (Nombre,Telefono,ListaCadetes);
            cadeteria = new Cadeteria(Access.InfoCadeteria(ArchivoCadeteria).Nombre,Access.InfoCadeteria(ArchivoCadeteria).TelefonoCadeteria,Access.ObtenerCadetes(ArchivoCadetes));

            do
            {
                Menu_Option(out option);
                switch (option)
                {
                    case 1:
                        Console.WriteLine("\nALTA PEDIDO\n");
                        Console.WriteLine("Acerca del cliente\n");
                        Console.WriteLine("Nombre: ");
                        nombreCliente = Console.ReadLine();
                        Console.WriteLine("Direccion: ");
                        direccionCliente = Console.ReadLine();
                        Console.WriteLine("Referencia A la Direccion: ");
                        refDireccionCliente = Console.ReadLine();
                        Console.WriteLine("Telefono: ");
                        telCliente = Console.ReadLine();
                        Console.WriteLine("\nAcerca del pedido\n");
                        Console.WriteLine("Numero Pedido: ");
                        ValidarNumero(out numeroPedido);
                        Console.WriteLine("Obs pedido: ");
                        observacionPedido = Console.ReadLine();
                        if (cadeteria.CrearPedido(numeroPedido, observacionPedido, EstadosPedido.Pendiente, nombreCliente, direccionCliente, telCliente, refDireccionCliente)) Console.WriteLine("Pedido creado correctamente\n");
                        else Console.WriteLine("Error al crear el pedido\n");
                        break;
                    case 2:
                        Console.WriteLine("\nASIGNAR CADETE A UN PEDIDO\n");
                        Console.WriteLine("Ingrese el numero de pedido\n");
                        ValidarNumero(out numeroPedido);
                        Console.WriteLine("Ingrese el numero ID del cadete\n");
                        ValidarNumero(out idCadete);
                        if (cadeteria.AsignarCadeteAPedido(idCadete, numeroPedido)) Console.WriteLine("Asignacion Exitosa\n");
                        else Console.WriteLine("Error: cadete o pedido no encontrado\n");

                        break;
                    case 3:
                        Console.WriteLine("\nCAMBIAR DE ESTADO UN PEDIDO\n");
                        Console.WriteLine("Ingrese el numero de pedido\n");
                        ValidarNumero(out numeroPedido);
                        Console.WriteLine("Ingrese el estado => (1) Entregado (2) Cancelado");
                        do
                        {
                            ValidarNumero(out eleccion);
                        } while (eleccion != 1 && eleccion != 2);
                        if (eleccion == 1) NewEstado = true; //Entregado
                        else NewEstado = false; // cancelado

                        var Respueta = cadeteria.CambiarEstadoPedido(numeroPedido, NewEstado);
                        if (Respueta ==1) Console.WriteLine("Estado del pedido Cambiado\n");
                        else if (Respueta == 0) Console.WriteLine("Error: Pedido No asignado, imposible marcar como entregado");
                            else Console.WriteLine("Error: Numero de Pedido inexistente");
                        break;
                    case 4:
                        Console.WriteLine("\nREASIGNAR CADETE A UN PEDIDO\n");
                        Console.WriteLine("Ingrese el numero de pedido\n");
                        ValidarNumero(out numeroPedido);
                        Console.WriteLine("Ingrese el numero ID del cadete\n");
                        ValidarNumero(out idCadete);
                        if (cadeteria.ReasignarCadeteApedido(idCadete, numeroPedido)) Console.WriteLine("Nuevo cadete reasignado al pedido\n");
                        else Console.WriteLine("Error: posible numero de pedido o identificador invalido, o pedido ya entregado/cancelado\n");
                       break;

                }

            } while (option != MaxOptionMenu);

            var Informe = cadeteria.SolicitarInforme();
            MostrarInforme(Informe);

        } else Console.WriteLine("Error: Direccion del archivo no existente");

        ///// Funciones Locales al metodo

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
            string ReadLine;
            do
            {
                ReadLine = Console.ReadLine();
            } while (int.TryParse(ReadLine, out numero) != true);
        }

        void MostrarInforme (Informe informe)
        {
            Console.WriteLine("\t<<<<<<<<< INFORME DEL DIA <<<<<<<<<\n");
            foreach (var cadete in informe.InfoCadetes)
            {
              Console.WriteLine("\t"+cadete+"\n");  
            }
            Console.WriteLine("\tTotal de envios: "+ informe.TotalEnviosCadetes+"\n");
            Console.WriteLine("\tPromedio de envios por cadete: "+informe.PromedioEnviosCdts+"\n");
        }

    }
}