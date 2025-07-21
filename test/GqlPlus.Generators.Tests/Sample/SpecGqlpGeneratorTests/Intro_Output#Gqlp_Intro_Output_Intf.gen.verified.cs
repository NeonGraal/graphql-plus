//HintName: Gqlp_Intro_Output_Intf.gen.cs
// Generated from Intro_Output.graphql+ for Intf

/*
*/
namespace GqlPlus.GqlpGeneratorSchemaTests.Gqlp_Intro_Output;

public interface I_TypeOutput
  : I_TypeObject
{
}

public interface I_OutputBase
  : I_ObjBase
{
  _DualBase As_DualBase { get; }
}

public interface I_OutputTypeParam
  : I_ObjTypeParam
{
  _TypeRef<_TypeKind> As_TypeRef { get; }
  _TypeRef<_TypeKind> As_TypeRef { get; }
}

public interface I_OutputField
  : I_Field
{
  _InputParam parameters { get; }
  _OutputEnum As_OutputEnum { get; }
}

public interface I_OutputAlternate
  : I_Alternate
{
}

public interface I_OutputTypeArg
  : I_ObjTypeArg
{
  _Identifier label { get; }
}

public interface I_OutputEnum
  : I_TypeRef
{
  _Identifier field { get; }
  _Identifier label { get; }
}
