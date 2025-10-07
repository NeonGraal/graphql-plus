//HintName: Gqlp_constraint-dom-enum+Dual_Impl.gen.cs
// Generated from constraint-dom-enum+Dual.graphql+ for Impl

/*
*/
namespace GqlPlus.GqlpGeneratorSchemaTests.Gqlp_constraint_dom_enum_Dual;

public class DualCnstDomEnumDual
  : ICnstDomEnumDual
{
  public RefCnstDomEnumDual<EnumCnstDomEnumDual> AsRefCnstDomEnumDual { get; set; }
}

public class DualRefCnstDomEnumDual<Ttype>
  : IRefCnstDomEnumDual<Ttype>
{
  public Ttype field { get; set; }
}

public class DomainJustCnstDomEnumDual
  : IJustCnstDomEnumDual
{
}
