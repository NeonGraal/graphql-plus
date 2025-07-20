//HintName: Model_field-object+Input.gen.cs
// Generated from field-object+Input.graphql+

/*
*/

namespace GqlPlus.GqlpGeneratorSchemaTests.Model_field_object_Input;

public interface IFieldObjInp
{
  FldFieldObjInp field { get; }
}
public class InputFieldObjInp
  : IFieldObjInp
{
  public FldFieldObjInp field { get; set; }
}

public interface IFldFieldObjInp
{
  Number field { get; }
  String AsString { get; }
}
public class InputFldFieldObjInp
  : IFldFieldObjInp
{
  public Number field { get; set; }
  public String AsString { get; set; }
}
