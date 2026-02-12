//HintName: test_generic-parent-enum-dom+Input_Intf.gen.cs
// Generated from generic-parent-enum-dom+Input.graphql+ for Intf
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_generic_parent_enum_dom_Input;

public interface ItestGnrcPrntEnumDomInp
  : ItestFieldGnrcPrntEnumDomInp<ItestDomGnrcPrntEnumDomInp>
{
  ItestGnrcPrntEnumDomInpObject AsGnrcPrntEnumDomInp { get; }
}

public interface ItestGnrcPrntEnumDomInpObject
  : ItestFieldGnrcPrntEnumDomInpObject<ItestDomGnrcPrntEnumDomInp>
{
}

public interface ItestFieldGnrcPrntEnumDomInp<TRef>
{
  ItestFieldGnrcPrntEnumDomInpObject<TRef> AsFieldGnrcPrntEnumDomInp { get; }
}

public interface ItestFieldGnrcPrntEnumDomInpObject<TRef>
{
  TRef Field { get; }
}

public interface ItestDomGnrcPrntEnumDomInp
  : IDomainEnum
{
}
