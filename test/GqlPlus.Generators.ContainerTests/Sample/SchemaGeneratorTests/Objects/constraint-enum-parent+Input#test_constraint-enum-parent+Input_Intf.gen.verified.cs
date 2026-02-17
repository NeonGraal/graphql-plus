//HintName: test_constraint-enum-parent+Input_Intf.gen.cs
// Generated from {CurrentDirectory}constraint-enum-parent+Input.graphql+
//   with GeneratorOption: BaseType: Interface, BaseName: IGqlpModelImplementationBase, GeneratorType: Intf
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_constraint_enum_parent_Input;

public interface ItestCnstEnumPrntInp
  : IGqlpModelImplementationBase
{
  ItestRefCnstEnumPrntInp<testEnumCnstEnumPrntInp> AsEnumCnstEnumPrntInpcnstEnumPrntInp { get; }
  ItestCnstEnumPrntInpObject AsCnstEnumPrntInp { get; }
}

public interface ItestCnstEnumPrntInpObject
{
}

public interface ItestRefCnstEnumPrntInp<TType>
  : IGqlpModelImplementationBase
{
  ItestRefCnstEnumPrntInpObject<TType> AsRefCnstEnumPrntInp { get; }
}

public interface ItestRefCnstEnumPrntInpObject<TType>
{
  TType Field { get; }
}
