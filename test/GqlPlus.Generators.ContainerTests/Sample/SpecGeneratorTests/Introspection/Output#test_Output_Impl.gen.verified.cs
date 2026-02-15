//HintName: test_Output_Impl.gen.cs
// Generated from Output.graphql+ for Impl
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
  public ICollection<Itest_InputParam> Parameters { get; set; }
}
