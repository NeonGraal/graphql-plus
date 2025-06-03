//HintName: Model_field-dual+Output.gen.cs
// Generated from field-dual+Output.graphql+

/*
*/

namespace GqlTest.Model_field_dual_Output;

public interface IOutpFieldDual
{
  FldOutpFieldDual field { get; }
}
public class OutputOutpFieldDual
  : IOutpFieldDual
{
  public FldOutpFieldDual field { get; set; }
}

public interface IFldOutpFieldDual
{
  Number field { get; }
  String AsString { get; }
}
public class DualFldOutpFieldDual
  : IFldOutpFieldDual
{
  public Number field { get; set; }
  public String AsString { get; set; }
}
