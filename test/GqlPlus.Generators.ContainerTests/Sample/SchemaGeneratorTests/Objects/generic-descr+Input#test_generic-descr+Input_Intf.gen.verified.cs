//HintName: test_generic-descr+Input_Intf.gen.cs
// Generated from generic-descr+Input.graphql+ for Intf
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_generic_descr_Input;

public interface ItestGnrcDescrInp<Ttype>
{
  ItestGnrcDescrInpObject AsGnrcDescrInp { get; }
}

public interface ItestGnrcDescrInpObject<Ttype>
{
  Ttype Field { get; }
}
