//HintName: Model_field-dual+input.gen.cs
// Generated from field-dual+input.graphql+

/*
*/

namespace GqlTest.Model_field_dual_input;

public interface IInpFieldDual
{
  FldInpFieldDual field { get; }
}
public class InputInpFieldDual
{
  public FldInpFieldDual field { get; set; }
}

public interface IFldInpFieldDual
{
  Number field { get; }
  String AsString { get; }
}
public class DualFldInpFieldDual
{
  public Number field { get; set; }
  public String AsString { get; set; }
}
