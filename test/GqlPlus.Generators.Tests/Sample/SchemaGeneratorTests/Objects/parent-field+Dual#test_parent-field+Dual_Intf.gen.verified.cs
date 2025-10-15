//HintName: test_parent-field+Dual_Intf.gen.cs
// Generated from parent-field+Dual.graphql+ for Intf

/*
*/
namespace GqlPlus.GeneratorTests.Gqlp_parent_field_Dual;

public interface ItestPrntFieldDual
  : ItestRefPrntFieldDual
{
  Number field { get; }
}

public interface ItestRefPrntFieldDual
{
  Number parent { get; }
  String AsString { get; }
}
