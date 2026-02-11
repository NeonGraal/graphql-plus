//HintName: test_constraint-enum+Output_Intf.gen.cs
// Generated from constraint-enum+Output.graphql+ for Intf
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_constraint_enum_Output;

public interface ItestCnstEnumOutp
{
  ItestRefCnstEnumOutp<testEnumCnstEnumOutp> AsRefCnstEnumOutp { get; }
  ItestCnstEnumOutpObject AsCnstEnumOutp { get; }
}

public interface ItestCnstEnumOutpObject
{
}

public interface ItestRefCnstEnumOutp<TType>
{
  ItestRefCnstEnumOutpObject AsRefCnstEnumOutp { get; }
}

public interface ItestRefCnstEnumOutpObject<TType>
{
  TType Field { get; }
}
