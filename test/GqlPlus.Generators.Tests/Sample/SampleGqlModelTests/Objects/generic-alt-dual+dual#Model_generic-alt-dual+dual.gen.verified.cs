//HintName: Model_generic-alt-dual+dual.gen.cs
// Generated from generic-alt-dual+dual.graphql+

/*
*/

namespace GqlTest.Model_generic_alt_dual_dual;

public interface IDualGnrcAltDual
{
  RefDualGnrcAltDual AsRefDualGnrcAltDual { get; }
}
public class DualDualGnrcAltDual
  : IDualGnrcAltDual
{
  public RefDualGnrcAltDual AsRefDualGnrcAltDual { get; set; }
}

public interface IRefDualGnrcAltDual<Tref>
{
  Tref Asref { get; }
}
public class DualRefDualGnrcAltDual<Tref>
  : IRefDualGnrcAltDual<Tref>
{
  public Tref Asref { get; set; }
}

public interface IAltDualGnrcAltDual
{
  Number alt { get; }
  String AsString { get; }
}
public class DualAltDualGnrcAltDual
  : IAltDualGnrcAltDual
{
  public Number alt { get; set; }
  public String AsString { get; set; }
}
