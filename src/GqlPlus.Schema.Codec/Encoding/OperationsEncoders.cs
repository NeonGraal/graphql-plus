namespace GqlPlus.Encoding;

internal class OperationsEncoder(
  IEncoderRepository encoders
) : AndTypeEncoder<OperationsModel, OperationModel>("operation", encoders)
{
  internal static OperationsEncoder Factory(IEncoderRepository r) => new(r);
}

internal class OperationEncoder(
  IEncoderRepository encoders
) : AliasedEncoder<OperationModel>()
{
  private readonly Encoder<OpDirectiveModel> _directive = encoders.EncoderFor<OpDirectiveModel>();
  private readonly Encoder<OpFragmentModel> _fragment = encoders.EncoderFor<OpFragmentModel>();
  private readonly Encoder<ModifierModel> _modifier = encoders.EncoderFor<ModifierModel>();
  private readonly Encoder<OpResultModel> _result = encoders.EncoderFor<OpResultModel>();
  private readonly Encoder<OpSelectionModel> _selection = encoders.EncoderFor<OpSelectionModel>();
  private readonly Encoder<OpVariableModel> _variable = encoders.EncoderFor<OpVariableModel>();

  internal override Structured Encode(OperationModel model)
    => base.Encode(model)
      .Add("category", model.Category.Encode())
      .AddList("directives", model.Directives, _directive)
      .AddMap("fragments", model.Fragments, _fragment, "_Fragments")
      .AddList("modifiers", model.Modifiers, _modifier, flow: true)
      .AddEncoded("result", model.Result, _result)
      .AddMapList("selections", model.Selections, _selection, "_Selections")
      .AddMap("variables", model.Variables, _variable, "_Variables");

  internal static OperationEncoder Factory(IEncoderRepository repo) => new(repo);
}

internal class OpDirectiveEncoder
  : NamedEncoder<OpDirectiveModel>
{
  internal static OpDirectiveEncoder Factory(IEncoderRepository _) => new();
}

internal class OpDirectivesEncoder<TModel>(
  IEncoderRepository encoders
) : NamedEncoder<TModel>
  where TModel : OpDirectivesModel
{
  private readonly Encoder<OpDirectiveModel> _directive = encoders.EncoderFor<OpDirectiveModel>();

  internal override Structured Encode(TModel model)
    => base.Encode(model)
      .AddList("directives", model.Directives, _directive);
}

internal class OpFragmentEncoder(
  IEncoderRepository encoders
) : OpDirectivesEncoder<OpFragmentModel>(encoders)
{
  private readonly Encoder<TypeRefModel<TypeKindModel>> _type = encoders.EncoderFor<TypeRefModel<TypeKindModel>>();

  internal override Structured Encode(OpFragmentModel model)
    => base.Encode(model)
      .AddEncoded("type", model.Type, _type);

  internal static OpFragmentEncoder Factory(IEncoderRepository repo) => new(repo);
}

internal class OpResultEncoder(
  IEncoderRepository encoders
) : BaseEncoder<OpResultModel>
{
  private readonly Encoder<OpArgumentModel> _argument = encoders.EncoderFor<OpArgumentModel>();
  private readonly Encoder<TypeRefModel<TypeKindModel>> _domain = encoders.EncoderFor<TypeRefModel<TypeKindModel>>();

  internal override Structured Encode(OpResultModel model)
    => base.Encode(model)
      .AddEncoded("domain", model.Domain, _domain)
      .AddEncoded("argument", model.Argument, _argument);

  internal static OpResultEncoder Factory(IEncoderRepository repo) => new(repo);
}

internal class OpSelectionEncoder(
  IEncoderRepository encoders
) : BaseEncoder<OpSelectionModel>
{
  private readonly Encoder<OpArgumentModel> _argument = encoders.EncoderFor<OpArgumentModel>();
  private readonly Encoder<OpDirectiveModel> _directive = encoders.EncoderFor<OpDirectiveModel>();
  private readonly Encoder<ModifierModel> _modifier = encoders.EncoderFor<ModifierModel>();
  private readonly Encoder<TypeRefModel<TypeKindModel>> _type = encoders.EncoderFor<TypeRefModel<TypeKindModel>>();

  internal override Structured Encode(OpSelectionModel model)
    => base.Encode(model)
    .Add("description", model.Description.Encode())
    .AddList("directives", model.Directives, _directive)
    .AddList("modifiers", model.Modifiers, _modifier)
    .FluentAction(s
      => {
        switch (model) {
          case OpFieldSelectionModel field:
            s.Add("name", field.Name.Encode())
             .Add("alias", field.Alias?.Encode())
             .AddEncoded("argument", field.Argument, _argument);
            break;
          case OpSpreadSelectionModel spread:
            s.Add("fragment", spread.Fragment.Encode());
            break;
          case OpInlineSelectionModel inline:
            s.AddEncoded("onType", inline.Type, _type);
            break;
        }
      });

  internal static OpSelectionEncoder Factory(IEncoderRepository repo) => new(repo);
}

internal class OpVariableEncoder(
  IEncoderRepository encoders
) : OpDirectivesEncoder<OpVariableModel>(encoders)
{
  private readonly Encoder<ConstantModel> _constant = encoders.EncoderFor<ConstantModel>();
  private readonly Encoder<TypeRefModel<TypeKindModel>> _type = encoders.EncoderFor<TypeRefModel<TypeKindModel>>();

  internal override Structured Encode(OpVariableModel model)
    => base.Encode(model)
      .AddEncoded("defaultValue", model.DefaultValue, _constant)
      .AddEncoded("type", model.Type, _type);

  internal static OpVariableEncoder Factory(IEncoderRepository repo) => new(repo);
}
