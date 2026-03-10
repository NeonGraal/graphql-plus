using GqlPlus.Abstractions.Schema;

namespace GqlPlus.Merging;

public interface IMergeRepositoryBuilder
{
  IMergeRepositoryBuilder AddMerge<T>(MergerFactory<IMerge<T>> factory)
    where T : IGqlpError;

  IMergeRepositoryBuilder AddMergeAll<TAst, TType, TService>(MergerFactory<TService> factory)
    where TAst : IGqlpType
    where TType : IGqlpType
    where TService : class, IMergeAll<TType>, IMerge<TAst>;
}

public delegate T MergerFactory<out T>(IMergerRepository mergers)
  where T : class;
