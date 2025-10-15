//HintName: test_-Schema_Intf.gen.cs
// Generated from -Schema.graphql+ for Intf

/*
*/
namespace GqlPlus.GeneratorTests.Gqlp__Schema;

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

public interface Itest_Aliased
  : Itest_Named
{
  _Identifier aliases { get; }
}

public interface Itest_Named
  : Itest_Described
{
  _Identifier name { get; }
}

public interface Itest_Described
{
  String description { get; }
}
