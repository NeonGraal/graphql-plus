//HintName: Model_field-object+output.gen.cs
// Generated from field-object+output.graphql+

/*
*/

namespace GqlTest.Model_field_object_output;

public interface IOutpFieldObj
{
  FldOutpFieldObj field { get; }
}
public class OutputOutpFieldObj
{
  public FldOutpFieldObj field { get; set; }
}

public interface IFldOutpFieldObj
{
  Number field { get; }
  String AsString { get; }
}
public class OutputFldOutpFieldObj
{
  public Number field { get; set; }
  public String AsString { get; set; }
}
