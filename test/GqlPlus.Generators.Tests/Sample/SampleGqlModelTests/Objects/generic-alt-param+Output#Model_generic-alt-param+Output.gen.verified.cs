//HintName: Model_generic-alt-param+Output.gen.cs
// Generated from generic-alt-param+Output.graphql+

/*
*/

namespace GqlTest.Model_generic_alt_param_Output;

public interface IGnrcAltParamOutp
{
  RefGnrcAltParamOutp<AltGnrcAltParamOutp> AsRefGnrcAltParamOutp { get; }
}
public class OutputGnrcAltParamOutp
  : IGnrcAltParamOutp
{
  public RefGnrcAltParamOutp<AltGnrcAltParamOutp> AsRefGnrcAltParamOutp { get; set; }
}

public interface IRefGnrcAltParamOutp<Tref>
{
  Tref Asref { get; }
}
public class OutputRefGnrcAltParamOutp<Tref>
  : IRefGnrcAltParamOutp<Tref>
{
  public Tref Asref { get; set; }
}

public interface IAltGnrcAltParamOutp
{
  Number alt { get; }
  String AsString { get; }
}
public class OutputAltGnrcAltParamOutp
  : IAltGnrcAltParamOutp
{
  public Number alt { get; set; }
  public String AsString { get; set; }
}
