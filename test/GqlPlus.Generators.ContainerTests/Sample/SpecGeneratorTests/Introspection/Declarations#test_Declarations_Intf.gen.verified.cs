//HintName: test_Declarations_Intf.gen.cs
// Generated from {CurrentDirectory}Declarations.graphql+
//   with GeneratorOption: BaseType: Interface, BaseName: IGqlpInterfaceBase, GeneratorType: Intf
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test, NamespaceIncludesBaseName: True
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_Declarations;

public interface Itest_Schema
  : Itest_Named
{
  Itest_SchemaObject? As__Schema { get; }
}

public interface Itest_SchemaObject
  : Itest_NamedObject
{
  IDictionary<Itest_Name, Itest_Categories> Categories { get; }
  IDictionary<Itest_Name, Itest_Categories>? Call_Categories(Itest_CategoryFilter? parameter);
  IDictionary<Itest_Name, Itest_Directives> Directives { get; }
  IDictionary<Itest_Name, Itest_Directives>? Call_Directives(Itest_Filter? parameter);
  IDictionary<Itest_Name, Itest_Type> Types { get; }
  IDictionary<Itest_Name, Itest_Type>? Call_Types(Itest_TypeFilter? parameter);
  IDictionary<Itest_Name, Itest_Setting> Settings { get; }
  IDictionary<Itest_Name, Itest_Setting>? Call_Settings(Itest_Filter? parameter);
}

public interface Itest_Name
  : IGqlpDomainString
{
}

public interface Itest_Filter
  : IGqlpInterfaceBase
{
  ICollection<Itest_NameFilter>? As_NameFilter { get; }
  Itest_FilterObject? As__Filter { get; }
}

public interface Itest_FilterObject
  : IGqlpInterfaceBase
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
