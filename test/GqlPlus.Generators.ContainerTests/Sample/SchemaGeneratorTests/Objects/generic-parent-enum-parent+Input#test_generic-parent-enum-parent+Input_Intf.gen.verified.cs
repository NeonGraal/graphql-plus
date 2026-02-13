//HintName: test_generic-parent-enum-parent+Input_Intf.gen.cs
// Generated from generic-parent-enum-parent+Input.graphql+ for Intf
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_generic_parent_enum_parent_Input;

public interface ItestGnrcPrntEnumPrntInp
  : ItestFieldGnrcPrntEnumPrntInp<testEnumGnrcPrntEnumPrntInp>
{
  ItestGnrcPrntEnumPrntInpObject AsGnrcPrntEnumPrntInp { get; }
}

public interface ItestGnrcPrntEnumPrntInpObject
  : ItestFieldGnrcPrntEnumPrntInpObject<testEnumGnrcPrntEnumPrntInp>
{
}

public interface ItestFieldGnrcPrntEnumPrntInp<TRef>
{
  ItestFieldGnrcPrntEnumPrntInpObject<TRef> AsFieldGnrcPrntEnumPrntInp { get; }
}

public interface ItestFieldGnrcPrntEnumPrntInpObject<TRef>
{
  TRef Field { get; }
}
