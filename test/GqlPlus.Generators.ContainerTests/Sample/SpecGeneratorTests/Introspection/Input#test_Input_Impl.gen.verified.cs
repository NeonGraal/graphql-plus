//HintName: test_Input_Impl.gen.cs
// Generated from {CurrentDirectory}Input.graphql+
//   with GeneratorOption: BaseType: Class, BaseName: GqlpModelImplementationBase, GeneratorType: Impl
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_Input;

public class test_InputField
  : test_ObjField<Itest_InputFieldType>
  , Itest_InputField
{
  public Itest_InputFieldObject? As__InputField { get; set; }
}

public class test_InputFieldObject
  : test_ObjFieldObject<Itest_InputFieldType>
  , Itest_InputFieldObject
{

  public test_InputFieldObject
    ()
  {
  }
}

public class test_InputFieldType
  : test_ObjFieldType
  , Itest_InputFieldType
{
  public Itest_InputFieldTypeObject? As__InputFieldType { get; set; }
}

public class test_InputFieldTypeObject
  : test_ObjFieldTypeObject
  , Itest_InputFieldTypeObject
{
  public GqlpValue? DefaultValue { get; set; }

  public test_InputFieldTypeObject
    ()
  {
  }
}
