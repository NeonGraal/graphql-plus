//HintName: Gqlp_constraint-enum+Dual_Impl.gen.cs
// Generated from constraint-enum+Dual.graphql+ for Impl

/*
*/
namespace GqlPlus.GqlpGeneratorSchemaTests.Gqlp_constraint_enum_Dual;

public class DualCnstEnumDual
  : ICnstEnumDual
{
  public RefCnstEnumDual<EnumCnstEnumDual> AsRefCnstEnumDual { get; set; }
}

public class DualRefCnstEnumDual<Ttype>
  : IRefCnstEnumDual<Ttype>
{
  public Ttype field { get; set; }
}
