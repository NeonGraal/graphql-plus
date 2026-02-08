//HintName: test_Names_Impl.gen.cs
// Generated from Names.graphql+ for Impl
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_Names;

public class test_Aliased
  : test_Named
  , Itest_Aliased
{
  public ICollection<Itest_Name> Aliases { get; set; }
}

public class test_Named
  : test_Described
  , Itest_Named
{
  public Itest_Name Name { get; set; }
}

public class test_Described
  : Itest_Described
{
  public ICollection<ItestString> Description { get; set; }
}

public class test_AndType
  : test_Named
  , Itest_AndType
{
  public Itest_Type Type { get; set; }
  public Itest_Type As_Type { get; set; }
}
