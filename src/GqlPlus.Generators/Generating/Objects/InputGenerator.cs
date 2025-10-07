namespace GqlPlus.Generating.Objects;

internal class InputGenerator
  : GenerateForObject<IGqlpInputObject, IGqlpInputField>
{
  public override string TypePrefix => "Input";
}
