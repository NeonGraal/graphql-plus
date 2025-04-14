//HintName: Model_generic-alt-param+output.gen.cs
// Generated from generic-alt-param+output.graphql+

/*
*/

namespace GqlTest.Model_generic_alt_param_output;

public interface IOutpGnrcAltParam
{
  RefOutpGnrcAltParam<AltOutpGnrcAltParam> AsRefOutpGnrcAltParam { get; }
}
public class OutputOutpGnrcAltParam
  : IOutpGnrcAltParam
{
  public RefOutpGnrcAltParam<AltOutpGnrcAltParam> AsRefOutpGnrcAltParam { get; set; }
}

public interface IRefOutpGnrcAltParam<Tref>
{
  Tref Asref { get; }
}
public class OutputRefOutpGnrcAltParam<Tref>
  : IRefOutpGnrcAltParam<Tref>
{
  public Tref Asref { get; set; }
}

public interface IAltOutpGnrcAltParam
{
  Number alt { get; }
  String AsString { get; }
}
public class OutputAltOutpGnrcAltParam
  : IAltOutpGnrcAltParam
{
  public Number alt { get; set; }
  public String AsString { get; set; }
}
