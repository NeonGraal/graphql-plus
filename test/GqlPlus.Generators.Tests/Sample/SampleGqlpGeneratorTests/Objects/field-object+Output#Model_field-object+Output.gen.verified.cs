//HintName: Model_field-object+Output.gen.cs
// Generated from field-object+Output.graphql+

/*
*/

namespace GqlPlus.GqlpGeneratorSchemaTests.Model_field_object_Output;

public interface IFieldObjOutp
{
  FldFieldObjOutp field { get; }
}
public class OutputFieldObjOutp
  : IFieldObjOutp
{
  public FldFieldObjOutp field { get; set; }
}

public interface IFldFieldObjOutp
{
  Number field { get; }
  String AsString { get; }
}
public class OutputFldFieldObjOutp
  : IFldFieldObjOutp
{
  public Number field { get; set; }
  public String AsString { get; set; }
}
