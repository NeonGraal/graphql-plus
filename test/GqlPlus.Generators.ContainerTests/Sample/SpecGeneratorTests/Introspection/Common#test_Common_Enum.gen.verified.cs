//HintName: test_Common_Enum.gen.cs
// Generated from Common.graphql+ for Enum
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_Common;

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
