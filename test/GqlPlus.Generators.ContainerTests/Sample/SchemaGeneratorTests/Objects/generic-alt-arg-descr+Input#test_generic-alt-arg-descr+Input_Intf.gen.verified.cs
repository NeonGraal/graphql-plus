//HintName: test_generic-alt-arg-descr+Input_Intf.gen.cs
// Generated from generic-alt-arg-descr+Input.graphql+ for Intf
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_generic_alt_arg_descr_Input;

public interface ItestGnrcAltArgDescrInp<Ttype>
{
  public ItestRefGnrcAltArgDescrInp<Ttype> AsRefGnrcAltArgDescrInp { get; set; }
}

public interface ItestGnrcAltArgDescrInpObject<Ttype>
{
}

public interface ItestRefGnrcAltArgDescrInp<Tref>
{
  public Tref Asref { get; set; }
}

public interface ItestRefGnrcAltArgDescrInpObject<Tref>
{
}
