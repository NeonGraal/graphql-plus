//HintName: test_Output_Enc.gen.cs
// Generated from {CurrentDirectory}Output.graphql+
//   with GeneratorOption: BaseType: Class, BaseName: GqlpEncoderBase, GeneratorType: Enc
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_Output;

public class test_OutputField
  : test_ObjField<Itest_ObjFieldType>
  , Itest_OutputField
{
  public Itest_OutputFieldObject? As__OutputField { get; set; }
}

public class test_OutputFieldObject
  : test_ObjFieldObject<Itest_ObjFieldType>
  , Itest_OutputFieldObject
{

  public test_OutputFieldObject
    ()
  {
  }
}

public class test_OutputFieldType
  : test_ObjFieldType
  , Itest_OutputFieldType
{
  public Itest_OutputFieldTypeObject? As__OutputFieldType { get; set; }
}

public class test_OutputFieldTypeObject
  : test_ObjFieldTypeObject
  , Itest_OutputFieldTypeObject
{
  public Itest_InputFieldType? Parameter { get; set; }

  public test_OutputFieldTypeObject
    ()
  {
  }
}
