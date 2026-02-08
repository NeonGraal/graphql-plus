//HintName: test_Option_Intf.gen.cs
// Generated from Option.graphql+ for Intf
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_Option;

public interface Itest_Setting
  : Itest_Named
{
  public Itest_SettingObject As_Setting { get; set; }
}

public interface Itest_SettingObject
  : Itest_NamedObject
{
  public Itest_Value Value { get; set; }
}
