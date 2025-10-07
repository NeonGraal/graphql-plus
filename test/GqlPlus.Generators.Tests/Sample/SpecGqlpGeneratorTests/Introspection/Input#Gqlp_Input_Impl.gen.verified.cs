//HintName: Gqlp_Input_Impl.gen.cs
// Generated from Input.graphql+ for Impl

/*
*/
namespace GqlPlus.GqlpGeneratorSchemaTests.Gqlp_Input;

public class Output_TypeInput
  : Output_TypeObject
  , I_TypeInput
{
}

public class Output_InputField
  : Output_ObjField
  , I_InputField
{
}

public class Output_InputFieldType
  : Output_ObjFieldType
  , I_InputFieldType
{
  public _Value default { get; set; }
}

public class Output_InputParam
  : Output_InputFieldType
  , I_InputParam
{
}
