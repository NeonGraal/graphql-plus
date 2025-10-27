//HintName: test_Enum_Intf.gen.cs
// Generated from Enum.graphql+ for Intf

/*
*/
namespace GqlPlus.GeneratorTests.Gqlp_Enum;

public interface Itest_EnumLabel
  : Itest_Aliased
{
  _Identifier enum { get; }
}

public interface Itest_EnumValue
  : Itest_TypeRef
{
  _Identifier label { get; }
}
