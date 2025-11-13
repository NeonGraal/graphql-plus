//HintName: test_Introspection_Enum.gen.cs
// Generated from Introspection.graphql+ for Enum

/*
*/
namespace GqlPlus.GeneratorTests.Gqlp_Introspection;

public enum test_Resolution
{
  Parallel,
  Sequential,
  Single,
}

public enum test_Location
{
  Operation,
  Variable,
  Field,
  Inline,
  Spread,
  Fragment,
}

public enum test_SimpleKind
{
  Basic,
  Enum,
  Internal,
  Domain,
  Union,
}

public enum test_TypeKind
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

public enum test_ModifierKind
{
  Opt,
  Optional = Opt,
  List,
  Dict,
  Dictionary = Dict,
  Param,
  TypeParam = Param,
}

public enum test_DomainKind
{
  Boolean,
  Enum,
  Number,
  String,
}
