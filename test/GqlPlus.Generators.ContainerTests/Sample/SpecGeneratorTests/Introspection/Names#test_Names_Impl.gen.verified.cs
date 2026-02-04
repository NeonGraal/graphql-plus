//HintName: test_Names_Impl.gen.cs
// Generated from Names.graphql+ for Impl
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_Names;

public class test_Aliased
  : test_Named
  , Itest_Aliased
{
  public ICollection<test_Name> aliases { get; set; }
  public test_Aliased _Aliased { get; set; }
}

public class test_Named
  : test_Described
  , Itest_Named
{
  public test_Name name { get; set; }
  public test_Named _Named { get; set; }
}

public class test_Described
  : Itest_Described
{
  public ICollection<testString> description { get; set; }
  public test_Described _Described { get; set; }
}

public class test_AndType
  : test_Named
  , Itest_AndType
{
  public test_Type type { get; set; }
  public test_Type As_Type { get; set; }
  public test_AndType _AndType { get; set; }
}
