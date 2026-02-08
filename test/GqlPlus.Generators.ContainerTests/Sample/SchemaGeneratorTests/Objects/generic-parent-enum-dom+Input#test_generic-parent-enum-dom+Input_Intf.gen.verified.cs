//HintName: test_generic-parent-enum-dom+Input_Intf.gen.cs
// Generated from generic-parent-enum-dom+Input.graphql+ for Intf
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_generic_parent_enum_dom_Input;

public interface ItestGnrcPrntEnumDomInp
  : ItestFieldGnrcPrntEnumDomInp
{
}

public interface ItestGnrcPrntEnumDomInpObject
  : ItestFieldGnrcPrntEnumDomInpObject
{
}

public interface ItestFieldGnrcPrntEnumDomInp<Tref>
{
}

public interface ItestFieldGnrcPrntEnumDomInpObject<Tref>
{
  public Tref Field { get; set; }
}

public interface ItestDomGnrcPrntEnumDomInp
  : IDomainEnum
{
}
