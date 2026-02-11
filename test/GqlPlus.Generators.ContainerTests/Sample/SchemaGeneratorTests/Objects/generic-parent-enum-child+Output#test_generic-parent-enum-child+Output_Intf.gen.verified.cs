//HintName: test_generic-parent-enum-child+Output_Intf.gen.cs
// Generated from generic-parent-enum-child+Output.graphql+ for Intf
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_generic_parent_enum_child_Output;

public interface ItestGnrcPrntEnumChildOutp
  : ItestFieldGnrcPrntEnumChildOutp
{
  ItestGnrcPrntEnumChildOutpObject AsGnrcPrntEnumChildOutp { get; }
}

public interface ItestGnrcPrntEnumChildOutpObject
  : ItestFieldGnrcPrntEnumChildOutpObject
{
}

public interface ItestFieldGnrcPrntEnumChildOutp<Tref>
{
  ItestFieldGnrcPrntEnumChildOutpObject AsFieldGnrcPrntEnumChildOutp { get; }
}

public interface ItestFieldGnrcPrntEnumChildOutpObject<Tref>
{
  Tref Field { get; }
}
