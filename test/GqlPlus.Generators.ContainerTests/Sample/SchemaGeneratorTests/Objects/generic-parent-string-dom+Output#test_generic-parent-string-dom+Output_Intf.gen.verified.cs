//HintName: test_generic-parent-string-dom+Output_Intf.gen.cs
// Generated from generic-parent-string-dom+Output.graphql+ for Intf
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_generic_parent_string_dom_Output;

public interface ItestGnrcPrntStrDomOutp
  : ItestFieldGnrcPrntStrDomOutp<ItestDomGnrcPrntStrDomOutp>
{
  ItestGnrcPrntStrDomOutpObject AsGnrcPrntStrDomOutp { get; }
}

public interface ItestGnrcPrntStrDomOutpObject
  : ItestFieldGnrcPrntStrDomOutpObject<ItestDomGnrcPrntStrDomOutp>
{
}

public interface ItestFieldGnrcPrntStrDomOutp<TRef>
{
  ItestFieldGnrcPrntStrDomOutpObject<TRef> AsFieldGnrcPrntStrDomOutp { get; }
}

public interface ItestFieldGnrcPrntStrDomOutpObject<TRef>
{
  TRef Field { get; }
}

public interface ItestDomGnrcPrntStrDomOutp
  : IDomainString
{
}
