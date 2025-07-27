namespace GqlPlus.Generating.Objects;

internal class OutputGenerator
  : GenerateForObject<IGqlpOutputObject, IGqlpOutputBase, IGqlpOutputField, IGqlpOutputAlternate>
{
  public override string TypePrefix => "Output";
}
