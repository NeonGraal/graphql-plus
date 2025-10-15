//HintName: test_Names_Intf.gen.cs
// Generated from Names.graphql+ for Intf

/*
*/
namespace GqlPlus.GeneratorTests.Gqlp_Names;

public interface Itest_Aliased
  : Itest_Named
{
  _Identifier aliases { get; }
}

public interface Itest_Named
  : Itest_Described
{
  _Identifier name { get; }
}

public interface Itest_Described
{
  String description { get; }
}

public interface Itest_AndType
  : Itest_Named
{
  _Type type { get; }
  _Type As_Type { get; }
}
