//HintName: test_generic-alt-arg-descr+Output_Intf.gen.cs
// Generated from generic-alt-arg-descr+Output.graphql+ for Intf
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_generic_alt_arg_descr_Output;

public interface ItestGnrcAltArgDescrOutp<TType>
{
  ItestRefGnrcAltArgDescrOutp<TType> AsRefGnrcAltArgDescrOutp { get; }
  ItestGnrcAltArgDescrOutpObject<TType> AsGnrcAltArgDescrOutp { get; }
}

public interface ItestGnrcAltArgDescrOutpObject<TType>
{
}

public interface ItestRefGnrcAltArgDescrOutp<TRef>
{
  TRef Asref { get; }
  ItestRefGnrcAltArgDescrOutpObject<TRef> AsRefGnrcAltArgDescrOutp { get; }
}

public interface ItestRefGnrcAltArgDescrOutpObject<TRef>
{
}
