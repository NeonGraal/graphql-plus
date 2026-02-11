//HintName: test_generic-parent-string-dom+Input_Intf.gen.cs
// Generated from generic-parent-string-dom+Input.graphql+ for Intf
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_generic_parent_string_dom_Input;

public interface ItestGnrcPrntStrDomInp
  : ItestFieldGnrcPrntStrDomInp
{
  ItestGnrcPrntStrDomInpObject AsGnrcPrntStrDomInp { get; }
}

public interface ItestGnrcPrntStrDomInpObject
  : ItestFieldGnrcPrntStrDomInpObject
{
}

public interface ItestFieldGnrcPrntStrDomInp<Tref>
{
  ItestFieldGnrcPrntStrDomInpObject AsFieldGnrcPrntStrDomInp { get; }
}

public interface ItestFieldGnrcPrntStrDomInpObject<Tref>
{
  Tref Field { get; }
}

public interface ItestDomGnrcPrntStrDomInp
  : IDomainString
{
}
