//HintName: test_generic-field-param+Dual_Impl.gen.cs
// Generated from generic-field-param+Dual.graphql+ for Impl
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_generic_field_param_Dual;

public class testGnrcFieldParamDual
  : ItestGnrcFieldParamDual
{
  public ItestRefGnrcFieldParamDual<ItestAltGnrcFieldParamDual> Field { get; set; }
  public ItestGnrcFieldParamDualObject AsGnrcFieldParamDual { get; set; }
}

public class testRefGnrcFieldParamDual<TRef>
  : ItestRefGnrcFieldParamDual<TRef>
{
  public TRef Asref { get; set; }
  public ItestRefGnrcFieldParamDualObject<TRef> AsRefGnrcFieldParamDual { get; set; }
}

public class testAltGnrcFieldParamDual
  : ItestAltGnrcFieldParamDual
{
  public decimal Alt { get; set; }
  public string AsString { get; set; }
  public ItestAltGnrcFieldParamDualObject AsAltGnrcFieldParamDual { get; set; }
}
