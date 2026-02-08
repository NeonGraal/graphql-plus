//HintName: test_parent-field+Dual_Impl.gen.cs
// Generated from parent-field+Dual.graphql+ for Impl
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_parent_field_Dual;

public class testPrntFieldDual
  : testRefPrntFieldDual
  , ItestPrntFieldDual
{
  public ItestNumber Field { get; set; }
  public ItestPrntFieldDualObject AsPrntFieldDual { get; set; }
}

public class testRefPrntFieldDual
  : ItestRefPrntFieldDual
{
  public ItestNumber Parent { get; set; }
  public ItestString AsString { get; set; }
  public ItestRefPrntFieldDualObject AsRefPrntFieldDual { get; set; }
}
