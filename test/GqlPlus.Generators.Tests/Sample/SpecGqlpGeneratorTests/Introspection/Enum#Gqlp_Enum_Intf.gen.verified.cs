//HintName: Gqlp_Enum_Intf.gen.cs
// Generated from Enum.graphql+ for Intf

/*
*/
namespace GqlPlus.GqlpGeneratorSchemaTests.Gqlp_Enum;

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
