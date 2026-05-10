using System.Runtime.CompilerServices;
using GqlPlus.Ast.Schema;

namespace GqlPlus.Merging;

internal class MergerRepository(
  MergerRepositoryBuilder builder,
  ILoggerFactory loggerFactory
) : BaseRepository<IMergerRepository>(loggerFactory)
  , IMergerRepository
{
  public MergerOne<T>.D MergerFor<T>([CallerMemberName] string callerName = "")
    where T : IAstError
    => () => Cached<T, IMerge<T>>(builder.Mergers, "merger for " + callerName, this);

  public MergerList<T>.D AllMergersFor<T>([CallerMemberName] string callerName = "")
    where T : IAstType
  {
    if (builder.AllMergerTypes.TryGetValue(typeof(T), out List<Type>? serviceTypes)) {
      return () => serviceTypes.Select(st
        => (IMergeAll<T>)Cached(builder.AllMergers, st, st, "allMerger for " + callerName, this));
    }

    return () => [];
  }
}
