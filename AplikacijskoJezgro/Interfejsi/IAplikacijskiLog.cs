namespace eNakit.AplikacijskoJezgro.Interfejsi
{
   
    public interface IAplikacijskiLog<T>
    {
        void LogInformacija(string poruka, params object[] argumenti);
        void LogUpozorenja(string poruka, params object[] argumenti);
    }
}

