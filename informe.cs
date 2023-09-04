using EspacioCadeteria;

namespace EspacioInforme
{
    public class Informe
    {
        const int P_Enviado = 500;
        private int totalEnviosCadetes;
        private double promedioEnviosCdts;
        private Cadeteria varibleCadeteria;
        public Cadeteria VaribleCadeteria { get => varibleCadeteria; set => varibleCadeteria = value; }
        public int TotalEnviosCadetes { get => totalEnviosCadetes; set => totalEnviosCadetes = value; }
        public double PromedioEnviosCdts { get => promedioEnviosCdts; set => promedioEnviosCdts = value; }

        public Informe (Cadeteria InstanciaCadeteria)
        {
            VaribleCadeteria=InstanciaCadeteria;
            EnviosRealizados();
            EnvioPromedio();
        }
        private void EnviosRealizados()
        {
            int totalEnviosCadetes=0;
            foreach (var cadete in VaribleCadeteria.ListaCadete)
            {
                int EnviosCadete = cadete.ListaPedidos.Count(estado => estado.Estado==true); 
                totalEnviosCadetes += EnviosCadete;
            }
            TotalEnviosCadetes = totalEnviosCadetes;
        }
        private void EnvioPromedio ()
        {
            double promedioEnviosCadetes=0;
            if(VaribleCadeteria.ListaCadete.Count!=0)
            {
                promedioEnviosCadetes = (double)TotalEnviosCadetes/VaribleCadeteria.ListaCadete.Count;
            }
            PromedioEnviosCdts = promedioEnviosCadetes;
        }

        public void MostrarInforme()
        {
            int contador;
            Console.WriteLine("\t>>>>>>>> Informe <<<<<<<<\n");
            Console.WriteLine("\n\t\t[ Cadetes ]\n");
            foreach (var cadete in VaribleCadeteria.ListaCadete)
            {
                Console.WriteLine("\tNombre : "+ cadete.Nombre);
                contador = 0;
                foreach (var pedido in cadete.ListaPedidos)
                {
                    if (pedido.Estado==true)
                    {
                        contador++;
                    }
                    
                }
                Console.WriteLine("\tCantidad de envios realizados "+contador);
                Console.WriteLine("\tMonto Ganado : " + cadete.JornalACobrar()+"\n");
            }
            Console.WriteLine("\t<<<<<<< Informacion en General >>>>>>>\n");
            Console.WriteLine("Promedio de envios por cadete : " + PromedioEnviosCdts);
            Console.WriteLine("Total de envios de los cadetes : "+ TotalEnviosCadetes);
            Console.WriteLine("Total: "+ totalEnviosCadetes*P_Enviado);
        }
        


    }
}