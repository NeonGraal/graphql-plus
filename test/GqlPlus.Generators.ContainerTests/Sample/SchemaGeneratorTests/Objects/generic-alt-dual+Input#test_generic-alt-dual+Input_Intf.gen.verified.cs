//HintName: test_generic-alt-dual+Input_Intf.gen.cs
// Generated from generic-alt-dual+Input.graphql+ for Intf
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_generic_alt_dual_Input;

public interface ItestGnrcAltDualInp
{
  public ItestRefGnrcAltDualInp<ItestAltGnrcAltDualInp> AsRefGnrcAltDualInp { get; set; }
  public ItestGnrcAltDualInpObject AsGnrcAltDualInp { get; set; }
}

public interface ItestGnrcAltDualInpObject
{
}

public interface ItestRefGnrcAltDualInp<Tref>
{
  public Tref Asref { get; set; }
  public ItestRefGnrcAltDualInpObject AsRefGnrcAltDualInp { get; set; }
}

public interface ItestRefGnrcAltDualInpObject<Tref>
{
}

public interface ItestAltGnrcAltDualInp
{
  public ItestString AsString { get; set; }
  public ItestAltGnrcAltDualInpObject AsAltGnrcAltDualInp { get; set; }
}

public interface ItestAltGnrcAltDualInpObject
{
  public ItestNumber Alt { get; set; }
}
