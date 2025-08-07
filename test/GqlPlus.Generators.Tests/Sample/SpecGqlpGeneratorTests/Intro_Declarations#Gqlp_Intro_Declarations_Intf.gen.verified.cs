//HintName: Gqlp_Intro_Declarations_Intf.gen.cs
// Generated from Intro_Declarations.graphql+ for Intf

/*
*/
namespace GqlPlus.GqlpGeneratorSchemaTests.Gqlp_Intro_Declarations;

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
