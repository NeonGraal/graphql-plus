//HintName: test_Output_Impl.gen.cs
// Generated from {CurrentDirectory}Output.graphql+
//   with GeneratorOption: BaseType: Class, BaseName: GqlpModelImplementationBase, GeneratorType: Impl
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_Output;

public class test_OutputField
  : test_ObjField<Itest_ObjFieldType>
  , Itest_OutputField
{
}

public class test_OutputFieldType
  : test_ObjFieldType
  , Itest_OutputFieldType
{
  public Itest_InputFieldType? Parameter { get; set; }
}
