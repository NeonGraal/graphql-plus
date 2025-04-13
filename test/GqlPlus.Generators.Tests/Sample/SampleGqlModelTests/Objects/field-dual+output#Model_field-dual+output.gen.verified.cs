//HintName: Model_field-dual+output.gen.cs
// Generated from field-dual+output.graphql+

/*
*/

namespace GqlTest.Model_field_dual_output;

public interface IOutpFieldDual
{
  FldOutpFieldDual field { get; }
}
public class OutputOutpFieldDual
{
  public FldOutpFieldDual field { get; set; }
}

public interface IFldOutpFieldDual
{
  Number field { get; }
  String AsString { get; }
}
public class DualFldOutpFieldDual
{
  public Number field { get; set; }
  public String AsString { get; set; }
}
