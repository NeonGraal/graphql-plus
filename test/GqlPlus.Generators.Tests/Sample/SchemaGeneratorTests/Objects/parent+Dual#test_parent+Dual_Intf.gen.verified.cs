//HintName: test_parent+Dual_Intf.gen.cs
// Generated from parent+Dual.graphql+ for Intf

/*
*/
namespace GqlPlus.GeneratorTests.Gqlp_parent_Dual;

public interface ItestPrntDual
  : ItestRefPrntDual
{
}

public interface ItestRefPrntDual
{
  Number parent { get; }
  String AsString { get; }
}
