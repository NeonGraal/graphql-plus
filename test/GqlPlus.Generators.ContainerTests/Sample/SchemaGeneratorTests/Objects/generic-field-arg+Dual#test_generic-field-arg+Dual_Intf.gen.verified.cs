//HintName: test_generic-field-arg+Dual_Intf.gen.cs
// Generated from generic-field-arg+Dual.graphql+ for Intf
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_generic_field_arg_Dual;

public interface ItestGnrcFieldArgDual<TType>
{
  ItestGnrcFieldArgDualObject<TType> AsGnrcFieldArgDual { get; }
}

public interface ItestGnrcFieldArgDualObject<TType>
{
  ItestRefGnrcFieldArgDual<TType> Field { get; }
}

public interface ItestRefGnrcFieldArgDual<TRef>
{
  TRef Asref { get; }
  ItestRefGnrcFieldArgDualObject<TRef> AsRefGnrcFieldArgDual { get; }
}

public interface ItestRefGnrcFieldArgDualObject<TRef>
{
}
