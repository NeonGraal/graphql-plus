//HintName: test_generic-alt-arg-descr+Input_Intf.gen.cs
// Generated from generic-alt-arg-descr+Input.graphql+ for Intf
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_generic_alt_arg_descr_Input;

public interface ItestGnrcAltArgDescrInp<TType>
{
  ItestRefGnrcAltArgDescrInp<TType> AsRefGnrcAltArgDescrInp { get; }
  ItestGnrcAltArgDescrInpObject<TType> AsGnrcAltArgDescrInp { get; }
}

public interface ItestGnrcAltArgDescrInpObject<TType>
{
}

public interface ItestRefGnrcAltArgDescrInp<TRef>
{
  TRef Asref { get; }
  ItestRefGnrcAltArgDescrInpObject<TRef> AsRefGnrcAltArgDescrInp { get; }
}

public interface ItestRefGnrcAltArgDescrInpObject<TRef>
{
}
