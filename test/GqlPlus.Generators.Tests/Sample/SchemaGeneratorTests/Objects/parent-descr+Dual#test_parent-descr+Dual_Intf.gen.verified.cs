//HintName: test_parent-descr+Dual_Intf.gen.cs
// Generated from parent-descr+Dual.graphql+ for Intf

/*
*/
namespace GqlPlus.GeneratorTests.Gqlp_parent_descr_Dual;

public interface ItestPrntDescrDual
  : ItestRefPrntDescrDual
{
}

public interface ItestRefPrntDescrDual
{
  Number parent { get; }
  String AsString { get; }
}
