//HintName: test_-Type_Enum.gen.cs
// Generated from -Type.graphql+ for Enum

/*
*/
namespace GqlPlus.GeneratorTests.Gqlp__Type;

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
