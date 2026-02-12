//HintName: test_generic-parent-enum-child+Output_Intf.gen.cs
// Generated from generic-parent-enum-child+Output.graphql+ for Intf
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_generic_parent_enum_child_Output;

public interface ItestGnrcPrntEnumChildOutp
  : ItestFieldGnrcPrntEnumChildOutp<testParentGnrcPrntEnumChildOutp>
{
  ItestGnrcPrntEnumChildOutpObject AsGnrcPrntEnumChildOutp { get; }
}

public interface ItestGnrcPrntEnumChildOutpObject
  : ItestFieldGnrcPrntEnumChildOutpObject<testParentGnrcPrntEnumChildOutp>
{
}

public interface ItestFieldGnrcPrntEnumChildOutp<TRef>
{
  ItestFieldGnrcPrntEnumChildOutpObject<TRef> AsFieldGnrcPrntEnumChildOutp { get; }
}

public interface ItestFieldGnrcPrntEnumChildOutpObject<TRef>
{
  TRef Field { get; }
}
