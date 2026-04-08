//HintName: test_Names_Dec.gen.cs
// Generated from {CurrentDirectory}Names.graphql+
//   with GeneratorOption: BaseType: Class, BaseName: GqlpDecoderBase, GeneratorType: Dec
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_Names;

public interface Itest_Aliased
  : Itest_Named
{
  Itest_AliasedObject? As__Aliased { get; }
}

public interface Itest_AliasedObject
  : Itest_NamedObject
{
  ICollection<Itest_Name> Aliases { get; }
}

public interface Itest_Named
  : Itest_Described
{
  Itest_NamedObject? As__Named { get; }
}

public interface Itest_NamedObject
  : Itest_DescribedObject
{
  Itest_Name Name { get; }
}

public interface Itest_Described
  // No Base because it's Class
{
  Itest_DescribedObject? As__Described { get; }
}

public interface Itest_DescribedObject
  // No Base because it's Class
{
  ICollection<string> Description { get; }
}

public interface Itest_AndType
  : Itest_Named
{
  Itest_Type? As_Type { get; }
  Itest_AndTypeObject? As__AndType { get; }
}

public interface Itest_AndTypeObject
  : Itest_NamedObject
{
  Itest_Type Type { get; }
}
