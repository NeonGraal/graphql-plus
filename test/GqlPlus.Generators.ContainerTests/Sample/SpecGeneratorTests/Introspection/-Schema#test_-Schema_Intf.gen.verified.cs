//HintName: test_-Schema_Intf.gen.cs
// Generated from {CurrentDirectory}-Schema.graphql+
//   with GeneratorOption: BaseType: Interface, BaseName: IGqlpModelImplementationBase, GeneratorType: Intf
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp__Schema;

public interface Itest_Schema
  : Itest_Named
{
  Itest_SchemaObject? As__Schema { get; }
}

public interface Itest_SchemaObject
  : Itest_NamedObject
{
  IDictionary<Itest_Name, Itest_Categories>? Categories(Itest_CategoryFilter? parameter);
  IDictionary<Itest_Name, Itest_Directives>? Directives(Itest_Filter? parameter);
  IDictionary<Itest_Name, Itest_Type>? Types(Itest_TypeFilter? parameter);
  IDictionary<Itest_Name, Itest_Setting>? Settings(Itest_Filter? parameter);
}

public interface Itest_Name
  : IGqlpDomainString
{
}

public interface Itest_Filter
  : IGqlpModelImplementationBase
{
  ICollection<Itest_NameFilter>? As_NameFilter { get; }
  Itest_FilterObject? As__Filter { get; }
}

public interface Itest_FilterObject
  : IGqlpModelImplementationBase
{
  ICollection<Itest_NameFilter> Names { get; }
  bool? MatchAliases { get; }
  ICollection<Itest_NameFilter> Aliases { get; }
  bool? ReturnByAlias { get; }
  bool? ReturnReferencedTypes { get; }
}

public interface Itest_NameFilter
  : IGqlpDomainString
{
}

public interface Itest_CategoryFilter
  : Itest_Filter
{
  Itest_CategoryFilterObject? As__CategoryFilter { get; }
}

public interface Itest_CategoryFilterObject
  : Itest_FilterObject
{
  ICollection<Itest_Resolution> Resolutions { get; }
}

public interface Itest_TypeFilter
  : Itest_Filter
{
  Itest_TypeFilterObject? As__TypeFilter { get; }
}

public interface Itest_TypeFilterObject
  : Itest_FilterObject
{
  ICollection<Itest_TypeKind> Kinds { get; }
}

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
  : IGqlpModelImplementationBase
{
  Itest_DescribedObject? As__Described { get; }
}

public interface Itest_DescribedObject
  : IGqlpModelImplementationBase
{
  ICollection<string> Description { get; }
}
