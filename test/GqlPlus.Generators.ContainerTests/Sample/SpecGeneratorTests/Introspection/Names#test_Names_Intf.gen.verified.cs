//HintName: test_Names_Intf.gen.cs
// Generated from Names.graphql+ for Intf
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_Names;

public interface Itest_Aliased
  : Itest_Named
{
  public test_Aliased _Aliased { get; set; }
}

public interface Itest_AliasedObject
  : Itest_NamedObject
{
  public ICollection<test_Name> aliases { get; set; }
}

public interface Itest_Named
  : Itest_Described
{
  public test_Named _Named { get; set; }
}

public interface Itest_NamedObject
  : Itest_DescribedObject
{
  public test_Name name { get; set; }
}

public interface Itest_Described
{
  public test_Described _Described { get; set; }
}

public interface Itest_DescribedObject
{
  public ICollection<testString> description { get; set; }
}

public interface Itest_AndType
  : Itest_Named
{
  public test_Type As_Type { get; set; }
  public test_AndType _AndType { get; set; }
}

public interface Itest_AndTypeObject
  : Itest_NamedObject
{
  public test_Type type { get; set; }
}
