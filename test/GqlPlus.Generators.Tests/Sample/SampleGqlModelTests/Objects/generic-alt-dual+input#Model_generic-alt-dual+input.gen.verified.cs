//HintName: Model_generic-alt-dual+input.gen.cs
// Generated from generic-alt-dual+input.graphql+

/*
*/

namespace GqlTest.Model_generic_alt_dual_input;

public interface IInpGnrcAltDual
{
  RefInpGnrcAltDual < I@044/0001 AltInpGnrcAltDual > AsRefInpGnrcAltDual { get; }
}
public class InputInpGnrcAltDual
{
  public RefInpGnrcAltDual < I@044/0001 AltInpGnrcAltDual > AsRefInpGnrcAltDual { get; set; }
}

public interface IRefInpGnrcAltDual
{
  $ref Asref { get; }
}
public class InputRefInpGnrcAltDual
{
  public $ref Asref { get; set; }
}

public interface IAltInpGnrcAltDual
{
  Number alt { get; }
  String AsString { get; }
}
public class DualAltInpGnrcAltDual
{
  public Number alt { get; set; }
  public String AsString { get; set; }
}
