//HintName: Model_Intro_Enum.gen.cs
// Generated from Intro_Enum.graphql+

/*
*/

namespace GqlPlus.GqlpGeneratorSchemaTests.Model_Intro_Enum;

public interface I_TypeEnum
  : I_ParentType
{
}
public class Output_TypeEnum
  : Output_ParentType
  , I_TypeEnum
{
}

public interface I_EnumLabel
  : I_Aliased
{
  _Identifier enum { get; }
}
public class Dual_EnumLabel
  : Dual_Aliased
  , I_EnumLabel
{
  public _Identifier enum { get; set; }
}

public interface I_EnumValue
  : I_TypeRef
{
  _Identifier label { get; }
}
public class Output_EnumValue
  : Output_TypeRef
  , I_EnumValue
{
  public _Identifier label { get; set; }
}
