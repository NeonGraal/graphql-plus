//HintName: test_generic-parent-arg+Input_Intf.gen.cs
// Generated from generic-parent-arg+Input.graphql+ for Intf
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_generic_parent_arg_Input;

public interface ItestGnrcPrntArgInp<TType>
  : ItestRefGnrcPrntArgInp<TType>
{
  ItestGnrcPrntArgInpObject AsGnrcPrntArgInp { get; }
}

public interface ItestGnrcPrntArgInpObject<TType>
  : ItestRefGnrcPrntArgInpObject<TType>
{
}

public interface ItestRefGnrcPrntArgInp<TRef>
{
  TRef Asref { get; }
  ItestRefGnrcPrntArgInpObject AsRefGnrcPrntArgInp { get; }
}

public interface ItestRefGnrcPrntArgInpObject<TRef>
{
}
