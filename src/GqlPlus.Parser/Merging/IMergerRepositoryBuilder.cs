using GqlPlus.Abstractions.Schema;

namespace GqlPlus.Merging;

public interface IMergerRepositoryBuilder
{
  IMergerRepositoryBuilder AddMerge<T>(Factory<IMerge<T>, IMergerRepository> factory)
    where T : IGqlpError;

  IMergerRepositoryBuilder AddMergeAll<TAst, TType, TService>(Factory<TService, IMergerRepository> factory)
    where TAst : IGqlpType
    where TType : IGqlpType
    where TService : class, IMergeAll<TType>, IMerge<TAst>;
}
