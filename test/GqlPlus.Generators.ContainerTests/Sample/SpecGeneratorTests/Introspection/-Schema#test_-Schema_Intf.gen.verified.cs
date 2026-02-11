//HintName: test_-Schema_Intf.gen.cs
// Generated from -Schema.graphql+ for Intf
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp__Schema;

public interface Itest_Schema
  : Itest_Named
{
  Itest_SchemaObject As_Schema { get; }
}

public interface Itest_SchemaObject
  : Itest_NamedObject
{
  IDictionary<Itest_Name, Itest_Categories> Categories { get; }
  IDictionary<Itest_Name, Itest_Directives> Directives { get; }
  IDictionary<Itest_Name, Itest_Type> Types { get; }
  IDictionary<Itest_Name, Itest_Setting> Settings { get; }
}

public interface Itest_Name
  : IDomainString
{
}

public interface Itest_Filter
{
  ICollection<Itest_NameFilter> As_NameFilter { get; }
  Itest_FilterObject As_Filter { get; }
}

public interface Itest_FilterObject
{
  ICollection<Itest_NameFilter> Names { get; }
  bool? MatchAliases { get; }
  ICollection<Itest_NameFilter> Aliases { get; }
  bool? ReturnByAlias { get; }
  bool? ReturnReferencedTypes { get; }
}

public interface Itest_NameFilter
  : IDomainString
{
}

public interface Itest_CategoryFilter
  : Itest_Filter
{
  Itest_CategoryFilterObject As_CategoryFilter { get; }
}

public interface Itest_CategoryFilterObject
  : Itest_FilterObject
{
  ICollection<Itest_Resolution> Resolutions { get; }
}

public interface Itest_TypeFilter
  : Itest_Filter
{
  Itest_TypeFilterObject As_TypeFilter { get; }
}

public interface Itest_TypeFilterObject
  : Itest_FilterObject
{
  ICollection<Itest_TypeKind> Kinds { get; }
}

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
