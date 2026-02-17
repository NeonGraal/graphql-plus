//HintName: test_constraint-enum-parent+Output_Intf.gen.cs
// Generated from {CurrentDirectory}constraint-enum-parent+Output.graphql+
//   with GeneratorOption: BaseType: Interface, BaseName: IGqlpModelImplementationBase, GeneratorType: Intf
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_constraint_enum_parent_Output;

public interface ItestCnstEnumPrntOutp
  : IGqlpModelImplementationBase
{
  ItestRefCnstEnumPrntOutp<testEnumCnstEnumPrntOutp> AsEnumCnstEnumPrntOutpcnstEnumPrntOutp { get; }
  ItestCnstEnumPrntOutpObject AsCnstEnumPrntOutp { get; }
}

public interface ItestCnstEnumPrntOutpObject
{
}

public interface ItestRefCnstEnumPrntOutp<TType>
  : IGqlpModelImplementationBase
{
  ItestRefCnstEnumPrntOutpObject<TType> AsRefCnstEnumPrntOutp { get; }
}

public interface ItestRefCnstEnumPrntOutpObject<TType>
{
  TType Field { get; }
}
