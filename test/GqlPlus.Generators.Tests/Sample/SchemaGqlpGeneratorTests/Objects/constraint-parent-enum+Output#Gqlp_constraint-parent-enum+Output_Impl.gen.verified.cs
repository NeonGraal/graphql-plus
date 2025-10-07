//HintName: Gqlp_constraint-parent-enum+Output_Impl.gen.cs
// Generated from constraint-parent-enum+Output.graphql+ for Impl

/*
*/
namespace GqlPlus.GqlpGeneratorSchemaTests.Gqlp_constraint_parent_enum_Output;

public class OutputCnstPrntEnumOutp
  : ICnstPrntEnumOutp
{
  public RefCnstPrntEnumOutp<ParentCnstPrntEnumOutp> AsRefCnstPrntEnumOutp { get; set; }
}

public class OutputRefCnstPrntEnumOutp<Ttype>
  : IRefCnstPrntEnumOutp<Ttype>
{
  public Ttype field { get; set; }
}
