//HintName: test_parent+Output_Intf.gen.cs
// Generated from {CurrentDirectory}parent+Output.graphql+
//   with GeneratorOption: BaseType: Interface, BaseName: IGqlpModelImplementationBase, GeneratorType: Intf
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_parent_Output;

public interface ItestPrntOutp
  : ItestRefPrntOutp
{
  ItestPrntOutpObject? As_PrntOutp { get; }
}

public interface ItestPrntOutpObject
  : ItestRefPrntOutpObject
{
}

public interface ItestRefPrntOutp
  : IGqlpModelImplementationBase
{
  string? AsString { get; }
  ItestRefPrntOutpObject? As_RefPrntOutp { get; }
}

public interface ItestRefPrntOutpObject
  : IGqlpModelImplementationBase
{
  decimal Parent { get; }
}
