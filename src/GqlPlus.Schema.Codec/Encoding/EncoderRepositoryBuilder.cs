using System.Runtime.CompilerServices;

namespace GqlPlus.Encoding;

internal class EncoderRepositoryBuilder
  : BaseFactory<IEncoderRepository>
  , IEncoderRepositoryBuilder
{
  internal readonly FactoryDict Encoders = [];
  internal readonly Dictionary<Type, FactoryList> ListEncoders = [];

  public IEncoderRepositoryBuilder AddEncoder<TModel>(Factory<IEncoder<TModel>, IEncoderRepository> factory)
    => this.FluentAction(b => b.Encoders[typeof(TModel)] = factory);

  IEncoderRepositoryBuilder IEncoderRepositoryBuilder.AddListEncoder<TList, TEncoder, TModel>(Factory<TEncoder, IEncoderRepository> factory)
    => this.FluentAction(b => {
      b.Encoders[typeof(TModel)] = factory;
      FactoryList list = b.ListEncoders.GetValueOrCreate(typeof(TList), _ => []);
      list.Add(r => r.EncoderFor<TModel>());
    });

  internal IEnumerable<Factory<TList, IEncoderRepository>> FactoriesFor<TList>([CallerMemberName] string callerName = "")
    where TList : class
    => ListEncoders.TryGetValue(typeof(TList), out FactoryList list)
      ? list.Select(ListFactory<TList>)
      : throw new InvalidOperationException("No factories of " + typeof(TList).ExpandTypeName() + " found for " + callerName);

  private Factory<TList, IEncoderRepository> ListFactory<TList>(Factory<object, IEncoderRepository> factory)
    where TList : class
    => r => (TList)factory(r);
}
