//HintName: test_constraint-enum+Output_Intf.gen.cs
// Generated from constraint-enum+Output.graphql+ for Intf

/*
*/
namespace GqlPlus.GeneratorTests.Gqlp_constraint_enum_Output;

public interface ItestCnstEnumOutp
{
  RefCnstEnumOutp<EnumCnstEnumOutp> AsRefCnstEnumOutp { get; }
}

public interface ItestRefCnstEnumOutp<Ttype>
{
  Ttype field { get; }
}
