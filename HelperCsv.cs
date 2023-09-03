using EspacioCadete;
namespace EspacioHelperCsv
{
    public static class HerramientasCsv
    {
        public static List<Cadete> ObtenerListaCadetes(string Path)
        {
            if (File.Exists(Path))
            {
                List<Cadete> Cadetes = new();
                List<string> LineasDelArchivoCsv = File.ReadAllLines(Path).ToList();
                foreach (var linea in LineasDelArchivoCsv)
                {
                    string[] LineaSeparada = linea.Split(",");
                    var cadete = new Cadete(int.Parse(LineaSeparada[0]), LineaSeparada[1], LineaSeparada[2], LineaSeparada[3]);
                    Cadetes.Add(cadete);
                }
                return Cadetes;

            } else return new List<Cadete>();   
        }
        public static string[] ObtenerDatosCadeteria(string Path)
        {
            if (File.Exists(Path))
            {
                List<string> LineaDelArchivoCsv = File.ReadAllLines(Path).ToList();
                string[] DatosCadeteria = LineaDelArchivoCsv[0].Split(",");
                return DatosCadeteria;
            } else return new string[0];
            
        } 
    }
}