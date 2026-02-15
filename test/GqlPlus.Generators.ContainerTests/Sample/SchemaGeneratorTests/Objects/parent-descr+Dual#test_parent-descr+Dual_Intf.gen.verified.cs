//HintName: test_parent-descr+Dual_Intf.gen.cs
// Generated from parent-descr+Dual.graphql+ for Intf
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_parent_descr_Dual;

public interface ItestPrntDescrDual
  : ItestRefPrntDescrDual
{
  ItestPrntDescrDualObject AsPrntDescrDual { get; }
}

public interface ItestPrntDescrDualObject
  : ItestRefPrntDescrDualObject
{
}

public interface ItestRefPrntDescrDual
{
  string AsString { get; }
  ItestRefPrntDescrDualObject AsRefPrntDescrDual { get; }
}

public interface ItestRefPrntDescrDualObject
{
  decimal Parent { get; }
}
