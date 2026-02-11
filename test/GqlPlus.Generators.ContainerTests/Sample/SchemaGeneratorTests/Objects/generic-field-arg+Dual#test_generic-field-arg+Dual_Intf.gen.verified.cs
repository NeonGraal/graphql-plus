//HintName: test_generic-field-arg+Dual_Intf.gen.cs
// Generated from generic-field-arg+Dual.graphql+ for Intf
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_generic_field_arg_Dual;

public interface ItestGnrcFieldArgDual<Ttype>
{
  ItestGnrcFieldArgDualObject AsGnrcFieldArgDual { get; }
}

public interface ItestGnrcFieldArgDualObject<Ttype>
{
  ItestRefGnrcFieldArgDual<Ttype> Field { get; }
}

public interface ItestRefGnrcFieldArgDual<Tref>
{
  Tref Asref { get; }
  ItestRefGnrcFieldArgDualObject AsRefGnrcFieldArgDual { get; }
}

public interface ItestRefGnrcFieldArgDualObject<Tref>
{
}
