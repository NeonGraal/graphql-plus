//HintName: test_parent-descr+Dual_Intf.gen.cs
// Generated from parent-descr+Dual.graphql+ for Intf
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_parent_descr_Dual;

public interface ItestPrntDescrDual
  : ItestRefPrntDescrDual
{
  public ItestPrntDescrDualObject AsPrntDescrDual { get; set; }
}

public interface ItestPrntDescrDualObject
  : ItestRefPrntDescrDualObject
{
}

public interface ItestRefPrntDescrDual
{
  public ItestString AsString { get; set; }
  public ItestRefPrntDescrDualObject AsRefPrntDescrDual { get; set; }
}

public interface ItestRefPrntDescrDualObject
{
  public ItestNumber Parent { get; set; }
}
