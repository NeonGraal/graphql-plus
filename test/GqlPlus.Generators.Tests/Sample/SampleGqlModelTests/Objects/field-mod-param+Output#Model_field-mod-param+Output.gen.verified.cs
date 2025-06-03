//HintName: Model_field-mod-param+Output.gen.cs
// Generated from field-mod-param+Output.graphql+

/*
*/

namespace GqlTest.Model_field_mod_param_Output;

public interface IFieldModParamOutp<Tmod>
{
  FldFieldModParamOutp field { get; }
}
public class OutputFieldModParamOutp<Tmod>
  : IFieldModParamOutp<Tmod>
{
  public FldFieldModParamOutp field { get; set; }
}

public interface IFldFieldModParamOutp
{
  Number field { get; }
  String AsString { get; }
}
public class OutputFldFieldModParamOutp
  : IFldFieldModParamOutp
{
  public Number field { get; set; }
  public String AsString { get; set; }
}
