//HintName: Model_field-mod-param+output.gen.cs
// Generated from field-mod-param+output.graphql+

/*
*/

namespace GqlTest.Model_field_mod_param_output;

public interface IOutpFieldModParam
{
  FldOutpFieldModParam field { get; }
}
public class OutputOutpFieldModParam
{
  public FldOutpFieldModParam field { get; set; }
}

public interface IFldOutpFieldModParam
{
  Number field { get; }
  String AsString { get; }
}
public class OutputFldOutpFieldModParam
{
  public Number field { get; set; }
  public String AsString { get; set; }
}
