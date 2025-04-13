namespace GqlPlus.Generating.Objects;

internal class InputGenerator
  : GenerateForObject<IGqlpInputObject>
{
  public override string TypePrefix => "Input";
}
