namespace GqlPlus.Generating.Objects;

internal class OutputGenerator
  : GenerateForObject<IGqlpOutputObject, IGqlpOutputField>
{
  public override string TypePrefix => "Output";
}
