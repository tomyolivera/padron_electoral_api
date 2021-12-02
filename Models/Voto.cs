namespace PadronAPI.Models
{
    public class Voto
    {
        private int _DNI;
        private int _NumeroTramite;
        
        public int DNI { get { return _DNI; } set { _DNI = value; } }
        public int NumeroTramite { get { return _NumeroTramite; } set { _NumeroTramite = value; } }
    }
}