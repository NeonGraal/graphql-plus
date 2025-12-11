//HintName: test_Input_Intf.gen.cs
// Generated from Input.graphql+ for Intf
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_Input;

public interface Itest_InputField
  : Itest_ObjField
{
  public test_InputField _InputField { get; set; }
}

public interface Itest_InputFieldField
  : Itest_ObjFieldField
{
}

public interface Itest_InputFieldType
  : Itest_ObjFieldType
{
  public test_InputFieldType _InputFieldType { get; set; }
}

public interface Itest_InputFieldTypeField
  : Itest_ObjFieldTypeField
{
  public test_Value? default { get; set; }
}

public interface Itest_InputParam
  : Itest_InputFieldType
{
  public test_InputParam _InputParam { get; set; }
}

public interface Itest_InputParamField
  : Itest_InputFieldTypeField
{
}
