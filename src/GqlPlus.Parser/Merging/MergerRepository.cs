using GqlPlus.Abstractions.Schema;

namespace GqlPlus.Merging;

internal class MergerRepository(
  MergerRepositoryState state,
  ILoggerFactory loggerFactory
) : BaseRepository<IMergerRepository>(loggerFactory)
  , IMergerRepository
{

  public IMerge<T> MergerFor<T>()
    where T : IGqlpError
    => Cached<T, IMerge<T>>(state.Mergers, "merger", this);

  public IEnumerable<IMergeAll<T>> AllMergersFor<T>()
    where T : IGqlpType
  {
    if (state.AllMergerTypes.TryGetValue(typeof(T), out List<Type>? serviceTypes)) {
      return serviceTypes.Select(st => (IMergeAll<T>)Cached(state.AllMergers, st, st, "allMerger", this));
    }

    return [];
  }
}
