//HintName: test_Enum_Intf.gen.cs
// Generated from Enum.graphql+ for Intf
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_Enum;

public interface Itest_EnumLabel
  : Itest_Aliased
{
  Itest_EnumLabelObject As_EnumLabel { get; }
}

public interface Itest_EnumLabelObject
  : Itest_AliasedObject
{
  Itest_Name Enum { get; }
}

public interface Itest_EnumValue
  : Itest_TypeRef
{
  Itest_EnumValueObject As_EnumValue { get; }
}

public interface Itest_EnumValueObject
  : Itest_TypeRefObject
{
  Itest_Name Label { get; }
}
