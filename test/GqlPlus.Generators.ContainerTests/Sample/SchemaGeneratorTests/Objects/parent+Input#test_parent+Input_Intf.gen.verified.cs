//HintName: test_parent+Input_Intf.gen.cs
// Generated from {CurrentDirectory}parent+Input.graphql+
//   with GeneratorOption: BaseType: Interface, BaseName: IGqlpModelImplementationBase, GeneratorType: Intf
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_parent_Input;

public interface ItestPrntInp
  : ItestRefPrntInp
{
  ItestPrntInpObject AsPrntInp { get; }
}

public interface ItestPrntInpObject
  : ItestRefPrntInpObject
{
}

public interface ItestRefPrntInp
  : IGqlpModelImplementationBase
{
  string AsString { get; }
  ItestRefPrntInpObject AsRefPrntInp { get; }
}

public interface ItestRefPrntInpObject
{
  decimal Parent { get; }
}
