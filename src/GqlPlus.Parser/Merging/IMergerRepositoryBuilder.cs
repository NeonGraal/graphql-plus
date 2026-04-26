using GqlPlus.Ast.Schema;

namespace GqlPlus.Merging;

public interface IMergerRepositoryBuilder
{
  IMergerRepositoryBuilder AddMerge<T>(Factory<IMerge<T>, IMergerRepository> factory)
    where T : IAstError;

  IMergerRepositoryBuilder AddMergeAll<TAst, TType, TService>(Factory<TService, IMergerRepository> factory)
    where TAst : IAstType
    where TType : IAstType
    where TService : class, IMergeAll<TType>, IMerge<TAst>;
}
