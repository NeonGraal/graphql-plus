//HintName: test_generic-alt-arg-descr+Input_Intf.gen.cs
// Generated from generic-alt-arg-descr+Input.graphql+ for Intf
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_generic_alt_arg_descr_Input;

public interface ItestGnrcAltArgDescrInp<Ttype>
{
  ItestRefGnrcAltArgDescrInp<Ttype> AsRefGnrcAltArgDescrInp { get; }
  ItestGnrcAltArgDescrInpObject AsGnrcAltArgDescrInp { get; }
}

public interface ItestGnrcAltArgDescrInpObject<Ttype>
{
}

public interface ItestRefGnrcAltArgDescrInp<Tref>
{
  Tref Asref { get; }
  ItestRefGnrcAltArgDescrInpObject AsRefGnrcAltArgDescrInp { get; }
}

public interface ItestRefGnrcAltArgDescrInpObject<Tref>
{
}
