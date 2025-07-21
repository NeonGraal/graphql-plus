//HintName: Gqlp_Intro_+Schema_Intf.gen.cs
// Generated from Intro_+Schema.graphql+

/*
*/

namespace GqlPlus.GqlpGeneratorSchemaTests.Gqlp_Intro__Schema;

public interface I_Schema
  : I_Named
{
  _Categories categories { get; }
  _Directives directives { get; }
  _Type types { get; }
  _Setting settings { get; }
}

public interface I_Identifier
{
}

public interface I_Filter
{
  _NameFilter names { get; }
  Boolean matchAliases { get; }
  _NameFilter aliases { get; }
  Boolean returnByAlias { get; }
  Boolean returnReferencedTypes { get; }
  _NameFilter As_NameFilter { get; }
}

public interface I_NameFilter
{
}

public interface I_CategoryFilter
  : I_Filter
{
  _Resolution resolutions { get; }
}

public interface I_TypeFilter
  : I_Filter
{
  _TypeKind kinds { get; }
}

public interface I_Aliased
  : I_Named
{
  _Identifier aliases { get; }
}

public interface I_Named
  : I_Described
{
  _Identifier name { get; }
}

public interface I_Described
{
  String description { get; }
}
