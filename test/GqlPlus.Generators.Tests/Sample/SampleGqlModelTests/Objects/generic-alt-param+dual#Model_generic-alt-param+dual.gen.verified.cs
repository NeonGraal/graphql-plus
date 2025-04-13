//HintName: Model_generic-alt-param+dual.gen.cs
// Generated from generic-alt-param+dual.graphql+

/*
*/

namespace GqlTest.Model_generic_alt_param_dual;

public interface IDualGnrcAltParam
{
  RefDualGnrcAltParam < I@047/0001 AltDualGnrcAltParam > AsRefDualGnrcAltParam { get; }
}
public class DualDualGnrcAltParam
{
  public RefDualGnrcAltParam < I@047/0001 AltDualGnrcAltParam > AsRefDualGnrcAltParam { get; set; }
}

public interface IRefDualGnrcAltParam
{
  $ref Asref { get; }
}
public class DualRefDualGnrcAltParam
{
  public $ref Asref { get; set; }
}

public interface IAltDualGnrcAltParam
{
  Number alt { get; }
  String AsString { get; }
}
public class DualAltDualGnrcAltParam
{
  public Number alt { get; set; }
  public String AsString { get; set; }
}
