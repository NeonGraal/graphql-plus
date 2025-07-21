﻿//HintName: Gqlp_Intro_+Type_Enum.gen.cs
// Generated from Intro_+Type.graphql+

/*
*/

namespace GqlPlus.GqlpGeneratorSchemaTests.Gqlp_Intro__Type;

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
