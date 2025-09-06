namespace GqlPlus.Generating.Objects;

internal class DualGenerator
  : GenerateForObject<IGqlpDualObject, IGqlpDualBase, IGqlpDualField, IGqlpDualAlternate>
{
  public override string TypePrefix => "Dual";
}
