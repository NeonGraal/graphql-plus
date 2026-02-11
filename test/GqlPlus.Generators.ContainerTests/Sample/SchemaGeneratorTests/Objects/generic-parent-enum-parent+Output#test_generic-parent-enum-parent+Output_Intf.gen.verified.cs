//HintName: test_generic-parent-enum-parent+Output_Intf.gen.cs
// Generated from generic-parent-enum-parent+Output.graphql+ for Intf
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_generic_parent_enum_parent_Output;

public interface ItestGnrcPrntEnumPrntOutp
  : ItestFieldGnrcPrntEnumPrntOutp
{
  ItestGnrcPrntEnumPrntOutpObject AsGnrcPrntEnumPrntOutp { get; }
}

public interface ItestGnrcPrntEnumPrntOutpObject
  : ItestFieldGnrcPrntEnumPrntOutpObject
{
}

public interface ItestFieldGnrcPrntEnumPrntOutp<Tref>
{
  ItestFieldGnrcPrntEnumPrntOutpObject AsFieldGnrcPrntEnumPrntOutp { get; }
}

public interface ItestFieldGnrcPrntEnumPrntOutpObject<Tref>
{
  Tref Field { get; }
}
