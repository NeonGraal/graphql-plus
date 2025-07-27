//HintName: Gqlp_parent-field+Dual_Impl.gen.cs
// Generated from parent-field+Dual.graphql+ for Impl

/*
*/
namespace GqlPlus.GqlpGeneratorSchemaTests.Gqlp_parent_field_Dual;

public class DualPrntFieldDual
  : DualRefPrntFieldDual
  , IPrntFieldDual
{
  public Number field { get; set; }
}

public class DualRefPrntFieldDual
  : IRefPrntFieldDual
{
  public Number parent { get; set; }
  public String AsString { get; set; }
}
