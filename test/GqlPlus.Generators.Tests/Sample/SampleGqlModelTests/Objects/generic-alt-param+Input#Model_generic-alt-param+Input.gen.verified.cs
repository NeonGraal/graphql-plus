//HintName: Model_generic-alt-param+Input.gen.cs
// Generated from generic-alt-param+Input.graphql+

/*
*/

namespace GqlTest.Model_generic_alt_param_Input;

public interface IInpGnrcAltParam
{
  RefInpGnrcAltParam<AltInpGnrcAltParam> AsRefInpGnrcAltParam { get; }
}
public class InputInpGnrcAltParam
  : IInpGnrcAltParam
{
  public RefInpGnrcAltParam<AltInpGnrcAltParam> AsRefInpGnrcAltParam { get; set; }
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
