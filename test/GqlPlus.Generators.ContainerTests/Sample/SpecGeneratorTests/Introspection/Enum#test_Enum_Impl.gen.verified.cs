//HintName: test_Enum_Impl.gen.cs
// Generated from Enum.graphql+ for Impl
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_Enum;

public class test_EnumLabel
  : test_Aliased
  , Itest_EnumLabel
{
  public Itest_Name Enum { get; set; }
}

public class test_EnumValue
  : test_TypeRef
  , Itest_EnumValue
{
  public Itest_Name Label { get; set; }
}
