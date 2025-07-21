//HintName: Gqlp_Intro_Enum_Impl.gen.cs
// Generated from Intro_Enum.graphql+

/*
*/

namespace GqlPlus.GqlpGeneratorSchemaTests.Gqlp_Intro_Enum;
public class Output_TypeEnum
  : Output_ParentType
  , I_TypeEnum
{
}
public class Dual_EnumLabel
  : Dual_Aliased
  , I_EnumLabel
{
  public _Identifier enum { get; set; }
}
public class Output_EnumValue
  : Output_TypeRef
  , I_EnumValue
{
  public _Identifier label { get; set; }
}
