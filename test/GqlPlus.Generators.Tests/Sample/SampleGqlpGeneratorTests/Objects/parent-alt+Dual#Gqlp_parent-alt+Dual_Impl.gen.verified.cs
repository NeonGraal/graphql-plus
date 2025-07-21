//HintName: Gqlp_parent-alt+Dual_Impl.gen.cs
// Generated from parent-alt+Dual.graphql+ for Impl

/*
*/
namespace GqlPlus.GqlpGeneratorSchemaTests.Gqlp_parent_alt_Dual;
public class DualPrntAltDual
  : DualRefPrntAltDual
  , IPrntAltDual
{
  public Number AsNumber { get; set; }
}
public class DualRefPrntAltDual
  : IRefPrntAltDual
{
  public Number parent { get; set; }
  public String AsString { get; set; }
}
