using GqlPlus.Ast.Schema;

namespace GqlPlus.Merging;

internal class MergerRepositoryBuilder
  : BaseFactory<IMergerRepository>, IMergerRepositoryBuilder
{
  internal readonly FactoryDict Mergers = [];
  internal readonly FactoryDict AllMergers = [];
  internal readonly Dictionary<Type, List<Type>> AllMergerTypes = [];

  public IEnumerable<KeyValuePair<Type, Factory<object, IMergerRepository>>> AllFactories
    => [.. Mergers, .. AllMergers];

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
      List<Type> list = b.AllMergerTypes.GetValueOr(typeof(TType), []);
      b.AllMergerTypes[typeof(TType)] = list;
      if (!list.Contains(typeof(TService))) {
        list.Add(typeof(TService));
      }
    });
}
