//HintName: test_generic-parent-enum-dom+Input_Intf.gen.cs
// Generated from generic-parent-enum-dom+Input.graphql+ for Intf
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_generic_parent_enum_dom_Input;

public interface ItestGnrcPrntEnumDomInp
  : ItestFieldGnrcPrntEnumDomInp
{
  ItestGnrcPrntEnumDomInpObject AsGnrcPrntEnumDomInp { get; }
}

public interface ItestGnrcPrntEnumDomInpObject
  : ItestFieldGnrcPrntEnumDomInpObject
{
}

public interface ItestFieldGnrcPrntEnumDomInp<Tref>
{
  ItestFieldGnrcPrntEnumDomInpObject AsFieldGnrcPrntEnumDomInp { get; }
}

public interface ItestFieldGnrcPrntEnumDomInpObject<Tref>
{
  Tref Field { get; }
}

public interface ItestDomGnrcPrntEnumDomInp
  : IDomainEnum
{
}
