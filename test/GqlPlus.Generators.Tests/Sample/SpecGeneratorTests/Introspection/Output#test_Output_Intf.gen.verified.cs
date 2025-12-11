//HintName: test_Output_Intf.gen.cs
// Generated from Output.graphql+ for Intf
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_Output;

public interface Itest_OutputField
  : Itest_ObjField
{
  public test_OutputField _OutputField { get; set; }
}

public interface Itest_OutputFieldField
  : Itest_ObjFieldField
{
}

public interface Itest_OutputFieldType
  : Itest_ObjFieldType
{
  public test_OutputFieldType _OutputFieldType { get; set; }
}

public interface Itest_OutputFieldTypeField
  : Itest_ObjFieldTypeField
{
  public ICollection<test_InputParam> parameters { get; set; }
}
