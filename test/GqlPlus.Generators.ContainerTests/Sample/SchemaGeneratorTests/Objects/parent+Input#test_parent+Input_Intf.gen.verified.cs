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
  ItestPrntInpObject? As_PrntInp { get; }
}

public interface ItestPrntInpObject
  : ItestRefPrntInpObject
{
}

public interface ItestRefPrntInp
  : IGqlpModelImplementationBase
{
  string? AsString { get; }
  ItestRefPrntInpObject? As_RefPrntInp { get; }
}

public interface ItestRefPrntInpObject
  : IGqlpModelImplementationBase
{
  decimal Parent { get; }
}
