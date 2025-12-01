namespace GqlPlus.Encoding;

internal class AliasedEncoder<TModel>
  : NamedEncoder<TModel>
  where TModel : IAliasedModel
{
  internal override Structured Encode(TModel model)
    => base.Encode(model)
      .Add("aliases", new(model.Aliases.Select(a => new Structured(new StructureValue(a))), flow: true));
}

internal class DescribedEncoder<TModel>
  : BaseEncoder<TModel>
  where TModel : IDescribedModel
{
  internal Structured Described(Structured encoded, TModel model)
    => encoded
    .AddIf(string.IsNullOrWhiteSpace(model.Description),
      onFalse: f => f.Add("description", new(model.Description)));

  internal override Structured Encode(TModel model)
    => Described(base.Encode(model), model);
}

internal class NamedEncoder<TModel>
  : DescribedEncoder<TModel>
  where TModel : INamedModel
{
  internal override Structured Encode(TModel model)
    => base.Encode(model)
      .Add("name", model.Name);
}
