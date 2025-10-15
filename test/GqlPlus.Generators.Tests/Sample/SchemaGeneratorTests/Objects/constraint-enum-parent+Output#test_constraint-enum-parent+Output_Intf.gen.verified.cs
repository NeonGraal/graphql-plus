//HintName: test_constraint-enum-parent+Output_Intf.gen.cs
// Generated from constraint-enum-parent+Output.graphql+ for Intf

/*
*/
namespace GqlPlus.GeneratorTests.Gqlp_constraint_enum_parent_Output;

public interface ItestCnstEnumPrntOutp
{
  RefCnstEnumPrntOutp<EnumCnstEnumPrntOutp> AsRefCnstEnumPrntOutp { get; }
}

public interface ItestRefCnstEnumPrntOutp<Ttype>
{
  Ttype field { get; }
}
