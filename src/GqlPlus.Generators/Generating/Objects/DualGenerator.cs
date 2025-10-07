namespace GqlPlus.Generating.Objects;

internal class DualGenerator
  : GenerateForObject<IGqlpDualObject, IGqlpDualField>
{
  public override string TypePrefix => "Dual";
}
