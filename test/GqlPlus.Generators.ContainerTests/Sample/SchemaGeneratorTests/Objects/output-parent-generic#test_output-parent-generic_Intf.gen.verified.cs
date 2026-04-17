//HintName: test_output-parent-generic_Intf.gen.cs
// Generated from {CurrentDirectory}output-parent-generic.graphql+
//   with GeneratorOption: BaseType: Interface, BaseName: IGqlpInterfaceBase, GeneratorType: Intf
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test, NamespaceIncludesBaseName: True
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_output_parent_generic;

public interface ItestOutpPrntGnrc
  : IGqlpInterfaceBase
{
  ItestRefOutpPrntGnrc<testEnumOutpPrntGnrc>? AsEnumOutpPrntGnrcprnt_outpPrntGnrc { get; }
  ItestOutpPrntGnrcObject? As_OutpPrntGnrc { get; }
}

public interface ItestOutpPrntGnrcObject
  : IGqlpInterfaceBase
{
}

public interface ItestRefOutpPrntGnrc<TType>
  : IGqlpInterfaceBase
{
  ItestRefOutpPrntGnrcObject<TType>? As_RefOutpPrntGnrc { get; }
}

public interface ItestRefOutpPrntGnrcObject<TType>
  : IGqlpInterfaceBase
{
  TType Field { get; }
}

public enum testEnumOutpPrntGnrc
{
  prnt_outpPrntGnrc = testPrntOutpPrntGnrc.prnt_outpPrntGnrc,
  outpPrntGnrc,
}

public enum testPrntOutpPrntGnrc
{
  prnt_outpPrntGnrc,
}
