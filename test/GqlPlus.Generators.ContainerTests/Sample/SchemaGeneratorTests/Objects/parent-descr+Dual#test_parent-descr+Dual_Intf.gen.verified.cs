//HintName: test_parent-descr+Dual_Intf.gen.cs
// Generated from parent-descr+Dual.graphql+ for Intf
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_parent_descr_Dual;

public interface ItestPrntDescrDual
  : ItestRefPrntDescrDual
{
  public testPrntDescrDual PrntDescrDual { get; set; }
}

public interface ItestPrntDescrDualObject
  : ItestRefPrntDescrDualObject
{
}

public interface ItestRefPrntDescrDual
{
  public testString AsString { get; set; }
  public testRefPrntDescrDual RefPrntDescrDual { get; set; }
}

public interface ItestRefPrntDescrDualObject
{
  public testNumber parent { get; set; }
}
