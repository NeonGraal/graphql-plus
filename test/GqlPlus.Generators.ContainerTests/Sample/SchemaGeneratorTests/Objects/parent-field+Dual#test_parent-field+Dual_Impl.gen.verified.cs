//HintName: test_parent-field+Dual_Impl.gen.cs
// Generated from parent-field+Dual.graphql+ for Impl
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_parent_field_Dual;

public class testPrntFieldDual
  : testRefPrntFieldDual
  , ItestPrntFieldDual
{
  public testNumber field { get; set; }
  public testPrntFieldDual PrntFieldDual { get; set; }
}

public class testRefPrntFieldDual
  : ItestRefPrntFieldDual
{
  public testNumber parent { get; set; }
  public testString AsString { get; set; }
  public testRefPrntFieldDual RefPrntFieldDual { get; set; }
}
