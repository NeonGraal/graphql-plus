//HintName: test_constraint-parent-enum+Output_Intf.gen.cs
// Generated from constraint-parent-enum+Output.graphql+ for Intf
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_constraint_parent_enum_Output;

public interface ItestCnstPrntEnumOutp
{
  public ItestRefCnstPrntEnumOutp<ItestParentCnstPrntEnumOutp> AsRefCnstPrntEnumOutp { get; set; }
}

public interface ItestCnstPrntEnumOutpObject
{
}

public interface ItestRefCnstPrntEnumOutp<Ttype>
{
}

public interface ItestRefCnstPrntEnumOutpObject<Ttype>
{
  public Ttype Field { get; set; }
}
