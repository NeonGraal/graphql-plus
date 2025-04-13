//HintName: Model_field-mod-param+input.gen.cs
// Generated from field-mod-param+input.graphql+

/*
*/

namespace GqlTest.Model_field_mod_param_input;

public interface IInpFieldModParam<Tmod>
{
  FldInpFieldModParam field { get; }
}
public class InputInpFieldModParam<Tmod>
  : IInpFieldModParam<Tmod>
{
  public FldInpFieldModParam field { get; set; }
}

public interface IFldInpFieldModParam
{
  Number field { get; }
  String AsString { get; }
}
public class InputFldInpFieldModParam
  : IFldInpFieldModParam
{
  public Number field { get; set; }
  public String AsString { get; set; }
}
