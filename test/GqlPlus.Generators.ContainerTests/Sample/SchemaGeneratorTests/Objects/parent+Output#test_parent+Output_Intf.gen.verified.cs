//HintName: test_parent+Output_Intf.gen.cs
// Generated from {CurrentDirectory}parent+Output.graphql+
//   with GeneratorOption: BaseType: Interface, BaseName: IGqlpInterfaceBase, GeneratorType: Intf
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test, NamespaceIncludesBaseName: True
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
  : IGqlpInterfaceBase
{
  string? AsString { get; }
  ItestRefPrntOutpObject? As_RefPrntOutp { get; }
}

public interface ItestRefPrntOutpObject
  : IGqlpInterfaceBase
{
  decimal Parent { get; }
}
