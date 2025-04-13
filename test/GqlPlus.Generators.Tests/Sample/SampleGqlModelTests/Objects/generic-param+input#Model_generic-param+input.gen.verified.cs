//HintName: Model_generic-param+input.gen.cs
// Generated from generic-param+input.graphql+

/*
*/

namespace GqlTest.Model_generic_param_input;

public interface IInpGnrcParam
{
  InpGnrcParamRef < I@045/0001 InpGnrcParamAlt > field { get; }
}
public class InputInpGnrcParam
{
  public InpGnrcParamRef < I@045/0001 InpGnrcParamAlt > field { get; set; }
}

public interface IInpGnrcParamRef
{
  $ref Asref { get; }
}
public class InputInpGnrcParamRef
{
  public $ref Asref { get; set; }
}

public interface IInpGnrcParamAlt
{
  Number alt { get; }
  String AsString { get; }
}
public class InputInpGnrcParamAlt
{
  public Number alt { get; set; }
  public String AsString { get; set; }
}
