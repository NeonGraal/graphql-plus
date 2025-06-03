//HintName: Model_generic-parent-param-parent+Input.gen.cs
// Generated from generic-parent-param-parent+Input.graphql+

/*
*/

namespace GqlTest.Model_generic_parent_param_parent_Input;

public interface IGnrcPrntParamPrntInp
  : IRefGnrcPrntParamPrntInp
{
}
public class InputGnrcPrntParamPrntInp
  : InputRefGnrcPrntParamPrntInp
  , IGnrcPrntParamPrntInp
{
}

public interface IRefGnrcPrntParamPrntInp<Tref>
  : Iref
{
}
public class InputRefGnrcPrntParamPrntInp<Tref>
  : Inputref
  , IRefGnrcPrntParamPrntInp<Tref>
{
}

public interface IAltGnrcPrntParamPrntInp
{
  Number alt { get; }
  String AsString { get; }
}
public class InputAltGnrcPrntParamPrntInp
  : IAltGnrcPrntParamPrntInp
{
  public Number alt { get; set; }
  public String AsString { get; set; }
}
