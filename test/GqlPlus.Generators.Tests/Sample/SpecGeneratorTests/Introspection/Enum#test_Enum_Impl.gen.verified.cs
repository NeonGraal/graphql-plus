//HintName: test_Enum_Impl.gen.cs
// Generated from Enum.graphql+ for Impl

/*
*/
namespace GqlPlus.GeneratorTests.Gqlp_Enum;

public class Outputtest_TypeEnum
  : Outputtest_ParentType
  , Itest_TypeEnum
{
}

public class Dualtest_EnumLabel
  : Dualtest_Aliased
  , Itest_EnumLabel
{
  public _Identifier enum { get; set; }
}

public class Outputtest_EnumValue
  : Outputtest_TypeRef
  , Itest_EnumValue
{
  public _Identifier label { get; set; }
}
