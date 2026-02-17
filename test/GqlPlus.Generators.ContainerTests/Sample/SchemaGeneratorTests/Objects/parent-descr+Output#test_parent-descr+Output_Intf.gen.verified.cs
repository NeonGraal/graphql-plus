//HintName: test_parent-descr+Output_Intf.gen.cs
// Generated from {CurrentDirectory}parent-descr+Output.graphql+
//   with GeneratorOption: BaseType: Interface, BaseName: IGqlpModelImplementationBase, GeneratorType: Intf
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_parent_descr_Output;

public interface ItestPrntDescrOutp
  : ItestRefPrntDescrOutp
{
  ItestPrntDescrOutpObject AsPrntDescrOutp { get; }
}

public interface ItestPrntDescrOutpObject
  : ItestRefPrntDescrOutpObject
{
}

public interface ItestRefPrntDescrOutp
  : IGqlpModelImplementationBase
{
  string AsString { get; }
  ItestRefPrntDescrOutpObject AsRefPrntDescrOutp { get; }
}

public interface ItestRefPrntDescrOutpObject
{
  decimal Parent { get; }
}
