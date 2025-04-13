//HintName: Model_generic-parent-param+input.gen.cs
// Generated from generic-parent-param+input.graphql+

/*
*/

namespace GqlTest.Model_generic_parent_param_input;

public interface IInpGnrcPrntParam
  : IRefInpGnrcPrntParam
{
}
public class InputInpGnrcPrntParam
  : InputRefInpGnrcPrntParam
  , IInpGnrcPrntParam
{
}

public interface IRefInpGnrcPrntParam<Tref>
{
  Tref Asref { get; }
}
public class InputRefInpGnrcPrntParam<Tref>
  : IRefInpGnrcPrntParam<Tref>
{
  public Tref Asref { get; set; }
}

public interface IAltInpGnrcPrntParam
{
  Number alt { get; }
  String AsString { get; }
}
public class InputAltInpGnrcPrntParam
  : IAltInpGnrcPrntParam
{
  public Number alt { get; set; }
  public String AsString { get; set; }
}
