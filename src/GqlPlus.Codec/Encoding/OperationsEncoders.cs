namespace GqlPlus.Encoding;

internal class OperationsEncoder(
  AndBaseTypeEncoders<OperationModel> and
) : AndTypeEncoder<OperationsModel, OperationModel>("operation", and)
{ }

internal class OperationEncoder(
  IEncoder<OpDirectiveModel> directives,
  IEncoder<OpFragmentModel> fragments,
  IEncoder<OpResultModel> result,
  IEncoder<OpSelectionModel[]> selections,
  IEncoder<OpVariableModel> variables
) : AliasedEncoder<OperationModel>
{
  internal override Structured Encode(OperationModel model)
    => base.Encode(model)
      .Add("category", model.Category)
      .AddList("directives", model.Directives, directives)
      .AddMap("fragments", model.Fragments, fragments, "_Fragments")
      .AddEncoded("result", model.Result, result)
      .AddMap("selections", model.Selections, selections, "_Selections")
      .AddMap("variables", model.Variables, variables, "_Variables");
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
