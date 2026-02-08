//HintName: test_generic-field-param+Dual_Intf.gen.cs
// Generated from generic-field-param+Dual.graphql+ for Intf
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_generic_field_param_Dual;

public interface ItestGnrcFieldParamDual
{
  public ItestGnrcFieldParamDualObject AsGnrcFieldParamDual { get; set; }
}

public interface ItestGnrcFieldParamDualObject
{
  public ItestRefGnrcFieldParamDual<ItestAltGnrcFieldParamDual> Field { get; set; }
}

public interface ItestRefGnrcFieldParamDual<Tref>
{
  public Tref Asref { get; set; }
  public ItestRefGnrcFieldParamDualObject AsRefGnrcFieldParamDual { get; set; }
}

public interface ItestRefGnrcFieldParamDualObject<Tref>
{
}

public interface ItestAltGnrcFieldParamDual
{
  public ItestString AsString { get; set; }
  public ItestAltGnrcFieldParamDualObject AsAltGnrcFieldParamDual { get; set; }
}

public interface ItestAltGnrcFieldParamDualObject
{
  public ItestNumber Alt { get; set; }
}
