namespace GqlPlus.Encoding;

internal class AliasedEncoder<TModel>
  : NamedEncoder<TModel>
  where TModel : IAliasedModel
{
  internal override Structured Encode(TModel model)
    => base.Encode(model)
      .Add("aliases", model.Aliases.Encode(flow: true));

  internal static AliasedEncoder<TModel> FactoryAliased(IEncoderRepository _) => new();
}

internal class DescribedEncoder<TModel>
  : BaseEncoder<TModel>
  where TModel : IDescribedModel
{
  internal Structured Described(Structured encoded, TModel model)
    => encoded
    .AddIf(string.IsNullOrWhiteSpace(model.Description),
      onFalse: f => f.Add("description", model.Description?.Encode()));

  internal override Structured Encode(TModel model)
    => Described(base.Encode(model), model);

  internal static DescribedEncoder<TModel> FactoryDescribed(IEncoderRepository _) => new();
}

internal class NamedEncoder<TModel>
  : DescribedEncoder<TModel>
  where TModel : INamedModel
{
  internal override Structured Encode(TModel model)
    => base.Encode(model)
      .Add("name", model.Name?.Encode());

  internal static NamedEncoder<TModel> FactoryNamed(IEncoderRepository _) => new();
}
