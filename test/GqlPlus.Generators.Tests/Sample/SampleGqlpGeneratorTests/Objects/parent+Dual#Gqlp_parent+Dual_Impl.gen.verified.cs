//HintName: Gqlp_parent+Dual_Impl.gen.cs
// Generated from parent+Dual.graphql+

/*
*/

namespace GqlPlus.GqlpGeneratorSchemaTests.Gqlp_parent_Dual;
public class DualPrntDual
  : DualRefPrntDual
  , IPrntDual
{
}
public class DualRefPrntDual
  : IRefPrntDual
{
  public Number parent { get; set; }
  public String AsString { get; set; }
}
