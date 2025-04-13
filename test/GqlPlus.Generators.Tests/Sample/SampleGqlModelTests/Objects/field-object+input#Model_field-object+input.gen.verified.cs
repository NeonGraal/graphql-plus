//HintName: Model_field-object+input.gen.cs
// Generated from field-object+input.graphql+

/*
*/

namespace GqlTest.Model_field_object_input;

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
