//HintName: test_constraint-enum+Input_Intf.gen.cs
// Generated from {CurrentDirectory}constraint-enum+Input.graphql+
//   with GeneratorOption: BaseType: Interface, BaseName: IGqlpModelImplementationBase, GeneratorType: Intf
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_constraint_enum_Input;

public interface ItestCnstEnumInp
  : IGqlpModelImplementationBase
{
  ItestRefCnstEnumInp<testEnumCnstEnumInp> AsEnumCnstEnumInpcnstEnumInp { get; }
  ItestCnstEnumInpObject AsCnstEnumInp { get; }
}

public interface ItestCnstEnumInpObject
{
}

public interface ItestRefCnstEnumInp<TType>
  : IGqlpModelImplementationBase
{
  ItestRefCnstEnumInpObject<TType> AsRefCnstEnumInp { get; }
}

public interface ItestRefCnstEnumInpObject<TType>
{
  TType Field { get; }
}
