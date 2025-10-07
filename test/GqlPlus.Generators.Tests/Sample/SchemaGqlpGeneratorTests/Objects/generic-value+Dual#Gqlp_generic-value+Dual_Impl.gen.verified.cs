//HintName: Gqlp_generic-value+Dual_Impl.gen.cs
// Generated from generic-value+Dual.graphql+ for Impl

/*
*/
namespace GqlPlus.GqlpGeneratorSchemaTests.Gqlp_generic_value_Dual;

public class DualGnrcValueDual
  : IGnrcValueDual
{
  public RefGnrcValueDual<EnumGnrcValueDual> AsRefGnrcValueDual { get; set; }
}

public class DualRefGnrcValueDual<Ttype>
  : IRefGnrcValueDual<Ttype>
{
  public Ttype field { get; set; }
}
