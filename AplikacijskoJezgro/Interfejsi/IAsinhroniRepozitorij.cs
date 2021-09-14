using Ardalis.Specification;
using eNakit.AplikacijskoJezgro.Entiteti;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace eNakit.AplikacijskoJezgro.Interfejsi
{
    public interface IAsinhroniRepozitorij<T> where T : BazniEntitet, IAgregacijaKorijen
    {
        Task<T> DohvatiPoIduAsinhrono(int id, CancellationToken prekidniToken = default);
        Task<IReadOnlyList<T>> IzlistajSveAsync(CancellationToken prekidniToken = default);
        Task<IReadOnlyList<T>> IzlistajAsinhrono(ISpecification<T> spec, CancellationToken prekidniToken = default);
        Task<T> DodajAsinhrono(T entitet, CancellationToken prekidniToken = default);
        Task AzurirajAsinhrono(T entitet, CancellationToken prekidniToken = default);
        Task IzbrisiAsinhrono(T entitet, CancellationToken prekidniToken = default);
        Task<int> PrebrojiAsinhrono(ISpecification<T> spec, CancellationToken prekidniToken = default);
        Task<T> PrviAsinhrono(ISpecification<T> spec, CancellationToken prekidniToken = default);
        Task<T> PrviIliDefaultAsinhrono(ISpecification<T> spec, CancellationToken prekidniToken = default);
    }
}
