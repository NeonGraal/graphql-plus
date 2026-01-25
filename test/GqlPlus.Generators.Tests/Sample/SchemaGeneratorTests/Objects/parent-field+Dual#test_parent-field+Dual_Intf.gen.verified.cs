//HintName: test_parent-field+Dual_Intf.gen.cs
// Generated from parent-field+Dual.graphql+ for Intf
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_parent_field_Dual;

public interface ItestPrntFieldDual
  : ItestRefPrntFieldDual
{
  public testPrntFieldDual PrntFieldDual { get; set; }
}

public interface ItestPrntFieldDualObject
  : ItestRefPrntFieldDualObject
{
  public testNumber field { get; set; }
}

public interface ItestRefPrntFieldDual
{
  public testString AsString { get; set; }
  public testRefPrntFieldDual RefPrntFieldDual { get; set; }
}

public interface ItestRefPrntFieldDualObject
{
  public testNumber parent { get; set; }
}
