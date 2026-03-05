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
  ItestRefCnstEnumPrntOutp<testEnumCnstEnumPrntOutp>? AsEnumCnstEnumPrntOutpcnstEnumPrntOutp { get; }
  ItestCnstEnumPrntOutpObject? As_CnstEnumPrntOutp { get; }
}

public interface ItestCnstEnumPrntOutpObject
  : IGqlpModelImplementationBase
{
}

public interface ItestRefCnstEnumPrntOutp<TType>
  : IGqlpModelImplementationBase
{
  ItestRefCnstEnumPrntOutpObject<TType>? As_RefCnstEnumPrntOutp { get; }
}

public interface ItestRefCnstEnumPrntOutpObject<TType>
  : IGqlpModelImplementationBase
{
  TType Field { get; }
}
