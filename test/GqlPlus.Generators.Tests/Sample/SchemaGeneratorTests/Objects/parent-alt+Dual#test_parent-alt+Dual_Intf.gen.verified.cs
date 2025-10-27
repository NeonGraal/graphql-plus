//HintName: test_parent-alt+Dual_Intf.gen.cs
// Generated from parent-alt+Dual.graphql+ for Intf

/*
*/
namespace GqlPlus.GeneratorTests.Gqlp_parent_alt_Dual;

public interface ItestPrntAltDual
  : ItestRefPrntAltDual
{
  Number AsNumber { get; }
}

public interface ItestRefPrntAltDual
{
  Number parent { get; }
  String AsString { get; }
}
