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

public interface ItestPrntDescrDualField
  : ItestRefPrntDescrDualField
{
}

public interface ItestRefPrntDescrDual
{
  public testString AsString { get; set; }
  public testRefPrntDescrDual RefPrntDescrDual { get; set; }
}

public interface ItestRefPrntDescrDualField
{
  public testNumber parent { get; set; }
}
