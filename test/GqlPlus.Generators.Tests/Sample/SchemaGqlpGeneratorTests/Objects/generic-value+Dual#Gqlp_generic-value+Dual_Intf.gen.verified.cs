//HintName: Gqlp_generic-value+Dual_Intf.gen.cs
// Generated from generic-value+Dual.graphql+ for Intf

/*
*/
namespace GqlPlus.GqlpGeneratorSchemaTests.Gqlp_generic_value_Dual;

public interface IGnrcValueDual
{
  RefGnrcValueDual<EnumGnrcValueDual> AsRefGnrcValueDual { get; }
}

public interface IRefGnrcValueDual<Ttype>
{
  Ttype field { get; }
}
