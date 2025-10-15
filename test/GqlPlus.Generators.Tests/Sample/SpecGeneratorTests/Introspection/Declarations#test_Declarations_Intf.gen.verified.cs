//HintName: test_Declarations_Intf.gen.cs
// Generated from Declarations.graphql+ for Intf

/*
*/
namespace GqlPlus.GeneratorTests.Gqlp_Declarations;

public interface Itest_Schema
  : Itest_Named
{
  _Categories categories { get; }
  _Directives directives { get; }
  _Type types { get; }
  _Setting settings { get; }
}

public interface Itest_Identifier
{
}

public interface Itest_Filter
{
  _NameFilter names { get; }
  Boolean matchAliases { get; }
  _NameFilter aliases { get; }
  Boolean returnByAlias { get; }
  Boolean returnReferencedTypes { get; }
  _NameFilter As_NameFilter { get; }
}

public interface Itest_NameFilter
{
}

public interface Itest_CategoryFilter
  : Itest_Filter
{
  _Resolution resolutions { get; }
}

public interface Itest_TypeFilter
  : Itest_Filter
{
  _TypeKind kinds { get; }
}
