//HintName: Model_generic-parent-param+dual.gen.cs
// Generated from generic-parent-param+dual.graphql+

/*
*/

namespace GqlTest.Model_generic_parent_param_dual;

public interface IDualGnrcPrntParam
  : IRefDualGnrcPrntParam
{
}
public class DualDualGnrcPrntParam
  : DualRefDualGnrcPrntParam
  , IDualGnrcPrntParam
{
}

public interface IRefDualGnrcPrntParam<Tref>
{
  Tref Asref { get; }
}
public class DualRefDualGnrcPrntParam<Tref>
  : IRefDualGnrcPrntParam<Tref>
{
  public Tref Asref { get; set; }
}

public interface IAltDualGnrcPrntParam
{
  Number alt { get; }
  String AsString { get; }
}
public class DualAltDualGnrcPrntParam
  : IAltDualGnrcPrntParam
{
  public Number alt { get; set; }
  public String AsString { get; set; }
}
