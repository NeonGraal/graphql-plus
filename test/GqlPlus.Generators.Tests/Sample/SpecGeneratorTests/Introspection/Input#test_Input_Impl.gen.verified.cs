//HintName: test_Input_Impl.gen.cs
// Generated from Input.graphql+ for Impl

/*
*/
namespace GqlPlus.GeneratorTests.Gqlp_Input;

public class test_TypeInput
  : test_TypeObject
  , Itest_TypeInput
{
}

public class test_InputField
  : test_ObjField
  , Itest_InputField
{
}

public class test_InputFieldType
  : test_ObjFieldType
  , Itest_InputFieldType
{
  public _Value default { get; set; }
}

public class test_InputParam
  : test_InputFieldType
  , Itest_InputParam
{
}
