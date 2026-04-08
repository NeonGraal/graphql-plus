//HintName: test_parent-descr+Output_Intf.gen.cs
// Generated from {CurrentDirectory}parent-descr+Output.graphql+
//   with GeneratorOption: BaseType: Interface, BaseName: IGqlpInterfaceBase, GeneratorType: Intf
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_parent_descr_Output;

public interface ItestPrntDescrOutp
  : ItestRefPrntDescrOutp
{
  ItestPrntDescrOutpObject? As_PrntDescrOutp { get; }
}

public interface ItestPrntDescrOutpObject
  : ItestRefPrntDescrOutpObject
{
}

public interface ItestRefPrntDescrOutp
  : IGqlpInterfaceBase
{
  string? AsString { get; }
  ItestRefPrntDescrOutpObject? As_RefPrntDescrOutp { get; }
}

public interface ItestRefPrntDescrOutpObject
  : IGqlpInterfaceBase
{
  decimal Parent { get; }
}
