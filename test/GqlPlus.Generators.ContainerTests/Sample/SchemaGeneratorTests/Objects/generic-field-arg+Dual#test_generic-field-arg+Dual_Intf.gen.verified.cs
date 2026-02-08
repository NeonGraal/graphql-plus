//HintName: test_generic-field-arg+Dual_Intf.gen.cs
// Generated from generic-field-arg+Dual.graphql+ for Intf
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_generic_field_arg_Dual;

public interface ItestGnrcFieldArgDual<Ttype>
{
  public ItestGnrcFieldArgDualObject AsGnrcFieldArgDual { get; set; }
}

public interface ItestGnrcFieldArgDualObject<Ttype>
{
  public ItestRefGnrcFieldArgDual<Ttype> Field { get; set; }
}

public interface ItestRefGnrcFieldArgDual<Tref>
{
  public Tref Asref { get; set; }
  public ItestRefGnrcFieldArgDualObject AsRefGnrcFieldArgDual { get; set; }
}

public interface ItestRefGnrcFieldArgDualObject<Tref>
{
}
