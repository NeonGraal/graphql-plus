//HintName: Model_generic-alt-dual+Dual.gen.cs
// Generated from generic-alt-dual+Dual.graphql+

/*
*/

namespace GqlPlus.GqlpGeneratorSchemaTests.Model_generic_alt_dual_Dual;

public interface IGnrcAltDualDual
{
  RefGnrcAltDualDual<AltGnrcAltDualDual> AsRefGnrcAltDualDual { get; }
}
public class DualGnrcAltDualDual
  : IGnrcAltDualDual
{
  public RefGnrcAltDualDual<AltGnrcAltDualDual> AsRefGnrcAltDualDual { get; set; }
}

public interface IRefGnrcAltDualDual<Tref>
{
  Tref Asref { get; }
}
public class DualRefGnrcAltDualDual<Tref>
  : IRefGnrcAltDualDual<Tref>
{
  public Tref Asref { get; set; }
}

public interface IAltGnrcAltDualDual
{
  Number alt { get; }
  String AsString { get; }
}
public class DualAltGnrcAltDualDual
  : IAltGnrcAltDualDual
{
  public Number alt { get; set; }
  public String AsString { get; set; }
}
