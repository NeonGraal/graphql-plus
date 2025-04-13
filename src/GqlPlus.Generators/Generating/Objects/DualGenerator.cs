namespace GqlPlus.Generating.Objects;

internal class DualGenerator
  : GenerateForObject<IGqlpDualObject>
{
  public override string TypePrefix => "Dual";
}
