//HintName: Gqlp_Intro_Common_Enum.gen.cs
// Generated from Intro_Common.graphql+ for Enum

/*
*/
namespace GqlPlus.GqlpGeneratorSchemaTests.Gqlp_Intro_Common;

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
