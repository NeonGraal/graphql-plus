namespace GqlPlus.Generating.Objects;

internal class InputGenerator
  : GenerateForObject<IGqlpInputObject, IGqlpInputBase, IGqlpInputField, IGqlpInputAlternate>
{
  public override string TypePrefix => "Input";
}
