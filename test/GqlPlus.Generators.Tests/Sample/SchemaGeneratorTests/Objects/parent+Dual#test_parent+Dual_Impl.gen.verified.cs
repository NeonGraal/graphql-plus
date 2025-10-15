//HintName: test_parent+Dual_Impl.gen.cs
// Generated from parent+Dual.graphql+ for Impl

/*
*/
namespace GqlPlus.GeneratorTests.Gqlp_parent_Dual;

public class DualtestPrntDual
  : DualtestRefPrntDual
  , ItestPrntDual
{
}

public class DualtestRefPrntDual
  : ItestRefPrntDual
{
  public Number parent { get; set; }
  public String AsString { get; set; }
}
