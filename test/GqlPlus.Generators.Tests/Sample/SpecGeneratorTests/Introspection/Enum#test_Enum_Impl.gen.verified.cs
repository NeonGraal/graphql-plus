//HintName: test_Enum_Impl.gen.cs
// Generated from Enum.graphql+ for Impl

/*
*/
namespace GqlPlus.GeneratorTests.Gqlp_Enum;

public class test_EnumLabel
  : test_Aliased
  , Itest_EnumLabel
{
  public test_Identifier enum { get; set; }
  public test_EnumLabel _EnumLabel { get; set; }
}

public class test_EnumValue
  : test_TypeRef
  , Itest_EnumValue
{
  public test_Identifier label { get; set; }
  public test_EnumValue _EnumValue { get; set; }
}
