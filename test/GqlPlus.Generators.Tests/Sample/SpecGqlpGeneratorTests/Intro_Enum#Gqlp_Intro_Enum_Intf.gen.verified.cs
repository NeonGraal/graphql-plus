//HintName: Gqlp_Intro_Enum_Intf.gen.cs
// Generated from Intro_Enum.graphql+ for Intf

/*
*/
namespace GqlPlus.GqlpGeneratorSchemaTests.Gqlp_Intro_Enum;

public interface I_TypeEnum
  : I_ParentType
{
}

public interface I_EnumLabel
  : I_Aliased
{
  _Identifier enum { get; }
}

public interface I_EnumValue
  : I_TypeRef
{
  _Identifier label { get; }
}
