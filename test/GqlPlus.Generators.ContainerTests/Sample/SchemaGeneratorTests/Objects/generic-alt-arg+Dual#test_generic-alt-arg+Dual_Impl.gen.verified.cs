//HintName: test_generic-alt-arg+Dual_Impl.gen.cs
// Generated from generic-alt-arg+Dual.graphql+ for Impl
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_generic_alt_arg_Dual;

public class testGnrcAltArgDual<TType>
  : ItestGnrcAltArgDual<TType>
{
  public ItestRefGnrcAltArgDual<TType> AsRefGnrcAltArgDual { get; set; }
  public ItestGnrcAltArgDualObject AsGnrcAltArgDual { get; set; }
}

public class testRefGnrcAltArgDual<TRef>
  : ItestRefGnrcAltArgDual<TRef>
{
  public TRef Asref { get; set; }
  public ItestRefGnrcAltArgDualObject AsRefGnrcAltArgDual { get; set; }
}
