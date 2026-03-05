//HintName: test_parent-alt+Output_Intf.gen.cs
// Generated from {CurrentDirectory}parent-alt+Output.graphql+
//   with GeneratorOption: BaseType: Interface, BaseName: IGqlpModelImplementationBase, GeneratorType: Intf
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_parent_alt_Output;

public interface ItestPrntAltOutp
  : ItestRefPrntAltOutp
{
  decimal? AsNumber { get; }
  ItestPrntAltOutpObject? As_PrntAltOutp { get; }
}

public interface ItestPrntAltOutpObject
  : ItestRefPrntAltOutpObject
{
}

public interface ItestRefPrntAltOutp
  : IGqlpModelImplementationBase
{
  string? AsString { get; }
  ItestRefPrntAltOutpObject? As_RefPrntAltOutp { get; }
}

public interface ItestRefPrntAltOutpObject
  : IGqlpModelImplementationBase
{
  decimal Parent { get; }
}
