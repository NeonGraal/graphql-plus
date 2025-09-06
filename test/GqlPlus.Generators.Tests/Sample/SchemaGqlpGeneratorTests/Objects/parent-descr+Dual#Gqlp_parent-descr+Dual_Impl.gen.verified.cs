//HintName: Gqlp_parent-descr+Dual_Impl.gen.cs
// Generated from parent-descr+Dual.graphql+ for Impl

/*
*/
namespace GqlPlus.GqlpGeneratorSchemaTests.Gqlp_parent_descr_Dual;

public class DualPrntDescrDual
  : DualRefPrntDescrDual
  , IPrntDescrDual
{
}

public class DualRefPrntDescrDual
  : IRefPrntDescrDual
{
  public Number parent { get; set; }
  public String AsString { get; set; }
}
