using GqlPlus.Abstractions.Schema;

namespace GqlPlus.Merging;

internal class MergerRepository(
  MergerRepositoryBuilder builder,
  ILoggerFactory loggerFactory
) : BaseRepository<IMergerRepository>(loggerFactory)
  , IMergerRepository
{

  public IMerge<T> MergerFor<T>()
    where T : IAstError
    => Cached<T, IMerge<T>>(builder.Mergers, "merger", this);

  public IEnumerable<IMergeAll<T>> AllMergersFor<T>()
    where T : IGqlpType
  {
    if (builder.AllMergerTypes.TryGetValue(typeof(T), out List<Type>? serviceTypes)) {
      return serviceTypes.Select(st => (IMergeAll<T>)Cached(builder.AllMergers, st, st, "allMerger", this));
    }

    return [];
  }
}
