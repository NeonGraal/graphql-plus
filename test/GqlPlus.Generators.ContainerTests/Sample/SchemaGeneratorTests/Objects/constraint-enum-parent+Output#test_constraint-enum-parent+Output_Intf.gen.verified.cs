//HintName: test_constraint-enum-parent+Output_Intf.gen.cs
// Generated from constraint-enum-parent+Output.graphql+ for Intf
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_constraint_enum_parent_Output;

public interface ItestCnstEnumPrntOutp
{
  public ItestRefCnstEnumPrntOutp<ItestEnumCnstEnumPrntOutp> AsRefCnstEnumPrntOutp { get; set; }
}

public interface ItestCnstEnumPrntOutpObject
{
}

public interface ItestRefCnstEnumPrntOutp<Ttype>
{
}

public interface ItestRefCnstEnumPrntOutpObject<Ttype>
{
  public Ttype Field { get; set; }
}
