//HintName: test_Input_Impl.gen.cs
// Generated from Input.graphql+ for Impl
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_Input;

public class test_InputField
  : test_ObjField<Itest_InputFieldType>
  , Itest_InputField
{
  public Itest_InputFieldObject As_InputField { get; set; }
}

public class test_InputFieldType
  : test_ObjFieldType
  , Itest_InputFieldType
{
  public GqlpValue? Default { get; set; }
  public Itest_InputFieldTypeObject As_InputFieldType { get; set; }
}

public class test_InputParam
  : test_InputFieldType
  , Itest_InputParam
{
  public Itest_InputParamObject As_InputParam { get; set; }
}
