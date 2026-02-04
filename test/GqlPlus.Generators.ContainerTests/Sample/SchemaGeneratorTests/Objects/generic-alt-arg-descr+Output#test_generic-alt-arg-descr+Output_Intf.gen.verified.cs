//HintName: test_generic-alt-arg-descr+Output_Intf.gen.cs
// Generated from generic-alt-arg-descr+Output.graphql+ for Intf
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_generic_alt_arg_descr_Output;

public interface ItestGnrcAltArgDescrOutp<Ttype>
{
  public testRefGnrcAltArgDescrOutp<Ttype> AsRefGnrcAltArgDescrOutp { get; set; }
  public testGnrcAltArgDescrOutp GnrcAltArgDescrOutp { get; set; }
}

public interface ItestGnrcAltArgDescrOutpObject<Ttype>
{
}

public interface ItestRefGnrcAltArgDescrOutp<Tref>
{
  public Tref Asref { get; set; }
  public testRefGnrcAltArgDescrOutp RefGnrcAltArgDescrOutp { get; set; }
}

public interface ItestRefGnrcAltArgDescrOutpObject<Tref>
{
}
