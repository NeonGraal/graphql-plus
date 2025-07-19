//HintName: Model_generic-parent-param+Input.gen.cs
// Generated from generic-parent-param+Input.graphql+

/*
*/

namespace GqlTest.Model_generic_parent_param_Input;

public interface IGnrcPrntParamInp
  : IRefGnrcPrntParamInp
{
}
public class InputGnrcPrntParamInp
  : InputRefGnrcPrntParamInp
  , IGnrcPrntParamInp
{
}

public interface IRefGnrcPrntParamInp<Tref>
{
  Tref Asref { get; }
}
public class InputRefGnrcPrntParamInp<Tref>
  : IRefGnrcPrntParamInp<Tref>
{
  public Tref Asref { get; set; }
}

public interface IAltGnrcPrntParamInp
{
  Number alt { get; }
  String AsString { get; }
}
public class InputAltGnrcPrntParamInp
  : IAltGnrcPrntParamInp
{
  public Number alt { get; set; }
  public String AsString { get; set; }
}
