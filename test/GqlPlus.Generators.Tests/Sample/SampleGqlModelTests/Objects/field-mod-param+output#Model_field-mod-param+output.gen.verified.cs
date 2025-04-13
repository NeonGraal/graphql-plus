//HintName: Model_field-mod-param+output.gen.cs
// Generated from field-mod-param+output.graphql+

/*
*/

namespace GqlTest.Model_field_mod_param_output;

public interface IOutpFieldModParam<Tmod>
{
  FldOutpFieldModParam field { get; }
}
public class OutputOutpFieldModParam<Tmod>
  : IOutpFieldModParam<Tmod>
{
  public FldOutpFieldModParam field { get; set; }
}

public interface IFldOutpFieldModParam
{
  Number field { get; }
  String AsString { get; }
}
public class OutputFldOutpFieldModParam
  : IFldOutpFieldModParam
{
  public Number field { get; set; }
  public String AsString { get; set; }
}
