//HintName: test_parent-descr+Input_Intf.gen.cs
// Generated from parent-descr+Input.graphql+ for Intf
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_parent_descr_Input;

public interface ItestPrntDescrInp
  : ItestRefPrntDescrInp
{
  ItestPrntDescrInpObject AsPrntDescrInp { get; }
}

public interface ItestPrntDescrInpObject
  : ItestRefPrntDescrInpObject
{
}

public interface ItestRefPrntDescrInp
{
  string AsString { get; }
  ItestRefPrntDescrInpObject AsRefPrntDescrInp { get; }
}

public interface ItestRefPrntDescrInpObject
{
  decimal Parent { get; }
}
