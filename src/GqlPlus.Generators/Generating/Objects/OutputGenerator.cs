namespace GqlPlus.Generating.Objects;

internal class OutputGenerator
  : GenerateForObject<IGqlpOutputObject>
{
  public override string TypePrefix => "Output";
}
