//HintName: test_Enum_Intf.gen.cs
// Generated from Enum.graphql+ for Intf

/*
*/
namespace GqlPlus.GeneratorTests.Gqlp_Enum;

public interface Itest_EnumLabel
  : Itest_Aliased
{
  public test_EnumLabel _EnumLabel { get; set; }
}

public interface Itest_EnumLabelField
  : Itest_AliasedField
{
  public test_Identifier enum { get; set; }
}

public interface Itest_EnumValue
  : Itest_TypeRef
{
  public test_EnumValue _EnumValue { get; set; }
}

public interface Itest_EnumValueField
  : Itest_TypeRefField
{
  public test_Identifier label { get; set; }
}
