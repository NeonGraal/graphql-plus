//HintName: test_generic-field-arg+Dual_Impl.gen.cs
// Generated from generic-field-arg+Dual.graphql+ for Impl
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_generic_field_arg_Dual;

public class testGnrcFieldArgDual<TType>
  : ItestGnrcFieldArgDual<TType>
{
  public ItestRefGnrcFieldArgDual<TType> Field { get; set; }
}

public class testRefGnrcFieldArgDual<TRef>
  : ItestRefGnrcFieldArgDual<TRef>
{
}
