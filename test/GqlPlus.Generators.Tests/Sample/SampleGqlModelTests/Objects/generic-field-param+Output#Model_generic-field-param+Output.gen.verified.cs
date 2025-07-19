//HintName: Model_generic-field-param+Output.gen.cs
// Generated from generic-field-param+Output.graphql+

/*
*/

namespace GqlTest.Model_generic_field_param_Output;

public interface IGnrcFieldParamOutp
{
  RefGnrcFieldParamOutp<AltGnrcFieldParamOutp> field { get; }
}
public class OutputGnrcFieldParamOutp
  : IGnrcFieldParamOutp
{
  public RefGnrcFieldParamOutp<AltGnrcFieldParamOutp> field { get; set; }
}

public interface IRefGnrcFieldParamOutp<Tref>
{
  Tref Asref { get; }
}
public class OutputRefGnrcFieldParamOutp<Tref>
  : IRefGnrcFieldParamOutp<Tref>
{
  public Tref Asref { get; set; }
}

public interface IAltGnrcFieldParamOutp
{
  Number alt { get; }
  String AsString { get; }
}
public class OutputAltGnrcFieldParamOutp
  : IAltGnrcFieldParamOutp
{
  public Number alt { get; set; }
  public String AsString { get; set; }
}
