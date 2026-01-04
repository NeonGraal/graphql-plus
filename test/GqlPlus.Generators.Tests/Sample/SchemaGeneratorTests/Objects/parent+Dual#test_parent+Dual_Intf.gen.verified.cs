//HintName: test_parent+Dual_Intf.gen.cs
// Generated from parent+Dual.graphql+ for Intf
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_parent_Dual;

public interface ItestPrntDual
  : ItestRefPrntDual
{
  public testPrntDual PrntDual { get; set; }
}

public interface ItestPrntDualField
  : ItestRefPrntDualField
{
}

public interface ItestRefPrntDual
{
  public testString AsString { get; set; }
  public testRefPrntDual RefPrntDual { get; set; }
}

public interface ItestRefPrntDualField
{
  public testNumber parent { get; set; }
}
