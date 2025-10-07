//HintName: Gqlp_constraint-parent-enum+Dual_Intf.gen.cs
// Generated from constraint-parent-enum+Dual.graphql+ for Intf

/*
*/
namespace GqlPlus.GqlpGeneratorSchemaTests.Gqlp_constraint_parent_enum_Dual;

public interface ICnstPrntEnumDual
{
  RefCnstPrntEnumDual<ParentCnstPrntEnumDual> AsRefCnstPrntEnumDual { get; }
}

public interface IRefCnstPrntEnumDual<Ttype>
{
  Ttype field { get; }
}
