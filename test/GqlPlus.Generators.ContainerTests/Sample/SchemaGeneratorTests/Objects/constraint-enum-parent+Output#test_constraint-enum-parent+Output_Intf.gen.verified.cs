//HintName: test_constraint-enum-parent+Output_Intf.gen.cs
// Generated from constraint-enum-parent+Output.graphql+ for Intf
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_constraint_enum_parent_Output;

public interface ItestCnstEnumPrntOutp
{
  ItestRefCnstEnumPrntOutp<testEnumCnstEnumPrntOutp> AsEnumCnstEnumPrntOutpcnstEnumPrntOutp { get; }
  ItestCnstEnumPrntOutpObject AsCnstEnumPrntOutp { get; }
}

public interface ItestCnstEnumPrntOutpObject
{
}

public interface ItestRefCnstEnumPrntOutp<TType>
{
  ItestRefCnstEnumPrntOutpObject AsRefCnstEnumPrntOutp { get; }
}

public interface ItestRefCnstEnumPrntOutpObject<TType>
{
  TType Field { get; }
}
