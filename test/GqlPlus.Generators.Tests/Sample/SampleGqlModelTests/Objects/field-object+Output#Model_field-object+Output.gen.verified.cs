//HintName: Model_field-object+Output.gen.cs
// Generated from field-object+Output.graphql+

/*
*/

namespace GqlTest.Model_field_object_Output;

public interface IOutpFieldObj
{
  FldOutpFieldObj field { get; }
}
public class OutputOutpFieldObj
  : IOutpFieldObj
{
  public FldOutpFieldObj field { get; set; }
}

public interface IFldOutpFieldObj
{
  Number field { get; }
  String AsString { get; }
}
public class OutputFldOutpFieldObj
  : IFldOutpFieldObj
{
  public Number field { get; set; }
  public String AsString { get; set; }
}
