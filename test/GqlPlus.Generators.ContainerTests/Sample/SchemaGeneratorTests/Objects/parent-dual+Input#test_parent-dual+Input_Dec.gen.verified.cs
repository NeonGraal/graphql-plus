//HintName: test_parent-dual+Input_Dec.gen.cs
// Generated from {CurrentDirectory}parent-dual+Input.graphql+
//   with GeneratorOption: BaseType: Class, BaseName: GqlpDecoderBase, GeneratorType: Dec
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_parent_dual_Input;

public interface ItestPrntDualInp
  : ItestRefPrntDualInp
{
  ItestPrntDualInpObject? As_PrntDualInp { get; }
}

public interface ItestPrntDualInpObject
  : ItestRefPrntDualInpObject
{
}

public interface ItestRefPrntDualInp
  // No Base because it's Class
{
  string? AsString { get; }
  ItestRefPrntDualInpObject? As_RefPrntDualInp { get; }
}

public interface ItestRefPrntDualInpObject
  // No Base because it's Class
{
  decimal Parent { get; }
}
