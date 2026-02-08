//HintName: test_Names_Intf.gen.cs
// Generated from Names.graphql+ for Intf
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_Names;

public interface Itest_Aliased
  : Itest_Named
{
  public Itest_AliasedObject As_Aliased { get; set; }
}

public interface Itest_AliasedObject
  : Itest_NamedObject
{
  public ICollection<Itest_Name> Aliases { get; set; }
}

public interface Itest_Named
  : Itest_Described
{
  public Itest_NamedObject As_Named { get; set; }
}

public interface Itest_NamedObject
  : Itest_DescribedObject
{
  public Itest_Name Name { get; set; }
}

public interface Itest_Described
{
  public Itest_DescribedObject As_Described { get; set; }
}

public interface Itest_DescribedObject
{
  public ICollection<ItestString> Description { get; set; }
}

public interface Itest_AndType
  : Itest_Named
{
  public Itest_Type As_Type { get; set; }
  public Itest_AndTypeObject As_AndType { get; set; }
}

public interface Itest_AndTypeObject
  : Itest_NamedObject
{
  public Itest_Type Type { get; set; }
}
