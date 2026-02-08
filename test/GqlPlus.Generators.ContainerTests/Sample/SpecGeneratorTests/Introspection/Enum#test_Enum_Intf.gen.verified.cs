//HintName: test_Enum_Intf.gen.cs
// Generated from Enum.graphql+ for Intf
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_Enum;

public interface Itest_EnumLabel
  : Itest_Aliased
{
  public Itest_EnumLabelObject As_EnumLabel { get; set; }
}

public interface Itest_EnumLabelObject
  : Itest_AliasedObject
{
  public Itest_Name Enum { get; set; }
}

public interface Itest_EnumValue
  : Itest_TypeRef
{
  public Itest_EnumValueObject As_EnumValue { get; set; }
}

public interface Itest_EnumValueObject
  : Itest_TypeRefObject
{
  public Itest_Name Label { get; set; }
}
