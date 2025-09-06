//HintName: Gqlp_Input_Intf.gen.cs
// Generated from Input.graphql+ for Intf

/*
*/
namespace GqlPlus.GqlpGeneratorSchemaTests.Gqlp_Input;

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
  _Value default { get; }
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
  _Value default { get; }
}
