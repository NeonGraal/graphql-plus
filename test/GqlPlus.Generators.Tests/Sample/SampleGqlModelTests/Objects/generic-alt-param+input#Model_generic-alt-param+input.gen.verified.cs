//HintName: Model_generic-alt-param+input.gen.cs
// Generated from generic-alt-param+input.graphql+

/*
*/

namespace GqlTest.Model_generic_alt_param_input;

public interface IInpGnrcAltParam
{
  RefInpGnrcAltParam < I@046/0001 AltInpGnrcAltParam > AsRefInpGnrcAltParam { get; }
}
public class InputInpGnrcAltParam
{
  public RefInpGnrcAltParam < I@046/0001 AltInpGnrcAltParam > AsRefInpGnrcAltParam { get; set; }
}

public interface IRefInpGnrcAltParam
{
  $ref Asref { get; }
}
public class InputRefInpGnrcAltParam
{
  public $ref Asref { get; set; }
}

public interface IAltInpGnrcAltParam
{
  Number alt { get; }
  String AsString { get; }
}
public class InputAltInpGnrcAltParam
{
  public Number alt { get; set; }
  public String AsString { get; set; }
}
