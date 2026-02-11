//HintName: test_constraint-enum-parent+Output_Intf.gen.cs
// Generated from constraint-enum-parent+Output.graphql+ for Intf
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_constraint_enum_parent_Output;

public interface ItestCnstEnumPrntOutp
{
  ItestRefCnstEnumPrntOutp<testEnumCnstEnumPrntOutp> AsRefCnstEnumPrntOutp { get; }
  ItestCnstEnumPrntOutpObject AsCnstEnumPrntOutp { get; }
}

public interface ItestCnstEnumPrntOutpObject
{
}

public interface ItestRefCnstEnumPrntOutp<Ttype>
{
  ItestRefCnstEnumPrntOutpObject AsRefCnstEnumPrntOutp { get; }
}

public interface ItestRefCnstEnumPrntOutpObject<Ttype>
{
  Ttype Field { get; }
}
