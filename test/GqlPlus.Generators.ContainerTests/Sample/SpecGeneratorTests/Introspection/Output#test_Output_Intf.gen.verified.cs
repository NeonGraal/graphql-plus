//HintName: test_Output_Intf.gen.cs
// Generated from Output.graphql+ for Intf
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_Output;

public interface Itest_OutputField
  : Itest_ObjField
{
  Itest_OutputFieldObject As_OutputField { get; }
}

public interface Itest_OutputFieldObject
  : Itest_ObjFieldObject
{
}

public interface Itest_OutputFieldType
  : Itest_ObjFieldType
{
  Itest_OutputFieldTypeObject As_OutputFieldType { get; }
}

public interface Itest_OutputFieldTypeObject
  : Itest_ObjFieldTypeObject
{
  ICollection<Itest_InputParam> Parameters { get; }
}
