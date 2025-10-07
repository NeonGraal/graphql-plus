//HintName: Gqlp_constraint-parent-enum+Output_Intf.gen.cs
// Generated from constraint-parent-enum+Output.graphql+ for Intf

/*
*/
namespace GqlPlus.GqlpGeneratorSchemaTests.Gqlp_constraint_parent_enum_Output;

public interface ICnstPrntEnumOutp
{
  RefCnstPrntEnumOutp<ParentCnstPrntEnumOutp> AsRefCnstPrntEnumOutp { get; }
}

public interface IRefCnstPrntEnumOutp<Ttype>
{
  Ttype field { get; }
}
