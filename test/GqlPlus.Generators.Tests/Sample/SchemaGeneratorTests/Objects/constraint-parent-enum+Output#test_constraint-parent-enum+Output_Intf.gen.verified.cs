//HintName: test_constraint-parent-enum+Output_Intf.gen.cs
// Generated from constraint-parent-enum+Output.graphql+ for Intf

/*
*/
namespace GqlPlus.GeneratorTests.Gqlp_constraint_parent_enum_Output;

public interface ItestCnstPrntEnumOutp
{
  RefCnstPrntEnumOutp<ParentCnstPrntEnumOutp> AsRefCnstPrntEnumOutp { get; }
}

public interface ItestRefCnstPrntEnumOutp<Ttype>
{
  Ttype field { get; }
}
