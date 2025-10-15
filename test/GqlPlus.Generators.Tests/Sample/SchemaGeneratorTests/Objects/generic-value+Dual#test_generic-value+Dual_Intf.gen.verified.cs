//HintName: test_generic-value+Dual_Intf.gen.cs
// Generated from generic-value+Dual.graphql+ for Intf

/*
*/
namespace GqlPlus.GeneratorTests.Gqlp_generic_value_Dual;

public interface ItestGnrcValueDual
{
  RefGnrcValueDual<EnumGnrcValueDual> AsRefGnrcValueDual { get; }
}

public interface ItestRefGnrcValueDual<Ttype>
{
  Ttype field { get; }
}
