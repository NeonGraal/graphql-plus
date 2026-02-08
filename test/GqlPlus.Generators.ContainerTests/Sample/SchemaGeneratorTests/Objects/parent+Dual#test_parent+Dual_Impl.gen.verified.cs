//HintName: test_parent+Dual_Impl.gen.cs
// Generated from parent+Dual.graphql+ for Impl
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_parent_Dual;

public class testPrntDual
  : testRefPrntDual
  , ItestPrntDual
{
}

public class testRefPrntDual
  : ItestRefPrntDual
{
  public ItestNumber Parent { get; set; }
  public ItestString AsString { get; set; }
}
