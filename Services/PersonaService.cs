using PadronAPI.Models;

namespace PadronAPI.Services
{
    public static class PersonaService
    {
        public static Persona Get(int dni) => BD.ConsultarPadron(dni);

        public static bool Votar(Voto voto) => BD.Votar(voto);
    }
}