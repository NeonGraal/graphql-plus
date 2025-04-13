//HintName: Model_generic-parent-param+input.gen.cs
// Generated from generic-parent-param+input.graphql+

/*
*/

namespace GqlTest.Model_generic_parent_param_input;

public interface IInpGnrcPrntParam
{
}
public class InputInpGnrcPrntParam
{
}

public interface IRefInpGnrcPrntParam
{
  $ref Asref { get; }
}
public class InputRefInpGnrcPrntParam
{
  public $ref Asref { get; set; }
}

public interface IAltInpGnrcPrntParam
{
  Number alt { get; }
  String AsString { get; }
}
public class InputAltInpGnrcPrntParam
{
  public Number alt { get; set; }
  public String AsString { get; set; }
}
