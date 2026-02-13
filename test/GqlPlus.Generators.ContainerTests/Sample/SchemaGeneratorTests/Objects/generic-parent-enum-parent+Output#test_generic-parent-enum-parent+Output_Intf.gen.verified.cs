//HintName: test_generic-parent-enum-parent+Output_Intf.gen.cs
// Generated from generic-parent-enum-parent+Output.graphql+ for Intf
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_generic_parent_enum_parent_Output;

public interface ItestGnrcPrntEnumPrntOutp
  : ItestFieldGnrcPrntEnumPrntOutp<testEnumGnrcPrntEnumPrntOutp>
{
  ItestGnrcPrntEnumPrntOutpObject AsGnrcPrntEnumPrntOutp { get; }
}

public interface ItestGnrcPrntEnumPrntOutpObject
  : ItestFieldGnrcPrntEnumPrntOutpObject<testEnumGnrcPrntEnumPrntOutp>
{
}

public interface ItestFieldGnrcPrntEnumPrntOutp<TRef>
{
  ItestFieldGnrcPrntEnumPrntOutpObject<TRef> AsFieldGnrcPrntEnumPrntOutp { get; }
}

public interface ItestFieldGnrcPrntEnumPrntOutpObject<TRef>
{
  TRef Field { get; }
}
