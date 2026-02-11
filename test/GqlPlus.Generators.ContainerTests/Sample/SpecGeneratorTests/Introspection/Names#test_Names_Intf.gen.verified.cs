//HintName: test_Names_Intf.gen.cs
// Generated from Names.graphql+ for Intf
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_Names;

public interface Itest_Aliased
  : Itest_Named
{
  Itest_AliasedObject As_Aliased { get; }
}

public interface Itest_AliasedObject
  : Itest_NamedObject
{
  ICollection<Itest_Name> Aliases { get; }
}

public interface Itest_Named
  : Itest_Described
{
  Itest_NamedObject As_Named { get; }
}

public interface Itest_NamedObject
  : Itest_DescribedObject
{
  Itest_Name Name { get; }
}

public interface Itest_Described
{
  Itest_DescribedObject As_Described { get; }
}

public interface Itest_DescribedObject
{
  ICollection<string> Description { get; }
}

public interface Itest_AndType
  : Itest_Named
{
  Itest_Type As_Type { get; }
  Itest_AndTypeObject As_AndType { get; }
}

public interface Itest_AndTypeObject
  : Itest_NamedObject
{
  Itest_Type Type { get; }
}
