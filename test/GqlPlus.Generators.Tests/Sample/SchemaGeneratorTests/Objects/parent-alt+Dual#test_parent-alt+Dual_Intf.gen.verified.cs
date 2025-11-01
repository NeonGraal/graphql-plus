//HintName: test_parent-alt+Dual_Intf.gen.cs
// Generated from parent-alt+Dual.graphql+ for Intf

/*
*/
namespace GqlPlus.GeneratorTests.Gqlp_parent_alt_Dual;

public interface ItestPrntAltDual
  : ItestRefPrntAltDual
{
  public testNumber AsNumber { get; set; }
  public testPrntAltDual PrntAltDual { get; set; }
}

public interface ItestPrntAltDualField
  : ItestRefPrntAltDualField
{
}

public interface ItestRefPrntAltDual
{
  public testString AsString { get; set; }
  public testRefPrntAltDual RefPrntAltDual { get; set; }
}

public interface ItestRefPrntAltDualField
{
  public testNumber parent { get; set; }
}
