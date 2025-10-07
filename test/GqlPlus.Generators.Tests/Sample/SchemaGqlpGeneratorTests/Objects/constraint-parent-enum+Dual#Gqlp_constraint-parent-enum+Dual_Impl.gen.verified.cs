//HintName: Gqlp_constraint-parent-enum+Dual_Impl.gen.cs
// Generated from constraint-parent-enum+Dual.graphql+ for Impl

/*
*/
namespace GqlPlus.GqlpGeneratorSchemaTests.Gqlp_constraint_parent_enum_Dual;

public class DualCnstPrntEnumDual
  : ICnstPrntEnumDual
{
  public RefCnstPrntEnumDual<ParentCnstPrntEnumDual> AsRefCnstPrntEnumDual { get; set; }
}

public class DualRefCnstPrntEnumDual<Ttype>
  : IRefCnstPrntEnumDual<Ttype>
{
  public Ttype field { get; set; }
}
