using GqlPlus.Ast.Schema;

namespace GqlPlus.Merging;

internal class MergerRepositoryBuilder
  : BaseFactory<IMergerRepository>, IMergerRepositoryBuilder
{
  internal readonly FactoryDict Mergers = [];
  internal readonly FactoryDict AllMergers = [];
  internal readonly Dictionary<Type, List<Type>> AllMergerTypes = [];

  public IMergerRepositoryBuilder AddMerge<T>(Factory<IMerge<T>, IMergerRepository> factory)
    where T : IAstError
    => this.FluentAction(b => b.Mergers[typeof(T)] = factory);

  public IMergerRepositoryBuilder AddMergeAll<TAst, TType, TService>(Factory<TService, IMergerRepository> factory)
    where TAst : IAstType
    where TType : IAstType
    where TService : class, IMergeAll<TType>, IMerge<TAst>
    => this.FluentAction(b => {
      b.Mergers[typeof(TAst)] = factory;
      b.AllMergers[typeof(TService)] = factory;
      b.AllMergerTypes.TryGetValue(typeof(TType), out List<Type>? list);
      list ??= [];
      b.AllMergerTypes[typeof(TType)] = list;
      if (!list.Contains(typeof(TService))) {
        list.Add(typeof(TService));
      }
    });
}
