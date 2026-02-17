//HintName: test_generic-enum+Input_Intf.gen.cs
// Generated from {CurrentDirectory}generic-enum+Input.graphql+
//   with GeneratorOption: BaseType: Interface, BaseName: IGqlpModelImplementationBase, GeneratorType: Intf
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_generic_enum_Input;

public interface ItestGnrcEnumInp
  : IGqlpModelImplementationBase
{
  ItestRefGnrcEnumInp<testEnumGnrcEnumInp>? AsEnumGnrcEnumInpgnrcEnumInp { get; }
  ItestGnrcEnumInpObject? As_GnrcEnumInp { get; }
}

public interface ItestGnrcEnumInpObject
  : IGqlpModelImplementationBase
{
}

public interface ItestRefGnrcEnumInp<TType>
  : IGqlpModelImplementationBase
{
  ItestRefGnrcEnumInpObject<TType>? As_RefGnrcEnumInp { get; }
}

public interface ItestRefGnrcEnumInpObject<TType>
  : IGqlpModelImplementationBase
{
  TType Field { get; }
}
