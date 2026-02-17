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
  ItestRefGnrcEnumInp<testEnumGnrcEnumInp> AsEnumGnrcEnumInpgnrcEnumInp { get; }
  ItestGnrcEnumInpObject AsGnrcEnumInp { get; }
}

public interface ItestGnrcEnumInpObject
{
}

public interface ItestRefGnrcEnumInp<TType>
  : IGqlpModelImplementationBase
{
  ItestRefGnrcEnumInpObject<TType> AsRefGnrcEnumInp { get; }
}

public interface ItestRefGnrcEnumInpObject<TType>
{
  TType Field { get; }
}
