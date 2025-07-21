//HintName: Gqlp_Intro_Input_Intf.gen.cs
// Generated from Intro_Input.graphql+

/*
*/

namespace GqlPlus.GqlpGeneratorSchemaTests.Gqlp_Intro_Input;

public interface I_TypeInput
  : I_TypeObject
{
}

public interface I_InputBase
  : I_ObjBase
{
  _DualBase As_DualBase { get; }
}

public interface I_InputTypeParam
  : I_ObjTypeParam
{
  _TypeRef<_TypeKind> As_TypeRef { get; }
}

public interface I_InputField
  : I_Field
{
  _Constant default { get; }
}

public interface I_InputAlternate
  : I_Alternate
{
}

public interface I_InputTypeArg
  : I_ObjTypeArg
{
}

public interface I_InputParam
  : I_InputBase
{
  _Modifiers modifiers { get; }
  _Constant default { get; }
}
