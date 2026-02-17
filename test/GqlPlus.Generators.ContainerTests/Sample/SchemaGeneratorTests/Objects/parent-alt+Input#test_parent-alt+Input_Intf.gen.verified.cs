//HintName: test_parent-alt+Input_Intf.gen.cs
// Generated from {CurrentDirectory}parent-alt+Input.graphql+
//   with GeneratorOption: BaseType: Interface, BaseName: IGqlpModelImplementationBase, GeneratorType: Intf
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_parent_alt_Input;

public interface ItestPrntAltInp
  : ItestRefPrntAltInp
{
  decimal AsNumber { get; }
  ItestPrntAltInpObject AsPrntAltInp { get; }
}

public interface ItestPrntAltInpObject
  : ItestRefPrntAltInpObject
{
}

public interface ItestRefPrntAltInp
  : IGqlpModelImplementationBase
{
  string AsString { get; }
  ItestRefPrntAltInpObject AsRefPrntAltInp { get; }
}

public interface ItestRefPrntAltInpObject
{
  decimal Parent { get; }
}
