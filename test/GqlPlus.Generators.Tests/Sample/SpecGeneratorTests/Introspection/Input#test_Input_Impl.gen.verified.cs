//HintName: test_Input_Impl.gen.cs
// Generated from Input.graphql+ for Impl

/*
*/
namespace GqlPlus.GeneratorTests.Gqlp_Input;

public class test_InputField
  : test_ObjField
  , Itest_InputField
{
  public test_InputField _InputField { get; set; }
}

public class test_InputFieldType
  : test_ObjFieldType
  , Itest_InputFieldType
{
  public test_Value? default { get; set; }
  public test_InputFieldType _InputFieldType { get; set; }
}

public class test_InputParam
  : test_InputFieldType
  , Itest_InputParam
{
  public test_InputParam _InputParam { get; set; }
}
