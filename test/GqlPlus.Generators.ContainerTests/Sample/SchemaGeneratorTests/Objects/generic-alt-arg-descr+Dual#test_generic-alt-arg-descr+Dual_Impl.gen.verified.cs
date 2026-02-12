//HintName: test_generic-alt-arg-descr+Dual_Impl.gen.cs
// Generated from generic-alt-arg-descr+Dual.graphql+ for Impl
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_generic_alt_arg_descr_Dual;

public class testGnrcAltArgDescrDual<TType>
  : ItestGnrcAltArgDescrDual<TType>
{
  public ItestRefGnrcAltArgDescrDual<TType> AsRefGnrcAltArgDescrDual { get; set; }
  public ItestGnrcAltArgDescrDualObject<TType> AsGnrcAltArgDescrDual { get; set; }
}

public class testRefGnrcAltArgDescrDual<TRef>
  : ItestRefGnrcAltArgDescrDual<TRef>
{
  public TRef Asref { get; set; }
  public ItestRefGnrcAltArgDescrDualObject<TRef> AsRefGnrcAltArgDescrDual { get; set; }
}
