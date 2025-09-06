//HintName: Gqlp_Introspection_Enum.gen.cs
// Generated from Introspection.graphql+ for Enum

/*
*/
namespace GqlPlus.GqlpGeneratorSchemaTests.Gqlp_Introspection;

public enum _Resolution
{
  Parallel,
  Sequential,
  Single,
}

public enum _Location
{
  Operation,
  Variable,
  Field,
  Inline,
  Spread,
  Fragment,
}

public enum _SimpleKind
{
  Basic,
  Enum,
  Internal,
  Domain,
  Union,
}

public enum _TypeKind
{
  Basic = _SimpleKind.Basic,
  Enum = _SimpleKind.Enum,
  Internal = _SimpleKind.Internal,
  Domain = _SimpleKind.Domain,
  Union = _SimpleKind.Union,
  Dual,
  Input,
  Output,
}

public enum _ModifierKind
{
  Opt,
  Optional = Opt,
  List,
  Dict,
  Dictionary = Dict,
  Param,
  TypeParam = Param,
}

public enum _DomainKind
{
  Boolean,
  Enum,
  Number,
  String,
}
