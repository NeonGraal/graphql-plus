//HintName: Model_generic-alt-dual+Dual.gen.cs
// Generated from generic-alt-dual+Dual.graphql+

/*
*/

namespace GqlTest.Model_generic_alt_dual_Dual;

public interface IDualGnrcAltDual
{
  RefDualGnrcAltDual<AltDualGnrcAltDual> AsRefDualGnrcAltDual { get; }
}
public class DualDualGnrcAltDual
  : IDualGnrcAltDual
{
  public RefDualGnrcAltDual<AltDualGnrcAltDual> AsRefDualGnrcAltDual { get; set; }
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
