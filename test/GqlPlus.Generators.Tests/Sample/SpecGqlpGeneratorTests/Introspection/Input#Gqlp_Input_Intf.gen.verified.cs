//HintName: Gqlp_Input_Intf.gen.cs
// Generated from Input.graphql+ for Intf

/*
*/
namespace GqlPlus.GqlpGeneratorSchemaTests.Gqlp_Input;

public interface I_TypeInput
  : I_TypeObject
{
}

public interface I_InputField
  : I_ObjField
{
}

public interface I_InputFieldType
  : I_ObjFieldType
{
  _Value default { get; }
}

public interface I_InputParam
  : I_InputFieldType
{
}
