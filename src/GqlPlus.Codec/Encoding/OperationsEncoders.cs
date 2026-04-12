namespace GqlPlus.Encoding;

internal class OperationsEncoder(
  IEncoderRepository encoders
) : AndTypeEncoder<OperationsModel, OperationModel>("operation", encoders)
{ }

internal class OperationEncoder(
  IEncoderRepository encoders
) : AliasedEncoder<OperationModel>()
{
  private readonly IEncoder<OpDirectiveModel> _directives = encoders.EncoderFor<OpDirectiveModel>();
  private readonly IEncoder<OpFragmentModel> _fragments = encoders.EncoderFor<OpFragmentModel>();
  private readonly IEncoder<OpResultModel> _result = encoders.EncoderFor<OpResultModel>();
  // private readonly IEncoder<OpSelectionModel> _selections = encoders.EncoderFor<OpSelectionModel>();
  private readonly IEncoder<OpVariableModel> _variables = encoders.EncoderFor<OpVariableModel>();

  internal override Structured Encode(OperationModel model)
    => base.Encode(model)
      .Add("category", model.Category)
      .AddList("directives", model.Directives, _directives)
      .AddMap("fragments", model.Fragments, _fragments, "_Fragments")
      .AddEncoded("result", model.Result, _result)
      // .AddList("selections", model.Selections, _selections)
      .AddMap("variables", model.Variables, _variables, "_Variables");
}

internal class OpDirectiveEncoder
  : NamedEncoder<OpDirectiveModel>
{ }

internal class OpFragmentEncoder
  : NamedEncoder<OpFragmentModel>
{ }

internal class OpResultEncoder
  : BaseEncoder<OpResultModel>
{ }

internal class OpSelectionEncoder
  : BaseEncoder<OpSelectionModel>
{ }

internal class OpSelectionsEncoder
  : IEncoder<OpSelectionModel[]>
{
  public Structured Encode(OpSelectionModel[] input)
    => Structured.Empty();
}

internal class OpVariableEncoder
  : NamedEncoder<OpVariableModel>
{ }
