//HintName: test_parent-alt+Input_Intf.gen.cs
// Generated from {CurrentDirectory}parent-alt+Input.graphql+
//   with GeneratorOption: BaseType: Interface, BaseName: IGqlpInterfaceBase, GeneratorType: Intf
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test, NamespaceIncludesBaseName: True
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_parent_alt_Input;

public interface ItestPrntAltInp
  : ItestRefPrntAltInp
{
  decimal? AsNumber { get; }
  ItestPrntAltInpObject? As_PrntAltInp { get; }
}

public interface ItestPrntAltInpObject
  : ItestRefPrntAltInpObject
{
}

public interface ItestRefPrntAltInp
  : IGqlpInterfaceBase
{
  string? AsString { get; }
  ItestRefPrntAltInpObject? As_RefPrntAltInp { get; }
}

public interface ItestRefPrntAltInpObject
  : IGqlpInterfaceBase
{
  decimal Parent { get; }
}
