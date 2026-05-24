using System.Text;

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
  private readonly Encoder<OpDirectiveModel> _directives = encoders.EncoderFor<OpDirectiveModel>();
  private readonly Encoder<OpFragmentModel> _fragments = encoders.EncoderFor<OpFragmentModel>();
  private readonly Encoder<ModifierModel> _modifiers = encoders.EncoderFor<ModifierModel>();
  private readonly Encoder<OpResultModel> _result = encoders.EncoderFor<OpResultModel>();
  // private readonly IEncoder<OpSelectionModel> _selections = encoders.EncoderFor<OpSelectionModel>();
  private readonly Encoder<OpVariableModel> _variables = encoders.EncoderFor<OpVariableModel>();

  internal override Structured Encode(OperationModel model)
    => base.Encode(model)
      .Add("category", model.Category.Encode())
      .AddList("directives", model.Directives, _directives)
      .AddMap("fragments", model.Fragments, _fragments, "_Fragments")
      .AddList("modifiers", model.Modifiers, _modifiers, flow: true)
      .AddEncoded("result", model.Result, _result)
      // .AddList("selections", model.Selections, _selections)
      .AddMap("variables", model.Variables, _variables, "_Variables");

  internal new static OperationEncoder Factory(IEncoderRepository repo) => new(repo);
}

internal class OpDirectiveEncoder
  : NamedEncoder<OpDirectiveModel>
{ }

internal class OpDirectivesEncoder<TModel>(
  IEncoderRepository encoders
) : NamedEncoder<TModel>
  where TModel : OpDirectivesModel
{
  private readonly Encoder<OpDirectiveModel> _directives = encoders.EncoderFor<OpDirectiveModel>();

  internal override Structured Encode(TModel model)
    => base.Encode(model)
      .AddList("directives", model.Directives, _directives);
}

internal class OpFragmentEncoder(
  IEncoderRepository encoders
) : OpDirectivesEncoder<OpFragmentModel>(encoders)
{
  private readonly Encoder<TypeRefModel<TypeKindModel>> _type = encoders.EncoderFor<TypeRefModel<TypeKindModel>>();

  internal override Structured Encode(OpFragmentModel model)
    => base.Encode(model)
      .AddEncoded("type", model.Type, _type);

  internal new static OpFragmentEncoder Factory(IEncoderRepository repo) => new(repo);
}

internal class OpResultEncoder(
  IEncoderRepository encoders
) : BaseEncoder<OpResultModel>
{
  private readonly Encoder<TypeRefModel<TypeKindModel>> _domain = encoders.EncoderFor<TypeRefModel<TypeKindModel>>();

  internal override Structured Encode(OpResultModel model)
    => base.Encode(model)
      .AddEncoded("domain", model.Domain, _domain);

  internal static OpResultEncoder Factory(IEncoderRepository repo) => new(repo);
}

internal class OpSelectionEncoder
  : BaseEncoder<OpSelectionModel>
{
  internal static OpSelectionEncoder Factory(IEncoderRepository _) => new();
}

internal class OpSelectionsEncoder
  : IEncoder<OpSelectionModel[]>
{
  public Structured Encode(OpSelectionModel[] input)
    => Structured.Empty();
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

  internal new static OpVariableEncoder Factory(IEncoderRepository repo) => new(repo);
}
