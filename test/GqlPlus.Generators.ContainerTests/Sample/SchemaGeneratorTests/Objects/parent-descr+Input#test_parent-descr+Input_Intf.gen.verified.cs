//HintName: test_parent-descr+Input_Intf.gen.cs
// Generated from {CurrentDirectory}parent-descr+Input.graphql+
//   with GeneratorOption: BaseType: Interface, BaseName: IGqlpModelImplementationBase, GeneratorType: Intf
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_parent_descr_Input;

public interface ItestPrntDescrInp
  : ItestRefPrntDescrInp
{
  ItestPrntDescrInpObject? As_PrntDescrInp { get; }
}

public interface ItestPrntDescrInpObject
  : ItestRefPrntDescrInpObject
{
}

public interface ItestRefPrntDescrInp
  : IGqlpModelImplementationBase
{
  string? AsString { get; }
  ItestRefPrntDescrInpObject? As_RefPrntDescrInp { get; }
}

public interface ItestRefPrntDescrInpObject
  : IGqlpModelImplementationBase
{
  decimal Parent { get; }
}
