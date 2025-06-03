//HintName: Model_field-object+Input.gen.cs
// Generated from field-object+Input.graphql+

/*
*/

namespace GqlTest.Model_field_object_Input;

public interface IInpFieldObj
{
  FldInpFieldObj field { get; }
}
public class InputInpFieldObj
  : IInpFieldObj
{
  public FldInpFieldObj field { get; set; }
}

public interface IFldInpFieldObj
{
  Number field { get; }
  String AsString { get; }
}
public class InputFldInpFieldObj
  : IFldInpFieldObj
{
  public Number field { get; set; }
  public String AsString { get; set; }
}
