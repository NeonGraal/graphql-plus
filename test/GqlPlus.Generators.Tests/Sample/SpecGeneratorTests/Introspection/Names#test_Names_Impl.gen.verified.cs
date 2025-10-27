//HintName: test_Names_Impl.gen.cs
// Generated from Names.graphql+ for Impl

/*
*/
namespace GqlPlus.GeneratorTests.Gqlp_Names;

public class test_Aliased
  : test_Named
  , Itest_Aliased
{
  public _Identifier aliases { get; set; }
}

public class test_Named
  : test_Described
  , Itest_Named
{
  public _Identifier name { get; set; }
}

public class test_Described
  : Itest_Described
{
  public String description { get; set; }
}

public class test_AndType
  : test_Named
  , Itest_AndType
{
  public _Type type { get; set; }
  public _Type As_Type { get; set; }
}
