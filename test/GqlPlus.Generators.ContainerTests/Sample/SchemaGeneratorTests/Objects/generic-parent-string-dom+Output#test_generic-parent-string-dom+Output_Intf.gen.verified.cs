//HintName: test_generic-parent-string-dom+Output_Intf.gen.cs
// Generated from generic-parent-string-dom+Output.graphql+ for Intf
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_generic_parent_string_dom_Output;

public interface ItestGnrcPrntStrDomOutp
  : ItestFieldGnrcPrntStrDomOutp
{
  public ItestGnrcPrntStrDomOutpObject AsGnrcPrntStrDomOutp { get; set; }
}

public interface ItestGnrcPrntStrDomOutpObject
  : ItestFieldGnrcPrntStrDomOutpObject
{
}

public interface ItestFieldGnrcPrntStrDomOutp<Tref>
{
  public ItestFieldGnrcPrntStrDomOutpObject AsFieldGnrcPrntStrDomOutp { get; set; }
}

public interface ItestFieldGnrcPrntStrDomOutpObject<Tref>
{
  public Tref Field { get; set; }
}

public interface ItestDomGnrcPrntStrDomOutp
  : IDomainString
{
}
