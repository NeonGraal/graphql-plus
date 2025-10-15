//HintName: test_Names_Impl.gen.cs
// Generated from Names.graphql+ for Impl

/*
*/
namespace GqlPlus.GeneratorTests.Gqlp_Names;

public class Dualtest_Aliased
  : Dualtest_Named
  , Itest_Aliased
{
  public _Identifier aliases { get; set; }
}

public class Dualtest_Named
  : Dualtest_Described
  , Itest_Named
{
  public _Identifier name { get; set; }
}

public class Dualtest_Described
  : Itest_Described
{
  public String description { get; set; }
}

public class Outputtest_AndType
  : Outputtest_Named
  , Itest_AndType
{
  public _Type type { get; set; }
  public _Type As_Type { get; set; }
}
