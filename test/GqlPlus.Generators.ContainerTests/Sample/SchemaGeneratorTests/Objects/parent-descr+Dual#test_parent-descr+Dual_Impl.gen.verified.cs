//HintName: test_parent-descr+Dual_Impl.gen.cs
// Generated from parent-descr+Dual.graphql+ for Impl
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_parent_descr_Dual;

public class testPrntDescrDual
  : testRefPrntDescrDual
  , ItestPrntDescrDual
{
  public ItestPrntDescrDualObject AsPrntDescrDual { get; set; }
}

public class testRefPrntDescrDual
  : ItestRefPrntDescrDual
{
  public decimal Parent { get; set; }
  public string AsString { get; set; }
  public ItestRefPrntDescrDualObject AsRefPrntDescrDual { get; set; }
}
