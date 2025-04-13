//HintName: Model_field-mod-param+input.gen.cs
// Generated from field-mod-param+input.graphql+

/*
*/

namespace GqlTest.Model_field_mod_param_input;

public interface IInpFieldModParam
{
  FldInpFieldModParam field { get; }
}
public class InputInpFieldModParam
{
  public FldInpFieldModParam field { get; set; }
}

public interface IFldInpFieldModParam
{
  Number field { get; }
  String AsString { get; }
}
public class InputFldInpFieldModParam
{
  public Number field { get; set; }
  public String AsString { get; set; }
}
