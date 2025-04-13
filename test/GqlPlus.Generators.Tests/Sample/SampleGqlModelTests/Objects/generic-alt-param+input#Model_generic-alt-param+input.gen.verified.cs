//HintName: Model_generic-alt-param+input.gen.cs
// Generated from generic-alt-param+input.graphql+

/*
*/

namespace GqlTest.Model_generic_alt_param_input;

public interface IInpGnrcAltParam
{
  RefInpGnrcAltParam AsRefInpGnrcAltParam { get; }
}
public class InputInpGnrcAltParam
  : IInpGnrcAltParam
{
  public RefInpGnrcAltParam AsRefInpGnrcAltParam { get; set; }
}

public interface IRefInpGnrcAltParam<Tref>
{
  Tref Asref { get; }
}
public class InputRefInpGnrcAltParam<Tref>
  : IRefInpGnrcAltParam<Tref>
{
  public Tref Asref { get; set; }
}

public interface IAltInpGnrcAltParam
{
  Number alt { get; }
  String AsString { get; }
}
public class InputAltInpGnrcAltParam
  : IAltInpGnrcAltParam
{
  public Number alt { get; set; }
  public String AsString { get; set; }
}
