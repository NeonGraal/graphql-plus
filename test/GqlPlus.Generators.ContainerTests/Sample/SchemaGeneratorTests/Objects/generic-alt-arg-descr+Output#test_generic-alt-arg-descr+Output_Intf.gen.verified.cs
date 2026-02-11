//HintName: test_generic-alt-arg-descr+Output_Intf.gen.cs
// Generated from generic-alt-arg-descr+Output.graphql+ for Intf
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_generic_alt_arg_descr_Output;

public interface ItestGnrcAltArgDescrOutp<Ttype>
{
  ItestRefGnrcAltArgDescrOutp<Ttype> AsRefGnrcAltArgDescrOutp { get; }
  ItestGnrcAltArgDescrOutpObject AsGnrcAltArgDescrOutp { get; }
}

public interface ItestGnrcAltArgDescrOutpObject<Ttype>
{
}

public interface ItestRefGnrcAltArgDescrOutp<Tref>
{
  Tref Asref { get; }
  ItestRefGnrcAltArgDescrOutpObject AsRefGnrcAltArgDescrOutp { get; }
}

public interface ItestRefGnrcAltArgDescrOutpObject<Tref>
{
}
