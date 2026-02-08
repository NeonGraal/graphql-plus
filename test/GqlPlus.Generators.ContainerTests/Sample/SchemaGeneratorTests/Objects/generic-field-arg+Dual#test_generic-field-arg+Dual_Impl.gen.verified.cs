//HintName: test_generic-field-arg+Dual_Impl.gen.cs
// Generated from generic-field-arg+Dual.graphql+ for Impl
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_generic_field_arg_Dual;

public class testGnrcFieldArgDual<Ttype>
  : ItestGnrcFieldArgDual<Ttype>
{
  public ItestRefGnrcFieldArgDual<Ttype> Field { get; set; }
  public ItestGnrcFieldArgDualObject AsGnrcFieldArgDual { get; set; }
}

public class testRefGnrcFieldArgDual<Tref>
  : ItestRefGnrcFieldArgDual<Tref>
{
  public Tref Asref { get; set; }
  public ItestRefGnrcFieldArgDualObject AsRefGnrcFieldArgDual { get; set; }
}
