//HintName: test_Output_Intf.gen.cs
// Generated from Output.graphql+ for Intf
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_Output;

public interface Itest_OutputField
  : Itest_ObjField
{
}

public interface Itest_OutputFieldObject
  : Itest_ObjFieldObject
{
}

public interface Itest_OutputFieldType
  : Itest_ObjFieldType
{
}

public interface Itest_OutputFieldTypeObject
  : Itest_ObjFieldTypeObject
{
  public ICollection<Itest_InputParam> Parameters { get; set; }
}
