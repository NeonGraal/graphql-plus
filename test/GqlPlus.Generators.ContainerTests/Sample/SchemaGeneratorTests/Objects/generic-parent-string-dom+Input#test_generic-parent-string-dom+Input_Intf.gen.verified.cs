//HintName: test_generic-parent-string-dom+Input_Intf.gen.cs
// Generated from generic-parent-string-dom+Input.graphql+ for Intf
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_generic_parent_string_dom_Input;

public interface ItestGnrcPrntStrDomInp
  : ItestFieldGnrcPrntStrDomInp<ItestDomGnrcPrntStrDomInp>
{
  ItestGnrcPrntStrDomInpObject AsGnrcPrntStrDomInp { get; }
}

public interface ItestGnrcPrntStrDomInpObject
  : ItestFieldGnrcPrntStrDomInpObject<ItestDomGnrcPrntStrDomInp>
{
}

public interface ItestFieldGnrcPrntStrDomInp<TRef>
{
  ItestFieldGnrcPrntStrDomInpObject<TRef> AsFieldGnrcPrntStrDomInp { get; }
}

public interface ItestFieldGnrcPrntStrDomInpObject<TRef>
{
  TRef Field { get; }
}

public interface ItestDomGnrcPrntStrDomInp
  : IGqlpDomainString
{
}
